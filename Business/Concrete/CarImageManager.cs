using System;
using System.Collections.Generic;
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
        public IResult AddCarImage(CarImage image, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(image.CarId));
            if (result!= null)
            {
                return result;
            }
            image.ImageDate=DateTime.Now;
            image.ImagePath = FileHelper.AddFile(file);

            _carImageDal.Add(image);
            return new SuccessResult(MessagesAdd.ImageAdded);
        }
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICarImageService.Get")]

        public IResult UpdateCarImage(CarImage image, IFormFile file)
        {
            var oldImage = _carImageDal.Get(ui => ui.ImageId == image.ImageId);
            if (oldImage==null)
            {
                return new ErrorResult(MessagesUpdate.ImageNotFound);
            }
            image.ImageDate=DateTime.Now;
            image.ImagePath = FileHelper.UpdateFile(file, oldImage.ImagePath);

            _carImageDal.Update(image);
            return new SuccessResult(MessagesUpdate.ImageUpdated);
        }
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICarImageService.Get")]

        public IResult DeleteCarImage(CarImage image)
        {
            var result = _carImageDal.Get(di => di.ImageId == image.ImageId);
            if (result==null)
            {
                return new ErrorResult(MessagesDelete.ImageNotFound);
            }

            FileHelper.DeleteFile(result.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult(MessagesDelete.ImageDeleted);
        }

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count>= 5)
            {
                return new ErrorResult(MessagesAdd.CarImageOverloading);
            }
            return new SuccessResult();
        }
    }
}
