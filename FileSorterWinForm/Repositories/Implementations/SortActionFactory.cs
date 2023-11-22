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
    public class SortActionFactory : ISortActionFactory
    {
        public ISortAction Create(string sortActionName)
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
                    return new SortActionCopy();
                default:
                    return new SortActionCopy();
            }
        }

        private SortActionMove CreateSortActionMove()  
        {
            
            DialogResult messageBox = MessageBox.Show("Moving your files can be risky, are you sure you want to proceed?",
                                                "Warning",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);
            
            return messageBox == DialogResult.No ? throw new SortActionBackDownException() : new SortActionMove();
        }
    }
}
