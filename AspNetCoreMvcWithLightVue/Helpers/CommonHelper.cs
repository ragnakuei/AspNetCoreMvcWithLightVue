using System.Text.Json;

namespace AspNetCoreMvcWithLightVue.Helpers
{
    public static class CommonHelper
    {
        public static string ToJson(this object source)
        {
            return JsonSerializer.Serialize(source);
        }
        public static T ParseJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
