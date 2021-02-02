using System;
using AppKit;
using Foundation;

namespace MacGallery.ThumbnailGrid.Models
{
    [Register(nameof(ThumbnailModel))]
    public class ThumbnailModel : NSObject
    {
        private NSString? _name;
        private NSImage? _icon;

        [Export(nameof(Icon))]
        public NSImage? Icon
        {
            get => _icon;
            set
            {
                WillChangeValue(nameof(Icon));
                _icon = value;
                DidChangeValue(nameof(Icon));
            }
        }

        [Export(nameof(Name))]
        public NSString Name
        {
            get => _name ?? NSString.Empty;
            set
            {
                WillChangeValue(nameof(Name));
                _name = value;
                DidChangeValue(nameof(Name));
            }
        }

        public ThumbnailModel(string name, NSImage? icon)
        {
            Name = (NSString)name;
            Icon = icon;
        }

        public ThumbnailModel(NSString name, NSImage? icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
