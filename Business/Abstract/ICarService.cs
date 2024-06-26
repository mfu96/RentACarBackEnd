﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails(int carId);
        IDataResult<List<Car>> GetByCategoryId(int categoryId);
        IResult AddCar(int currentUserId, Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);

        IDataResult<List<Car>> GetByBrandId(string brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetByCarDetailId( int carId);

        IDataResult<List<Car>> GetCarsByBrandAndColor(int brandId, int colorId);
    }
}
