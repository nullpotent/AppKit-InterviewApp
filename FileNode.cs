using System;
using Foundation;
using MacGallery.Extensions;
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
        private NSUrl? _url = default;
        private string? _title = default;
        private NSImage? _icon;

        [Export("fileType")]
        public NodeType FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                WillChangeValue("fileType");
                _fileType = value;
                DidChangeValue("fileType");
            }
        }

        [Export("url")]
        public NSUrl? Url
        {
            get
            {
                return _url;
            }
            set
            {
                WillChangeValue("url");
                _url = value;
                DidChangeValue("url");
            }
        }

        [Export("title")]
        public string Title
        {
            get
            {
                return _title ?? string.Empty;
            }
            set
            {
                WillChangeValue("title");
                _title = value;
                DidChangeValue("title");
            }
        }

        [Export("children")]
        public NSArray Children => _children;

        [Export("setChildren:")]
        public void SetChildren(NSMutableArray array)
        {
            WillChangeValue("children");
            _children = array;
            DidChangeValue("children");
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
            get => _icon;
            set
            {
                WillChangeValue("icon");
                _icon = value;
                DidChangeValue("icon");
            }
        }

        public static FileNode? From(NSObject? obj)
        {
            return obj switch
            {
                NSTreeNode treeNode => treeNode?.RepresentedObject as FileNode,
                NSUrl url => new FileNode
                {
                    Url = url,
                    //Icon = url.GetIcon(),
                    FileType = url.IsFolder() ? NodeType.Folder : url.IsImage() ? NodeType.Image : NodeType.Unknown,
                    Title = url.GetLocalizedName()
                },
                _ => null
            };
        }

        public override string ToString()
        {
            return $"{Title}, {FileType}, {Url}";
        }

        internal void LoadIcon()
        {
            Icon = IsFolder ?
                NSWorkspace.SharedWorkspace.IconForFileType(HfsTypeCode.GenericFolderIcon) :
                Url?.GetIcon();
        }
    }
}