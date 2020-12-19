using NodePad.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NodePad.ViewModels
{
    class EditorViewModels
    {
        public ICommand FormatCommand { get; }
        public ICommand Wrapcommand { get; }
        public FormateModels Format { get; set; }
        public DocumentModels Document { get; set; }

        public EditorViewModels (DocumentModels document)
        {
            Document = document;
            Format = new FormateModels();
            FormatCommand = new RelayCommand(OpenStyleDialog);
            Wrapcommand = new RelayCommand(ToggleWrap);
        }
        private void OpenStyleDialog()
        {
            var fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
        }

        private void ToggleWrap()
        {
            if (Format.Wrap == System.Windows.TextWrapping.Wrap)
                Format.Wrap = System.Windows.TextWrapping.NoWrap;
            else
                Format.Wrap = System.Windows.TextWrapping.Wrap;
        }
    }
}
