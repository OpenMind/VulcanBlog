using CookComputing.XmlRpc;

namespace VulcanBlog.Web.Services.RssModels
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Enclosure
    {
        public int length;
        public string type;
        public string url;
    }
}