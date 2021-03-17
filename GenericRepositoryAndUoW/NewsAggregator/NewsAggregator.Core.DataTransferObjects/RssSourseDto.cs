using System;

namespace NewsAggregator.Core.DataTransferObjects
{
    public class RssSourseDto //Data transfer objects
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }
    }
}
