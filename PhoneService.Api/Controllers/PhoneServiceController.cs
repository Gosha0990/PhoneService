using Microsoft.AspNetCore.Mvc;
using PhoneService.Api.Models;
using PhoneService.Api.Services;
using System.Diagnostics;
using System.Numerics;

namespace PhoneService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhoneServiceController : ControllerBase
    {
        private readonly PhoneServiceWorck _phoneServiceWorck;

        public PhoneServiceController(PhoneServiceWorck phoneServiceWorck) 
        {
            _phoneServiceWorck = phoneServiceWorck;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneConvert(string phone, Guid TraceId)
        {
            var result = new PhoneConvertResponse();

            var rTask = await Task.Run(() => _phoneServiceWorck.PhoneConvertToNumber(new() { Phone = phone, TraceId = TraceId }));

            if(rTask is not null) 
            { 
                result = rTask;
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPhoneConvert(PhoneConvertRequest phoneConvertRequest)
        {
            var result = new PhoneConvertResponse();

            var rTask = await Task.Run(() => _phoneServiceWorck.PhoneConvertToNumber(phoneConvertRequest));

            if (rTask is not null)
            {
                result = rTask;
            }

            return Ok(result);
        }
    }
}
