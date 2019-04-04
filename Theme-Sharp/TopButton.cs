// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sharp
{
    public class SharpTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"
        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }
        private MouseState State;

        int X;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        #endregion
        public enum TxtState : byte
        {
            Close = 1,
            Minim = 2
        }
        private TxtState BtnTxt;
        public TxtState TopButtonTXT
        {
            get { return BtnTxt; }
            set
            {
                BtnTxt = value;
                Invalidate();
            }
        }
        public SharpTopButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 8.25f);
            Size = new Size(30, 20);

            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);

            G.Clear(BackColor);

            base.OnPaint(e);


            switch (State)
            {
                case MouseState.Over:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(170, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(170, 18, 32), Color.FromArgb(147, 156, 162), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(147, 156, 162), Color.FromArgb(170, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 175));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 175), Color.FromArgb(157, 166, 172), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(157, 166, 172), Color.FromArgb(0, 102, 175), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.None:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(140, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(140, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(140, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 156));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 156), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(0, 102, 156), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.Down:
                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(130, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(130, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(130, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;
                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(151, 161, 171), Color.FromArgb(83, 83, 83), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(97, 107, 117))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 146));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 154), Color.FromArgb(132, 141, 147), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(132, 141, 147), Color.FromArgb(0, 102, 154), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(37, 47, 57))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(150, 150, 150), Color.FromArgb(127, 137, 147), 90);
                        G.DrawRectangle(new Pen(InnerRect1), new Rectangle(1, 1, Width - 3, Height - 3));
                    }

                    break;
            }
            switch (BtnTxt)
            {
                case TxtState.Close:
                    Size = new Size(30, 20);
                    G.DrawString("r", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case TxtState.Minim:
                    Size = new Size(25, 20);
                    G.DrawString("0", new Font("Marlett", 12), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(1, -1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            //  G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(40, 40, 40))), 0, 0, 29, 19)

            e.Graphics.DrawImage((Image)bmp.Clone(), 0, 0);
            G.Dispose();
            bmp.Dispose();
        }

    }

}


