// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconTxtBox : TextBox
    {

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 15:
                    Invalidate();
                    base.WndProc(ref m);
                    this.CustomPaint();
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                default:
                    base.WndProc(ref m);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }
        }

        public ReconTxtBox()
        {
            Font = new Font("Microsoft Sans Serif", 8);
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(28, 28, 28);
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void CustomPaint()
        {
            Pen p = new Pen(Color.Black);
            Pen o = new Pen(Color.FromArgb(45, 45, 45));
            CreateGraphics().DrawLine(p, 0, 0, Width, 0);
            CreateGraphics().DrawLine(p, 0, Height - 1, Width, Height - 1);
            CreateGraphics().DrawLine(p, 0, 0, 0, Height - 1);
            CreateGraphics().DrawLine(p, Width - 1, 0, Width - 1, Height - 1);

            CreateGraphics().DrawLine(o, 1, 1, Width - 2, 1);
            CreateGraphics().DrawLine(o, 1, Height - 2, Width - 2, Height - 2);
            CreateGraphics().DrawLine(o, 1, 1, 1, Height - 2);
            CreateGraphics().DrawLine(o, Width - 2, 1, Width - 2, Height - 2);
        }
    }

}


