using System.Collections.Generic;
using System.Linq;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Provider
{
    public class BreadcrumbProvider
    {
        public BreadcrumbProvider(int id)
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
            IEnumerable<string> itemIds = helper.TypedContent(id).Path.Split(',');
            BreadcrumbItems = helper.TypedContent(itemIds).As<Item>().ToList();
        }

        public List<Item> BreadcrumbItems { get; private set; }
    }
}