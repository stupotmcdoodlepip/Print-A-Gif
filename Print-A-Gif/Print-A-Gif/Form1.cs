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
* 
* History:
* 2017/01/21 - v1.0
*  - First public release 
* 
* 
***************************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public partial class PrintGif : Form
{
	private string _inDir = Path.Combine(Environment.CurrentDirectory, "input");
	private string _outDir = Path.Combine(Environment.CurrentDirectory, "output");
	private string _currentPreviewImg = string.Empty;
	private bool _suppressEvents;
        
	public PrintGif()
	{
		InitializeComponent();
	}

		
	/// <summary>
	/// Order of operations:
	/// Take first frame as soon as gif is selected and analyse size
	/// Allow user to adjust size of binding tab and to tile frames with print preview
	/// (User can modify dimensions of gif, preserving aspect ratio)		
	/// Offer user option for binding tab colour?
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
		
	private void Form1_Load(object sender, EventArgs e)
	{
		_suppressEvents = true;

		txtInputGif.Text = _inDir;
		txtOutputDir.Text = _outDir;

		_suppressEvents = false;

		if (!Directory.Exists(_inDir))
		Directory.CreateDirectory(_inDir);
		if (!Directory.Exists(_outDir))
		Directory.CreateDirectory(_outDir);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	private bool execute(string args)
	{
		var start = new ProcessStartInfo
		{
			Arguments = args,
			FileName = @"magick.exe",
			WindowStyle = ProcessWindowStyle.Hidden,
			CreateNoWindow = true
		};
		// don't show console window
		int exitCode;

		// Run the external process & wait for it to finish
		using (var proc = Process.Start(start))
		{
			proc.WaitForExit();

			// Retrieve the app's exit code
			exitCode = proc.ExitCode;
		}

		return exitCode == 0;
	}

	/// <summary>
	/// Show a preview of an example print page with tiled images.
	/// Note that only first frame is repeated in montage
	/// </summary>
	private void previewMontage()
	{
		if (_suppressEvents)
		return;
            
		// When input gif filename string changes, try to snag the first frame
		try
		{
			var gifPath = txtInputGif.Text;
			var fileName = Path.GetFileNameWithoutExtension(gifPath);

			var outPath = Path.Combine(txtOutputDir.Text, fileName);
			if (!Directory.Exists(outPath))
			Directory.CreateDirectory(outPath);
                
			_currentPreviewImg = Path.Combine(outPath, fileName + "-frame.png");
			string cmd = string.Format("convert \"{0}[0]\" \"{1}\"", gifPath, _currentPreviewImg);
			var tabWidth = 0;
			if (execute(cmd))
			{
				var img = System.Drawing.Image.FromFile(_currentPreviewImg);
				txtImgWidth.Text = img.Width.ToString();
				txtImgHeight.Text = img.Height.ToString();
				tabWidth = img.Width / 5;
				nudTabWidth.Value = tabWidth;
			}
            
			var imgWidth = int.Parse(txtImgWidth.Text);
			var imgHeight = int.Parse(txtImgHeight.Text);
			tabWidth = (int)nudTabWidth.Value;
			var repeatX = (int)nudRepeatX.Value;
			var repeatY = (int)nudRepeatY.Value;
			var spacing = (int)nudCutSpacing.Value;
			var margin = (int)nudMargin.Value;

			var path = Path.GetDirectoryName(_currentPreviewImg);
			fileName = Path.GetFileNameWithoutExtension(_currentPreviewImg);
			var processedPreview = Path.Combine(path, fileName + "-preview.png");

			// coalesce ensures frames are same size. Convert may create different sized frames for some kinds of gifs. Apparently.
			cmd = string.Format("convert -coalesce -gravity east -extent {1}x{2} -background gray90 -bordercolor yellow -border {0} \"{3}\" \"{4}\"", spacing, imgWidth + tabWidth, imgHeight, _currentPreviewImg, processedPreview);
			execute(cmd);

			string finalFile = Path.Combine(path, fileName + "_final.png");
			cmd = string.Format("convert -border {0} -size {1}x{2} tile:\"{3}\" \"{4}\"", margin, (imgWidth + tabWidth) * repeatX, imgHeight * repeatY, processedPreview, finalFile);
			execute(cmd);

			//picPreview.Image = Image.FromFile(finalFile);     // Note: This locks file.
			picPreview.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(finalFile)));
		}
		catch
		{
			MessageBox.Show("Something went tits up!");
			return;
		}
	}

	/// <summary>
	/// Work some magic! Convert gif file into tiled frames, then paginate, then PDF
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void btnGo_Click(object sender, EventArgs e)
	{
		var gifPath = txtInputGif.Text;
		if (gifPath == "")
		{
			MessageBox.Show("Please Select a GIF file for conversion");
			return;
		}

		if (txtOutputDir.Text == "")
		{
			MessageBox.Show("Please Select a folder for output");
			return;
		}

		var outFolder = Path.GetFileNameWithoutExtension(gifPath);
		var outPath = Path.Combine(txtOutputDir.Text, outFolder);
		if (!Directory.Exists(outPath))
		Directory.CreateDirectory(outPath);

		// empty output directory
		var di = new DirectoryInfo(outPath);
		foreach (var file in di.GetFiles())
		{
			if ((!file.Name.Contains("-frame") && file.Name.EndsWith(".png")) || file.Name == "output.pdf")
			file.Delete();
		}

		var r = new Random().Next();
            
		var imgWidth = int.Parse(txtImgWidth.Text);
		var imgHeight = int.Parse(txtImgHeight.Text);
		var tabWidth = (int)nudTabWidth.Value;
		var repeatX = (int)nudRepeatX.Value;
		var repeatY = (int)nudRepeatY.Value;
		var spacing = (int)nudCutSpacing.Value;
		var printMargin = (int)nudMargin.Value;

		string cmd;
		// can also use coalesce to "unoptimise" an optimised gif, it would seem? Just set the output as a gif
		if (chkUnoptimise.CheckState == CheckState.Checked)
		{
			cmd = string.Format("convert \"{0}\" -coalesce \"{0}\"", gifPath);
			execute(cmd);
		}
		// coalesce (rather than convert) ensures frames are same size. Convert may create different sized frames for some kinds of gifs. Apparently.
		// Separate gifs into frames, add grey binding tab to the left and yellow spacing border to each frame
		cmd = string.Format("convert -coalesce -gravity east -extent {1}x{2} -background gray90 -bordercolor yellow -border {0} \"{3}\" \"{4}\"", spacing, imgWidth + tabWidth, imgHeight, gifPath, outPath + "\\" + r.ToString() + ".png");
		execute(cmd);
            
		// GetFiles() is shit at ordering files numerically. Alphabetical sorting via LINQ also doesn't work. 
		// But since we know the files were created in the correct order chronologically, we can sort by creation time
		var files = Directory.GetFiles(outPath, "*.png").Select(f=> new FileInfo(f)).OrderBy(f=> f.CreationTime);
		var fileCount = files.Count() - 3;	// minus temporary frame images
            
		// if the total frame count is not perfectly divisible by the chosen tile count, 
		// make some dummy images to fill the gaps. This just makes it easier later
		var modulus = fileCount % (repeatX * repeatY);
		if(modulus != 0)
		{
			// get last file number (again, we know they're sorted chronologically hence the last file has the highest number)
			var lastFileName = Path.GetFileNameWithoutExtension(files.Last().ToString());
			var lastFileIndex = int.Parse(lastFileName.Substring(lastFileName.LastIndexOf('-') + 1));
                
			// if final page of frames isn't full, we still need to make it the same size / scaling as previous pages.
			// Calculating that is a PITA, so we just pad the page out with blank frames.
			var remainder = (repeatX * repeatY) - modulus;
			for (var i = 1; i <= remainder; i++)
			{
				// Just making a blank frame from scratch results in weird spacing for some reason, so take an existing frame and just wipe it clean
				var fileName = Path.Combine(outPath, r.ToString() + "-" + (lastFileIndex + i).ToString() + ".png");
				File.Copy(files.Last().ToString(), fileName);
				cmd = string.Format("convert \"{0}\"  -alpha Opaque +level-colors White \"{0}\"", fileName);
				execute(cmd);
			}
			fileCount += remainder;
		}

		var index = 0;
		foreach (var file in files)
		{
			if (file.ToString().Contains("frame"))
			continue;
                
			if (index++ == 0)
			continue;   // don't write number on first frame
			// write frame number in binding tab
			cmd = string.Format("convert \"{1}\" -pointsize 30 -annotate 270x270+30+200  \"{0}\" \"{1}\"", index, file);
			execute(cmd);
		}
            
		var totalWidth = repeatX * (imgWidth + tabWidth + (spacing * 2));
		var totalHeight = repeatY * (imgHeight + (spacing * 2));

		// Paper dimensions (A4) = 210 x 297
		// Maybe give user some options here (one day!)
		var widthFill = 210F / totalWidth;
		var heightFill = 297F / totalHeight;

		int widthPadding = 0, heightPadding = 0;
		if (widthFill < heightFill)
		{
			// no padding required to width
			heightPadding = (int)((297F - (widthFill * totalHeight)) / widthFill) / 2;   // divide by 2 to split between top and bottom
		}
		else
		{
			// no padding required to height
			widthPadding = (int)((210F - (heightFill * totalWidth)) / heightFill) / 2;   // divide by 2 to split between left and right
		}

		var count = 0;
		int to = 0, from = 0, page = 0;
		while (count < fileCount)
		{
			to = from + (repeatX * repeatY) - 1;

			// construct a list of all frames for this page
			string fileList = "";
			for (var fNum = from; fNum <= to; fNum++)
			{
				fileList += "\"" + outPath + "\\" + r.ToString() + "-" + fNum.ToString() + ".png\" ";
			}
                
			// tile images into a page using user-specified x*y parameters. +0+0 means don't add a border
			// store this in a temporary image called blah.png
			cmd = string.Format("montage {0} -tile {1}x{2} -geometry +0+0 \"{3}\"", fileList, repeatX, repeatY, outPath + "\\blah.png");
			execute(cmd);
                
			// Add user-specified print margin to page
			cmd = string.Format("convert \"{0}\" -bordercolor none -border {1}x{2} \"{3}\"", outPath + "\\blah.png", widthPadding + printMargin, heightPadding + printMargin, outPath + "\\page-" + page++.ToString() + ".png");
			execute(cmd);
			count = from = to + 1;
		}

		// Chuck all .png pages into a PDF
		cmd = string.Format("convert \"{0}\\page-*.png\" \"{0}\\output.pdf\"", outPath);
		execute(cmd);
	}

	private void btnSelectGif_Click(object sender, EventArgs e)
	{
		ofdInputGif.Filter = "GIF Files (*.gif)|*.gif";
		ofdInputGif.InitialDirectory = _inDir;
		ofdInputGif.Title = "Please select a GIF file to be converted.";
		if (ofdInputGif.ShowDialog() == DialogResult.OK)
		{
			txtInputGif.Text = ofdInputGif.FileName;
		}
	}

	private void btnSelectOutputDir_Click(object sender, EventArgs e)
	{
		DialogResult result = fbdOutput.ShowDialog();
		if (result == DialogResult.OK)
		{
			txtOutputDir.Text = fbdOutput.SelectedPath;
		}
	}

	private void txtInputGif_TextChanged(object sender, EventArgs e)
	{
		previewMontage();
	}

	private void nudRepeatX_ValueChanged(object sender, EventArgs e)
	{
		previewMontage();
	}

	private void nudRepeatY_ValueChanged(object sender, EventArgs e)
	{
		previewMontage();
	}

	private void nudTabWidth_ValueChanged(object sender, EventArgs e)
	{
		previewMontage();
	}

	private void nudMargin_ValueChanged(object sender, EventArgs e)
	{
		previewMontage();
	}

	private void nudCutSpacing_ValueChanged(object sender, EventArgs e)
	{
		previewMontage();
	}
}

