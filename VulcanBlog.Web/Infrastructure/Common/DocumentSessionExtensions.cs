﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Linq;
using VulcanBlog.Web.Infrastructure.Automapper;
using VulcanBlog.Web.Infrastructure.Indexes;
using VulcanBlog.Web.Models;
using VulcanBlog.Web.ViewModels;

namespace VulcanBlog.Web.Infrastructure.Common
{
    public static class DocumentSessionExtensions
    {
        public static IList<Tuple<PostComments.Comment, Post>> QueryForRecentComments(
            this IDocumentSession documentSession,
            Func<IRavenQueryable<PostComments_CreationDate.ReduceResult>, IQueryable<PostComments_CreationDate.ReduceResult>> processQuery)
        {
            var query = documentSession
                .Query<PostComments_CreationDate.ReduceResult, PostComments_CreationDate>()
                .Include(comment => comment.PostCommentsId)
                .Include(comment => comment.PostId)
                .OrderByDescending(x => x.PostPublishAt)
                .ThenByDescending(x => x.CreatedAt)
                .Where(x => x.PostPublishAt < DateTimeOffset.Now.AsMinutes())
                .AsProjection<PostComments_CreationDate.ReduceResult>();

            var commentsIdentifiers = processQuery(query)
                .ToList();

            return (from commentIdentifier in commentsIdentifiers
                    let comments = documentSession.Load<PostComments>(commentIdentifier.PostCommentsId)
                    let post = documentSession.Load<Post>(commentIdentifier.PostId)
                    let comment = comments.Comments.FirstOrDefault(x => x.Id == commentIdentifier.CommentId)
                    where comment != null && post.IsDeleted == false
                    select Tuple.Create(comment, post))
                .ToList();
        }

        public static PostReference GetNextPrevPost(this IDocumentSession session, Post compareTo, bool isNext)
        {
            var queryable = session.Query<Post>()
                .WhereIsPublicPost();

            if (isNext)
            {
                queryable = queryable
                    .Where(post => post.PublishAt >= compareTo.PublishAt && post.Id != compareTo.Id)
                    .OrderBy(post => post.PublishAt);
            }
            else
            {
                queryable = queryable
                    .Where(post => post.PublishAt <= compareTo.PublishAt && post.Id != compareTo.Id)
                    .OrderByDescending(post => post.PublishAt);
            }

            var postReference = queryable
                .Select(p => new Post { Id = p.Id, Title = p.Title })
                .FirstOrDefault();

            if (postReference == null)
                return null;

            return postReference.MapTo<PostReference>();
        }

        public static User GetCurrentUser(this IDocumentSession session)
        {
            if (HttpContext.Current.Request.IsAuthenticated == false)
                return null;

            var email = HttpContext.Current.User.Identity.Name;
            var user = session.GetUserByEmail(email);
            return user;
        }

        public static User GetUserByEmail(this IDocumentSession session, string email)
        {
            return session.Query<User>().FirstOrDefault(u => u.Email == email);
        }

        public static Commenter GetCommenter(this IDocumentSession session, string commenterKey)
        {
            Guid guid;
            return Guid.TryParse(commenterKey, out guid) == false ? null : GetCommenter(session, guid);
        }

        public static Commenter GetCommenter(this IDocumentSession session, Guid? commenterKey)
        {
            return commenterKey == null ? null : GetCommenter(session, commenterKey.Value);
        }

        public static Commenter GetCommenter(this IDocumentSession session, Guid commenterKey)
        {
            return session.Query<Commenter>().FirstOrDefault(x => x.Key == commenterKey);
        }
    }
}