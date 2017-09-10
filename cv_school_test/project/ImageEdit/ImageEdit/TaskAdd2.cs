
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEdit {
    class TaskAdd2 {

        private string pathToFragments = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\fragments_greyscale\"));
        private string pathToRoot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @".\"));

        public void run() {

            //see folder fragments_flip, if no folder - create folder
            string[] dirsDest = Directory.GetDirectories(pathToRoot);

            bool folderExist = false;
            foreach (string dir in dirsDest) {

                string dirName = Path.GetDirectoryName(dir);

                if (dirName.Equals("fragments_flip")) {
                    folderExist = true;
                    break;
                }

            }

            if (!folderExist) {
                Directory.CreateDirectory(pathToRoot + "fragments_flip");
            }

            ////////////////////////////////////////////////////

            string[] filesFragmnts = Directory.GetFiles(pathToFragments);

            foreach (string filePath in filesFragmnts) {

                string fileNameImg = Path.GetFileNameWithoutExtension(filePath);

                Bitmap bitmap = new Bitmap(filePath);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);

                bitmap.Save(pathToRoot + "fragments_flip\\" + fileNameImg + "_flip.png", ImageFormat.Png);

            }

        }

    }
}
