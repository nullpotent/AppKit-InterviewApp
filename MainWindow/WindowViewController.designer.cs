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
	[Register ("WindowViewController")]
	partial class WindowViewController
	{
		[Outlet]
		AppKit.NSView containerView { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator progressBar { get; set; }

		[Action ("BrowseToolbarAction:")]
		partial void BrowseToolbarAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (containerView != null) {
				containerView.Dispose ();
				containerView = null;
			}

			if (progressBar != null) {
				progressBar.Dispose ();
				progressBar = null;
			}
		}
	}
}
