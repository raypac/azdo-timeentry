using System;
using Newtonsoft.Json;

namespace AzdoTimeEntryFunction.Model
{
    public partial class WorkItemTask
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("publisherId")]
        public string PublisherId { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("detailedMessage")]
        public Message DetailedMessage { get; set; }

        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        [JsonProperty("resourceVersion")]
        public string ResourceVersion { get; set; }

        [JsonProperty("resourceContainers")]
        public ResourceContainers ResourceContainers { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("markdown")]
        public string Markdown { get; set; }
    }

    public partial class Resource
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("workItemId")]
        public long WorkItemId { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("revisedBy")]
        public RevisedBy RevisedBy { get; set; }

        [JsonProperty("revisedDate")]
        public string RevisedDate { get; set; }

        [JsonProperty("fields")]
        public ResourceFields Fields { get; set; }

        [JsonProperty("_links")]
        public ResourceLinks Links { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("revision")]
        public Revision Revision { get; set; }
    }

    public partial class ResourceFields
    {
        [JsonProperty("System.Rev")]
        public FieldValue Rev { get; set; }

        [JsonProperty("System.AuthorizedDate")]
        public FieldValue mAuthorizedDate { get; set; }

        [JsonProperty("System.RevisedDate")]
        public FieldValue RevisedDate { get; set; }

        [JsonProperty("System.ChangedDate")]
        public FieldValue ChangedDate { get; set; }

        [JsonProperty("System.Watermark")]
        public FieldValue Watermark { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Activity")]
        public FieldValue Activity { get; set; }

        [JsonProperty("Microsoft.VSTS.Scheduling.CompletedWork")]
        public FieldValue CompletedWork { get; set; }

        [JsonProperty("Custom.WorkDate")]
        public FieldValue WorkDate { get; set; }
    }

    public partial class FieldValue
    {
        [JsonProperty("oldValue")]
        public string OldValue { get; set; }

        [JsonProperty("newValue")]
        public string NewValue { get; set; }
    }

    public partial class ResourceLinks
    {
        [JsonProperty("self")]
        public Html Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public Html WorkItemUpdates { get; set; }

        [JsonProperty("parent")]
        public Html Parent { get; set; }

        [JsonProperty("html")]
        public Html Html { get; set; }
    }

    public partial class Html
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class RevisedBy
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("_links")]
        public RevisedByLinks Links { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("descriptor")]
        public string Descriptor { get; set; }
    }

    public partial class RevisedByLinks
    {
        [JsonProperty("avatar")]
        public Html Avatar { get; set; }
    }

    public partial class Revision
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("fields")]
        public RevisionFields Fields { get; set; }

        [JsonProperty("_links")]
        public RevisionLinks Links { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class RevisionFields
    {
        [JsonProperty("System.AreaPath")]
        public string AreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string TeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string State { get; set; }

        [JsonProperty("System.Reason")]
        public string Reason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public string AssignedTo { get; set; }

        [JsonProperty("System.CreatedDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public string ChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty("System.CommentCount")]
        public long CommentCount { get; set; }

        [JsonProperty("System.Title")]
        public string Title { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public string ChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public long Priority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Activity")]
        public string Activity { get; set; }

        [JsonProperty("Microsoft.VSTS.Scheduling.RemainingWork")]
        public long RemainingWork { get; set; }

        [JsonProperty("Microsoft.VSTS.Scheduling.OriginalEstimate")]
        public long OriginalEstimate { get; set; }

        [JsonProperty("Microsoft.VSTS.Scheduling.CompletedWork")]
        public long CompletedWork { get; set; }

        [JsonProperty("Custom.WorkDate")]
        public string WorkDate { get; set; }

        [JsonProperty("System.Description")]
        public string Description { get; set; }
    }

    public partial class RevisionLinks
    {
        [JsonProperty("self")]
        public Html Self { get; set; }

        [JsonProperty("workItemRevisions")]
        public Html WorkItemRevisions { get; set; }

        [JsonProperty("parent")]
        public Html Parent { get; set; }
    }

    public partial class ResourceContainers
    {
        [JsonProperty("collection")]
        public Account Collection { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("project")]
        public Account Project { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("baseUrl")]
        public Uri BaseUrl { get; set; }
    }
}
