using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace API
{
    public static class JSONParser
    {
        public static string ScenarioListToJSON(ScenarioList scenarioList)
        {
            return JsonConvert.SerializeObject(scenarioList, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new MyContractResolver(), PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
        }

        public static ScenarioList JSONToScenarioList(string json)
        {
            return JsonConvert.DeserializeObject<ScenarioList>(json, new JsonSerializerSettings { ContractResolver = new MyContractResolver(), PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize });
        }
    }

    public class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(p => base.CreateProperty(p, memberSerialization)).Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Select(f => base.CreateProperty(f, memberSerialization))).ToList();

            props.ForEach(p => { p.Writable = true; p.Readable = true; });

            return props;
        }
    }
}