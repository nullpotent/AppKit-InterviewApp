// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacGallery
{
	[Register ("OutlineViewController")]
	partial class OutlineViewController
	{
		[Outlet]
		MacGallery.OutlineView outlineView { get; set; }

		[Outlet]
		AppKit.NSTreeController treeController { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (outlineView != null) {
				outlineView.Dispose ();
				outlineView = null;
			}

			if (treeController != null) {
				treeController.Dispose ();
				treeController = null;
			}
		}
	}
}
