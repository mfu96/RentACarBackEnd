using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), MessagesGet.ImageListed);

        }
        [CacheAspect]
        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.ImageId == imageId), MessagesGet.ImageListed);

        }

        [ValidationAspect(typeof(CarImageValidator))]
        // [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCarImage(IFormFile file, CarImage image)
        {
            var result = BusinessRules.Run(CheckCarImageCount(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.AddFile(file);
            image.ImageDate = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult(MessagesAdd.ImageAdded);
        }
        //[SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICarImageService.Get")]

        public IResult UpdateCarImage(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));

           
            if (result != null)
            {
                return result;
            }
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.CarId == image.CarId).ImagePath;

            image.ImagePath = FileHelper.UpdateFile(oldPath, file);
            image.ImageDate = DateTime.Now;

            _carImageDal.Update(image);
            return new SuccessResult(MessagesUpdate.ImageUpdated);
        }
        //[SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICarImageService.Get")]

        public IResult DeleteCarImage(CarImage image)
        {
            var result = _carImageDal.Get(di => di.ImageId == image.ImageId);
            if (result == null)
            {
                return new ErrorResult(MessagesDelete.ImageNotFound);
            }

            FileHelper.DeleteFile(result.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(MessagesDelete.ImageDeleted);
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.ImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetByImagesCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }
        //business rules
        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(MessagesAdd.CarImageOverloading);
            }

            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count >= 5)
            {
                return new ErrorResult(MessagesAdd.CarImageOverloading);
            }
            return new SuccessResult();
        }
    }
}
