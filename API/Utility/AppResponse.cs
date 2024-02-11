using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace API.Utility
{
    public class AppResponse<T> where T : class
    {
        public T Data { get; set; }
        public Meta Meta { get; set; }
        public override string ToString()
        {
            // return JsonSerializer.Serialize(this);
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
