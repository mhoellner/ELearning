using System.Linq;
using ELearning.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace ELearning.Extensions
{
    /// <summary>
    /// Helper Methods for Umbraco-Items
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Helper to get RootItem.
        /// </summary>
        /// <returns>Homepage at Root.</returns>
        public static Homepage RootItem()
        {
            UmbracoHelper helper = new UmbracoHelper(UmbracoContext.Current);
            var root = helper.TypedContentAtRoot().FirstOrDefault().As<Homepage>();
            return root;
        }
    }
} 