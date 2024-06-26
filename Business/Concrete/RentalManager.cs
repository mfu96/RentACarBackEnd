using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }
        //[SecuredOperation("admin,employer,editor")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int rentId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentId == rentId),
                MessagesGet.RentalDetailListed);
        }

        public IDataResult<Rental> GetLastRentalByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll().Where(rn => rn.CarId == carId).LastOrDefault());

        }

        //[SecuredOperation("admin,employer,editor")]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails(int rentId)
        {
            if (rentId == 0)
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),
               MessagesGet.RentalsDetailListed);
            }
            else
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(rn => rn.RentId == rentId), MessagesGet.RentalDetailListed);

            }

        }



        [ValidationAspect(typeof(RentalValidator))]
        // [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("IRentalService.Get")]
        //[TransactionScopeAspect]



        public IResult AddRent(Rental rental)
        {
            var result = BusinessRules.Run(CheckReturnDate(rental));

            if (result != null)
            {
                return result;
            }



            _rentalDal.Add(rental);
            return new SuccessResult(MessagesAdd.RentSuccessful);


        }
        private IResult CheckReturnDate(Rental rental)
        {

          

            //30.03.23

            var overlappingDateList = _rentalDal.GetAll(r => r.CarId == rental.CarId
                                                                       && r.RentDate < rental.ReturnDate
                                                                       && r.ReturnDate > rental.RentDate);

            if (overlappingDateList.Count() == 0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(MessagesAdd.AlreadyRented);
            }


        }

       




        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("IRentalService.Get")]
        //[TransactionScopeAspect]

        public IResult UpdateRent(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(MessagesDelete.RentUpdated);
        }

        //[SecuredOperation("admin,editor")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeleteRent(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(MessagesDelete.RentDeleted);
        }




        // [SecuredOperation("admin,employer,editor")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), MessagesGet.RentAllListed);
        }

    }
}
