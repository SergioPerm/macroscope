using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEdit {
    class TaskAdd3 {

        private string pathToFragments = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\fragments_flip\"));
        private string pathToRoot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\"));

        public void run() {

            //see folder fragments_flip, if no folder - create folder
            string[] dirsDest = Directory.GetDirectories(pathToRoot);

            bool folderExist = false;
            foreach (string dir in dirsDest) {

                string dirName = Path.GetDirectoryName(dir);

                if (dirName.Equals("fragments_normalize")) {
                    folderExist = true;
                    break;
                }

            }

            if (!folderExist) {
                Directory.CreateDirectory(pathToRoot + "fragments_normalize");
            }

            //////////////////////////////////////////////////////////

            string[] filesFragmnts = Directory.GetFiles(pathToFragments);

            foreach (string filePath in filesFragmnts) {

                string fileNameImg = Path.GetFileNameWithoutExtension(filePath);

                Bitmap bitmap = new Bitmap(filePath);

                Bitmap normBitmap = NormalizeImageBrightness(bitmap);
                normBitmap.Save(pathToRoot + "fragments_normalize\\" + fileNameImg + "_normal.png", ImageFormat.Png);

                bitmap.Dispose();
                
            }

        }

        public Bitmap NormalizeImageBrightness(Bitmap image) {

            float minBrightness = 1;
            float maxBrightness = 0;

            for (int x = 0; x < image.Width; x++) {
                for (int y = 0; y < image.Height; y++) {

                    float pixelBrightness = image.GetPixel(x, y).GetBrightness();

                    minBrightness = Math.Min(minBrightness, pixelBrightness);
                    maxBrightness = Math.Max(maxBrightness, pixelBrightness);

                }
            }

            /* Normalize the image brightness. */
            for (int x = 0; x < image.Width; x++) {

                for (int y = 0; y < image.Height; y++) {

                    Color pixelColor = image.GetPixel(x, y);

                    float normBr = (pixelColor.GetBrightness() - minBrightness) / (maxBrightness - minBrightness);

                    float factor = 0f;
                    if (normBr > pixelColor.GetBrightness()) {
                        factor = normBr / pixelColor.GetBrightness();
                    } else {
                        factor = pixelColor.GetBrightness() / normBr;
                    }

                    Color normColor = Color.FromArgb((byte)(factor * pixelColor.R), (byte)(factor * pixelColor.G), (byte)(factor * pixelColor.B));
                    
                    image.SetPixel(x, y, normColor);

                }
            }
            
            return image;

        }
    }
}

