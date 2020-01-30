using System;
using System.Collections.Immutable;

namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class Workspace
    {
        public long Id { get; }
        public string Name { get; }
        public bool Admin { get; }
        public DateTimeOffset? SuspendedAt { get; }
        public double? DefaultHourlyRate { get; }
        public string DefaultCurrency { get; }
        public bool OnlyAdminsMayCreateProjects { get; }
        public bool OnlyAdminsSeeBillableRates { get; }
        public bool OnlyAdminsSeeTeamDashboard { get; }
        public bool ProjectsBillableByDefault { get; }
        public int Rounding { get; }
        public int RoundingMinutes { get; }
        public string LogoUrl { get; }
        public IImmutableList<WorkspaceFeatureId> EnabledFeatures { get; }
        public DateTimeOffset? ServerDeletedAt { get; }
        public DateTimeOffset At { get; }

        public Workspace(
            long id,
            string name,
            bool admin,
            DateTimeOffset? suspendedAt,
            double? defaultHourlyRate,
            string defaultCurrency,
            bool onlyAdminsMayCreateProjects,
            bool onlyAdminsSeeBillableRates,
            bool onlyAdminsSeeTeamDashboard,
            bool projectsBillableByDefault,
            int rounding,
            int roundingMinutes,
            string logoUrl,
            IImmutableList<WorkspaceFeatureId> enabledFeatures,
            DateTimeOffset? serverDeletedAt,
            DateTime at)
        {
            Id = id;
            Name = name;
            Admin = admin;
            SuspendedAt = suspendedAt;
            DefaultHourlyRate = defaultHourlyRate;
            DefaultCurrency = defaultCurrency;
            OnlyAdminsMayCreateProjects = onlyAdminsMayCreateProjects;
            OnlyAdminsSeeBillableRates = onlyAdminsSeeBillableRates;
            OnlyAdminsSeeTeamDashboard = onlyAdminsSeeTeamDashboard;
            ProjectsBillableByDefault = projectsBillableByDefault;
            Rounding = rounding;
            RoundingMinutes = roundingMinutes;
            LogoUrl = logoUrl;
            EnabledFeatures = enabledFeatures;
            ServerDeletedAt = serverDeletedAt;
            At = at;
        }
    }
}
