﻿using System;
using System.Reactive.Linq;
using CoreGraphics;
using Toggl.iOS.Extensions;
using Toggl.iOS.Extensions.Reactive;
using Toggl.Core;
using Toggl.Core.UI.ViewModels.Calendar;
using Toggl.iOS.ViewSources;
using Toggl.Shared.Extensions;
using UIKit;

namespace Toggl.iOS.ViewControllers.Calendar
{
    public sealed partial class SelectUserCalendarsViewController
        : ReactiveViewController<SelectUserCalendarsViewModel>
    {
        private const int heightAboveTableView = 98;
        private const int heightBelowTableView = 80;
        private readonly int maxHeight = UIScreen.MainScreen.Bounds.Width > 320 ? 627 : 528;
        private const int width = 288;

        private const float enabledDoneButtonAlpha = 1;
        private const float disabledDoneButtonAlpha = 0.32f;

        public SelectUserCalendarsViewController()
            : base(null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            HeadingLabel.Text = Resources.SelectCalendars;
            DescriptionLabel.Text = Resources.SelectCalendarsDescription;
            DoneButton.SetTitle(Resources.Done, UIControlState.Normal);

            var source = new SelectUserCalendarsTableViewSource(TableView);
            TableView.Source = source;

            DoneButton.Rx()
                .BindAction(ViewModel.Done)
                .DisposedBy(DisposeBag);

            source.Rx().ModelSelected()
                .Subscribe(ViewModel.SelectCalendar.Inputs)
                .DisposedBy(DisposeBag);

            ViewModel.Done.Enabled
                .Subscribe(DoneButton.Rx().Enabled())
                .DisposedBy(DisposeBag);

            ViewModel.Done.Enabled
                .Select(alphaForEnabled)
                .Subscribe(DoneButton.Rx().AnimatedAlpha())
                .DisposedBy(DisposeBag);

            ViewModel.Calendars
                .Subscribe(TableView.Rx().ReloadSections(source))
                .DisposedBy(DisposeBag);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            setDialogSize();
        }

        private void setDialogSize()
        {
            var targetHeight = calculateTargetHeight();
            PreferredContentSize = new CGSize(
                width,
                targetHeight > maxHeight ? maxHeight : targetHeight
            );

            //Implementation in ModalPresentationController
            View.Frame = PresentationController.FrameOfPresentedViewInContainerView;

            TableView.ScrollEnabled = targetHeight > maxHeight;
        }

        private int calculateTargetHeight()
            => heightAboveTableView + heightBelowTableView + (int)TableView.ContentSize.Height;

        private float alphaForEnabled(bool enabled)
            => enabled ? enabledDoneButtonAlpha : disabledDoneButtonAlpha;
    }
}