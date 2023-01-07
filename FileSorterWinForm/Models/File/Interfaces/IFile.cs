using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileSorterWinForm.Models.Files.Interfaces
{
    public interface IFile : IFileInfo
    {
        DateTime CreationDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string FileFullPath { get; set; }
        string FileDirectory { get; set; }
        string FileNameWithoutExtension { get; set; }
        string FileExtension { get; set; }

        /// <summary>
        /// This function returns the original creation date of a file. This is needed because different devices have different conventions for dating a file.
        /// </summary>
        /// <returns>DateTime</returns>
        DateTime GetFileOriginalDate();
    }


}
