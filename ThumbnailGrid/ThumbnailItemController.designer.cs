using Foundation;

namespace MacGallery.ThumbnailGrid
{

    // Should subclass AppKit.NSViewController
    [Foundation.Register("ThumbnailItemController")]
    public partial class ThumbnailItemController
    {
        [Outlet]
        AppKit.NSBox Background { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (Background != null)
            {
                Background.Dispose();
                Background = null;
            }
        }
    }
}
