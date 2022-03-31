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
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [SecuredOperation("admin,employer")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), MessagesGet.UsersListed);
        }

        
        [ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("admin,editor")]
        //[TransactionScopeAspect]
        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(MessagesAdd.UserAdded);
        }
        [SecuredOperation("admin,editor")]
        [CacheRemoveAspect("IUserService.Get")]
        //[TransactionScopeAspect]
        public IResult UpdateUser(User user)
        {
            if (user.FirstName.Length <= 2)
            {
                return new ErrorResult(MessagesUpdate.NameInvalid);
            }
            _userDal.Update(user);
            return new SuccessResult(MessagesUpdate.UserUpdated);
        }
        [SecuredOperation("admin,editor")]
        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(MessagesDelete.UserDeleted);
        }
        [SecuredOperation("admin,editor,employer")]
        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email), MessagesGet.UserListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), MessagesGet.ClaimsListed);
        }
    }
}
