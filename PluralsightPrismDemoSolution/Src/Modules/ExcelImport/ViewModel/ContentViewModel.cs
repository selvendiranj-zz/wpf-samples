using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelImport.ViewModel
{
    public class ContentViewModel
    {
        public DelegateCommand FileOpenCommand;
        public ContentViewModel()
        {
            FileOpenCommand = new DelegateCommand(OpenFileDialogue);
        }

        private void OpenFileDialogue()
        {

        }
    }
}
