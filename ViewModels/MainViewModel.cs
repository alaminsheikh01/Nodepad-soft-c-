using NodePad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodePad.ViewModels
{
    class MainViewModel
    {
        private DocumentModels _document;
        public EditorViewModels Editor { get; set; }
        public FileViewModel File { get; set; }
        public HelpViewModel Help { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModels();
            Help = new HelpViewModel();
            Editor = new EditorViewModels(_document);
            File = new FileViewModel(_document);
        }

    }
}
