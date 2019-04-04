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

using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Perplex
{
    public class PerplexControlBox : Control
    {

        #region " MouseStates "
        MouseState State = MouseState.None;
        Rectangle MinBtn = new Rectangle(0, 0, 20, 20);
        Rectangle MaxBtn = new Rectangle(25, 0, 20, 20);

        int X;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Location.X > 0 && e.Location.X < 20)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (e.Location.X > 25 && e.Location.X < 45)
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

        public PerplexControlBox()
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

            base.OnPaint(e);

            G.Clear(BackColor);

            //G.CompositingQuality = CompositingQuality.HighQuality
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush mlgb = new LinearGradientBrush(MinBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(mlgb, Draw.RoundRect(MinBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                    Font mf = new Font("Marlett", 9);
                    SolidBrush mfb = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("0", mf, mfb, 4, 4);

                    LinearGradientBrush lgb = new LinearGradientBrush(MaxBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb, Draw.RoundRect(MaxBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                    Font f = new Font("Marlett", 9);
                    SolidBrush fb = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("r", f, fb, 28, 4);
                    break;
                case MouseState.Over:
                    if (X > 0 && X < 20)
                    {
                        LinearGradientBrush mlgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(100, 66, 67, 70), Color.FromArgb(100, 43, 44, 48), 90);
                        G.FillPath(mlgb1, Draw.RoundRect(MinBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                        Font mf1 = new Font("Marlett", 9);
                        SolidBrush mfb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("0", mf1, mfb1, 4, 4);

                        LinearGradientBrush lgb1 = new LinearGradientBrush(MaxBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                        G.FillPath(lgb1, Draw.RoundRect(MaxBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                        Font f1 = new Font("Marlett", 9);
                        SolidBrush fb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("r", f1, fb1, 28, 4);

                    }
                    else if (X > 25 && X < 45)
                    {
                        LinearGradientBrush mlgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                        G.FillPath(mlgb1, Draw.RoundRect(MinBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                        Font mf1 = new Font("Marlett", 9);
                        SolidBrush mfb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("0", mf1, mfb1, 4, 4);

                        LinearGradientBrush lgb1 = new LinearGradientBrush(MaxBtn, Color.FromArgb(100, 66, 67, 70), Color.FromArgb(100, 43, 44, 48), 90);
                        G.FillPath(lgb1, Draw.RoundRect(MaxBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                        Font f1 = new Font("Marlett", 9);
                        SolidBrush fb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("r", f1, fb1, 28, 4);
                    }
                    else
                    {
                        LinearGradientBrush mlgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                        G.FillPath(mlgb1, Draw.RoundRect(MinBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                        Font mf1 = new Font("Marlett", 9);
                        SolidBrush mfb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("0", mf1, mfb1, 4, 4);

                        LinearGradientBrush lgb1 = new LinearGradientBrush(MaxBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                        G.FillPath(lgb1, Draw.RoundRect(MaxBtn, 4));
                        G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                        Font f1 = new Font("Marlett", 9);
                        SolidBrush fb1 = new SolidBrush(Color.FromArgb(174, 195, 30));
                        G.DrawString("r", f1, fb1, 28, 4);
                    }
                    break;
                case MouseState.Down:
                    LinearGradientBrush mlgb2 = new LinearGradientBrush(MinBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(mlgb2, Draw.RoundRect(MinBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                    Font mf2 = new Font("Marlett", 9);
                    SolidBrush mfb2 = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("0", mf2, mfb2, 4, 4);

                    LinearGradientBrush lgb2 = new LinearGradientBrush(MaxBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb2, Draw.RoundRect(MaxBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                    Font f2 = new Font("Marlett", 9);
                    SolidBrush fb2 = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("r", f2, fb2, 28, 4);
                    break;
                default:
                    LinearGradientBrush mlgb3 = new LinearGradientBrush(MinBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(mlgb3, Draw.RoundRect(MinBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MinBtn, 4));
                    Font mf3 = new Font("Marlett", 9);
                    SolidBrush mfb3 = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("0", mf3, mfb3, 4, 4);

                    LinearGradientBrush lgb3 = new LinearGradientBrush(MaxBtn, Color.FromArgb(66, 67, 70), Color.FromArgb(43, 44, 48), 90);
                    G.FillPath(lgb3, Draw.RoundRect(MaxBtn, 4));
                    G.DrawPath(new Pen(Color.FromArgb(21, 21, 21), 1), Draw.RoundRect(MaxBtn, 4));
                    Font f3 = new Font("Marlett", 9);
                    SolidBrush fb3 = new SolidBrush(Color.FromArgb(174, 195, 30));
                    G.DrawString("r", f3, fb3, 28, 4);
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
}


