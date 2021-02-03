using System;
using System.Collections.Generic;
using System.Security.Policy;
using AppKit;
using Foundation;

namespace MacGallery.ThumbnailGrid.Models
{
    [Register(nameof(ThumbnailModel))]
    public class ThumbnailModel : NSObject, IEquatable<ThumbnailModel>
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

        public NSUrl Url { get; }

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

        public ThumbnailModel(string name, NSImage? icon, NSUrl url)
        {
            Name = (NSString)name;
            Icon = icon;
            Url = url;
        }

        public override bool Equals(object? obj)
        {
            return obj is ThumbnailModel model && Equals(model);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Url);
        }

        public bool Equals(ThumbnailModel other)
        {
            return EqualityComparer<NSUrl>.Default.Equals(Url, other.Url);
        }
    }
}
