// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{
    [DefaultEvent("CheckedChanged")]
    public class BoosterRadioButton : ThemeControl154
    {

        public BoosterRadioButton()
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
            G.Clear(BackColor);




            switch (_Checked)
            {
                case true:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(129, 10, 10)), 2, 2, Height - 3, Height - 3);
                    G.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.White)), 2, 2, Height - 3, Height / 2);
                    break;
                case false:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(51, 28, 28)), 2, 2, Height - 3, Height - 3);
                    break;
            }

            G.DrawEllipse(new Pen(Color.FromArgb(92, 92, 92)), 2, 2, Height - 3, Height - 3);
            G.DrawEllipse(Pens.Black, 1, 1, Height - 1, Height - 1);

            DrawText(Brushes.White, HorizontalAlignment.Left, 18, 1);
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

