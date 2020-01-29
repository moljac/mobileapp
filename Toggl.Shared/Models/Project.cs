using System;

namespace Toggl.Shared.Models
{
    public sealed class Project
    {
        public long Id { get; }
        public string Name { get; }
        public bool IsPrivate { get; }
        public bool Active { get; }
        public string Color { get; }
        public bool? Billable { get; }
        public bool? Template { get; }
        public bool? AutoEstimates { get; }
        public long? EstimatedHours { get; }
        public double? Rate { get; }
        public string Currency { get; }
        public int? ActualHours { get; }
        public Workspace Workspace { get; }
        public Client? Client { get; }
        public DateTimeOffset? ServerDeletedAt { get; }
        public DateTimeOffset At { get; }

        public Project(
            long id,
            string name,
            bool isPrivate,
            bool active,
            string color,
            bool? billable,
            bool? template,
            bool? autoEstimates,
            long? estimatedHours,
            double? rate,
            string currency,
            int? actualHours,
            Workspace workspace,
            Client? client,
            DateTimeOffset? serverDeletedAt,
            DateTimeOffset at)
        {
            Id = id;
            Name = name;
            IsPrivate = isPrivate;
            Active = active;
            Color = color;
            Billable = billable;
            Template = template;
            AutoEstimates = autoEstimates;
            EstimatedHours = estimatedHours;
            Rate = rate;
            Currency = currency;
            ActualHours = actualHours;
            Workspace = workspace;
            Client = client;
            ServerDeletedAt = serverDeletedAt;
            At = at;
        }
    }
}
