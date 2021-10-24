using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace RestaurantManagement.Helpers
{
    public static class FileSave
    {
        public static string SaveFile(out string fileName, IFormFile file, string localPath)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" , ".pdf"};
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine(localPath, DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveHRManualAttachment(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine("HRManualAttachment", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveEmpAttachment(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine("EmployeeCV", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload file";
            }
            return message;
        }
        public static string SaveImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("EmpImages", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        } 
        
        public static string SaveFoodImage(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine("FoodImages", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }
        public static string SaveEmpCV(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine(DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EmployeeCV", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveEmpAttachmentNew(out string fileName, IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            string message = "success";

            var extention = Path.GetExtension(file.FileName);
            if (file.Length > 2000000)
                message = "Select jpg or jpeg or png or pdf less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png or pdf";

            fileName = Path.Combine(DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EmpAttachment", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

   
        public static string SaveImageNew(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine(DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EmpImages", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }
        public static string SaveImageDiscipline(out string fileName, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";

            var extention = Path.GetExtension(img.FileName);
            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            fileName = Path.Combine(DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DisciplineImg", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }
            return message;
        }

        public static string SaveImageWithLoacation(out string fileName, string filePath, IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            string message = "success";
            var extention = Path.GetExtension(img.FileName);
            fileName = Path.Combine(filePath, DateTime.Now.Ticks + extention);

            if (img.Length > 2000000)
                return "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                return "Must be jpg or jpeg or png";


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
            }
            catch
            {
                return "can not upload image";
            }
            return message;
        }
    }
}
