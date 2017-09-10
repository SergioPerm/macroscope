using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEdit {
    class TaskAdd4 {

        private string pathToFragmentsGrey = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\fragments_greyscale\\"));
        private string pathToRoot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\"));

        public void run() {

            //see folder fragments_flip, if no folder - create folder
            string[] dirsDest = Directory.GetDirectories(pathToRoot);

            bool folderExist = false;
            foreach (string dir in dirsDest) {

                string dirName = Path.GetDirectoryName(dir);

                if (dirName.Equals("fragments_noise")) {
                    folderExist = true;
                    break;
                }

            }

            if (!folderExist) {
                Directory.CreateDirectory(pathToRoot + "fragments_noise");
            }

            //////////////////////////////////////////////////////////

            string[] filesFragmnts = Directory.GetFiles(pathToFragmentsGrey);

            foreach (string filePath in filesFragmnts) {

                string fileNameImg = Path.GetFileNameWithoutExtension(filePath);

                Bitmap bitmap = new Bitmap(filePath);

                Bitmap bitmapNoise = AddGaussianNoise(bitmap, 30);

                bitmapNoise.Save(pathToRoot + "fragments_noise\\" + fileNameImg + "_noise.png", ImageFormat.Png);

            }
        }

        Bitmap AddGaussianNoise(Bitmap bmp, float noisePower = 20) {
            Bitmap res = (Bitmap)bmp.Clone();
            Random rnd = new Random();

            using (ImageWrapper wrapper = new ImageWrapper(res)) {
                foreach (var pixel in wrapper) {

                    Color curColor = wrapper[pixel];
                    double noise = (rnd.NextDouble() + rnd.NextDouble() + rnd.NextDouble() + rnd.NextDouble() - 2) * noisePower;
                    wrapper.SetPixel(pixel, curColor.R + noise, curColor.G + noise, curColor.B + noise);
                }
            }

            return res;
        }


        /// Bitmap wrapper for more speed read and edit pixels
        /// Also, this class control out overflow image size, if goinf over size on read return DEfaultColor, on write ignore set pixel
        public class ImageWrapper : IDisposable, IEnumerable<Point> {

            public int Width { get; private set; }
  
            public int Height { get; private set; }

            public Color DefaultColor { get; set; }

            private byte[] data;//buffer default image
            private byte[] outData;//out buffer
            private int stride;
            private BitmapData bmpData;
            private Bitmap bmp;

            public ImageWrapper(Bitmap bmp) {
                Width = bmp.Width;
                Height = bmp.Height;
                this.bmp = bmp;

                bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                stride = bmpData.Stride;

                data = new byte[stride * Height];
                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, data.Length);

                outData = new byte[stride * Height];
            }

            /// return pixel from def image or set pixel in out buffer
            public Color this[int x, int y] {
                get {
                    int i = GetIndex(x, y);
                    return i < 0 ? DefaultColor : Color.FromArgb(data[i + 3], data[i + 2], data[i + 1], data[i]);
                }

                set {
                    var i = GetIndex(x, y);
                    if (i >= 0) {
                        outData[i] = value.B;
                        outData[i + 1] = value.G;
                        outData[i + 2] = value.R;
                        outData[i + 3] = value.A;
                    };
                }
            }

            /// return pixel from def image or set pixel in out buffer
            public Color this[Point p] {
                get { return this[p.X, p.Y]; }
                set { this[p.X, p.Y] = value; }
            }

            /// set in out buffer color value (double)
            /// allows output of value beyond 0-255
            public void SetPixel(Point p, double r, double g, double b) {
                if (r < 0) r = 0;
                if (r >= 256) r = 255;
                if (g < 0) g = 0;
                if (g >= 256) g = 255;
                if (b < 0) b = 0;
                if (b >= 256) b = 255;

                this[p.X, p.Y] = Color.FromArgb((int)r, (int)g, (int)b);
            }

            int GetIndex(int x, int y) {
                return (x < 0 || x >= Width || y < 0 || y >= Height) ? -1 : x * 4 + y * stride;
            }

            /// bitmap in output buffer
            public void Dispose() {
                System.Runtime.InteropServices.Marshal.Copy(outData, 0, bmpData.Scan0, outData.Length);
                bmp.UnlockBits(bmpData);
            }

            /// enumeration points of image
            public IEnumerator<Point> GetEnumerator() {
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                        yield return new Point(x, y);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return GetEnumerator();
            }

        }

    }
}
