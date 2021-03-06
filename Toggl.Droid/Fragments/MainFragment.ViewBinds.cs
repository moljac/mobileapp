using Android.Views;
using Android.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using Google.Android.Material.AppBar;
using Google.Android.Material.FloatingActionButton;
using Toggl.Droid.Views;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace Toggl.Droid.Fragments
{
    public sealed partial class MainFragment
    {
        private View runningEntryCardFrame;
        private AnimatedFloatingActionButton playButton;
        private FloatingActionButton stopButton;
        private CoordinatorLayout coordinatorLayout;
        private TextView timeEntryCardTimerLabel;
        private TextView timeEntryCardDescriptionLabel;
        private TextView timeEntryCardAddDescriptionLabel;
        private View timeEntryCardDotContainer;
        private View timeEntryCardDotView;
        private TextView timeEntryCardProjectClientTaskLabel;
        private SwipeRefreshLayout refreshLayout;
        private RecyclerView mainRecyclerView;
        private ViewStub emptyStateViewStub;
        private View emptyStateView;
        private ViewStub welcomeBackStub;
        private View welcomeBackView;
        private TextView welcomeBackTitle;
        private TextView welcomeBackSubText;
        private AppBarLayout appBarLayout;
        private TooltipLayout hereIsYourTimeEntryTooltip;
        private TooltipLayout tapHereToStartYourTimeTooltip;
        private TooltipLayout tapHereToStopYourTimeTooltip;
        private TooltipLayout finalTooltip;
        private TextView emptyStateGetReadyToTrackTimeTextView;

        protected override void InitializeViews(View fragmentView)
        {
            mainRecyclerView = fragmentView.FindViewById<RecyclerView>(Resource.Id.MainRecyclerView);
            runningEntryCardFrame = fragmentView.FindViewById(Resource.Id.MainRunningTimeEntrySheet);
            playButton = fragmentView.FindViewById<AnimatedFloatingActionButton>(Resource.Id.MainPlayButton);
            stopButton = fragmentView.FindViewById<FloatingActionButton>(Resource.Id.MainStopButton);
            coordinatorLayout = fragmentView.FindViewById<CoordinatorLayout>(Resource.Id.MainCoordinatorLayout);
            timeEntryCardTimerLabel = fragmentView.FindViewById<TextView>(Resource.Id.MainRunningTimeEntryTimerLabel);
            timeEntryCardDescriptionLabel = fragmentView.FindViewById<TextView>(Resource.Id.MainRunningTimeEntryDescription);
            timeEntryCardAddDescriptionLabel = fragmentView.FindViewById<TextView>(Resource.Id.MainRunningTimeEntryAddDescriptionLabel);
            timeEntryCardDotContainer = fragmentView.FindViewById(Resource.Id.MainRunningTimeEntryProjectDotContainer);
            timeEntryCardDotView = fragmentView.FindViewById(Resource.Id.MainRunningTimeEntryProjectDotView);
            timeEntryCardProjectClientTaskLabel = fragmentView.FindViewById<TextView>(Resource.Id.MainRunningTimeEntryProjectClientTaskLabel);
            refreshLayout = fragmentView.FindViewById<SwipeRefreshLayout>(Resource.Id.MainSwipeRefreshLayout);
            emptyStateViewStub = fragmentView.FindViewById<ViewStub>(Resource.Id.EmptyStateViewStub);
            welcomeBackStub = fragmentView.FindViewById<ViewStub>(Resource.Id.WelcomeBackViewStub);
            appBarLayout = fragmentView.FindViewById<AppBarLayout>(Resource.Id.AppBarLayout);
            hereIsYourTimeEntryTooltip = fragmentView.FindViewById<TooltipLayout>(Resource.Id.HereIsYourTimeEntryTooltip);
            tapHereToStartYourTimeTooltip = fragmentView.FindViewById<TooltipLayout>(Resource.Id.TapHereToStartYourTimeTooltip);
            tapHereToStopYourTimeTooltip = fragmentView.FindViewById<TooltipLayout>(Resource.Id.TapHereToStopYourTimeTooltip);
            finalTooltip = fragmentView.FindViewById<TooltipLayout>(Resource.Id.FinalTooltip);

            timeEntryCardAddDescriptionLabel.Text = Shared.Resources.AddDescription;
            hereIsYourTimeEntryTooltip.Text = Shared.Resources.HereIsYourRunningTimeEntryTooltip;
            tapHereToStartYourTimeTooltip.Text = Shared.Resources.TapHereToStartYourNextTimeEntry;
            tapHereToStopYourTimeTooltip.Text = Shared.Resources.TapHereToStopYourTimeEntry;
            finalTooltip.Title = Shared.Resources.YouveMadeYourFirstTimeEntry;
            finalTooltip.Text = Shared.Resources.YouCanAccessTimeEntriesFromAnyTogglApp;
            finalTooltip.ButtonText = Shared.Resources.OkGotIt;
        }
    }
}
