using CL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CL.Interface
{
   public interface ICategory
    {
        Task<IEnumerable<CategoryModel>> GetCategory();
        Task<int> DeleteCategory(int id);
    }
}
