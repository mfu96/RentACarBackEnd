using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {

                //Burada belirtilen geçici isimmler p veya başka bi şey olabilir
                //fakat her geçici isim aslında entity altında bir class'a 
                // işaret ettiği için isimlendirmeyi tam vermeyi tercih ediyorum.
                var result = from p in context.Cars
                             join c in context.Categories
                                 on p.CategoryId equals c.CategoryId
                             join cl in context.Colors
                                on p.ColorId equals cl.ColorId
                             join b in context.Brands
                                  on p.BrandId equals b.BrandId
                             join cus in context.Customers
                                 on p.UserId equals cus.UserId



                             select new CarDetailDto
                             {
                                 //Sol taraftaki CarDetailDto daki nesneler sağ taraftaki DB deki
                                 CarId = p.CarId,
                                 CategoryName = c.CategoryName,
                                 CarName = p.CarName,
                                 UnitPrice = p.UnitPrice,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 UnitsInStock = p.UnitsInStock,
                                 CompanyName = cus.CompanyName,
                                 ImagePaths = (from img in context.CarImages
                                               where img.CarId == p.CarId
                                               select new CarImage
                                               {
                                                   ImageId = img.ImageId,
                                                   CarId = img.CarId,
                                                   ImagePath = img.ImagePath,
                                                   ImageDate = img.ImageDate
                                               }).ToList()

                             };
                
                
                //return result.ToList();   //120624 color ve brand filtresi için değişklik

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<CarDetailDto> GetByCarDetailId(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {

                //Burada belirtilen geçici isimmler p veya başka bi şey olabilir
                //fakat her geçici isim aslında entity altında bir class'a 
                // işaret ettiği için isimlendirmeyi tam vermeyi tercih ediyorum.

                var result = from car in context.Cars.Where(c=>c.CarId==carId)
                             join category in context.Categories
                                 on car.CategoryId equals category.CategoryId
                             join color in context.Colors
                                on car.ColorId equals color.ColorId
                             join brand in context.Brands
                                  on car.BrandId equals brand.BrandId
                             join cus in context.Customers
                                 on car.UserId equals cus.UserId


                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 CategoryName = category.CategoryName,
                                 CarName = car.CarName,
                                 UnitPrice = car.UnitPrice,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 UnitsInStock = car.UnitsInStock,
                                 CompanyName = cus.CompanyName,
                                 ImagePaths = (from carImage in context.CarImages
                                               where carImage.CarId == car.CarId
                                               select new CarImage
                                               {
                                                   ImageId = carImage.ImageId,
                                                   CarId = carImage.CarId,
                                                   ImagePath = carImage.ImagePath,
                                                   ImageDate = carImage.ImageDate
                                               }).ToList()

                             };
                return result.ToList();
            }
        }
    }
}
