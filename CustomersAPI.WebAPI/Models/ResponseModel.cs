using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomersAPI.WebAPI.Models
{
    public class ResponseModel<T> 
    {
        public List<T> dataList { get; set; }
        public T data { get; set; }
    }
}