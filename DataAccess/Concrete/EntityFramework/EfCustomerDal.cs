using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from c in context.Customers
                    join usr in context.Users on c.UserId equals usr.UserId
                    select new CustomerDetailDto()
                    {
                        CompanyName = c.CompanyName,
                        CustomerId = c.CustomerId,
                        UserId = usr.UserId,
                        Email = usr.Email,
                        FirstName = usr.FirstName,
                        LastName = usr.LastName
                    };
                return result.ToList();
            }
        }
    }
}
