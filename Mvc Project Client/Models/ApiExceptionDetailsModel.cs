using System.Collections.Generic;

namespace Mvc_Project_Client.Models
{
    public class ApiExceptionDetailsModel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string TraceId { get; set; }
        public string Message { get; set; }
        public Dictionary<string, ApiErrorListModel> Errors { get; set; } = new Dictionary<string, ApiErrorListModel>();
    }
}
