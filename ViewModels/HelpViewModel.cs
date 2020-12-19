using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NodePad.ViewModels
{
    class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }
        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayAbout);
        }

        private void DisplayAbout()
        {
            //we will open help dialog
        }
    }
}
