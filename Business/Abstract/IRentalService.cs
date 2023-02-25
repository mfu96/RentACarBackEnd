using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails(int rentId);
        IDataResult<Rental> GetById(int rentId);
        IDataResult<Rental> GetLastRentalByCarId(int carId);
        IResult AddRent(Rental rental);
        IResult UpdateRent(Rental rental);
        IResult DeleteRent(Rental rental);
        //IResult CheckReturnDate(Rental rental);

    }
}
