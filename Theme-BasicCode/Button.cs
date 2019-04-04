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




namespace Zeroit.Framework.UIThemes.BasicCode
{

    public class BCEvoButton : ThemeControl154
    {

        protected override void ColorHook()
        {
        }
        private Color _ForeColor;
        public Color TextColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

        public BCEvoButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            TextColor = Color.Gray;
            Size = new Size(97, 23);
            Location = new Point(40, 30);
        }
        private GraphicsPath BPath;
        private GraphicsPath TPath;
        private Point[] BITPoints;
        private Rectangle BRect;
        private Rectangle TRect;
        private Rectangle BIRect;
        private LinearGradientBrush BBrush;
        private LinearGradientBrush BIBrush;
        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.HighSpeed;
            BRect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            TRect = new Rectangle(0, 0, ClientRectangle.Width - 2, Convert.ToInt32(ClientRectangle.Height / 2));
            BITPoints = new Point[] {
            new Point(4, 4),
            new Point(ClientRectangle.Width - 4, 4),
            new Point(ClientRectangle.Width - 4, ClientRectangle.Height - 4),
            new Point(4, ClientRectangle.Height - 4),
            new Point(4, 4)
        };
            BIRect = new Rectangle(3, 3, ClientRectangle.Width - 4, ClientRectangle.Height - 4);
            BBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 55, 55, 55), Color.FromArgb(255, 22, 22, 22), LinearGradientMode.Vertical);
            BIBrush = new LinearGradientBrush(BIRect, Color.FromArgb(255, 100, 0, 0), Color.FromArgb(255, 60, 0, 0), LinearGradientMode.Vertical);

            switch (State)
            {
                case MouseState.Over:
                    BIBrush = new LinearGradientBrush(BIRect, Color.FromArgb(255, 60, 0, 0), Color.FromArgb(255, 100, 0, 0), LinearGradientMode.Vertical);
                    G.FillRectangle(BBrush, BRect);
                    G.DrawRectangle(Pens.Black, BRect);
                    G.FillPolygon(BIBrush, BITPoints);
                    DrawBorders(Pens.Black, 3);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(25, 255, 255, 255)), TRect);
                    break;
                case MouseState.Down:
                    G.FillRectangle(BBrush, BRect);
                    G.DrawRectangle(Pens.Black, BRect);
                    G.FillPolygon(BIBrush, BITPoints);
                    DrawBorders(Pens.Black, 3);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(25, 255, 255, 255)), TRect);
                    break;
                case MouseState.None:
                    G.FillRectangle(BBrush, BRect);
                    G.DrawRectangle(Pens.Black, BRect);
                    G.FillPolygon(BIBrush, BITPoints);
                    DrawBorders(Pens.Black, 3);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(25, 255, 255, 255)), TRect);
                    break;
            }
            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Center, 0, 0);

            if (Enabled == false)
            {
                BIBrush = new LinearGradientBrush(BIRect, Color.FromArgb(255, 40, 40, 40), Color.FromArgb(255, 20, 20, 20), LinearGradientMode.Vertical);
                G.FillRectangle(BBrush, BRect);
                G.DrawRectangle(Pens.Black, BRect);
                G.FillPolygon(BIBrush, BITPoints);
                DrawBorders(Pens.Black, 3);
                G.FillRectangle(new SolidBrush(Color.FromArgb(13, 255, 255, 255)), TRect);
                DrawText(Brushes.Gray, HorizontalAlignment.Center, 0, 0);
            }
            else
            {
            }
        }
    }
    
}
