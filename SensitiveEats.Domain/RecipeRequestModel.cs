using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensitiveEats.Domain
{
    public class RecipeRequestModel
    {
        [JsonIgnore]
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set;}
        public string RecipeDescription { get; set;}
        public bool Test { get; set; }
    }
}
    