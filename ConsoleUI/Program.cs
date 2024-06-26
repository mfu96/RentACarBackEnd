using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;



namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           //ColorTest();
           // BrandTest();
        //  CategoryTest();
            //GetCarByIdTest();
           //CustomerTest();

           //CarTestGetAll();
           // CarDetailTest();



            // UserTest();

            // RentalTest();
            var kiralamaGunu = DateTime.Now;
            var geriDon = DateTime.Now + TimeSpan.FromHours(2);
            Console.WriteLine(kiralamaGunu);
            Console.WriteLine(geriDon);

            if (kiralamaGunu<geriDon)
            {
                Console.WriteLine("kiralama günü küçük");   
            }
            else
            {
                Console.WriteLine("Geri dön küçük");
            }
        }

        private static void GetCarByIdTest()
        {
            CarManager car = new CarManager(new EfCarDal());
            var result = car.GetById(4);
            Console.WriteLine(result.Data.CarName);
        }

        private static void CarTestGetAll()
        {
            CarManager car = new CarManager(new EfCarDal());
            var resultCr = car.GetAll();
            foreach (var cars in resultCr.Data)
            {
                Console.WriteLine(cars.CarName);
            }
        }

        private static void RentalTest()
        {
            RentalManager rent = new RentalManager(new EfRentalDal());
            rent.AddRent(new Rental
            {
                CarId = 1,
                CustomerId = 17,
                ReturnDate = new DateTime(2021, 05, 12)
            });

            //rent.DeleteRent(new Rental { RentId = 10 });
            var resultRn = rent.GetAll().Data;
            foreach (var rnt in resultRn)
            {
                Console.WriteLine("Araç Id: " + rnt.CarId);
            }
        }

        private static void UserTest()
        {
            UserManager user = new UserManager(new EfUserDal());

            //user.AddUser(new User { FirstName = " FUrkan", LastName = "USLU", Email = "222@ww.com", Password = "qwert", });
            //user.AddUser(new User { FirstName = " Şinasi", LastName = "Yanbakan", Email = "333@ww.com", Password = "qwert", });


            var resultUsr = user.GetAll();
            foreach (var users in resultUsr.Data)
            {
                Console.WriteLine(users.UserId + "/" + users.FirstName + " " + users.LastName);
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customer = new CustomerManager(new EfCustomerDal());
            customer.AddCustomer(new Customer { CompanyName = "Doktorundan Kiralık A.Ş." });
            customer.AddCustomer(new Customer { CompanyName = "Merdiven Altından Global'a A.Ş." });
            //customer.DeleteCustomer(new Customer { CustomerId = 5 });


            var resultCos = customer.GetCustomerDetail();
            foreach (var cos in resultCos.Data)
            {
                Console.WriteLine(cos.CompanyName + "/" + cos.Email);
            }
        }

        private static void BrandTest()
        {
            BrandManager brand = new BrandManager(new EfBrandDal());
            brand.AddBrand(new Brand { BrandName = "Renault" });
            brand.AddBrand(new Brand { BrandName = "Hyundai" });
            brand.AddBrand(new Brand { BrandName = "Ford" });
            brand.AddBrand(new Brand { BrandName = "Opel" });
            brand.AddBrand(new Brand { BrandName = "Fiat" });
            brand.AddBrand(new Brand { BrandName = "Peugeot" });
            brand.AddBrand(new Brand { BrandName = "Toyota" });
            brand.AddBrand(new Brand { BrandName = "Volkswagen" });
            brand.AddBrand(new Brand { BrandName = "Bmw" });
            brand.AddBrand(new Brand { BrandName = "Tata" });

            ////brand.DeleteBrand(new Brand{BrandId = 3});


            var resultBr = brand.GetAll();
            foreach (var br in resultBr.Data)
            {
                Console.WriteLine(br.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager color = new ColorManager(new EfColorDal());
            color.AddColor(new Color { ColorName = "Beyaz" });
            color.AddColor(new Color { ColorName = "Siyah" });
            color.AddColor(new Color { ColorName = "Gri" });
            color.AddColor(new Color { ColorName = "Gümüş" });
            color.AddColor(new Color { ColorName = "Kırmızı" });
            color.AddColor(new Color { ColorName = "Mavi" });

            ////color.DeleteColor(new Color{ColorId = 2});
            var resultCl = color.GetAll();
            foreach (var cl in resultCl.Data)
            {
                Console.WriteLine(cl.ColorName);
            }
        }



        //private static CarManager CarDetailTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.AddCar(new Car { BrandId = 1, ColorId = 3, CategoryId = 3, CarName = "Opel", UnitPrice = 350, Description = "Afilli mi acep?", ModelYear = 2021 });
        //    carManager.AddCar(new Car { BrandId = 7, ColorId = 9, CategoryId = 9, CarName = "Mercedes", UnitPrice = 350, Description = "Afilli", ModelYear = 2021 });
        //    carManager.AddCar(new Car { BrandId = 1, ColorId = 3, CategoryId = 3, CarName = "Renault", UnitPrice = 150, Description = "Tam Şirket arabası", ModelYear = 2020 });
        //    carManager.AddCar(new Car { BrandId = 5, ColorId = 3, CategoryId = 5, CarName = "Tata", UnitPrice = 150, Description = "Tam Şirket arabası", ModelYear = 2020 });

        //    ////carManager.DeleteCar(new Car { Id = 2 });

        //    //Console.WriteLine("--Araç ismi--");

        //    var resultCar = carManager.GetCarDetails();

        //    if (resultCar.Success == true)
        //    {
        //        foreach (var car in resultCar.Data)
        //        {
        //            Console.WriteLine(car.CarName + "---" + car.ColorName + "---" + car.BrandName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(resultCar.Message);
        //    }


        //    return carManager;




        //}

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            categoryManager.AddCategory(new Category { CategoryName = "Mini" });
            categoryManager.AddCategory(new Category { CategoryName = "Mini" });
            categoryManager.AddCategory(new Category { CategoryName = "Ekonomi" });
            categoryManager.AddCategory(new Category { CategoryName = "Kompakt" });
            categoryManager.AddCategory(new Category { CategoryName = "Orta Sınıf" });
            categoryManager.AddCategory(new Category { CategoryName = "SUV" });
            categoryManager.AddCategory(new Category { CategoryName = "Minibüs/Van" });
            categoryManager.AddCategory(new Category { CategoryName = "Lüks" });
            categoryManager.AddCategory(new Category { CategoryName = "Cabrio" });

            ////categoryManager.DeleteCategory(new Category{CategoryId = 6});

            var resultCt = categoryManager.GetAll();


            foreach (var category in resultCt.Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
