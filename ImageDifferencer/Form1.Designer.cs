namespace ImageDifferencer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceImageBox1 = new System.Windows.Forms.PictureBox();
            this.sourceImageBox2 = new System.Windows.Forms.PictureBox();
            this.resultImageBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chooseImage1Btn = new System.Windows.Forms.Button();
            this.chooseImage2Btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.percentageAccuracyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fragmentNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveImgBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageAccuracyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sourceImageBox1
            // 
            this.sourceImageBox1.Location = new System.Drawing.Point(24, 20);
            this.sourceImageBox1.Name = "sourceImageBox1";
            this.sourceImageBox1.Size = new System.Drawing.Size(229, 207);
            this.sourceImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceImageBox1.TabIndex = 0;
            this.sourceImageBox1.TabStop = false;
            // 
            // sourceImageBox2
            // 
            this.sourceImageBox2.Location = new System.Drawing.Point(23, 245);
            this.sourceImageBox2.Name = "sourceImageBox2";
            this.sourceImageBox2.Size = new System.Drawing.Size(229, 200);
            this.sourceImageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceImageBox2.TabIndex = 1;
            this.sourceImageBox2.TabStop = false;
            // 
            // resultImageBox
            // 
            this.resultImageBox.Location = new System.Drawing.Point(391, 12);
            this.resultImageBox.Name = "resultImageBox";
            this.resultImageBox.Size = new System.Drawing.Size(395, 356);
            this.resultImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resultImageBox.TabIndex = 2;
            this.resultImageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Calculate difference";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chooseImage1Btn
            // 
            this.chooseImage1Btn.Location = new System.Drawing.Point(267, 57);
            this.chooseImage1Btn.Name = "chooseImage1Btn";
            this.chooseImage1Btn.Size = new System.Drawing.Size(83, 23);
            this.chooseImage1Btn.TabIndex = 4;
            this.chooseImage1Btn.Text = "Load image 1";
            this.chooseImage1Btn.UseVisualStyleBackColor = true;
            this.chooseImage1Btn.Click += new System.EventHandler(this.chooseImage1Btn_Click);
            // 
            // chooseImage2Btn
            // 
            this.chooseImage2Btn.Location = new System.Drawing.Point(267, 275);
            this.chooseImage2Btn.Name = "chooseImage2Btn";
            this.chooseImage2Btn.Size = new System.Drawing.Size(83, 23);
            this.chooseImage2Btn.TabIndex = 5;
            this.chooseImage2Btn.Text = "Load image 2";
            this.chooseImage2Btn.UseVisualStyleBackColor = true;
            this.chooseImage2Btn.Click += new System.EventHandler(this.chooseImage2Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // percentageAccuracyNumericUpDown
            // 
            this.percentageAccuracyNumericUpDown.Location = new System.Drawing.Point(497, 399);
            this.percentageAccuracyNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.percentageAccuracyNumericUpDown.Name = "percentageAccuracyNumericUpDown";
            this.percentageAccuracyNumericUpDown.Size = new System.Drawing.Size(101, 20);
            this.percentageAccuracyNumericUpDown.TabIndex = 6;
            this.percentageAccuracyNumericUpDown.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(613, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "RGB compare %";
            // 
            // fragmentNameTextBox
            // 
            this.fragmentNameTextBox.Location = new System.Drawing.Point(258, 425);
            this.fragmentNameTextBox.Name = "fragmentNameTextBox";
            this.fragmentNameTextBox.Size = new System.Drawing.Size(92, 20);
            this.fragmentNameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Fragment name";
            // 
            // saveImgBtn
            // 
            this.saveImgBtn.Location = new System.Drawing.Point(682, 373);
            this.saveImgBtn.Name = "saveImgBtn";
            this.saveImgBtn.Size = new System.Drawing.Size(75, 22);
            this.saveImgBtn.TabIndex = 12;
            this.saveImgBtn.Text = "Save image";
            this.saveImgBtn.UseVisualStyleBackColor = true;
            this.saveImgBtn.Click += new System.EventHandler(this.saveImgBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(390, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "Find image 2 on image 1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(387, 388);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 34);
            this.button3.TabIndex = 13;
            this.button3.Text = "FAST Find image 2 on image 1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.saveImgBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fragmentNameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.percentageAccuracyNumericUpDown);
            this.Controls.Add(this.chooseImage2Btn);
            this.Controls.Add(this.chooseImage1Btn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultImageBox);
            this.Controls.Add(this.sourceImageBox2);
            this.Controls.Add(this.sourceImageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.percentageAccuracyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourceImageBox1;
        private System.Windows.Forms.PictureBox sourceImageBox2;
        private System.Windows.Forms.PictureBox resultImageBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button chooseImage1Btn;
        private System.Windows.Forms.Button chooseImage2Btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown percentageAccuracyNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fragmentNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

