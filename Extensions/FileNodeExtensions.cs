using AppKit;

namespace MacGallery.Extensions
{
    internal static class FileNodeExtensions
    {
        public static bool IsLeaf(this FileNode node)
        {
            return node.FileType is NodeType.Unknown or NodeType.Image;
        }

        public static bool IsFolder(this FileNode node)
        {
            return node.FileType is NodeType.Folder;
        }

        public static bool IsImage(this FileNode node)
        {
            return node.FileType is NodeType.Image;
        }

        public static NSImage? Icon(this FileNode node)
        {
            return null; // node.FileType is NodeType.Image;
        }
    }
}