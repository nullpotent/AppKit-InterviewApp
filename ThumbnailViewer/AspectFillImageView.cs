using System;
using AppKit;
using CoreAnimation;
using Foundation;

namespace MacGallery
{
    [Register(nameof(AspectFillImageView))]
    public class AspectFillImageView : NSImageView
    {
        public override NSImage? Image
        {
            get => base.Image;
            set
            {
                Layer = new CALayer
                {
                    ContentsGravity = CALayer.GravityResizeAspect,
                    Contents = value?.CGImage,
                    Frame = Frame
                };
                WantsLayer = true;
            }
        }

        public AspectFillImageView(IntPtr handle) : base(handle)
        {
        }
    }
}
