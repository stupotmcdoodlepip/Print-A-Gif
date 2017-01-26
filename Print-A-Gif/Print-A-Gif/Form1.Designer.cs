/***************************************************************************************
* Print-A-Gif
*
*  Copyright 2017 by Stuart McConnel (stupotmcdoodlepip) <stumcconnel at gmail.com>
*
* This file is part of Print-A-Gif.
* 
* Print-A-Gif is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
* 
* Print-A-Gif is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of 
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License
* along with Print-A-Gif.  If not, see <http://www.gnu.org/licenses/>.
* 
* 
* 
***********  Licencing for ImageMagick  ************************************************
* 
* Copyright 2017 Stuart McConnel
*
*   Licensed under the ImageMagick License (the "License"); you may not use
*   this file except in compliance with the License.  You may obtain a copy
*   of the License at
*
*     https://www.imagemagick.org/script/license.php
*
*   Unless required by applicable law or agreed to in writing, software
*   distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
*   WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the
*   License for the specific language governing permissions and limitations
*   under the License. 
*   
* 
***************************************************************************************/

partial class PrintGif
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintGif));
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtInputGif = new System.Windows.Forms.TextBox();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnSelectGif = new System.Windows.Forms.Button();
            this.btnSelectOutputDir = new System.Windows.Forms.Button();
            this.nudMargin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.fbdOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdInputGif = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImgWidth = new System.Windows.Forms.TextBox();
            this.txtImgHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTabWidth = new System.Windows.Forms.NumericUpDown();
            this.nudRepeatX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudRepeatY = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCutSpacing = new System.Windows.Forms.NumericUpDown();
            this.chkUnoptimise = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCutSpacing)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(12, 81);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(420, 594);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // txtInputGif
            // 
            this.txtInputGif.Location = new System.Drawing.Point(12, 12);
            this.txtInputGif.Name = "txtInputGif";
            this.txtInputGif.Size = new System.Drawing.Size(420, 20);
            this.txtInputGif.TabIndex = 1;
            this.txtInputGif.TextChanged += new System.EventHandler(this.txtInputGif_TextChanged);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(12, 38);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(420, 20);
            this.txtOutputDir.TabIndex = 2;
            // 
            // btnSelectGif
            // 
            this.btnSelectGif.Location = new System.Drawing.Point(449, 10);
            this.btnSelectGif.Name = "btnSelectGif";
            this.btnSelectGif.Size = new System.Drawing.Size(114, 23);
            this.btnSelectGif.TabIndex = 3;
            this.btnSelectGif.Text = "Select Input GIF";
            this.btnSelectGif.UseVisualStyleBackColor = true;
            this.btnSelectGif.Click += new System.EventHandler(this.btnSelectGif_Click);
            // 
            // btnSelectOutputDir
            // 
            this.btnSelectOutputDir.Location = new System.Drawing.Point(449, 39);
            this.btnSelectOutputDir.Name = "btnSelectOutputDir";
            this.btnSelectOutputDir.Size = new System.Drawing.Size(114, 23);
            this.btnSelectOutputDir.TabIndex = 4;
            this.btnSelectOutputDir.Text = "Select Output Folder";
            this.btnSelectOutputDir.UseVisualStyleBackColor = true;
            this.btnSelectOutputDir.Click += new System.EventHandler(this.btnSelectOutputDir_Click);
            // 
            // nudMargin
            // 
            this.nudMargin.Location = new System.Drawing.Point(526, 222);
            this.nudMargin.Name = "nudMargin";
            this.nudMargin.Size = new System.Drawing.Size(64, 20);
            this.nudMargin.TabIndex = 5;
            this.nudMargin.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudMargin.ValueChanged += new System.EventHandler(this.nudMargin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Print Margin";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(616, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(97, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ofdInputGif
            // 
            this.ofdInputGif.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Image width";
            // 
            // txtImgWidth
            // 
            this.txtImgWidth.Enabled = false;
            this.txtImgWidth.Location = new System.Drawing.Point(526, 78);
            this.txtImgWidth.Name = "txtImgWidth";
            this.txtImgWidth.Size = new System.Drawing.Size(64, 20);
            this.txtImgWidth.TabIndex = 9;
            // 
            // txtImgHeight
            // 
            this.txtImgHeight.Enabled = false;
            this.txtImgHeight.Location = new System.Drawing.Point(526, 102);
            this.txtImgHeight.Name = "txtImgHeight";
            this.txtImgHeight.Size = new System.Drawing.Size(64, 20);
            this.txtImgHeight.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Image height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tab width";
            // 
            // nudTabWidth
            // 
            this.nudTabWidth.Location = new System.Drawing.Point(526, 200);
            this.nudTabWidth.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudTabWidth.Name = "nudTabWidth";
            this.nudTabWidth.Size = new System.Drawing.Size(64, 20);
            this.nudTabWidth.TabIndex = 13;
            this.nudTabWidth.ValueChanged += new System.EventHandler(this.nudTabWidth_ValueChanged);
            // 
            // nudRepeatX
            // 
            this.nudRepeatX.Location = new System.Drawing.Point(526, 138);
            this.nudRepeatX.Name = "nudRepeatX";
            this.nudRepeatX.Size = new System.Drawing.Size(64, 20);
            this.nudRepeatX.TabIndex = 15;
            this.nudRepeatX.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudRepeatX.ValueChanged += new System.EventHandler(this.nudRepeatX_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(446, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Repeat X";
            // 
            // nudRepeatY
            // 
            this.nudRepeatY.Location = new System.Drawing.Point(526, 160);
            this.nudRepeatY.Name = "nudRepeatY";
            this.nudRepeatY.Size = new System.Drawing.Size(64, 20);
            this.nudRepeatY.TabIndex = 17;
            this.nudRepeatY.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudRepeatY.ValueChanged += new System.EventHandler(this.nudRepeatY_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Repeat Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Cut spacing";
            // 
            // nudCutSpacing
            // 
            this.nudCutSpacing.Location = new System.Drawing.Point(526, 244);
            this.nudCutSpacing.Name = "nudCutSpacing";
            this.nudCutSpacing.Size = new System.Drawing.Size(64, 20);
            this.nudCutSpacing.TabIndex = 18;
            this.nudCutSpacing.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCutSpacing.ValueChanged += new System.EventHandler(this.nudCutSpacing_ValueChanged);
            // 
            // chkUnoptimise
            // 
            this.chkUnoptimise.AutoSize = true;
            this.chkUnoptimise.Location = new System.Drawing.Point(616, 40);
            this.chkUnoptimise.Name = "chkUnoptimise";
            this.chkUnoptimise.Size = new System.Drawing.Size(97, 17);
            this.chkUnoptimise.TabIndex = 21;
            this.chkUnoptimise.Text = "Unoptimise first";
            this.chkUnoptimise.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(449, 361);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 193);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // PrintGif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 687);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkUnoptimise);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudCutSpacing);
            this.Controls.Add(this.nudRepeatY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudRepeatX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudTabWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImgHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImgWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMargin);
            this.Controls.Add(this.btnSelectOutputDir);
            this.Controls.Add(this.btnSelectGif);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.txtInputGif);
            this.Controls.Add(this.picPreview);
            this.Name = "PrintGif";
            this.Text = "Print-A-Gif v1.0 by Stuart McConnel (stupotmcdoodlepip)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTabWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCutSpacing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.TextBox txtInputGif;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnSelectGif;
        private System.Windows.Forms.Button btnSelectOutputDir;
        private System.Windows.Forms.NumericUpDown nudMargin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.FolderBrowserDialog fbdOutput;
        private System.Windows.Forms.OpenFileDialog ofdInputGif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImgWidth;
        private System.Windows.Forms.TextBox txtImgHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTabWidth;
        private System.Windows.Forms.NumericUpDown nudRepeatX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudRepeatY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCutSpacing;
		private System.Windows.Forms.CheckBox chkUnoptimise;
        private System.Windows.Forms.TextBox textBox1;
}