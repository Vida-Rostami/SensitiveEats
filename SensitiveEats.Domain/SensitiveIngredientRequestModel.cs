using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensitiveEats.Domain
{
    public class SensitiveIngredientRequestModel
    {
        [JsonIgnore]
        public int SensitiveIngredientId { get; set; }
        public string SensitiveIngredientName { get; set; }
    }
}
