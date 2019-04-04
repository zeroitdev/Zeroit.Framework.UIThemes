// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Advert.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Skype
{
    public class SkypeAdvertisement : ThemeControl154
    {
        private Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
        Image CornerImg1;
        Image CornerImg2;

        public Bitmap FlipImage(Bitmap img)
        {
            Bitmap NewBMP = new Bitmap(img);
            for (int x = 0; x <= img.Width - 1; x++)
            {
                for (int y = 0; y <= img.Height - 1; y++)
                {
                    int NewX = img.Width - x - 1;
                    int NewY = img.Height - y - 1;
                    NewBMP.SetPixel(NewX, NewY, img.GetPixel(x, y));
                }
            }
            return NewBMP;
        }
        public SkypeAdvertisement()
        {
        }
        private Image _Image = null;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            CornerImg1 = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAMAAAADCAIAAADZSiLoAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAB9JREFUGFdj7Nn3X4iLQVGYgWHeif/H7oMQw/7bUBYA31ESKR4EWfAAAAAASUVORK5CYII=");
            CornerImg2 = CodeToImage("iVBORw0KGgoAAAANSUhEUgAAAAMAAAADCAIAAADZSiLoAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAB9JREFUGFdj3H/7//23DO++MTAcu/8fiOad+A9lAWUAOvkV2aJ25r4AAAAASUVORK5CYII=");


            G.Clear(Color.FromArgb(198, 223, 255));
            G.DrawImage(CornerImg1, 0, 0);
            G.DrawImage(CornerImg2, Width - 3, 0);
            G.DrawImage(FlipImage((Bitmap)CornerImg2), 0, Height - 3);
            G.DrawImage(FlipImage((Bitmap)CornerImg1), Width - 3, Height - 3);
            try
            {
                G.DrawImage(_Image, 5, 5, Width - 10, Height - 10);

            }
            catch (Exception ex)
            {
            }
        }
    }

}

