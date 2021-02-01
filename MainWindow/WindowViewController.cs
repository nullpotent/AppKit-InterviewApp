// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using ObjCRuntime;
using System.Diagnostics;
using System.Collections.Generic;
using MacGallery.Extensions;
using System.IO;
using System.Linq;

namespace MacGallery.MainWindow
{
    public partial class WindowViewController : NSViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupObservers();
        }

        private NSUrl? PromptForWorkingDirectory()
        {
            var openPanel = NSOpenPanel.OpenPanel;
            openPanel.Message = "Choose directory";
            openPanel.Title = "Choose";
            openPanel.AllowedFileTypes = new[] { "none" };
            openPanel.AllowsOtherFileTypes = false;
            openPanel.CanChooseFiles = false;
            openPanel.CanChooseDirectories = true;

            return openPanel.Show() switch
            {
                NSModalResponse.OK => openPanel.Urls.FirstOrDefault(),
                _ => null
            };
        }

        private IEnumerable<FileNode> EnumerateAllFilesInDirectory(NSUrl? folderUrl)
        {
            if (folderUrl is null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }

            if (!folderUrl.IsFolder())
            {
                throw new DirectoryNotFoundException(folderUrl.Path);
            }

            var fileManager = NSFileManager.DefaultManager;
            var files = fileManager.GetDirectoryContent(
                folderUrl,
                NSArray.FromObjects(),
                NSDirectoryEnumerationOptions.SkipsHiddenFiles,
                out var error);

            if (error != null)
            {
                throw new NSErrorException(error);
            }

            return files.Select(FileNode.FromUrl);
        }

        private void SetupObservers()
        {
            NSNotificationCenter.DefaultCenter.AddObserver(
                this,
                new Selector("onShowBrowseDialog:"),
                WindowController.Notifications.ShowBrowseDialog,
                null);
        }

        [Export("onShowBrowseDialog:")]
        private void OnShowBrowseDialog(NSNotification notification)
        {
            Debug.WriteLine(nameof(OnShowBrowseDialog));
            var workingDir = PromptForWorkingDirectory();
            //var list = EnumerateAllFilesInDirectory(workingDir).ToList();
            var vc = this.ChildViewControllers;
        }

        public WindowViewController(IntPtr handle) : base(handle) { }
    }
}
