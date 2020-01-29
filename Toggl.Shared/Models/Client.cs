using System;

namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class Client
    {
        public long Id { get; }
        public string Name { get; }
        public Workspace Workspace { get; }
        public DateTimeOffset? ServerDeletedAt { get; }
        public DateTimeOffset At { get; }

        public Client(
            long id,
            string name,
            Workspace workspace,
            DateTimeOffset? serverDeletedAt,
            DateTimeOffset at)
        {
            Id = id;
            Name = name;
            Workspace = workspace;
            ServerDeletedAt = serverDeletedAt;
            At = at;
        }
    }
}
