using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
  public  class AuthManager:IAuthService
  {
      private IUserService _userService;
      private ITokenHelper _tokenHelper;


      public AuthManager(IUserService userService, ITokenHelper tokenHelper)
      {
          _userService = userService;
          _tokenHelper = tokenHelper;
      }

      [TransactionScopeAspect]
      public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
      {
          byte[] passwordHash, passwordSalt;
          HashingHelper.CreatePasswordHash(password,out passwordHash,out passwordSalt );
          var user = new User
          {
              Email = userForRegisterDto.Email,
              FirstName = userForRegisterDto.FirstName,
              LastName = userForRegisterDto.LastName,
              PasswordHash = passwordHash,
              PasswordSalt = passwordSalt,
              Status = true
          };
          _userService.AddUser(user);
          return new SuccessDataResult<User>(user, MessagesAuth.UserRegistered);


      }

      [CacheRemoveAspect("IUserService.Get")]       //Kullanıcı ekledikten sonra projeyi kapatıp açmadan kullanıcı login olamaz Cache'den silmezsen
      public IDataResult<User> Login(UserForLoginDto userForLoginDto)
      {
          var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
          if (userToCheck==null)
          {
              return new ErrorDataResult<User>(MessagesAuth.UserNotFound);
          }
            //Normalde Kullanıcı bulunamadı veya şifre bulunmadaı gibi hatalar direkt çıkmaması gerekir
            //fakat burası back-and olduğu için veritabanında ne oluyor direkt görmem lazım
            //Arayüz tarafında - yani dışarıya açık kısımda gerekli hata mesajlarının düznlenemesi gerekir


           
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(MessagesAuth.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck);
      }

        public IResult UserExists(string email)
      {
          if (_userService.GetByMail(email).Data!=null)
          {
              return new ErrorResult(MessagesAuth.UserAlreadyExists);
          }
          return new SuccessResult();

      }

      public IDataResult<AccessToken> CreateAccessToken(User user)
      {
          var claims = _userService.GetClaims(user);
          var accessToken = _tokenHelper.CreateToken(user,claims.Data);
          return new SuccessDataResult<AccessToken>(accessToken, MessagesAuth.AccessTokenCreated);
      }
  }
}
