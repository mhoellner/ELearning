using System.Linq;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Extensions
{
    public static class ItemExtensions
    {
        public static Homepage RootItem()
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
            var root = helper.TypedContentAtRoot().FirstOrDefault().As<Homepage>();
            return root;
        }

        public static Item CurrentItem(int id)
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
            Item item = helper.TypedContent(id).As<Item>();
            return item;
        }
    }
} 