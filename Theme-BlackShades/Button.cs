// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BlackShades
{

    public class BlackShadesNetButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private MouseState State = MouseState.None;
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
        private StringAlignment _align = StringAlignment.Center;
        public new StringAlignment TextAlignment
        {
            get { return _align; }
            set
            {
                _align = value;
                Invalidate();
            }
        }

        #endregion

        public BlackShadesNetButton() : base()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            //BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold);
            //ForeColor = Color.FromArgb(142, 152, 156)
            ForeColor = Color.White;
            DoubleBuffered = true;
            Size = new Size(75, 23);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            const int curve = 3;
            dynamic ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Draw d = new Draw();
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);
            //Dim bg As Color = Parent.FindForm.BackColor

            //G.Clear(Color.FromArgb(42, 47, 49));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    G.FillPath(new SolidBrush(Color.FromArgb(32, 36, 38)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(1, 1, Width - 5, Height / 2 - 3), Color.FromArgb(70, Color.White), Color.Transparent, 90);
                    G.FillPath(gloss, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 3), curve));
                    LinearGradientBrush borderRect = new LinearGradientBrush(ClientRectangle, Color.FromArgb(36, 31, 43), Color.FromArgb(61, 65, 68), 90);
                    G.DrawPath(new Pen(Color.FromArgb(99, 103, 105)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), curve));
                    G.DrawPath(new Pen(borderRect), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    G.DrawPath(new Pen(Color.FromArgb(27, 31, 33)), d.RoundRect(new Rectangle(1, 0, Width - 3, Height - 3), curve));
                    break;
                case MouseState.Over:
                    //Mouse Hover
                    G.FillPath(new SolidBrush(Color.FromArgb(32, 36, 38)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    LinearGradientBrush gloss1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 5, Height / 2 - 3), Color.FromArgb(70, Color.White), Color.Transparent, 90);
                    G.FillPath(gloss1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 3), curve));
                    LinearGradientBrush borderRect1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(36, 31, 43), Color.FromArgb(61, 65, 68), 90);
                    G.DrawPath(new Pen(Color.FromArgb(99, 103, 105)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), curve));
                    G.DrawPath(new Pen(Color.FromArgb(100, 99, 103, 105)), d.RoundRect(new Rectangle(2, 2, Width - 5, Height - 6), curve));
                    G.DrawPath(new Pen(borderRect1), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    G.DrawPath(new Pen(Color.FromArgb(27, 31, 33)), d.RoundRect(new Rectangle(1, 0, Width - 3, Height - 3), curve));
                    G.DrawPath(new Pen(Color.FromArgb(0, 186, 255)), d.RoundRect(new Rectangle(1, 1, Width - 3, Height - 4), curve));
                    break;
                case MouseState.Down:
                    //Mouse Down
                    G.FillPath(new SolidBrush(Color.FromArgb(32, 36, 38)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    LinearGradientBrush topGrad = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2 - 1), Color.FromArgb(32, 36, 38), Color.FromArgb(57, 57, 57), 90);
                    G.FillPath(topGrad, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 + 1), curve));
                    LinearGradientBrush botGrad = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2 - 1), Color.FromArgb(57, 57, 57), Color.FromArgb(32, 36, 38), 90);
                    G.FillPath(botGrad, d.RoundRect(new Rectangle(0, Height / 2 - 1, Width - 1, Height / 2 + 2), curve));
                    G.DrawLine(new Pen(Color.FromArgb(57, 57, 57)), 0, Convert.ToInt32(Height / 2 - 1), Width - 1, Convert.ToInt32(Height / 2 - 1));

                    LinearGradientBrush borderRect2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(36, 31, 43), Color.FromArgb(61, 65, 68), 90);
                    G.DrawPath(new Pen(borderRect2), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), curve));
                    G.DrawPath(new Pen(Color.FromArgb(27, 31, 33)), d.RoundRect(new Rectangle(1, 0, Width - 3, Height - 3), curve));

                    break;
            }

            //G.DrawRectangle(Pens.Black, ClientRectangle)

            //G.DrawString(Text, Font, Brushes.Black, New Rectangle(-1, -2, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(-1, -1, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    
}
