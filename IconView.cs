using System;
using AppKit;
using Foundation;

namespace MacGallery
{
    [Register(nameof(IconView))]
    public class IconView : NSObject
    {
        private NSString? _name = default;
        private NSImage? _icon;

        [Export("icon")]
        public NSImage? Icon
        {
            get => _icon;
            set
            {
                WillChangeValue("icon");
                _icon = value;
                DidChangeValue("icon");
            }
        }

        [Export("name")]
        public NSString Name
        {
            get
            {
                return _name ?? NSString.Empty;
            }
            set
            {
                WillChangeValue("name");
                _name = value;
                DidChangeValue("name");
            }
        }
    }
}
