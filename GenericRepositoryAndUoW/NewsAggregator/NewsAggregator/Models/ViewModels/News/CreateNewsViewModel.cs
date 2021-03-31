using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewsAggregator.Models.ViewModels.News
{
    public class CreateNewsViewModel
    {
        public Guid Id { get; set; }
        public string Article { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string Body2 { get; set; }

        public Guid? RssSourseId { get; set; }

       public SelectList Sources { get; set; } 
    }
}
