// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="LabelButton.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDisklblButton : Label
    {

        #region " Variables"

        private Color _MDColor_normal;
        private Color _MDColor_click;

        private Color _MDColor_hover;
        #endregion

        #region " Properties"
        public Color MDcolor_normal
        {
            get { return _MDColor_normal; }
            set { _MDColor_normal = value; }
        }

        public Color MDcolor_click
        {
            get { return _MDColor_click; }
            set { _MDColor_click = value; }
        }

        public Color MDcolor_hover
        {
            get { return _MDColor_hover; }
            set { _MDColor_hover = value; }
        }

        #endregion


        public MetroDisklblButton()
        {
            MouseUp += Metro_MouseUp;
            MouseLeave += Metro_MouseLeave;
            MouseHover += MDIcon_MouseHover;
            MouseEnter += Metro_MouseEnter;
            MouseDown += Metro_MouseDown;
            _MDColor_click = Color.DarkGray;
            _MDColor_hover = Color.LightGray;
            _MDColor_normal = Color.Silver;


            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
            this.ForeColor = _MDColor_normal;
        }

        private void Metro_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ForeColor = _MDColor_click;
        }

        private void Metro_MouseEnter(object sender, System.EventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

        private void MDIcon_MouseHover(object sender, EventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

        private void Metro_MouseLeave(object sender, System.EventArgs e)
        {
            this.ForeColor = _MDColor_normal;
        }

        private void Metro_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.ForeColor = _MDColor_hover;
        }

    }

}