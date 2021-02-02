using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using MacGallery.ThumbnailGrid.Models;

namespace MacGallery.ThumbnailGrid
{
    public partial class ThumbnailItemController : NSCollectionViewItem
    {
        #region Private Variables
        /// <summary>
        /// The person that will be displayed.
        /// </summary>
        private ThumbnailModel? _thumbnail;
        #endregion

        #region Computed Properties
        // strongly typed view accessor
        public new ThumbnailItem View
        {
            get
            {
                return (ThumbnailItem)base.View;
            }
        }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>The person that this item belongs to.</value>
        [Export("Thumbnail")]
        public ThumbnailModel? Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                WillChangeValue("Thumbnail");
                _thumbnail = value;
                DidChangeValue("Thumbnail");
            }
        }

        /// <summary>
        /// Gets or sets the color of the background for the item.
        /// </summary>
        /// <value>The color of the background.</value>
        public NSColor BackgroundColor
        {
            get { return Background.FillColor; }
            set { Background.FillColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MacCollectionNew.EmployeeItemController"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        /// <remarks>This also changes the background color based on the selected state
        /// of the item.</remarks>
        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                base.Selected = value;

                // Set background color based on the selection state
                if (value)
                {
                    BackgroundColor = NSColor.DarkGray;
                }
                else
                {
                    BackgroundColor = NSColor.LightGray;
                }
            }
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
    }
}
