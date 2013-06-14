using CookComputing.XmlRpc;

namespace VulcanBlog.Web.Services.RssModels
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct MediaObject
    {
        public string name;
        public string type;
        public byte[] bits;
    }
}