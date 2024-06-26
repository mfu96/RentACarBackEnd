using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult AddCard(CreditCard creditCard);
        IResult UpdateCard(CreditCard creditCard);
        IResult DeleteCard(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetByCustomer(int customerId);

    }
}
