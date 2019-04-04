// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing.Drawing2D;

using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Perplex
{
    public class PerplexButton : Control
    {
        #region " MouseStates "
        MouseState State = MouseState.None;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        #endregion

        public PerplexButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);


            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Tahoma", 8, FontStyle.Bold);

            //G.CompositingQuality = CompositingQuality.HighQuality
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 2));
                    LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(0, 0, Width - 125, 35 / 2), Color.FromArgb(75, Color.FromArgb(26, 26, 26)), Color.FromArgb(3, 255, 255, 255), 90);
                    G.FillPath(gloss, Draw.RoundRect(ClientRectangle, 2));

                    LinearGradientBrush botbar = new LinearGradientBrush(new Rectangle(5, Height - 10, Width - 11, 5), Color.FromArgb(44, 45, 49), Color.FromArgb(45, 46, 50), 90);
                    G.FillPath(botbar, Draw.RoundRect(new Rectangle(5, Height - 10, Width - 11, 5), 1));

                    LinearGradientBrush fill = new LinearGradientBrush(new Rectangle(6, Height - 9, Width - 13, 3), Color.FromArgb(174, 195, 30), Color.FromArgb(141, 153, 16), 90);
                    G.FillPath(fill, Draw.RoundRect(new Rectangle(6, Height - 9, Width - 13, 3), 1));
                    Pen o = new Pen(Color.FromArgb(50, 50, 50), 1);
                    G.DrawPath(o, Draw.RoundRect(ClientRectangle, 2));
                    G.DrawPath(Pens.Black, Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));
                    break;
                case MouseState.Over:
                    LinearGradientBrush lgb1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb1, Draw.RoundRect(ClientRectangle, 2));
                    LinearGradientBrush gloss1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 125, 35 / 2), Color.FromArgb(15, Color.FromArgb(26, 26, 26)), Color.FromArgb(1, 255, 255, 255), 90);
                    G.FillPath(gloss1, Draw.RoundRect(ClientRectangle, 2));

                    LinearGradientBrush botbar1 = new LinearGradientBrush(new Rectangle(5, Height - 10, Width - 11, 5), Color.FromArgb(44, 45, 49), Color.FromArgb(45, 46, 50), 90);
                    G.FillPath(botbar1, Draw.RoundRect(new Rectangle(5, Height - 10, Width - 11, 5), 1));

                    LinearGradientBrush fill1 = new LinearGradientBrush(new Rectangle(6, Height - 9, Width - 13, 3), Color.FromArgb(174, 195, 30), Color.FromArgb(141, 153, 16), 90);
                    G.FillPath(fill1, Draw.RoundRect(new Rectangle(6, Height - 9, Width - 13, 3), 1));
                    Pen o1 = new Pen(Color.FromArgb(50, 50, 50), 1);
                    G.DrawPath(o1, Draw.RoundRect(ClientRectangle, 2));
                    G.DrawPath(Pens.Black, Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));
                    break;
                case MouseState.Down:
                    LinearGradientBrush lgb2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb2, Draw.RoundRect(ClientRectangle, 2));
                    LinearGradientBrush gloss2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 125, 35 / 2), Color.FromArgb(100, Color.FromArgb(26, 26, 26)), Color.FromArgb(1, 255, 255, 255), 90);
                    G.FillPath(gloss2, Draw.RoundRect(ClientRectangle, 2));

                    LinearGradientBrush botbar2 = new LinearGradientBrush(new Rectangle(5, Height - 10, Width - 11, 5), Color.FromArgb(44, 45, 49), Color.FromArgb(45, 46, 50), 90);
                    G.FillPath(botbar2, Draw.RoundRect(new Rectangle(5, Height - 10, Width - 11, 5), 1));

                    LinearGradientBrush fill2 = new LinearGradientBrush(new Rectangle(6, Height - 9, Width - 13, 3), Color.FromArgb(174, 195, 30), Color.FromArgb(141, 153, 16), 90);
                    G.FillPath(fill2, Draw.RoundRect(new Rectangle(6, Height - 9, Width - 13, 3), 1));
                    Pen o2 = new Pen(Color.FromArgb(50, 50, 50), 1);
                    G.DrawPath(o2, Draw.RoundRect(ClientRectangle, 2));
                    G.DrawPath(Pens.Black, Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));
                    break;
            }

            G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(5, 5, 5)), new Rectangle(1, 0, Width - 1, Height - 1), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(205, 205, 205)), new Rectangle(0, -1, Width - 1, Height - 1), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}


