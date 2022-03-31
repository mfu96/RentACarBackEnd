using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService

    {
       ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }
        [CacheAspect]
       // [SecuredOperation("admin,employer")]
       public IDataResult<List<Customer>> GetAll()
       {
           
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),MessagesGet.CustomersListed);
       }
        [SecuredOperation("admin,editor,employer")]
        [CacheAspect]
        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(cs => cs.CustomerId == customerId));
        }

        //[SecuredOperation("admin,editor,employer")]
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(),MessagesGet.CustomerDetailListed);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICustomerService.Get")]
      //  [TransactionScopeAspect]

        public IResult AddCustomer(Customer customer)
        {
          
            
            _customerDal.Add(customer);
            return new SuccessResult(MessagesAdd.CustomerAdded);
        }
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICustomerService.Get")]
       // [TransactionScopeAspect]

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(MessagesUpdate.CustomerUpdate);
        }
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(MessagesDelete.CustomerDeleted);
        }
    }
}
