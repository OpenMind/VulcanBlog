using CookComputing.XmlRpc;

namespace VulcanBlog.Web.Services.RssModels
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Source
    {
        public string name;
        public string url;
    }
}