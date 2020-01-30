using System.Collections.Generic;

namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class WorkspaceFeatureCollection
    {
        public Workspace Workspace { get; }
        public IEnumerable<IWorkspaceFeature> Features { get; }

        public WorkspaceFeatureCollection(Workspace workspace, IEnumerable<IWorkspaceFeature> features)
        {
            Workspace = workspace;
            Features = features;
        }
    }
}
