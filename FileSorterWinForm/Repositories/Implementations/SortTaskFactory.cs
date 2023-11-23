using FileSorterWinForm.Exceptions;
using FileSorterWinForm.Repositories.Interfaces;
using FileSorterWinForm.Services;
using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm.Repositories.Implementations
{
    public class SortTaskFactory : ISortTaskFactory
    {
        public ISorterTask Create(string sortActionName)
        {
            switch (sortActionName)
            {
                case "Move":
                    try
                    {
                        return CreateSortActionMove();
                    }
                    catch (SortActionBackDownException)
                    {
                        throw;
                    }
                case "Copy":
                    return new SorterTaskCopy();
                default:
                    return new SorterTaskCopy();
            }
        }

        private SorterTaskMove CreateSortActionMove()  
        {
            
            DialogResult messageBox = MessageBox.Show("Moving your files can be risky, are you sure you want to proceed?",
                                                "Warning",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);
            
            return messageBox == DialogResult.No ? throw new SortActionBackDownException() : new SorterTaskMove();
        }
    }
}
