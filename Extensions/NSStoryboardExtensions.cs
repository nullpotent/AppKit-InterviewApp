using System;
using AppKit;

namespace MacGallery.Extensions
{
    public static class NSStoryboardExtensions
    {
        public static TController CreateController<TController>(this NSStoryboard self) where TController : NSViewController
        {
            if (self.InstantiateControllerWithIdentifier(typeof(TController).Name) is TController controller)
            {
                return controller;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public static TController CreateWindow<TController>(this NSStoryboard self) where TController : NSWindowController
        {
            if (self.InstantiateControllerWithIdentifier(typeof(TController).Name) is TController controller)
            {
                return controller;
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
