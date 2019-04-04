// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{
    public class UbuntuControlBox : Control
    {

        #region " MouseStates "
        MouseState State = MouseState.None;
        int X;
        Rectangle CloseBtn = new Rectangle(43, 2, 17, 17);
        Rectangle MinBtn = new Rectangle(3, 2, 17, 17);
        Rectangle MaxBtn = new Rectangle(23, 2, 17, 17);

        Rectangle bgr = new Rectangle(0, 0, (int)62.5, 21);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (X > 3 && X < 20)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 23 && X < 40)
            {
                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                    Parent.FindForm().WindowState = FormWindowState.Normal;
                }
                else
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                }

            }
            else if (X > 43 && X < 60)
            {
                Parent.FindForm().Close();
            }
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
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion

        public UbuntuControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Marlett", 7);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(BackColor);

            LinearGradientBrush bg0 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
            G.FillPath(bg0, Draw.RoundRect(bgr, 10));

            LinearGradientBrush lgb10 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
            G.FillEllipse(lgb10, MinBtn);
            G.DrawEllipse(Pens.DimGray, MinBtn);
            G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

            LinearGradientBrush lgb20 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
            G.FillEllipse(lgb20, MaxBtn);
            G.DrawEllipse(Pens.DimGray, MaxBtn);
            G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

            LinearGradientBrush lgb30 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
            G.FillEllipse(lgb30, CloseBtn);
            G.DrawEllipse(Pens.DimGray, CloseBtn);
            G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush bg = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
                    G.FillPath(bg, Draw.RoundRect(bgr, 10));

                    LinearGradientBrush lgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                    G.FillEllipse(lgb1, MinBtn);
                    G.DrawEllipse(Pens.DimGray, MinBtn);
                    G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

                    LinearGradientBrush lgb2 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                    G.FillEllipse(lgb2, MaxBtn);
                    G.DrawEllipse(Pens.DimGray, MaxBtn);
                    G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

                    LinearGradientBrush lgb3 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
                    G.FillEllipse(lgb3, CloseBtn);
                    G.DrawEllipse(Pens.DimGray, CloseBtn);
                    G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
                    break;
                case MouseState.Over:
                    if (X > 3 && X < 20)
                    {
                        LinearGradientBrush bg1 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
                        G.FillPath(bg1, Draw.RoundRect(bgr, 10));

                        LinearGradientBrush lgb11 = new LinearGradientBrush(MinBtn, Color.FromArgb(172, 171, 166), Color.FromArgb(76, 75, 71), 90);
                        G.FillEllipse(lgb11, MinBtn);
                        G.DrawEllipse(Pens.DimGray, MinBtn);
                        G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

                        LinearGradientBrush lgb21 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                        G.FillEllipse(lgb21, MaxBtn);
                        G.DrawEllipse(Pens.DimGray, MaxBtn);
                        G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

                        LinearGradientBrush lgb31 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
                        G.FillEllipse(lgb31, CloseBtn);
                        G.DrawEllipse(Pens.DimGray, CloseBtn);
                        G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
                    }
                    else if (X > 23 && X < 40)
                    {
                        LinearGradientBrush bg3 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
                        G.FillPath(bg3, Draw.RoundRect(bgr, 10));

                        LinearGradientBrush lgb13 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                        G.FillEllipse(lgb13, MinBtn);
                        G.DrawEllipse(Pens.DimGray, MinBtn);
                        G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

                        LinearGradientBrush lgb23 = new LinearGradientBrush(MaxBtn, Color.FromArgb(172, 171, 166), Color.FromArgb(76, 75, 71), 90);
                        G.FillEllipse(lgb23, MaxBtn);
                        G.DrawEllipse(Pens.DimGray, MaxBtn);
                        G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

                        LinearGradientBrush lgb33 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
                        G.FillEllipse(lgb33, CloseBtn);
                        G.DrawEllipse(Pens.DimGray, CloseBtn);
                        G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
                    }
                    else if (X > 43 && X < 60)
                    {
                        LinearGradientBrush bg3 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
                        G.FillPath(bg3, Draw.RoundRect(bgr, 10));

                        LinearGradientBrush lgb13 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                        G.FillEllipse(lgb13, MinBtn);
                        G.DrawEllipse(Pens.DimGray, MinBtn);
                        G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

                        LinearGradientBrush lgb23 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                        G.FillEllipse(lgb23, MaxBtn);
                        G.DrawEllipse(Pens.DimGray, MaxBtn);
                        G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

                        LinearGradientBrush lgb33 = new LinearGradientBrush(CloseBtn, Color.FromArgb(255, 170, 136), Color.FromArgb(243, 101, 26), 90);
                        G.FillEllipse(lgb33, CloseBtn);
                        G.DrawEllipse(Pens.DimGray, CloseBtn);
                        G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
                    }
                    break;
                default:
                    LinearGradientBrush bg4 = new LinearGradientBrush(bgr, Color.FromArgb(60, 59, 55), Color.FromArgb(60, 59, 55), 90);
                    G.FillPath(bg4, Draw.RoundRect(bgr, 10));

                    LinearGradientBrush lgb14 = new LinearGradientBrush(MinBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                    G.FillEllipse(lgb14, MinBtn);
                    G.DrawEllipse(Pens.DimGray, MinBtn);
                    G.DrawString("0", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle((int)5.5, 6, 0, 0));

                    LinearGradientBrush lgb24 = new LinearGradientBrush(MaxBtn, Color.FromArgb(152, 151, 146), Color.FromArgb(56, 55, 51), 90);
                    G.FillEllipse(lgb24, MaxBtn);
                    G.DrawEllipse(Pens.DimGray, MaxBtn);
                    G.DrawString("1", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(26, 7, 0, 0));

                    LinearGradientBrush lgb34 = new LinearGradientBrush(CloseBtn, Color.FromArgb(247, 150, 116), Color.FromArgb(223, 81, 6), 90);
                    G.FillEllipse(lgb34, CloseBtn);
                    G.DrawEllipse(Pens.DimGray, CloseBtn);
                    G.DrawString("r", Font, new SolidBrush(Color.FromArgb(58, 57, 53)), new Rectangle(46, 7, 0, 0));
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


