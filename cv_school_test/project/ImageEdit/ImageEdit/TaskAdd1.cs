using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEdit {
    class TaskAdd1 {

        private string pathToFragments = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\fragments\"));
        private string pathToRoot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\"));

        public void run() {

            //see folder fragments_greyscale, if no folder - create folder
            string[] dirsDest = Directory.GetDirectories(pathToRoot);

            bool folderExist = false;
            foreach (string dir in dirsDest) {

                string dirName = Path.GetDirectoryName(dir);

                if (dirName.Equals("fragments_greyscale")) {
                    folderExist = true;
                    break;
                }

            }

            if (!folderExist) {
                Directory.CreateDirectory(pathToRoot + "fragments_greyscale");
            }

            ////////////////////////////////////////////////////

            string[] filesFragmnts = Directory.GetFiles(pathToFragments);

            foreach (string filePath in filesFragmnts) {

                string fileNameImg = Path.GetFileNameWithoutExtension(filePath);

                Bitmap bitmap = new Bitmap(filePath);
                Bitmap bitmapGray;
                int x, y;

                for (x = 0; x < bitmap.Width; x++) {
                    for (y = 0; y < bitmap.Height; y++) {
                        Color pixelColor = bitmap.GetPixel(x, y);

                        int grayScale = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));

                        Color newColor = Color.FromArgb(pixelColor.A, grayScale, grayScale, grayScale);
                        bitmap.SetPixel(x, y, newColor); 
                    }
                }
                bitmapGray = bitmap;  
                

                bitmapGray.Save(pathToRoot + "fragments_greyscale\\" + fileNameImg + "_grey.png", ImageFormat.Png);

                bitmap.Dispose();
                bitmapGray.Dispose();
            }

        }

    }
}
