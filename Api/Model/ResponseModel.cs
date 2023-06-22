using Core.Exceptions;
using System.ComponentModel;

namespace Api.Model
{
    public class ResponseModel
    {
        [Description("Response code. 0 is success, others are errors")]
        public int Code { get; set; }
        [Description("Response Message")]
        public string Message { get; set; }
        public Object Content { get; set; }

        public ResponseModel(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public ResponseModel(Object content) : this(0, "Success")
        {
            this.Content = content;
        }

        public ResponseModel(MABException e) : this(e.Code, e.Message)
        {
            this.Content = e.StackTrace;
        }

        public ResponseModel()
        {
        }

    }
}
