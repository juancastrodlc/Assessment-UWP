using Assessment.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Threading.Tasks;
using static Assessment.Core.Models.ItemFieldNames;

namespace Assessment.Core.Models
{
    [Serializable]
    public class Item : Entity<Ulid>
    {
        [JsonProperty(name)]
        public string Name { get; set; }

        [JsonProperty(imageUri)]
        public string ImageUri { get; set; }

        [JsonProperty(color)]
        public Color? Color { get; set; }

        public static async Task<Item> ParseAsync(string json)
        {
            return await Json.ToObjectAsync<Item>(json);
        }

        protected override int GetBusinessHashcode()
        {
            return HashCode.Combine(Name, ImageUri, Color);
        }

        public override int CompareTo(Entity<Ulid> other)
        {
            if (other is not Item theOther)
            {
                return -1;
            }
            return string.Compare(Name, theOther.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool EqualByFields<T>(T other)
        {
            if (other is not Item theOther)
            {
                return false;
            }
            return Name == theOther.Name &&
                ImageUri == theOther.ImageUri &&
                Color == theOther.Color;
        }
    }
}
