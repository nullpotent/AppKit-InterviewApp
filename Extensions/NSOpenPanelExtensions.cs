using System;
using AppKit;

namespace MacGallery.Extensions
{
    public static class NSOpenPanelExtensions
    {
        public static NSModalResponse Show(this NSOpenPanel openPanel)
        {
            return (NSModalResponse)(long)openPanel.RunModal();
        }
    }
}
