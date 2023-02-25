using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context =new RentACarContext())
            {
                var result = from rn in filter == null ? context.Rentals: context.Rentals.Where(filter)
                    join cos in context.Customers on rn.CustomerId equals cos.CustomerId
                    join cr in context.Cars on rn.CarId equals cr.CarId



                    select new RentalDetailDto()
                    {
                        RentId = rn.RentId,
                        CompanyName = cos.CompanyName,
                        RentDate = rn.RentDate,
                        ReturnDate = rn.ReturnDate,
                        CarName = cr.CarName,
                        UnitPrice = cr.UnitPrice
                    };
                return result.ToList();
            }
        }
    }
}
