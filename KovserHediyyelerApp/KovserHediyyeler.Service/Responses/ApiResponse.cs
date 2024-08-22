using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovserHediyyeler.Service.Responses
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
}
