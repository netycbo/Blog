using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_AppServices.API.ErrorResponse
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            Error = message;
        }
        public string Error { get; set; }
    }
}
