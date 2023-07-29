using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementApi.Helper
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public ApiResponse(bool status,string message,object result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;

        }
    }
}
