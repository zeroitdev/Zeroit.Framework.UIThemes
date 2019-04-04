// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Meph
{

    public class MephGroupBox : ContainerControl
    {

        public enum HeaderLine
        {
            Enabled,
            Disabled
        }
        private HeaderLine _HeaderLine;
        public HeaderLine Header_Line
        {
            get { return _HeaderLine; }
            set
            {
                _HeaderLine = value;
                Invalidate();
            }
        }

        public MephGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(174, 115);
            _HeaderLine = HeaderLine.Enabled;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);


            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Verdana", 8, FontStyle.Regular);

            G.SmoothingMode = SmoothingMode.HighQuality;

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), ClientRectangle);
            Draw.InnerGlow(G, ClientRectangle, c);

            switch (_HeaderLine)
            {
                case HeaderLine.Enabled:
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 16, 29, Width - 17, 29);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), 15, 30, Width - 16, 30);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 16, 31, Width - 17, 31);
                    break;
                case HeaderLine.Disabled:
                    break;
            }

            G.DrawString(Text, drawFont, Brushes.Silver, new Rectangle(0, 3, Width - 1, 27), new StringFormat
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


