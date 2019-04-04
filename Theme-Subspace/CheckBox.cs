// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.SubSpace
{
    [DefaultEvent("CheckedChanged")]
    public class SubspaceCheckbox : ThemeControl154
    {

        public SubspaceCheckbox()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            LockHeight = 15;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            Rectangle CheckRectangle = new Rectangle(1, 1, Height - 3, Height - 3);

            G.Clear(BackColor);
            DrawGradient(Color.FromArgb(124, 175, 214), Color.FromArgb(95, 141, 205), CheckRectangle, 45);
            G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, Height - 1, Height / 2);


            switch (_Checked)
            {
                case true:
                    //Put your checked state here
                    DrawGradient(Color.FromArgb(84, 182, 255), Color.FromArgb(45, 134, 255), CheckRectangle, 45);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), 0, 0, Height - 1, Height / 2);
                    G.DrawRectangle(new Pen(Color.FromArgb(84, 177, 255)), CheckRectangle);
                    break;
                case false:
                    break;
                    //Put your unchecked state here

            }

            DrawText(Brushes.DodgerBlue, HorizontalAlignment.Left, 18, 1);
        }


        private bool _Checked { get; set; }
        public bool Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
        }
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
    }

}




