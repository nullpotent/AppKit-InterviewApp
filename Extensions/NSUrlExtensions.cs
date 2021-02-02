using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppKit;
using CoreGraphics;
using CoreServices;
using Foundation;
using ImageIO;
using OpenTK;
using QuickLook;
using QuickLookThumbnailing;

namespace MacGallery.Extensions
{
    public static class NSUrlExtensions
    {
        public static readonly string[] ImageFormats = new[] { "jpg", "jpeg", "png", "gif", "tiff" };

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
                return ImageFormats.Contains(url.PathExtension);
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

        private static NSImage? ImageWithPreviewOfFileAtPath(NSUrl path)
        {
            try
            {
                var size = new CGSize(48, 48);
                var qlThumbnail = QLThumbnailImage.Create(path, size, 1, true);
                return new NSImage(qlThumbnail, size);
            }
            catch
            {
                return null;
            }
        }

        public static NSImage? GetIcon(this NSUrl url)
        {
            //var resources = url.GetResourceValues(new[] {
            //    NSUrl.CustomIconKey, NSUrl.EffectiveIconKey, NSUrl.ThumbnailDictionaryKey
            //}, out var error);

            //if (resources == null || error != null)
            //{
            //    Debug.WriteLine(error);
            //    var osType = IsFolder(url) ? HfsTypeCode.GenericFolderIcon : HfsTypeCode.GenericDocumentIcon;
            //    return NSWorkspace.SharedWorkspace.IconForFileType(osType);
            //}

            //if (resources.TryGetValue(NSUrl.ThumbnailDictionaryKey, out var thumbnailObj))
            //{
            //    return ImageWithPreviewOfFileAtPath(url);
            //}
            //else if (resources.TryGetValue(NSUrl.CustomIconKey, out var customIconObj) && customIconObj is NSImage customIcon)
            //{
            //    return customIcon;
            //}
            //else if (resources.TryGetValue(NSUrl.EffectiveIconKey, out var effectiveIconObj) && effectiveIconObj is NSImage effectiveIcon)
            //{
            //    return effectiveIcon;
            //}

            //return null;

            return ImageWithPreviewOfFileAtPath(url);
        }
    }
}
