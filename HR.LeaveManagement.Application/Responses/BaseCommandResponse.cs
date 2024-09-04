using System.Collections.Generic;

namespace HR.LeaveManagement.Application.Responses
{
    public class BaseCommandResponse
    {
        public int RecordId { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}