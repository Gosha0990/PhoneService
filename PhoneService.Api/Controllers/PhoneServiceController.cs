using Microsoft.AspNetCore.Mvc;
using PhoneService.Api.Models;
using PhoneService.Api.Services;

namespace PhoneService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    internal class PhoneServiceController : ControllerBase
    {
        private readonly PhoneServiceWorck _phoneServiceWorck;
        private readonly SemaphoreService _semaphoreService;

        public PhoneServiceController(PhoneServiceWorck phoneServiceWorck, SemaphoreService semaphoreService) 
        {
            _phoneServiceWorck = phoneServiceWorck;
            _semaphoreService = semaphoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneConvert(string phone, Guid TraceId)
        {
            var result = new PhoneConvertResponse();

            _phoneServiceWorck.PhoneConvertToNumber(new() { Phone = phone, TraceId = TraceId });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostPhoneConvert(PhoneConvertRequest phoneConvertRequest)
        {
            return Ok();
        }
    }
}
