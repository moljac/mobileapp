using System;
using System.Collections.Generic;

namespace Toggl.Shared.Models
{
    public sealed class TimeEntry
    {
        public long Id { get; }
        public bool Billable { get; }
        public DateTimeOffset Start { get; }
        public long? Duration { get; }
        public string Description { get; }
        public User User { get; }
        public Workspace Workspace { get; }
        public Project? Project { get; }
        public Task? Task { get; }
        public IEnumerable<Tag> Tags { get; }
        public DateTimeOffset? ServerDeletedAt { get; }
        public DateTimeOffset At { get; }

        public TimeEntry(
            long id,
            bool billable,
            DateTimeOffset start,
            long? duration,
            string description,
            User user,
            Workspace workspace,
            Project? project,
            Task? task,
            IEnumerable<Tag> tags,
            DateTimeOffset? serverDeletedAt,
            DateTimeOffset at)
        {
            Id = id;
            Billable = billable;
            Start = start;
            Duration = duration;
            Description = description;
            User = user;
            Workspace = workspace;
            Project = project;
            Task = task;
            Tags = tags;
            ServerDeletedAt = serverDeletedAt;
            At = at;
        }
    }
}
