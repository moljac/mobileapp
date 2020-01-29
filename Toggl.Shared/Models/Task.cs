using System;

namespace Toggl.Shared.Models
{
    public sealed class Task
    {
        public long Id { get; }
        public string Name { get; }
        public long EstimatedSeconds { get; }
        public bool Active { get; }
        public long TrackedSeconds { get; }
        public User? User { get; }
        public Project Project { get; }
        public Workspace Workspace { get; }
        public DateTimeOffset At { get; }

        public Task(
            long id,
            string name,
            long estimatedSeconds,
            bool active,
            long trackedSeconds,
            User? user,
            Project project,
            Workspace workspace,
            DateTimeOffset at)
        {
            Id = id;
            Name = name;
            EstimatedSeconds = estimatedSeconds;
            Active = active;
            TrackedSeconds = trackedSeconds;
            User = user;
            Project = project;
            Workspace = workspace;
            At = at;
        }
    }
}
