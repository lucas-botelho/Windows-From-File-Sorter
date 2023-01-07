using FileSorterWinForm.Patterns.Factory.Implementations;
using FileSorterWinForm.Patterns.Factory.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services.Base
{
    public abstract class BaseSortingMethodService : ISortingMethodSerivce
    {
        public readonly IDirectoryRepository _fileDirectoryRepository;
        public readonly ICustomFileFactory _customFileFactory;

        public BaseSortingMethodService(IDirectoryRepository fileDirectoryRepository)
        {
            _fileDirectoryRepository = fileDirectoryRepository;
            _customFileFactory = (ICustomFileFactory)Program.ServiceProvider.GetService(typeof(ICustomFileFactory));
        }

        public abstract void Execute(string filePath, string destionationDirectory);
    }
}
