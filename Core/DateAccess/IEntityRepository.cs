using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DateAccess
{
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetById(Expression<Func<T,bool>> filter=null);
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);  //GetAllByDailyPrice yerine bu gelmiştir
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       // List<Car> GetAllByDailyPrice(decimal dailyPriceDecimal);
    }
}
