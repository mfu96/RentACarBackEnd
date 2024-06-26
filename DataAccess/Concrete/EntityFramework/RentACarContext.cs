using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true");
            //local bir server kullmırsam yukrdaki gibi bulut bir server kullanırsam ise aşağıdaki
            //gibi biz dizilim olması gerekli
            /*optionsBuilder.UseSqlServer(@"Server=mfu.database.windows.net;Database=RentACar;uid=kul;pwd=Rahman99.");*/

            optionsBuilder.UseSqlServer(@"Server=10.20.30.15;Database=RentACar;uid=mfu;pwd=1q2w3");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        //22.04.2021
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        //28.08.2021
        
        public DbSet<CarImage> CarImages { get; set; }

        //22.11.2021

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        //20.05.2023

        public  DbSet<CreditCard> CreditCards { get; set; }

        




        //Gerçek hayatta bizim şuan verdiğimiz gibi veritabanı ile class'larımız uyuşmayabliyor(Renk(local) Colors(veritabanı))
        //yahut farklı varyasyonlar. Bu gibi durumlarda yapıyı bozmak, class isimlerini kötü vermek yerine
        //framwork'ün bir methodu var (OnModelCreating) Aşığdaki ki gibi yazılır 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Renk>().ToTable("Colors")
        //modelBuilder.Entity<Renk>().property(p=>p.Id).HasColumnName("ColorId")
        //modelBuilder.Entity<Renk>().property(p=>p.Isim).HasColumnName("ColorName")
        //}
        //public DbSet<Renk> Renks { get; set; }
    }
}
