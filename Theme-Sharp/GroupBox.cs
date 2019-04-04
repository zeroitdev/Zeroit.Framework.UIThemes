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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sharp
{
    public class SharpGroupBOx : ContainerControl
    {
        #region " Control Help - Properties & Flicker Control"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion
        public SharpGroupBOx() : base()
        {
            Size = new Size(200, 100);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            //BackColor = Color.Transparent
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(210, 220, 230);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);

            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(Color.FromArgb(43, 53, 63));

            LinearGradientBrush s2 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 25), Color.FromArgb(35, 45, 55), Color.FromArgb(50, Color.White), 90);
            G.FillRectangle(s2, new Rectangle(1, 14, Width - 3, 13));
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 3, 25), Color.FromArgb(90, Color.White), Color.FromArgb(35, 45, 55), 90);
            G.FillRectangle(s1, new Rectangle(1, 1, Width - 3, 13));


            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), 0, 0, Width - 1, 28);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(111, 121, 131))), 1, 1, Width - 3, 26);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), 0, 30, Width - 1, Height - 31);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(60, 70, 80))), 1, 31, Width - 3, Height - 33);

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 30, 30))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(20, 30, 40))), 1, 29, Width - 2, 29);

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(1, 4, Width, 20), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Image)bmp.Clone(), 0, 0);
            G.Dispose();
            bmp.Dispose();
        }
    }

}


