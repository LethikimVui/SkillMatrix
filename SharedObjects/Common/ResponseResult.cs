using System;
using System.Collections.Generic;
using System.Text;

namespace SharedObjects.Common
{
    public class ResponseResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public List<string> Notifications { get; set; }
        public ResponseResult(int statusCode)
        {
            StatusCode = statusCode;
        }
        public ResponseResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public ResponseResult(int statusCode, List<string> notifications)
        {
            StatusCode = statusCode;
            Notifications = notifications;
        }
        public ResponseResult()
        {

        }
    }
}
