// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="BigButton.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchBigButton : ThemeControl154
    {
        public int twTabPageNumber { get; set; }
        public TwitchTabControl twTabPage { get; set; }
        public bool twDoesTurnPurple { get; set; }
        public bool twStarred { get; set; }
        #region "StarBase64"
        #endregion
        string StarBase64 = "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";

        public TwitchBigButton()
        {
            Cursor = Cursors.Hand;
            System.Drawing.Size sw = new System.Drawing.Size(245, 30);
            Size = sw;
            this.Click += Clicked;
            Transparent = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            twDoesTurnPurple = false;
            twStarred = false;
            twTabPageNumber = 1;
            Tag = "black";
        }

        private void Clicked(object sender, EventArgs e)
        {
            if (twDoesTurnPurple == true)
            {
                foreach (Control C in Parent.Controls)
                {
                    if (!object.ReferenceEquals(C, this) && C is TwitchBigButton)
                    {
                        switch (C.Tag)
                        {
                            case "purple":
                                ((TwitchBigButton)C).Tag = "black";
                                break;
                            case "purplebottom":
                                ((TwitchBigButton)C).Tag = "blackbottom";
                                break;
                        }
                        C.Invalidate();
                    }
                }
                switch (Tag)
                {
                    case "black":
                        Tag = "purple";
                        break;
                    case "blackbottom":
                        Tag = "purplebottom";
                        break;
                }
            }
            if (!(twTabPageNumber == null))
            {
                try
                {
                    Methods.SelectTab(twTabPageNumber, twTabPage);

                }
                catch (Exception ex)
                {
                }
            }
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            switch (Tag)
            {
                case "black":
                    switch (State)
                    {
                        case MouseState.None:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), new Point(1, 1), new Point(Width - 2, 1));
                            DrawText(new SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Over:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), new Point(1, 1), new Point(Width - 2, 1));
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Down:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                    }
                    if (twStarred == true)
                    {
                        byte[] imageBytes = Convert.FromBase64String(StarBase64);
                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                        Image star = Image.FromStream(ms, true);
                        G.DrawImage(star, Width - 20, 0, star.Width, star.Height);
                    }
                    break;
                case "purple":
                    G.Clear(BackColor);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(100, 65, 165)), new Rectangle(0, 0, Width, Height));
                    G.DrawLine(Pens.Black, 0, 0, Width, 0);
                    DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                    break;
                case "blackbottom":
                    switch (State)
                    {
                        case MouseState.None:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
                            G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), new Point(1, 1), new Point(Width - 2, 1));
                            DrawText(new SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Over:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
                            G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), new Point(1, 1), new Point(Width - 2, 1));
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Down:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                    }
                    if (twStarred == true)
                    {
                        byte[] imageBytes = Convert.FromBase64String(StarBase64);
                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                        Image star = Image.FromStream(ms, true);
                        G.DrawImage(star, Width - 20, 0, star.Width, star.Height);
                    }
                    break;
                case "purplebottom":
                    G.FillRectangle(new SolidBrush(Color.FromArgb(100, 65, 165)), new Rectangle(0, 0, Width, Height));
                    G.DrawLine(Pens.Black, 0, 0, Width, 0);
                    G.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
                    DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                    break;
                default:
                    switch (State)
                    {
                        case MouseState.None:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            DrawText(new SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Over:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                        case MouseState.Down:
                            G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), new Rectangle(0, 0, Width, Height));
                            G.DrawLine(Pens.Black, 0, 0, Width, 0);
                            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Left, 30, 0);
                            break;
                    }
                    if (twStarred == true)
                    {
                        byte[] imageBytes = Convert.FromBase64String(StarBase64);
                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                        Image star = Image.FromStream(ms, true);
                        G.DrawImage(star, Width - 20, 0, star.Width, star.Height);
                    }
                    break;
            }

            if ((Image != null))
                G.DrawImage(Image, 10, 7, 16, 16);
        }
    }

}

