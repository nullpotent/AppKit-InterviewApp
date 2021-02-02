// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacGallery.ThumbnailGrid
{
    [Register("ThumbnailGridViewController")]
    partial class ThumbnailGridViewController
    {
        [Outlet]
        AppKit.NSCollectionView ThumbnailCollection { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (ThumbnailCollection != null)
            {
                ThumbnailCollection.Dispose();
                ThumbnailCollection = null;
            }
        }
    }
}
