using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzdoTimeEntryFunction.Model
{
    public class WorkItemPayload
    {
        public WorkItemPayload()
        {
            Item = new List<WorkItemUpdateItem>();
        }

        public List<WorkItemUpdateItem> Item { get; set; }

    }

    public class WorkItemUpdateItem
    {

        [JsonProperty("op")]
        public string Op { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }

}
