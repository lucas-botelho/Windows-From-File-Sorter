using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Patterns.Factory.Interfaces
{
    public interface ISortingMethodFactory
    {
        ISortingMethodSerivce CreatinSortingMethodRepository(string method);
    }
}
