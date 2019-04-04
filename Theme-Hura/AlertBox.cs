// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="AlertBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Hura
{
    public class HuraAlertBox : Control
    {

        private Point exitLocation;

        private bool overExit;
        public enum Style
        {
            Simple,
            Success,
            Notice,
            Warning,
            Informations
        }

        private Style _alertStyle;
        public Style AlertStyle
        {
            get { return _alertStyle; }
            set
            {
                _alertStyle = value;
                Invalidate();
            }
        }

        public HuraAlertBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Font = new Font("Verdana", 8);
            Size = new Size(200, 40);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Color borderColor = default(Color);
            Color innerColor = default(Color);
            Color textColor = default(Color);
            switch (_alertStyle)
            {
                case Style.Simple:
                    borderColor = Color.FromArgb(90, 90, 90);
                    innerColor = Color.FromArgb(50, 50, 50);
                    textColor = Color.FromArgb(150, 150, 150);
                    break;
                case Style.Success:
                    borderColor = Color.FromArgb(60, 98, 79);
                    innerColor = Color.FromArgb(60, 85, 79);
                    textColor = Color.FromArgb(35, 169, 110);
                    break;
                case Style.Notice:
                    borderColor = Color.FromArgb(70, 91, 107);
                    innerColor = Color.FromArgb(70, 91, 94);
                    textColor = Color.FromArgb(97, 185, 186);
                    break;
                case Style.Warning:
                    borderColor = Color.FromArgb(100, 71, 71);
                    innerColor = Color.FromArgb(87, 71, 71);
                    textColor = Color.FromArgb(254, 142, 122);
                    break;
                case Style.Informations:
                    borderColor = Color.FromArgb(133, 133, 71);
                    innerColor = Color.FromArgb(120, 120, 71);
                    textColor = Color.FromArgb(254, 224, 122);
                    break;
            }

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            G.FillRectangle(new SolidBrush(innerColor), mainRect);
            G.DrawRectangle(new Pen(borderColor), mainRect);

            string styleText = null;

            switch (_alertStyle)
            {

            }

            Font styleFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
            int textY = ((this.Height - 1) / 2) - (int)(G.MeasureString(Text, Font).Height / 2);
            G.DrawString(styleText, styleFont, new SolidBrush(textColor), new Point(10, textY));
            G.DrawString(Text, Font, new SolidBrush(textColor), new Point(10 + (int)G.MeasureString(styleText, styleFont).Width + 4, textY));

            Font exitFont = new Font("Marlett", 6);
            int exitY = ((this.Height - 1) / 2) - (int)(G.MeasureString("r", exitFont).Height / 2) + 1;
            exitLocation = new Point(Width - 26, exitY - 3);
            G.DrawString("r", exitFont, new SolidBrush(textColor), new Point(Width - 23, exitY));

        }


        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.X >= Width - 26 && e.X <= Width - 12 && e.Y > exitLocation.Y && e.Y < exitLocation.Y + 12)
            {
                if (Cursor != Cursors.Hand)
                    Cursor = Cursors.Hand;
                overExit = true;
            }
            else
            {
                if (Cursor != Cursors.Arrow)
                    Cursor = Cursors.Arrow;
                overExit = false;
            }

            Invalidate();

        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (overExit)
                this.Visible = false;

        }

    }


}


