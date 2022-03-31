using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
  public  static class MessagesAuth
  {
      public static string UserNotFound = "Kullnıcı bulunamadı";
      public static string PasswordError = "Parolo hatalı!";
      public static string SuccessfulLogin = "Giriş Başarılı";
      public static string UserAlreadyExists = "Bu adda bir kullanıcı zaten var";
      public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
      public static string AccessTokenCreated = "Giriş anahtarı başarıyla oluşturuldu";
      public static string AuthorizationDenied = "Haddini bil! Burdan sonrası seni aşar RentACar";
    }
}
