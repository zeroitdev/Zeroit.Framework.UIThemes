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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Element
{

    public class ElementGroupBox : ContainerControl
    {

        #region " Properties "
        private Color _SideColor = Color.FromArgb(231, 75, 60);
        public Color SideColor
        {
            get { return _SideColor; }
            set { _SideColor = value; }
        }

        #endregion

        public ElementGroupBox()
        {
            Size = new Size(200, 100);
            BackColor = Color.FromArgb(32, 32, 32);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(32, 32, 32));

            G.FillRectangle(new SolidBrush(_SideColor), new Rectangle(0, 0, 7, Height));
            G.DrawString(Text, new Font("Arial", 9), Brushes.White, new Point(10, 4));
        }
    }


}


