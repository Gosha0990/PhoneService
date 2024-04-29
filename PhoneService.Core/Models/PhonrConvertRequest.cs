using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Models
{
    public class PhonrConvertRequest
    {
        public string Phone {  get; set; } = string.Empty;
        public Guid TracId { get; set; }
    }
}
