using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }


        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult AddCard(CreditCard creditCard)

        {
            //ValidationTool.Validate(new CardValidator(), creditCard);
            var result = BusinessRules.Run(IsCardExist(creditCard));

            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult(MessagesAdd.CardAdded);
        }

        private IResult IsCardExist(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(cr =>
                cr.CardNumber == creditCard.CardNumber
                && cr.CVV == creditCard.CVV);
            if (result != null)
            {
                return new ErrorResult(MessagesAdd.CardExist);
            }

            return new SuccessResult();
        }

        [CacheRemoveAspect("ICreditCardService.Get")]

        public IResult UpdateCard(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICreditCardService.Get")]

        public IResult DeleteCard(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCustomer(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(cs => cs.CustomerId == customerId));

        }
    }
}
