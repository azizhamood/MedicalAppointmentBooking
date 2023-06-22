using System.ComponentModel;

namespace UiBlazor.Model
{
    public class ResponseModel<T>
    {
      
        public int Code { get; set; }
        
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
