using System;
using AppKit;
using Foundation;

namespace MacGallery.MainWindow
{
    public partial class SplitViewController : NSSplitViewController
    {
        public SplitViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
