using FileSorterWinForm.Models.Files.Bases;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models.Files
{
    public class GenericImageFile : CustomFileBase
    {
        public GenericImageFile(string filePath) : base(filePath)
        {
        }

        public override DateTime GetFileOriginalDate()
        {
            return this.ModifiedDate < this.CreationDate ? this.ModifiedDate : this.CreationDate;
        }
    }

}
