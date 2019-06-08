using System;
using System.Drawing;
using System.IO;

namespace Oyku
{
    public class ImageProcess
    {
        public void SaveCentered(Image file, int width, int height, string fileName, string filePath)
        {
            Image picture = file;

            var ratioX = (double)width / picture.Width;
            var ratioY = (double)height / picture.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(picture.Width * ratio);
            var newHeight = (int)(picture.Height * ratio);

            Bitmap b = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(b).DrawImage(picture, 0, 0, newWidth, newHeight);

            int x = 0;
            int y = 0;
            if (newWidth == width)
            {
                int ff = (height - newHeight) / 2;
                y = ff;
            }

            if (newHeight == height)
            {
                int ff = (width - newWidth) / 2;
                x = ff;
            }

            if (newWidth < width)
            {
                y = (height - newHeight) / 2;
                x = (width - newWidth) / 2;
            }

            Image img = new Bitmap(width, height);
            Graphics g2 = Graphics.FromImage(img);
            g2.Clear(Color.White);
            g2.DrawImage(b, new Point(x, y));

            //path kontrolü yapıyoruz varsa sorun yok eğer yoksa açıyoruz
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            // path ve image adını birleştiriyoruz
            string savePath = Path.Combine(filePath, fileName);
            img.Save(savePath);
            //img.Save(HttpContext.Current.Server.MapPath(fileName), ImageFormat.Jpeg);
            img.Dispose();
        }
    }
}