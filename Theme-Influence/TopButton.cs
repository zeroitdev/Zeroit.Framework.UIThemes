// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"
        public enum ButtonType : byte
        {
            Blank = 0,
            Close = 1,
            Minim = 2
        }

        private MouseState State = MouseState.None;
        private ButtonType _type = ButtonType.Blank;
        public ButtonType ButtonIcon
        {
            get { return _type; }
            set
            {
                _type = value;
                Invalidate();
            }
        }

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
        #endregion

        public InfluenceTopButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8.25f);
            Size = new Size(43, 21);
            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    LinearGradientBrush g1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g1, g1.Rectangle);
                    HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h1, g1.Rectangle);
                    LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s1, s1.Rectangle);
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Over:
                    LinearGradientBrush g11 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g11, g11.Rectangle);
                    HatchBrush h11 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h11, g11.Rectangle);
                    LinearGradientBrush s11 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s11, s11.Rectangle);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Down:
                    LinearGradientBrush g12 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g12, g12.Rectangle);
                    HatchBrush h12 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h12, g12.Rectangle);
                    LinearGradientBrush s12 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s12, s12.Rectangle);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }

            switch (_type)
            {
                case ButtonType.Close:
                    Size = new Size(43, 21);
                    G.DrawString("r", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case ButtonType.Minim:
                    Size = new Size(30, 21);
                    G.DrawString("0", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle((int)1.5, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

