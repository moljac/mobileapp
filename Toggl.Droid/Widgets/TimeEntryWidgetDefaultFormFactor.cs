using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using Android.Views;
using Toggl.Droid.Extensions;
using Color = Android.Graphics.Color;
using Toggl.Shared;
using Toggl.Droid.Helper;

namespace Toggl.Droid.Widgets
{
    public sealed class TimeEntryWidgetDefaultFormFactor : TimeEntryWidgetStartStopButtonFormFactor
    {
        public override RemoteViews Setup(Context context, TimeEntryWidgetInfo widgetInfo)
        {
            var view = new RemoteViews(context.PackageName, Resource.Layout.TimeEntryWidget);

            SetupActionsForStartAndStopButtons(context, view);
            view.SetTextViewText(Resource.Id.NoRunningTimeEntryLabel, Resources.NoRunningTimeEntry);
            view.SetOnClickPendingIntent(Resource.Id.RootLayout, context.GetOpenAppPendingIntent());

            var timeEntryIsRunning = widgetInfo.IsRunning;
            var timeEntryIsStopped = !widgetInfo.IsRunning;

            view.SetViewVisibility(Resource.Id.StartButton, timeEntryIsStopped.ToVisibility());
            view.SetViewVisibility(Resource.Id.NoRunningTimeEntryLabel, timeEntryIsStopped.ToVisibility());

            view.SetViewVisibility(Resource.Id.StopButton, timeEntryIsRunning.ToVisibility());
            view.SetViewVisibility(Resource.Id.TimeEntryInfoContainer, timeEntryIsRunning.ToVisibility());

            if (timeEntryIsStopped)
                return view;

            var duration = (DateTimeOffset.Now - widgetInfo.StartTime).TotalMilliseconds;
            view.SetChronometer(Resource.Id.DurationTextView, SystemClock.ElapsedRealtime() - (long)duration, "%s", true);

            if (string.IsNullOrEmpty(widgetInfo.Description))
            {
                view.SetTextViewText(Resource.Id.NoDescriptionTextView, Resources.NoDescription);
                view.SetViewVisibility(Resource.Id.NoDescriptionTextView, ViewStates.Visible);
                view.SetViewVisibility(Resource.Id.DescriptionTextView, ViewStates.Gone);
            }
            else
            {
                view.SetTextViewText(Resource.Id.DescriptionTextView, widgetInfo.Description);
                view.SetViewVisibility(Resource.Id.DescriptionTextView, ViewStates.Visible);
                view.SetViewVisibility(Resource.Id.NoDescriptionTextView, ViewStates.Gone);
            }

            view.SetViewVisibility(Resource.Id.DotView, widgetInfo.HasProject.ToVisibility());
            view.SetViewVisibility(Resource.Id.ProjectTextView, widgetInfo.HasProject.ToVisibility());
            view.SetViewVisibility(Resource.Id.ClientTextView, widgetInfo.HasClient.ToVisibility());
            if (widgetInfo.HasProject)
            {
                // Project
                var projectColor = widgetInfo.ProjectColor != null
                    ? Shared.Color.ParseAndAdjustToLabel(widgetInfo.ProjectColor, ActiveTheme.Is.DarkTheme).ToNativeColor()
                    : Color.Black;
                view.SetInt(Resource.Id.DotView, "setBackgroundColor", projectColor);
                view.SetTextViewText(Resource.Id.ProjectTextView, widgetInfo.ProjectName ?? "");
                view.SetTextColor(Resource.Id.ProjectTextView, projectColor);

                // Client
                if (widgetInfo.HasClient)
                {
                    view.SetTextViewText(Resource.Id.ClientTextView, widgetInfo.ClientName);
                }
            }

            return view;
        }
    }
}
