﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DateAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal:EfEntityRepositoryBase<CarImage,RentACarContext>,ICarImageDal
    {
    }
}
