using System;
using AppKit;
using Foundation;

namespace MacGallery
{
    [Register(nameof(FullScreenWindow))]
    public class FullScreenWindow : NSWindow
    {
        public override bool CanBecomeKeyWindow => true;
        public override bool CanBecomeMainWindow => true;

        public FullScreenWindow(IntPtr handle) : base(handle)
        {
        }
    }
}
