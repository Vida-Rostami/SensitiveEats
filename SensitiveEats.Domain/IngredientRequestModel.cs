using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensitiveEats.Domain
{
    public class IngredientRequestModel
    {
        [JsonIgnore]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
    }
}
