using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEdit {
    public partial class Form1 : Form {

        private bool TaskFinish = false;
        private bool TaskAdd1Finish = false;
        private bool TaskAdd2Finish = false;
        private bool TaskAdd3Finish = false;
        private bool TaskAdd4Finish = false;

        private bool closeApp = false;

        public Form1() {
            InitializeComponent();

            //string pathToRoot = Path.GetFullPath(Path.Combine(@Directory.GetCurrentDirectory(), @"..\\.\\"));

            //string[] dirsDest = Directory.GetDirectories(pathToRoot);

            //bool folderExist = false;
            //foreach (string dir in dirsDest) {

            //    string dirName = Path.GetDirectoryName(dir);

            //    if (dirName.Equals("cv_school_test")) {
            //        folderExist = true;
            //        break;
            //    }

            //}

            //if (!folderExist) {
            //    string message = "Исполняемый файл должен находится в папке cv_school_test";
            //    string caption = "ВНИМАНИЕ!";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;

            //    DialogResult result;

            //    result = MessageBox.Show(message, caption, buttons);

            //    if (result == System.Windows.Forms.DialogResult.OK) {
            //        closeApp = true;
            //    }
            //}

        }

        private void updateBtnsView() {

            btnRunTaskAdd1.Enabled = TaskFinish;
            btnRunTaskAdd2.Enabled = TaskAdd1Finish;
            btnRunTaskAdd3.Enabled = TaskAdd2Finish;
            btnRunTaskAdd4.Enabled = TaskAdd3Finish;

        }

        private void button2_Click(object sender, EventArgs e) {

            TaskAdd1 myTaskAdd1 = new TaskAdd1();
            myTaskAdd1.run();

            TaskAdd1Finish = true;
            updateBtnsView();

        }

        private void Form1_Load(object sender, EventArgs e) {
            if (closeApp)
                Application.Exit();
        }

        private void btnRunTask1_Click(object sender, EventArgs e) {

            Task1 myTask = new Task1();
            myTask.run();

            TaskFinish = true;
            updateBtnsView();

        }

        private void button1_Click_1(object sender, EventArgs e) {


            TaskAdd2 myTaskAdd2 = new TaskAdd2();
            myTaskAdd2.run();

            TaskAdd2Finish = true;
            updateBtnsView();

        }

        private void button2_Click_1(object sender, EventArgs e) {

            TaskAdd3 myTaskAdd3 = new TaskAdd3();
            myTaskAdd3.run();

            TaskAdd3Finish = true;
            updateBtnsView();

        }

        private void button3_Click(object sender, EventArgs e) {

            TaskAdd4 myTaskAdd4 = new TaskAdd4();
            myTaskAdd4.run();

            TaskAdd4Finish = true;
            updateBtnsView();

            labelDone.Visible = true;

        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
