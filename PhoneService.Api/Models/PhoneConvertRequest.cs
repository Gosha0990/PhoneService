namespace PhoneService.Api.Models
{
    internal class PhoneConvertRequest : BasicRequest
    {
        public string Phone {  get; set; } = string.Empty;
    }
}
