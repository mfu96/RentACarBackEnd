using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
       // [SecuredOperation("admin,employer")]
        public IDataResult<List<Car>> GetAll()
        {
            //Adam mı ki erişecek? if else vs
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(MessagesGet.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), MessagesGet.CarsListed);

        }
       
       [CacheAspect]
       [SecuredOperation("admin,editor,employer")]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId),MessagesGet.CarListed);
        }
        [CacheRemoveAspect("ICarService.Get")]   //Açıklama için MyFinalProject.Business.Conrete.ProductManager.Update
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,editor")]   //Burda seçili controller için yetki/authorization ayarlaması yapıyorum
                                                 //ve bunlar key olacağı için hep küçük harf kullanıyorum
       // [TransactionScopeAspect]

        public IResult AddCar(Car car)
        {
        

            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(MessagesAdd.CarAdded);


        }
        [CacheRemoveAspect("ICarService.Get")]   //Açıklama için MyFinalProject.Business.Conrete.ProductManager.Update
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,editor")]
       // [TransactionScopeAspect]

        public IResult UpdateCar(Car car) 
        {
            _carDal.Update(car);
            return new SuccessResult(MessagesUpdate.CarUpdated);
        }
        [CacheRemoveAspect("ICarService.Get")]   //Açıklama için MyFinalProject.Business.Conrete.ProductManager.Update
        //[SecuredOperation("admin,editor")]
        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(MessagesDelete.CarDeleted);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetByCarDetailId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByCarDetailId(carId));
        }

        public IDataResult<List<Car>> GetByImageId(int imageId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ImageId == imageId));
        }

        // [SecuredOperation("admin,editor,employer")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CategoryId == categoryId));
        }
    }
}
