using System.Collections.Generic;
using System.Linq;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Provider
{
    public class BreadcrumbProvider
    {
        /// <summary>
        /// Builds a List of Items to use when generating breadcrumbs.
        /// </summary>
        /// <param name="id">Umbraco-ID of the Item you want to guide to.</param>
        public BreadcrumbProvider(int id)
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
            IEnumerable<string> itemIds = helper.TypedContent(id).Path.Split(',');
            BreadcrumbItems = helper.TypedContent(itemIds).As<Item>().ToList();
        }
        /// <summary>
        /// List of Items to use in Breadcrumb.
        /// </summary>
        public List<Item> BreadcrumbItems { get; private set; }
    }
}