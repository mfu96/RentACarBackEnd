using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICategoryService
   {
      IDataResult<List<Category>> GetAll();
       IDataResult<Category> GetById(int categoryId);
       IResult AddCategory(Category category);
       IResult UpdateCategory(Category category);
       IResult DeleteCategory(Category category);

   }
}
