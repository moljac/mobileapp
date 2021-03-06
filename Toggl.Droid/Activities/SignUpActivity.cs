﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using System;
using System.Reactive;
using System.Reactive.Linq;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Toggl.Core.UI.ViewModels;
using Toggl.Droid.Extensions.Reactive;
using Toggl.Droid.Helper;
using Toggl.Droid.Presentation;
using Toggl.Shared;
using Toggl.Shared.Extensions;

namespace Toggl.Droid.Activities
{
    [Activity(Theme = "@style/Theme.Splash",
              ScreenOrientation = ScreenOrientation.Portrait,
              WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden,
              ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public sealed partial class SignUpActivity : ReactiveActivity<SignUpViewModel>
    {
        public SignUpActivity() : base(
            Resource.Layout.SignUpActivity,
            Resource.Style.AppTheme,
            Transitions.SlideInFromBottom)
        { }

        public SignUpActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        { }
        
        protected override void InitializeBindings()
        {
            ViewModel.Email
                .Select(email => email.ToString())
                .Take(1)
                .Subscribe(emailEditText.Rx().TextObserver(true))
                .DisposedBy(DisposeBag);

            ViewModel.Password
                .Select(password => password.ToString())
                .Take(1)
                .Subscribe(passwordEditText.Rx().TextObserver(true))
                .DisposedBy(DisposeBag);

            ViewModel.IsPasswordStrong
                .Subscribe(resetPasswordErrorLabelColorIfPasswordStrong)
                .DisposedBy(DisposeBag);

            emailEditText.Rx().Text()
                .Select(Email.From)
                .Subscribe(ViewModel.Email.Accept)
                .DisposedBy(DisposeBag);

            passwordEditText.Rx().Text()
                .Select(Password.From)
                .Subscribe(ViewModel.Password.Accept)
                .DisposedBy(DisposeBag);

            ViewModel.EmailError
                .Subscribe(emailInputLayout.Rx().ErrorObserver())
                .DisposedBy(DisposeBag);

            ViewModel.PasswordError
                .Subscribe(passwordInputLayout.Rx().ErrorObserver())
                .DisposedBy(DisposeBag);

            ViewModel.PasswordError
                .Subscribe(handlePasswordError)
                .DisposedBy(DisposeBag);

            ViewModel.SignUpError
                .Subscribe(errorLabel.Rx().TextObserver())
                .DisposedBy(DisposeBag);

            var animatedLoadingMessage = TextHelpers.AnimatedLoadingMessage();

            ViewModel.IsLoading
                .CombineLatest(animatedLoadingMessage, signupButtonTitle)
                .Subscribe(signUpButton.Rx().TextObserver())
                .DisposedBy(DisposeBag);

            ViewModel.IsLoading
                .Subscribe(loadingOverlay.Rx().IsVisible(useGone: false))
                .DisposedBy(DisposeBag);

            var isNotLoading = ViewModel.IsLoading.Invert();
            isNotLoading
                .Subscribe(emailInputLayout.Rx().Enabled())
                .DisposedBy(DisposeBag);

            isNotLoading
                .Subscribe(passwordInputLayout.Rx().Enabled())
                .DisposedBy(DisposeBag);

            isNotLoading
                .Subscribe(this.Rx().NavigationEnabled())
                .DisposedBy(DisposeBag);

            loadingOverlay.Rx().Tap()
                .Subscribe(CommonFunctions.DoNothing)
                .DisposedBy(DisposeBag);

            passwordEditText.Rx().EditorActionSent()
                .Subscribe(ViewModel.SignUp.Inputs)
                .DisposedBy(DisposeBag);

            signUpButton.Rx()
                .BindAction(ViewModel.SignUp)
                .DisposedBy(DisposeBag);

            loginLabel.Rx().Tap()
                .Subscribe(_ =>
                {
                    ViewModel.Login.Inputs.OnNext(Unit.Default);
                    ViewModel.CloseWithDefaultResult();
                })
                .DisposedBy(DisposeBag);

            string signupButtonTitle(bool isLoading, string currentLoadingMessage)
                => isLoading
                    ? currentLoadingMessage
                    : Shared.Resources.SignUp;
        }

        private void handlePasswordError(string error)
        {
            if (error == "")
            {
                setPasswordErrorLabelTextColor(Shared.Resources.StrongPasswordCriteria, secondaryTextColor, null);
            }
            else
            {
                setPasswordErrorLabelTextColor(error, errorTextColor, defaultErrorDrawable);
            }
        }

        private void resetPasswordErrorLabelColorIfPasswordStrong(bool isStrong)
        {
            if (isStrong)
            {
                handlePasswordError("");
            }
        }

        private void setPasswordErrorLabelTextColor(string errorText, ColorStateList textColor, Drawable errorDrawable)
        {
            passwordInputLayout.SetErrorTextColor(textColor);
            passwordInputLayout.ErrorIconDrawable = errorDrawable;
            passwordInputLayout.Error = errorText;
        }
    }
}