using System;
using System.Collections.Generic;
using Umbraco.Core.Models;

namespace ELearning.Models
{
    /// <summary>
    /// Umbraco Base Model. Equals the standard IPublishedContent.
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentTypeAlias { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Path { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<IPublishedContent> Children { get; set; }
        public IPublishedContent Parent { get; set; }
        public string Url { get; set; }
    }
}