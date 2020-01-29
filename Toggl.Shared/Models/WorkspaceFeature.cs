namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class WorkspaceFeature
    {
        public WorkspaceFeatureId FeatureId { get; }
        public bool Enabled { get; }

        public WorkspaceFeature(WorkspaceFeatureId featureId, bool enabled)
        {
            FeatureId = featureId;
            Enabled = enabled;
        }
    }
}
