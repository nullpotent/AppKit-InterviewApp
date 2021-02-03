using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Foundation;
using MacGallery.Extensions;
using MacGallery.ThumbnailGrid.Models;

namespace MacGallery
{
    public static class ThumbnailStore
    {
        public static List<ThumbnailModel> Thumbnails { get; } = new();

        public static List<ThumbnailModel> GetThumbnails(NSUrl url)
        {
            Thumbnails.Clear();
            var fileUrls = NSFileManager.DefaultManager.GetDirectoryContent(url,
                                                        NSArray.FromObjects(NSUrl.IsDirectoryKey, NSUrl.IsPackageKey, NSUrl.TypeIdentifierKey, NSUrl.LocalizedNameKey),
                                                        NSDirectoryEnumerationOptions.SkipsHiddenFiles,
                                                        out var error).Where(url => url.IsImage());
            if (error != null)
            {
                Debug.WriteLine(error);
                throw new NSErrorException(error);
            }

            foreach (var fileUrl in fileUrls)
            {
                var elementNameStr = fileUrl.GetLocalizedName();
                var elementIcon = fileUrl.GetIcon();

                Thumbnails.Add(new ThumbnailModel(elementNameStr, elementIcon, fileUrl));
            }

            return Thumbnails;
        }

        internal static ThumbnailModel? GetNext(ThumbnailModel? currentThumbnail)
        {
            if (currentThumbnail is null)
            {
                return null;
            }

            var index = Thumbnails.IndexOf(currentThumbnail);
            var nextIndex = (index + 1) % Thumbnails.Count;
            return Thumbnails.ElementAtOrDefault(nextIndex);
        }

        internal static ThumbnailModel? GetPrevious(ThumbnailModel? currentThumbnail)
        {
            if (currentThumbnail is null)
            {
                return null;
            }

            var index = Thumbnails.IndexOf(currentThumbnail);
            var prevIndex = index - 1;
            if (prevIndex < 0)
            {
                prevIndex = Thumbnails.Count - 1;
            }
            return Thumbnails.ElementAtOrDefault(prevIndex);
        }
    }
}
