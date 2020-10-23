using System;
using Toggl.Core.UI.ViewModels;
using Toggl.Core.UI.ViewModels.Calendar;
using Toggl.Core.UI.ViewModels.DateRangePicker;
using Toggl.Core.UI.ViewModels.Reports;
using Toggl.Core.UI.ViewModels.Settings;
using Toggl.Core.UI.ViewModels.Settings.Siri;
using Toggl.iOS.ViewControllers;
using Toggl.iOS.ViewControllers.Calendar;
using Toggl.iOS.ViewControllers.Settings;
using Toggl.iOS.ViewControllers.Settings.Siri;
using Toggl.Shared.Extensions;
using UIKit;

namespace Toggl.iOS.Presentation
{
    public static class ViewControllerLocator
    {
        public static UIViewController GetViewController<TViewModel>(TViewModel viewModel)
            where TViewModel : IViewModel
        {
            switch (viewModel)
            {
                case AboutViewModel vm:
                    return new AboutViewController(vm);
                case CalendarViewModel vm:
                    return new CalendarViewController(vm);
                case CalendarPermissionDeniedViewModel vm:
                    return new CalendarPermissionDeniedViewController(vm);
                case IndependentCalendarSettingsViewModel vm:
                    return new CalendarSettingsViewController(vm);
                case CalendarSettingsViewModel vm:
                    return new CalendarSettingsViewController(vm);
                case EditDurationViewModel vm:
                    return new EditDurationViewController(vm);
                case EditProjectViewModel vm:
                    return new EditProjectViewController(vm);
                case EditTimeEntryViewModel vm:
                    return new EditTimeEntryViewController(vm);
                case ForgotPasswordViewModel vm:
                    return new ForgotPasswordViewController(vm);
                case LicensesViewModel vm:
                    return new LicensesViewController(vm);
                case LoginViewModel vm:
                    return new LoginViewController(vm);
                case MainTabBarViewModel vm:
                    return new MainTabBarController(vm);
                case MainViewModel vm:
                    return new MainViewController(vm);
                case NotificationSettingsViewModel vm:
                    return new NotificationSettingsViewController(vm);
                case NoWorkspaceViewModel vm:
                    return new NoWorkspaceViewController(vm);
                case OnboardingViewModel vm:
                    return new OnboardingViewController(vm);
                case OutdatedAppViewModel vm:
                    return new OutdatedAppViewController(vm);
                case PasteFromClipboardViewModel vm:
                    return new PasteFromClipboardViewController(vm);
                case ReportsViewModel vm:
                    return new ReportsViewController(vm);
                case SelectClientViewModel vm:
                    return new SelectClientViewController(vm);
                case SelectColorViewModel vm:
                    return new SelectColorViewController(vm);
                case SelectCountryViewModel vm:
                    return new SelectCountryViewController(vm);
                case SelectDateTimeViewModel vm:
                    return new SelectDateTimeViewController(vm);
                case SelectDefaultWorkspaceViewModel vm:
                    return new SelectDefaultWorkspaceViewController(vm);
                case SelectProjectViewModel vm:
                    return new SelectProjectViewController(vm);
                case SelectTagsViewModel vm:
                    return new SelectTagsViewController(vm);
                case SendFeedbackViewModel vm:
                    return new SendFeedbackViewController(vm);
                case SettingsViewModel vm:
                    return new SettingsViewController(vm);
                case SignUpViewModel vm:
                    return new SignUpViewController(vm);
                case SiriShortcutsCustomTimeEntryViewModel vm:
                    return new SiriShortcutsCustomTimeEntryViewController(vm);
                case SiriShortcutsSelectReportPeriodViewModel vm:
                    return new SiriShortcutsSelectReportPeriodViewController(vm);
                case SiriShortcutsViewModel vm:
                    return new SiriShortcutsViewController(vm);
                case SsoViewModel vm:
                    return new SsoLoginViewController(vm);
                case SsoLinkViewModel vm:
                    return new SsoLinkViewController(vm);
                case StartTimeEntryViewModel vm:
                    return new StartTimeEntryViewController(vm);
                case SyncFailuresViewModel vm:
                    return new SyncFailuresViewController(vm);
                case TermsOfServiceViewModel vm:
                    return new TermsOfServiceViewController(vm);
                case TokenResetViewModel vm:
                    return new TokenResetViewController(vm);
                case UpcomingEventsNotificationSettingsViewModel vm:
                    return new UpcomingEventsNotificationSettingsViewController(vm);
                case DateRangePickerViewModel vm:
                    return new DateRangePickerViewController(vm);
                case TermsAndCountryViewModel vm:
                    return new TermsAndCountryViewController(vm);
                case YourPlanViewModel vm:
                    return new YourPlanViewController(vm);
                case AnnouncementViewModel vm:
                    return new AnnouncementViewController(vm);
                case ConnectCalendarsPopupViewModel vm:
                    return new ConnectCalendarsPopupViewController(vm);
                default:
                    throw new Exception($"Failed to create ViewController for ViewModel of type {viewModel.GetType().Name}");
            }
        }

        public static UIViewController GetNavigationViewController<TViewModel>(TViewModel viewModel)
            where TViewModel : IViewModel
            => GetViewController(viewModel).Apply(wrapInNavigationController);

        private static UIViewController wrapInNavigationController(UIViewController viewController)
        {
            if (viewController is CalendarViewController)
                return viewController;

            return new ReactiveNavigationController(viewController);
        }
    }
}
