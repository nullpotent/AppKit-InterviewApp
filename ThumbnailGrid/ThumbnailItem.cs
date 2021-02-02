using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace MacGallery.ThumbnailGrid
{
    public partial class ThumbnailItem : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public ThumbnailItem(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ThumbnailItem(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
