// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacGallery.MainWindow
{
    [Register("WindowController")]
    partial class WindowController
    {
        [Outlet]
        AppKit.NSToolbar toolbar { get; set; }

        [Action("BrowseToolbarAction:")]
        partial void BrowseToolbarAction(Foundation.NSObject sender);

        void ReleaseDesignerOutlets()
        {
            if (toolbar != null)
            {
                toolbar.Dispose();
                toolbar = null;
            }
        }
    }
}
