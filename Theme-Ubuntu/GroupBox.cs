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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{
    public class UbuntuGroupBox : ContainerControl
    {

        public UbuntuGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TopBar = new Rectangle(0, 0, Width - 1, 20);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            base.OnPaint(e);

            G.Clear(Color.Transparent);

            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush bodygrade = new LinearGradientBrush(ClientRectangle, Color.White, Color.White, 120);
            G.FillPath(bodygrade, Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

            LinearGradientBrush outerBorder = new LinearGradientBrush(ClientRectangle, Color.FromArgb(50, 50, 50), Color.DimGray, 90);
            G.DrawPath(new Pen(outerBorder), Draw.RoundRect(new Rectangle(0, 12, Width - 1, Height - 15), 1));

            LinearGradientBrush lbb = new LinearGradientBrush(TopBar, Color.FromArgb(87, 86, 81), Color.FromArgb(60, 59, 55), 90);
            G.FillPath(lbb, Draw.RoundRect(TopBar, 1));

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), Draw.RoundRect(TopBar, 2));

            Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);

            G.DrawString(Text, drawFont, new SolidBrush(Color.White), TopBar, new StringFormat
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


