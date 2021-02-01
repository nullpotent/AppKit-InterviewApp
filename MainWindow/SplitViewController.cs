using System;
using System.Diagnostics;
using AppKit;
using Foundation;
using ObjCRuntime;

namespace MacGallery.MainWindow
{
    public partial class SplitViewController : NSSplitViewController
    {
        private NSLayoutConstraint[]? horizontalConstraints;
        private NSLayoutConstraint[]? verticalConstraints;

        private DetailViewController DetailViewController
        {
            get
            {
                var rightSplitViewItem = SplitViewItems[1];
                return (rightSplitViewItem.ViewController as DetailViewController)!;
            }
        }

        private OutlineViewController OutlineViewController
        {
            get
            {
                var leftSplitViewItem = SplitViewItems[0];
                return (leftSplitViewItem.ViewController as OutlineViewController)!;
            }
        }

        private bool HasChildViewController
        {
            get
            {
                return !(DetailViewController.ChildViewControllers.Length == 0);
            }
        }

        private void EmbedChildViewController(NSViewController childViewController)
        {
            // To embed a new child view controller.
            var currentDetailVC = DetailViewController;
            currentDetailVC.AddChildViewController(childViewController);
            currentDetailVC.View.AddSubview(childViewController.View);

            // Build the horizontal, vertical constraints so that added child view controllers matches the width and height of it's parent.

            var views = new NSMutableDictionary();
            views.Add(new NSString("targetView"), childViewController.View);
            horizontalConstraints = NSLayoutConstraint.FromVisualFormat("H:|[targetView]|", NSLayoutFormatOptions.None, null, views);
            NSLayoutConstraint.ActivateConstraints(horizontalConstraints);


            verticalConstraints =
                NSLayoutConstraint.FromVisualFormat("V:|[targetView]|", NSLayoutFormatOptions.None, null, views);
            NSLayoutConstraint.ActivateConstraints(verticalConstraints);
        }

        public SplitViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var initialViewController = OutlineViewController.ViewControllerForSelection(null)!;
            EmbedChildViewController(initialViewController);

            GetSplitViewItem(OutlineViewController).Collapsed = true;
            SetupObservers();
        }

        private void SetupObservers()
        {
            NSNotificationCenter.DefaultCenter.AddObserver(
                this,
                new Selector("onBrowseFolderSelected:"),
                WindowViewController.Notifications.BrowseFolderSelected,
                null);
        }

        [Export("onBrowseFolderSelected:")]
        private void OnBrowseFolderSelected(NSNotification notification)
        {
            Debug.WriteLine(nameof(OnBrowseFolderSelected));
            GetSplitViewItem(OutlineViewController).Collapsed = false;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
