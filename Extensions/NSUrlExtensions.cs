using System;
using System.Diagnostics;
using System.Linq;
using Foundation;
using ImageIO;

namespace MacGallery.Extensions
{
    public static class NSUrlExtensions
    {
        static readonly string[] imageFormats = new[] { "jpg", "jpeg", "png", "gif", "tiff" };

        public static bool IsFolder(this NSUrl url)
        {
            var resources = url.GetResourceValues(new[]
            {
                NSUrl.IsDirectoryKey, NSUrl.IsPackageKey
            }, out var error);

            if (error != null)
            {
                Debug.WriteLine(error);
                return false;
            }

            var isDir = resources.TryGetValue(NSUrl.IsDirectoryKey, out var isDirObj) && ((NSNumber)isDirObj).BoolValue;
            var isPackage = resources.TryGetValue(NSUrl.IsPackageKey, out var isPackageObj) && ((NSNumber)isPackageObj).BoolValue;
            return isDir && !isPackage;
        }

        public static bool IsImage(this NSUrl url)
        {
            if (url.TryGetResource(NSUrl.TypeIdentifierKey, out var typeObj, out var error))
            {
                var typeIdentifier = (NSString)typeObj;
                return CGImageSource.TypeIdentifiers.Any(imageType => MobileCoreServices.UTType.ConformsTo(typeIdentifier, imageType));
            }
            else
            {
                // Can't find the type identifier, check further by extension.
                return imageFormats.Contains(url.PathExtension);
            }
        }

        // Returns the type or UTI.
        public static string GetFileType(this NSUrl url)
        {
            if (url.TryGetResource(NSUrl.TypeIdentifierKey, out var fileTypeObj, out var error))
            {
                return (NSString)fileTypeObj;
            }
            return string.Empty;
        }

        public static bool IsHidden(this NSUrl url)
        {
            if (url.TryGetResource(NSUrl.IsHiddenKey, out var isHiddenObj, out var error))
            {
                return ((NSNumber)isHiddenObj).BoolValue;
            }
            return false;
        }

        public static string GetLocalizedName(this NSUrl url)
        {
            if (url.TryGetResource(NSUrl.LocalizedNameKey, out var nameObj, out var error))
            {
                return (NSString)nameObj;
            }
            else
            {
                // Failed to get the localized name, use it's last path component as the name.
                return url.LastPathComponent;
            }
        }
    }
}
