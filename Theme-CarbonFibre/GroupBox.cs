// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberGroupBox : ThemeContainer154
    {

        #region "Properties"
        public CarbonFiberGroupBox()
        {
            ControlMode = true;
            TransparencyKey = Color.Fuchsia;
            Font = new Font("Verdana", 8);
            this.Size = new Size(172, 105);
        }

        protected override void ColorHook()
        {
            // another waste of time HAHA !!
        }
        #endregion

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            ///''''''' Draw Header '''''''

            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(1, 1, Width - 3, Height - 3));

            LinearGradientBrush Header = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, 26), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270);
            G.FillRectangle(Header, new Rectangle(0, 0, Width - 1, 26));

            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, new Rectangle(0, 0, Width - 1, 26));
            G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, Width - 1, 13);

            G.DrawLine(new Pen(Color.FromArgb(42, 42, 42)), 0, 13, Width - 1, 13);
            // Cuz it has a bug dont worry i will fix it =)

            G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(0, 0, Width - 1, Height - 1));
            // Draw Border
            //G.DrawRectangle(New Pen(Color.FromArgb(6, 6, 6)), New Rectangle(0, 0, Width - 1, 27))
            //G.DrawRectangle(New Pen(Color.FromArgb(32, 32, 32)), New Rectangle(0, 0, Width - 1, Height - 1))


            G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(1, 1, Width - 3, 25));
            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(1, 1, Width - 3, 24));

            ///''''''' Draw Text and Shadw '''''''
            //G.DrawString(Text, Font, New SolidBrush(Color.Black), New Point(9, 7)) ' Text Shadow
            //G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(255, 150, 0)), New Point(8, 6))

            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.FromArgb(255, 150, 0)), HorizontalAlignment.Center, 2, 2);

            //DrawCorners(Color.FromArgb(22, 22, 22), 1)
            //DrawCorners(Color.FromArgb(22, 22, 22))
        }


    }


}


