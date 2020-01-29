using System.Collections.Generic;

namespace Toggl.Shared.Models
{
    public sealed class WorkspaceFeatureCollection
    {
        public long WorkspaceId { get; }
        public IEnumerable<IWorkspaceFeature> Features { get; }

        public WorkspaceFeatureCollection(long workspaceId, IEnumerable<IWorkspaceFeature> features)
        {
            WorkspaceId = workspaceId;
            Features = features;
        }
    }
}
