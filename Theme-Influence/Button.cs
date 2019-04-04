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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceButton : Control
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
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private StringAlignment _align = StringAlignment.Near;
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

        public InfluenceButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8.25f);
            DoubleBuffered = true;
            Size = new Size(115, 30);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            dynamic ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Draw d = new Draw();
            G.SmoothingMode = SmoothingMode.HighQuality;
            //G.Clear(Color.FromArgb(20, 20, 20))
            G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    G.FillPath(new SolidBrush(Color.FromArgb(20, 20, 20)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    LinearGradientBrush g1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillPath(h1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillPath(s1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 1), 2));
                    G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
                    G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
                    break;
                case MouseState.Over:
                    //Mouse Hover
                    LinearGradientBrush g11 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillPath(g11, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    //G.FillRectangle(g1, ClientRectangle)
                    HatchBrush h11 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillPath(h11, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    //G.FillRectangle(h1, New Rectangle(0, 0, Width - 1, Height - 2))
                    LinearGradientBrush s11 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillPath(s11, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 1), 2));
                    G.FillPath(new SolidBrush(Color.FromArgb(15, Color.White)), d.RoundRect(ClientRectangle, 2));
                    G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
                    G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
                    break;
                case MouseState.Down:
                    //Mouse Down
                    LinearGradientBrush g12 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillPath(g12, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    //G.FillRectangle(g1, ClientRectangle)
                    HatchBrush h12 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillPath(h12, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
                    //G.FillRectangle(h1, New Rectangle(0, 0, Width - 1, Height - 2))
                    LinearGradientBrush s12 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillPath(s12, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 1), 2));
                    G.FillPath(new SolidBrush(Color.FromArgb(15, Color.Black)), d.RoundRect(ClientRectangle, 2));
                    G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
                    G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
                    break;
            }

            //G.DrawRectangle(Pens.Black, ClientRectangle)

            G.DrawString(Text, Font, Brushes.Black, new Rectangle(5, 0, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = _align
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(5, 1, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = _align
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

