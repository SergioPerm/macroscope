using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageEdit {
    class Task1 {

        //пути до папок из задания
        private string pathToImg = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\images\"));
        private string pathToAnnot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\annotations\"));
        private string pathToFragments = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\"));

        public void run() {

            //see folder fragments, if no folder - create folder
           string[] dirsDest = Directory.GetDirectories(pathToFragments);

            bool folderExist = false;
            foreach (string dir in dirsDest) {

                //string dirName = Path.GetDirectoryName(dir);

                string dirName = new DirectoryInfo(dir).Name;

                if (dirName.Equals("fragments")) {
                    folderExist = true;
                    break;
                }

            }

            if (!folderExist) {
                Directory.CreateDirectory(pathToFragments + "fragments");
            }

            ////////////////////////////////////////////////////

            //get images filenames in array
            string[] dirs = Directory.GetFiles(pathToImg);
            
            foreach (string dir in dirs) {

                //create img file from path to img
                Image img = Image.FromFile(dir);

                //create array rectangles for crop images
                Rectangle[] rects = madeRect(dir);

             
                string fileNameImg = Path.GetFileNameWithoutExtension(dir);

                int n = 0;
                foreach (Rectangle rect in rects) {

                    //crop image
                    Bitmap cloned = new Bitmap(img).Clone(rect, img.PixelFormat);

                    //create image
                    Bitmap bitmap = new Bitmap(cloned, new Size(rect.Width, rect.Height));

                    //delete clon from memory
                    cloned.Dispose();

                    //save image
                    bitmap.Save(pathToFragments + "fragments\\" + fileNameImg + "_" + n + ".png", ImageFormat.Png);

                    n++;
                }

            }

        }

        private Rectangle[] madeRect(string pathImg) {

            //create file name annotation
            string fileName = Path.GetFileNameWithoutExtension(pathImg);
            fileName += ".txt";

            //create stream for read txt file
            StreamReader file = new StreamReader(pathToAnnot + fileName);

            //get count lines from txt file for out array of rects
            int countLines = File.ReadLines(pathToAnnot + fileName).Count();

            Rectangle[] rects = new Rectangle[countLines];

            //initial var for line
            string line = "";
             
            int n = 0;

            while ((line = file.ReadLine()) != null) {

                //create array with coordinates
                string[] annotations = line.Split(',');


                int x = Int32.Parse(annotations[0]);
                int y = Int32.Parse(annotations[1]);


                int width = Int32.Parse(annotations[2]) - x;
                int height = Int32.Parse(annotations[3]) - y;

               
                Rectangle rect = new Rectangle(x, y, width, height);
                rects[n] = rect;

                n++;
            }
  
            return rects;

        }

    }
}
