using System.Text.Json.Serialization;

namespace SensitiveEats.Domain
{
    public class UserRequestModel
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

    }
}
