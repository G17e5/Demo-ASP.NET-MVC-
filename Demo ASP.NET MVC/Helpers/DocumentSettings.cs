using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Demo_ASP.NET_MVC.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //  string folderPath = $"E:\COURSES\backend with route\MVC Demo\Demo ASP.NET MVC Solution\Demo ASP.NET MVC\wwwroot\Files\"\
            // string folderPath = $"Directory.GetParent()\\wwwroot\\Files\\{folderName}";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\",folderName);

            if (Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //2.get file name and make uniqe
            string fileName = $"{Guid.NewGuid()} , {Path.GetExtension(file.FileName)}";
             //3.get file path
             string filePath = Path.Combine(folderPath, fileName);
            //4.save file as streams =>> data per time
             using  var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;

        }


        public static void DeleteFile(string fileName , string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", folderName,fileName);

            if(File.Exists(filePath))
                File.Delete(filePath);

        }


    }
}
