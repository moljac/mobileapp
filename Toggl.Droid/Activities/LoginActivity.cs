using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using System;
using System.Reactive.Linq;
using Toggl.Core.UI.Extensions;
using Toggl.Core.UI.ViewModels;
using Toggl.Droid.Extensions;
using Toggl.Droid.Extensions.Reactive;
using Toggl.Droid.Presentation;
using Toggl.Shared;
using Toggl.Shared.Extensions;

namespace Toggl.Droid.Activities
{
    [Activity(Theme = "@style/Theme.Splash",
              ScreenOrientation = ScreenOrientation.Portrait,
              WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden,
              ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public sealed partial class LoginActivity : ReactiveActivity<LoginViewModel>
    {
        public LoginActivity() : base(
            Resource.Layout.LoginActivity,
            Resource.Style.AppTheme,
            Transitions.SlideInFromBottom)
        { }

        public LoginActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        protected override void InitializeBindings()
        {
            forgotPasswordLabel.Rx().Tap()
                .Subscribe(ViewModel.ForgotPassword.Inputs)
                .DisposedBy(DisposeBag);
            
            // TODO: bind correct view model
            
            string loginButtonTitle(bool isLoading)
                => isLoading ? "" : Shared.Resources.LoginTitle;

            this.CancelAllNotifications();
        }
    }
}
