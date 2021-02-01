// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Diagnostics;
using AppKit;
using Foundation;

namespace MacGallery.MainWindow
{
    public partial class WindowController : NSWindowController
    {
        public static class Notifications
        {
            public static readonly NSString ShowBrowseDialog = new NSString(nameof(ShowBrowseDialog));
        }

        partial void BrowseToolbarAction(NSObject sender)
        {
            Debug.WriteLine(nameof(BrowseToolbarAction));
            NSNotificationCenter.DefaultCenter.PostNotificationName(Notifications.ShowBrowseDialog, null);
        }

        public WindowController(IntPtr handle) : base(handle) { }
    }
}