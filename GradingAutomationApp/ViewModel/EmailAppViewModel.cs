using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
namespace GradingAutomationApp.ViewModel
{
    internal class EmailAppViewModel : ViewModelBase
    {
        public EmailAppViewModel()
        {
            Explore = new DelegateCommand<object>(FileExplorer);
        }

        public void FileExplorer(object parameter)
        {
            string s = parameter as string;
            string selectedPath = null;
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a Folder";

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    selectedPath = dialog.SelectedPath;
                }
            }
            /*            using (var dialog = new OpenFileDialog())
                        {
                            dialog.Title = "Select a File or Folder";
                            dialog.CheckFileExists = false; // Allow selecting folders
                            dialog.CheckPathExists = true; // Check if the path exists
                            DialogResult result = dialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                selectedPath = dialog.FileName; // If a file is selected, this will be the file path
                                if (string.IsNullOrEmpty(selectedPath))
                                {
                                    selectedPath = Path.GetDirectoryName(dialog.FileName); // Get the folder path if no file is selected
                                }
                            }
                        }*/
            if (s == "email")
            {
                EmailListUrl = selectedPath;
            }
            else if(s == "folder")
            {
                FolderUrl = selectedPath;
            }
        }
        private string _emailListUrl;
        public string EmailListUrl
        {
            get { return _emailListUrl; }
            set { _emailListUrl = value; OnPropertyChanged(); }
        }
        private string _folderUrl;
        public string FolderUrl
        {
            get { return _folderUrl; }
            set { _folderUrl = value; OnPropertyChanged(); }
        }
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; OnPropertyChanged(); }
        }
        private string _body;
        public string Body
        {
            get { return _body; }
            set { _body = value; OnPropertyChanged(); }
        }
        private DelegateCommand<object> _explore;
        public DelegateCommand<object> Explore
        {
            get { return _explore; }
            set { _explore = value; OnPropertyChanged(); }
        }
    }
}
