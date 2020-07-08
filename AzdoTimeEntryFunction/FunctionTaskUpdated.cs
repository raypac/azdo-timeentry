using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using AzdoTimeEntryFunction.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzdoTimeEntryFunction
{
    public static class FunctionTaskUpdated
    {
        [FunctionName("FunctionTaskUpdated")]
        public static void Run([ServiceBusTrigger("timeentry-ns-queue", Connection = "AzureServiceBusConnStr")]string myQueueItem, 
            ILogger log, ExecutionContext context)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var workItemTask = JsonConvert.DeserializeObject<WorkItemTask>(myQueueItem);

            var completedWork = workItemTask.Resource.Revision.Fields.CompletedWork;
            var remainingWork = workItemTask.Resource.Revision.Fields.RemainingWork;

            var updatedRemainingWork = remainingWork - completedWork;
            var updatedCompletedWork = 0;

            var payload = new WorkItemPayload();

            payload.Item.Add(new WorkItemUpdateItem
            {
                Op = "add",
                Path = "/fields/Microsoft.VSTS.Scheduling.RemainingWork",
                Value = updatedRemainingWork.ToString()
            });

            payload.Item.Add(new WorkItemUpdateItem
            {
                Op = "add",
                Path = "/fields/Microsoft.VSTS.Scheduling.CompletedWork",
                Value = updatedCompletedWork.ToString()
            });

            var config = new ConfigurationBuilder()
            .SetBasePath(context.FunctionAppDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

            var azdoToken = config["AzdoToken"];
            var azdoWorkItemUpdateUri = config["AzdoWorkItemUpdateUri"];

            using (var client = new HttpClient())
            {
                var apiUri = azdoWorkItemUpdateUri.Replace("{id}", workItemTask.Resource.WorkItemId.ToString());

                client.BaseAddress = new Uri(apiUri);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                Convert.ToBase64String(
                                    Encoding.ASCII.GetBytes(
                                        string.Format("{0}:{1}", "", azdoToken))));

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), apiUri);

                request.Content = new StringContent(JsonConvert.SerializeObject(payload.Item), Encoding.UTF8, "application/json-patch+json");

                using (var resp = client.SendAsync(request).Result)
                {
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        log.LogInformation($"Work Item Id: {workItemTask.Resource.WorkItemId} Updated");
                    }
                    else
                    {
                        log.LogInformation($"Work Item Id: {workItemTask.Resource.WorkItemId} Not Updated");
                    }
                }
            }
        }
    }
}
