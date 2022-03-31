using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DateAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetByCarDetailId(int carId);

    }
}
