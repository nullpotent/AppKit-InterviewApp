using System.Collections.Generic;
using System;
using Foundation;
using MacGallery.Extensions;
using System.Diagnostics;

namespace MacGallery
{
    internal enum NodeType
    {
        Unknown,
        Folder,
        Image,
    }

    internal class FileNode
    {
        public NodeType FileType { get; private set; } = NodeType.Unknown;
        public string Url { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public List<FileNode> Children { get; private set; } = new();

        private FileNode() { }

        public static FileNode FromUrl(NSUrl url)
        {
            var node = new FileNode
            {
                Url = url.AbsoluteString,
                FileType = url.IsFolder() ? NodeType.Folder : url.IsImage() ? NodeType.Image : NodeType.Unknown,
                Title = url.GetLocalizedName()
            };
            Debug.WriteLine(node);
            return node;
        }

        public override string ToString()
        {
            return $"{Title}, {FileType}, {Url}";
        }
    }
}