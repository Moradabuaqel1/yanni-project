using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ImageHandle
    {

        public ImageHandle()
        { }

        public string TargetPath()
        {
            string currentDir = (System.AppDomain.CurrentDomain.BaseDirectory);//Environment.CurrentDirectory;
            string[] dirStr = currentDir.Split('\\');

            int index = dirStr.Length - 3;
            dirStr[index] = "ViewModel";
            Array.Resize(ref dirStr, index + 1);
            string pathStr = String.Join("\\", dirStr);
            return pathStr + "\\Images\\";
        }
        public byte[] GetImageByByte(string imgName)
        {
            string ServerMapPath = TargetPath();
            string imagePath = Path.Combine(ServerMapPath, imgName);

            if (File.Exists(imagePath))
                return File.ReadAllBytes(imagePath);

            return null;
        }
        // end of GetImageByByte

        public string GetServerImage(string imgName)
        {
            string imgRef = "";
            byte[] imageData = GetImageByByte(imgName);
            if (imageData != null)
            {
                string base64String = Convert.ToBase64String(imageData);
                imgRef = "data:image/jpeg;base64," + base64String;
            }
            return imgRef;
        }
        // end of GetServerImage

    
}
}
