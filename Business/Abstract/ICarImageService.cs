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
        IResult AddCarImage(CarImage image, IFormFile file);
        IResult UpdateCarImage( CarImage image,IFormFile file);
        IResult DeleteCarImage(CarImage image);
    }
}
