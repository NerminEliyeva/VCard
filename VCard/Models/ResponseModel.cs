using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCard.Models
{
    public class ResponseModel
    {
        public string Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
