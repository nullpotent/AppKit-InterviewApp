// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using ObjCRuntime;
using System.Diagnostics;
using System.Collections.Generic;
using MacGallery.Extensions;
using System.IO;
using System.Linq;
using CoreFoundation;

namespace MacGallery.MainWindow
{
    public partial class WindowViewController : NSViewController
    {
        private IconViewController? iconViewController;

        public static class Notifications
        {
            public static readonly NSString ShowProgressBar = new NSString(nameof(ShowProgressBar));
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ShowProgress(false);
            iconViewController = Storyboard.InstantiateControllerWithIdentifier(nameof(IconViewController)) as IconViewController;
            SetupObservers();
        }

        private void ShowProgress(bool show)
        {
            progressBar.Hidden = !show;
            if (progressBar.Hidden)
                progressBar.StopAnimation(this);
            else
                progressBar.StartAnimation(this);
        }

        private NSUrl? PromptForWorkingDirectory()
        {
            var openPanel = NSOpenPanel.OpenPanel;
            openPanel.Message = "Choose directory";
            openPanel.Title = "Choose";
            openPanel.AllowedFileTypes = new[] { "none" };
            openPanel.AllowsOtherFileTypes = false;
            openPanel.CanChooseFiles = false;
            openPanel.CanChooseDirectories = true;

            return openPanel.Show() switch
            {
                NSModalResponse.OK => openPanel.DirectoryUrl,
                _ => null
            };
        }

        private void EmbedChildViewController(NSViewController? childViewController)
        {
            if (childViewController is null)
            {
                return;
            }

            foreach (var view in containerView.Subviews)
            {
                view.RemoveFromSuperview();
            }

            childViewController.View.Frame = containerView.Bounds;
            containerView.AddSubview(childViewController.View);
        }

        partial void BrowseToolbarAction(NSObject sender)
        {
            Debug.WriteLine(nameof(BrowseToolbarAction));

            var workingDir = PromptForWorkingDirectory();
            iconViewController?.SetWorkingDirectoryUrl(workingDir);

            EmbedChildViewController(iconViewController);
        }

        public static void SendShowProgress()
        {
            Debug.WriteLine(nameof(SendShowProgress));
            NSNotificationCenter.DefaultCenter.PostNotificationName(Notifications.ShowProgressBar, NSNumber.FromBoolean(true));
        }

        public static void SendHideProgress()
        {
            Debug.WriteLine(nameof(SendHideProgress));
            //DispatchQueue.DefaultGlobalQueue.DispatchAsync(() =>
            //{
            //action();
            NSNotificationCenter.DefaultCenter.PostNotificationName(Notifications.ShowProgressBar, NSNumber.FromBoolean(false));
            //});
        }

        private void SetupObservers()
        {
            NSNotificationCenter.DefaultCenter.AddObserver(
                this,
                new Selector("onToggleProgress:"),
                WindowViewController.Notifications.ShowProgressBar,
                null);
        }

        [Export("onToggleProgress:")]
        private void OnToggleProgress(NSNotification notification)
        {
            Debug.WriteLine(nameof(OnToggleProgress));
            if (notification.Object is NSNumber showProgressBar)
            {
                ShowProgress(showProgressBar.BoolValue);
            }
        }

        public WindowViewController(IntPtr handle) : base(handle) { }
    }
}
