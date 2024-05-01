namespace PhoneService.Api.Models
{
    public class PhoneConvertRequest : BasicRequest
    {
        public string Phone {  get; set; } = string.Empty;
    }
}
