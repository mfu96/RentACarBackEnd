using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    //public static class FileHelper
    //{


    //    public static string DefaultImagePath = Directory.GetCurrentDirectory() + @"\upload_images\no-image.jpg";
    //    public static string UploadImagePath = Directory.GetCurrentDirectory() + @"\upload_images";


    //    public static string CreatePath(IFormFile file)
    //    {

    //        FileInfo fileInfo = new FileInfo(file.FileName);

    //        string path = Path.Combine(UploadImagePath);
    //        string fileExtension = fileInfo.Extension;
    //        string uniqueFilename = Guid.NewGuid().ToString() + fileExtension;
    //        string result = $@"{path}\{uniqueFilename}";

    //        return result;

    //    }


    //    public static string AddFile(IFormFile file)
    //    {

    //        string result;

    //        try
    //        {
    //            if (file == null)
    //            {
    //                result = DefaultImagePath;

    //                return result;
    //            }
    //            else
    //            {
    //                result = CreatePath(file);

    //                var sourcePath = Path.GetTempFileName();

    //                using (var stream = new FileStream(sourcePath, FileMode.Create))
    //                {
    //                    file.CopyTo(stream);
    //                }

    //                File.Move(sourcePath, result);

    //                return result;
    //            }
    //        }
    //        catch (Exception exception)
    //        {
    //            return exception.Message;
    //        }

    //    }


    //    public static string DeleteFile(string imagePath)
    //    {

    //        try
    //        {
    //            File.Delete(imagePath);

    //            return "Deleted";
    //        }
    //        catch (Exception exception)
    //        {
    //            return exception.Message;
    //        }

    //    }


    //    public static string UpdateFile(IFormFile file, string oldImagePath)
    //    {

    //        string result;

    //        try
    //        {
    //            if (file == null)
    //            {
    //                File.Delete(oldImagePath);

    //                result = DefaultImagePath;

    //                return result;
    //            }
    //            else
    //            {
    //                result = CreatePath(file);

    //                var sourcePath = Path.GetTempFileName();

    //                using (var stream = new FileStream(sourcePath, FileMode.Create))
    //                {
    //                    file.CopyTo(stream);
    //                }

    //                File.Move(sourcePath, result);

    //                File.Delete(oldImagePath);

    //                return result;
    //            }
    //        }
    //        catch (Exception exception)
    //        {
    //            return exception.Message;
    //        }

    //    }


    //}

    public class FileHelper
    {
        public static string AddFile(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);
                File.Move(sourcePath, result.newPath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static string UpdateFile(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static IResult DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = Guid.NewGuid() + fileExtension;


            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";

            string result = $@"{path}\{newPath}";

            return (result, $"\\uploads\\{newPath}");
        }
    }
}
