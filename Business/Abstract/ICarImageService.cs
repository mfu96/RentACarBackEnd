using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int imageId);
        IDataResult<CarImage> Get(int imageId);
        IResult AddCarImage(IFormFile file, CarImage image);
        IResult UpdateCarImage(IFormFile file, CarImage image);
        IResult DeleteCarImage(CarImage image);
        IDataResult<List<CarImage>> GetByImagesCarId(int carId);
    }
}
