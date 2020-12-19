using Microsoft.Win32;
using NodePad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace NodePad.ViewModels
{
    class FileViewModel
    {
        public DocumentModels Document { get; private set; }

        //toolber commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public FileViewModel (DocumentModels document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        public void SaveFile()
        {
            if ((Document.FileName == string.Empty) || (Document.FileName == null))
                SaveFileAs();
            else
                File.WriteAllText(Document.FilePath, Document.Text);

        }
        private void SaveFileAs()
        {
            var saveFilDialog = new SaveFileDialog();
            saveFilDialog.Filter = "Text File (*.txt)| *.txt";
            if(saveFilDialog.ShowDialog() == true)
            {
                Dockfile(saveFilDialog);
                File.WriteAllText(saveFilDialog.FileName, Document.Text);
            }

        }
        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Dockfile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        public void Dockfile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
