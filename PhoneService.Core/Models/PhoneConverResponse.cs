using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Models
{
    public class PhoneConverResponse
    {
        public long Phone {  get; set; }
        public Guid TraceId { get; set; }
    }
}
