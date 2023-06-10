using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Assessment.Core.Helpers
{
    public static class Json
    {
        public static Task<T> ToObjectAsync<T>(string value)
        {
            return Task.Run(() => JsonConvert.DeserializeObject<T>(value));
        }

        public static async Task<string> StringifyAsync(object value)
        {
            return await Task.Run(() => JsonConvert.SerializeObject(value));
        }
    }
}
