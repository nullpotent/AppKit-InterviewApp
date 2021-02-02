using System;
using System.Diagnostics;
using AppKit;
using Foundation;
using MacGallery.ThumbnailGrid.Models;

namespace MacGallery.ThumbnailGrid
{
    public partial class ThumbnailItemController : NSCollectionViewItem
    {
        #region Private Variables
        private ThumbnailModel? _thumbnail;
        #endregion

        #region Computed Properties
        public new ThumbnailItem View => (ThumbnailItem)base.View;

        [Export(nameof(Thumbnail))]
        public ThumbnailModel? Thumbnail
        {
            get => _thumbnail;
            set
            {
                WillChangeValue(nameof(Thumbnail));
                _thumbnail = value;
                DidChangeValue(nameof(Thumbnail));
            }
        }

        public NSColor BackgroundColor
        {
            get => Background.FillColor;
            set => Background.FillColor = value;
        }

        public override bool Selected
        {
            get => base.Selected;
            set => base.Selected = value;
        }
        #endregion

        #region Constructors
        // Called when created from unmanaged code
        public ThumbnailItemController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ThumbnailItemController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public ThumbnailItemController() : base(nameof(ThumbnailItem), NSBundle.MainBundle)
        {
            Initialize();
        }

        // Added to support loading from XIB/NIB
        public ThumbnailItemController(string nibName, NSBundle nibBundle) : base(nibName, nibBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }
        #endregion

        public override void MouseDown(NSEvent theEvent)
        {
            base.MouseDown(theEvent);
            if (theEvent.ClickCount > 1)
            {
                OnDoubleClick();
            }
        }

        private void OnDoubleClick()
        {
            Debug.WriteLine(nameof(OnDoubleClick));
            NSApplication.SharedApplication.SendAction(new ObjCRuntime.Selector("CollectionItemViewDoubleClick:"), null, this);
        }
    }
}
