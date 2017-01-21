# Print-A-Gif
Turn any gif into a printable flip book!
Demo: https://www.youtube.com/watch?v=roJq69vgE2U

Program written in C# and uses ImageMagick for image processing.

<DISCLAIMER #1>
This software probably harbours a few sins. I am not a professional programmer.
There will certainly be things that can be optimised / factorised.
I threw it together in an evening and it serves its purpose for me.
Having said that, it works pretty well. Suggestions welcome.
</DISCLAIMER #1>


For portability, I used the ImageMagick static binary downloaded from
https://www.imagemagick.org/download/binaries/ImageMagick-7.0.4-4-Q16-x64-static.exe

This installs ImageMagick to Program Files\ImageMagick-7.0.4-Q16
I then copied magick.exe into my program's working directory. No other files are needed.

Microsoft VC++ Redistributable is also required

Instructions for use:
- For simplicity / housekeeping, I usually start by placing a gif in the 'input' directory. This is not strictly necessary, but it saves a few clicks later on as the default location for the OpenFileDialog is the input directory.

- Fire up the program, select your gif and change the output directory if you wish. I usually just use the output folder. A separate folder will be created in here for all intermediate working files and the final generated PDF.
*** VERY IMPORTANT NOTE ***
Output directory will be emptied of any .png files upon pressing the 'Go' button
Don't use any folder that you have precious .png files stored in!
***************************

- Use the Repeat X and Repeat Y controls to choose how the images are tiled. I've found that 2 frames wide works nicely, then fit as many as you can vertically. If the overall tile pattern exceeds the size of the 'paper', each frame will be scaled so that either the full height or the full width of the paper is utilised without changing the aspect ratio of the frame. The actual frame sizes will not be modified in the final output file, so no resolution is lost. You will need to scale to fit the page when printing.

- Tab width: This is the width of the gluing / clamping area at the left of the frames. This is automatically set to 20% of the width of the original frame but can be adjusted if preferred.

- Print margin: This is the margin around the edge of each page of frames in the final output file. Adjust so that nothing is lost from the edges when printing.

- Cut spacing: This is the spacing between each frame. I tend to leave this set to 1 as it makes it easier to cut all the frames the same size with an scalpel.

- Bear in mind that tab width, print margin and cut spacings are subject to change when printed due to final scaling. Experiment if necessary.

- Once everything's set, hit the "Go" button and then look in the output directory. You will see an individual .png image for every frame of the gif, followed by paginated frames, named page-0, page-1, etc. The final file to be created is output.pdf. Give this a few seconds before opening as it appears in the output directory before the program has finished creating it.

- You may also see some blank frames in the output directory. These are used to pad out the final page if necessary. This ensured that all pages came out the same size and saved a lot of calculations.

- Now you can print the pdf and cut out the frames!
- I recommend using Adobe Acrobat Reader to view and print the output.pdf file.



Notes:
- If after conversion, you find that the first frame is intact but subsequent frames are incomplete, showing only vestiges of the image, it was probably an optimised gif, i.e., after the first frame, each subsequent frame contains only information that changed since the previous frame. To get around this, before hitting the "Go" button, check the "Unoptimise first" box just below the "Go" button. This can take a while, hence it is not always performed by default.


Tips:
- Be sure to leave adequate tab width for gluing / clamping. Too narrow and it's hard to see the left side of the images when flipping through the flip book.
- Stiffer paper, e.g., glossy photo paper lends to a better flipping experience
- When stacking the cut-out frames, slant the stack a little bit so that the bottom layers protrude a little further to the right than the top layers. This makes it easier to flip through the pages.
- Try to be as accurate as possible when cutting so that the left and right edges of the flip book aren't too jagged. There will inevitably be some variation.
- When stacking the frames, tap the right edge of the stack down on a table. It's more important that this edge is aligned when it comes to flipping through the book.
- Clamp the spine edge securely when gluing


Potential improvements if I find the motivation:
- Choose spacing colour - This is currently hardcoded to be yellow.
- Landscape / portrait page modes
- Option to tidy up intermediate files after processing (they handy sometimes, though)
- Option to have binding tab on left / right / top / bottom
- Options for different paper size (default is A4, i.e., 210 x 297mm)
- Some kind of progress indicator. Large gifs take a while
- Since most of the fancy image processing legwork is performed by ImageMagick, it probably 

- wouldn't be too difficult to port this to Mac / Linux. I am not offering to do this though! If anyone has the patience for that, please keep me posted :)




