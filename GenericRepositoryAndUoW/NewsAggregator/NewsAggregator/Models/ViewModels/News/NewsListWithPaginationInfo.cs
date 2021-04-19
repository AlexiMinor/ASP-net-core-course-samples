using System.Collections.Generic;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.Models.ViewModels.News
{
    public class NewsListWithPaginationInfo
    {
        public bool IsAdmin { get; set; }
        public IEnumerable<NewsDto> News { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
