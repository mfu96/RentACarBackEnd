using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal /* :ICarDal*/
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1,BrandId = 1,ColorId = 3,UnitPrice = 200,ModelYear = 2015,Description = "Az yakar çok kaçar"},
                new Car{CarId = 2,BrandId = 1,ColorId = 3,UnitPrice = 200,ModelYear = 2015,Description = "Az yakar çok kaçar"},
                new Car{CarId = 3,BrandId = 4,ColorId = 10,UnitPrice = 400,ModelYear = 2020,Description = "Havan yoksa bu sana katar(Ancak acizler için)"},

            };
        }
        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }


        public List<Car> GetById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(uCar => uCar.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.UnitPrice = car.UnitPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(cDelete => cDelete.CarId == car.CarId);
            _cars.Remove(carToDelete);


        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByDailyPrice(decimal dailyPriceDecimal)
        {
            return _cars.Where(c => c.UnitPrice == dailyPriceDecimal).ToList();


        }
    }
}
