using PhoneService.Core.Interfaces;
using PhoneService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Service
{
    internal class PhoneServiceCore : IPhoneServiceCore
    {
        //todo добавь логер

        public PhoneConverResponse PhoneConvert(PhonrConvertRequest phoneNumber)
        {
            var result = new PhoneConverResponse();
            result.TraceId = phoneNumber.TracId;
            try
            {
                if(phoneNumber is not null 
                    && !string.IsNullOrEmpty(phoneNumber.Phone))
                {
                    var arrayCh = phoneNumber.Phone.Where(w => char.IsDigit(w)).ToArray();

                    if(arrayCh.Length == 11)
                    {
                        if (arrayCh[0] == '8')
                        {
                            arrayCh[0] = '7';
                            long.TryParse(arrayCh, out var phone);
                            result.Phone = phone;
                        }
                        else if (arrayCh[0] == '7')
                        {
                            long.TryParse(arrayCh, out var phone);
                            result.Phone = phone;
                        }
                    }
                }
            }
            catch 
            {
            
            }

            return result;
        }
    }
}
