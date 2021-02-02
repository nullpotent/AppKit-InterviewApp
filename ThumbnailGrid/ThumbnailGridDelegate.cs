using System;
using Foundation;
using AppKit;

namespace MacGallery.ThumbnailGrid
{
    public class ThumbnailGridDelegate : NSCollectionViewDelegateFlowLayout
    {
        #region Computed Properties
        public ThumbnailGridViewController ParentViewController { get; set; }
        #endregion

        #region Constructors
        public ThumbnailGridDelegate(ThumbnailGridViewController parentViewController)
        {
            ParentViewController = parentViewController;
        }
        #endregion

        #region Override Methods
        public override void ItemsSelected(NSCollectionView collectionView, NSSet indexPaths)
        {
            var paths = indexPaths.ToArray<NSIndexPath>();
            var index = (int)paths[0].Item;

            ParentViewController.ThumbnailSelected = ParentViewController.Source.Data[index];
        }

        public override void ItemsDeselected(NSCollectionView collectionView, NSSet indexPaths)
        {
            var paths = indexPaths.ToArray<NSIndexPath>();
            var index = paths[0].Item;
            ParentViewController.ThumbnailSelected = null;
        }
        #endregion
    }
}
