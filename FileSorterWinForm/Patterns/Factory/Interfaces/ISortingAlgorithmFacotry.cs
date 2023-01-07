using FileSorterWinForm.Enums;
using FileSorterWinForm.Repositories.Interfaces;

namespace FileSorterWinForm.Patterns.Factory.Interfaces
{
    public interface ISortingAlgorithmFacotry
    {
        IDirectoryRepository CreateSortingAlgorithmRepository(SortingAlgorithmOption option); 
    }
}
