namespace ImageEdit {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.btnRunTask1 = new System.Windows.Forms.Button();
            this.btnRunTaskAdd1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunTaskAdd4 = new System.Windows.Forms.Button();
            this.btnRunTaskAdd3 = new System.Windows.Forms.Button();
            this.btnRunTaskAdd2 = new System.Windows.Forms.Button();
            this.labelDone = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunTask1
            // 
            this.btnRunTask1.Location = new System.Drawing.Point(12, 12);
            this.btnRunTask1.Name = "btnRunTask1";
            this.btnRunTask1.Size = new System.Drawing.Size(282, 43);
            this.btnRunTask1.TabIndex = 0;
            this.btnRunTask1.Text = "Запуск основного задания";
            this.btnRunTask1.UseVisualStyleBackColor = true;
            this.btnRunTask1.Click += new System.EventHandler(this.btnRunTask1_Click);
            // 
            // btnRunTaskAdd1
            // 
            this.btnRunTaskAdd1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnRunTaskAdd1.Enabled = false;
            this.btnRunTaskAdd1.Location = new System.Drawing.Point(6, 19);
            this.btnRunTaskAdd1.Name = "btnRunTaskAdd1";
            this.btnRunTaskAdd1.Size = new System.Drawing.Size(270, 29);
            this.btnRunTaskAdd1.TabIndex = 1;
            this.btnRunTaskAdd1.Text = "Дополнительное задание №1 (Greyscale)";
            this.btnRunTaskAdd1.UseVisualStyleBackColor = true;
            this.btnRunTaskAdd1.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelDone);
            this.groupBox1.Controls.Add(this.btnRunTaskAdd4);
            this.groupBox1.Controls.Add(this.btnRunTaskAdd3);
            this.groupBox1.Controls.Add(this.btnRunTaskAdd2);
            this.groupBox1.Controls.Add(this.btnRunTaskAdd1);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 184);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дополнительные задания";
            // 
            // btnRunTaskAdd4
            // 
            this.btnRunTaskAdd4.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnRunTaskAdd4.Enabled = false;
            this.btnRunTaskAdd4.Location = new System.Drawing.Point(6, 124);
            this.btnRunTaskAdd4.Name = "btnRunTaskAdd4";
            this.btnRunTaskAdd4.Size = new System.Drawing.Size(270, 29);
            this.btnRunTaskAdd4.TabIndex = 4;
            this.btnRunTaskAdd4.Text = "Дополнительное задание №4 (Noise)";
            this.btnRunTaskAdd4.UseVisualStyleBackColor = true;
            this.btnRunTaskAdd4.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnRunTaskAdd3
            // 
            this.btnRunTaskAdd3.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnRunTaskAdd3.Enabled = false;
            this.btnRunTaskAdd3.Location = new System.Drawing.Point(6, 89);
            this.btnRunTaskAdd3.Name = "btnRunTaskAdd3";
            this.btnRunTaskAdd3.Size = new System.Drawing.Size(270, 29);
            this.btnRunTaskAdd3.TabIndex = 3;
            this.btnRunTaskAdd3.Text = "Дополнительное задание №3 (Normalization)";
            this.btnRunTaskAdd3.UseVisualStyleBackColor = true;
            this.btnRunTaskAdd3.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnRunTaskAdd2
            // 
            this.btnRunTaskAdd2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnRunTaskAdd2.Enabled = false;
            this.btnRunTaskAdd2.Location = new System.Drawing.Point(6, 54);
            this.btnRunTaskAdd2.Name = "btnRunTaskAdd2";
            this.btnRunTaskAdd2.Size = new System.Drawing.Size(270, 29);
            this.btnRunTaskAdd2.TabIndex = 2;
            this.btnRunTaskAdd2.Text = "Дополнительное задание №2 (flip)";
            this.btnRunTaskAdd2.UseVisualStyleBackColor = true;
            this.btnRunTaskAdd2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelDone
            // 
            this.labelDone.AutoSize = true;
            this.labelDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelDone.Location = new System.Drawing.Point(113, 165);
            this.labelDone.Name = "labelDone";
            this.labelDone.Size = new System.Drawing.Size(55, 16);
            this.labelDone.TabIndex = 5;
            this.labelDone.Text = "DONE!";
            this.labelDone.Visible = false;
            this.labelDone.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 252);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRunTask1);
            this.Name = "Form1";
            this.Text = "Задание для Macroscope";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunTask1;
        private System.Windows.Forms.Button btnRunTaskAdd1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRunTaskAdd4;
        private System.Windows.Forms.Button btnRunTaskAdd3;
        private System.Windows.Forms.Button btnRunTaskAdd2;
        private System.Windows.Forms.Label labelDone;
    }
}

