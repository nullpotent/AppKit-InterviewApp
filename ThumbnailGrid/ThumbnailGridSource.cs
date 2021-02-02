using System;
using System.Collections.Generic;
using AppKit;
using Foundation;
using MacGallery.ThumbnailGrid.Models;

namespace MacGallery.ThumbnailGrid
{
    public class ThumbnailGridSource : NSCollectionViewDataSource
    {
        #region Computed Properties
        public List<ThumbnailModel> Data { get; } = new();
        #endregion

        #region Constructors
        public ThumbnailGridSource()
        {
        }
        #endregion

        #region Override Methods
        public override nint GetNumberOfSections(NSCollectionView collectionView)
            => 1;

        public override nint GetNumberofItems(NSCollectionView collectionView, nint section)
            => Data.Count;

        public override NSCollectionViewItem GetItem(NSCollectionView collectionView, NSIndexPath indexPath)
        {
            if (collectionView.MakeItem("ThumbnailCell", indexPath) is not ThumbnailItemController item)
            {
                throw new NullReferenceException(nameof(item));
            }

            item.Thumbnail = Data[(int)indexPath.Item];
            return item;
        }
        #endregion
    }
}
