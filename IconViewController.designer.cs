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
	[Register ("IconViewController")]
	partial class IconViewController
	{
		[Outlet]
		AppKit.NSBox boxic { get; set; }

		[Outlet]
		MacGallery.CollectionView CollectionView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (boxic != null) {
				boxic.Dispose ();
				boxic = null;
			}

			if (CollectionView != null) {
				CollectionView.Dispose ();
				CollectionView = null;
			}
		}
	}
}
