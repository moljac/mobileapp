using System;
using System.Collections.Generic;
using System.Text;

namespace Toggl.Shared.Models.DoNotUse
{
    public sealed class Preferences
    {
        public TimeFormat TimeOfDayFormat { get; }
        public DateFormat DateFormat { get; }
        public DurationFormat DurationFormat { get; }
        public bool CollapseTimeEntries { get; }

        public Preferences(
            TimeFormat timeOfDayFormat,
            DateFormat dateFormat,
            DurationFormat durationFormat,
            bool collapseTimeEntries)
        {
            TimeOfDayFormat = timeOfDayFormat;
            DateFormat = dateFormat;
            DurationFormat = durationFormat;
            CollapseTimeEntries = collapseTimeEntries;
        }
    }
}
