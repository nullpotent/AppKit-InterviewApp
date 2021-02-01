using System.Collections.Generic;
using System;
using Foundation;
using MacGallery.Extensions;
using System.Diagnostics;
using AppKit;

namespace MacGallery
{
    internal enum NodeType
    {
        Unknown,
        Folder,
        Image,
    }

    [Register("FileNode")]
    internal class FileNode : NSObject
    {
        private NSMutableArray _children = new NSMutableArray();
        private NodeType _fileType = NodeType.Unknown;
        private string _url = string.Empty;
        private string _title = string.Empty;

        [Export("fileType")]
        public NodeType FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                WillChangeValue(nameof(FileType));
                _fileType = value;
                DidChangeValue(nameof(FileType));
            }
        }

        [Export("url")]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                WillChangeValue(nameof(Url));
                _url = value;
                DidChangeValue(nameof(Url));
            }
        }

        [Export("title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                WillChangeValue(nameof(Title));
                _url = value;
                DidChangeValue(nameof(Title));
            }
        }

        [Export("children")]
        public NSArray Children => _children;

        [Export("setChildren:")]
        public void SetChildren(NSMutableArray array)
        {
            WillChangeValue(nameof(Children));
            _children = array;
            DidChangeValue(nameof(Children));
        }

        [Export("numberOfChildren")]
        public nint NumberOfChildren => (nint)_children.Count;

        [Export("isLeaf")]
        public bool IsLeaf => FileType is NodeType.Unknown or NodeType.Image;

        [Export("isFolder")]
        public bool IsFolder => FileType is NodeType.Folder;

        [Export("isImage")]
        public bool IsImage => FileType is NodeType.Image;

        [Export("icon")]
        public NSImage? Icon
        {
            get => null; // node.FileType is NodeType.Image;
        }

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

        private FileNode() { }
    }
}