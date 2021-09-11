using Newtonsoft.Json;

namespace Infraestructure.Crosscutting
{
    public static  class JsonFormater
    {
        public static T Deserialize<T>(string value)
        {
            var model = JsonConvert.DeserializeObject<T>(value);
            return model;
        }

        public static string Serialize<T>(T value)
        {
            var model = JsonConvert.SerializeObject(value); 
            return model;
        }
    }
}
