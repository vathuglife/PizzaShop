using DaoVietAnh.Asm2.Repo.Constants;
using DaoVietAnh.Asm2.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DaoVietAnh.Asm2.Repo.Utils
{
    public static class ImageUtils
    {
        public static string GetBase64ImageFromByteArray(byte[] byteArrayImage)
        {
            
            string? base64Img = "";
            if (byteArrayImage == null) return base64Img;            
            base64Img = "data:image/jpg;base64," + Convert.ToBase64String(byteArrayImage);            
            return base64Img;
        }
        public static byte[] ConvertImageStringToByteArray(string image)
        {
            string convertedImageString = TryRemoveMetadataFromString(image);
            return Convert.FromBase64String(convertedImageString);
        }

        private static string TryRemoveMetadataFromString(string originalString)
        {
            foreach(string extension in ImageExtensions.Extensions) {
                string testString = originalString
                    .Replace($"data:image/{extension};base64,", string.Empty);
                if (testString != originalString) return testString;
            }
            return originalString;
            

        }
    }
}
