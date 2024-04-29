using PhoneService.Api.Models;
using PhoneService.Core.Interfaces;

namespace PhoneService.Api.Services
{
    internal class PhoneServiceWorck
    {
        private readonly IPhoneServiceCore _phoneServiceCore;

        public PhoneServiceWorck(IPhoneServiceCore phoneServiceCore)
        {
            _phoneServiceCore = phoneServiceCore;
        }

        public PhoneConvertResponse PhoneConvertToNumber(PhoneConvertRequest phoneConverResponse) 
        {
            var result = new PhoneConvertResponse();

            try
            {
                if(phoneConverResponse is not null) 
                {
                    var pResult = _phoneServiceCore.PhoneConvert(new() 
                    { 
                        Phone = phoneConverResponse.Phone, 
                        TracId = phoneConverResponse.TraceId 
                    });

                    if(pResult is not null)
                    {
                        result.Success = true;
                        result.PhoneNumber = pResult.Phone;
                    }
                    else
                    {
                        result.Message = "Сonversion error.";
                        result.Errors.Add("Сonversion error.");
                    }
                }
            }
            catch
            { }

            return result;
        }
    }
}
