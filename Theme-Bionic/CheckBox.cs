// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Bionic
{
    public class BionicCheckBox : Control
    {

        #region " Declarations "
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        private MouseState _State = MouseState.None;
        #endregion
        private bool _Checked;

        #region " Properties "
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!_Checked)
                Checked = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.Clear(Parent.BackColor);

            G.FillRectangle(new SolidBrush(Color.FromArgb(29, 29, 29)), new Rectangle(0, 0, 15, 15));
            switch (_State)
            {
                case MouseState.Hover:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(5, Color.White)), new Rectangle(0, 0, 15, 15));
                    break;
            }
            if (Checked)
            {
                G.FillRectangle(new LinearGradientBrush(new Point(4, 4), new Point(4, 11), Color.FromArgb(252, 132, 19), Color.FromArgb(212, 75, 31)), new Rectangle(4, 4, 7, 7));
            }
            G.DrawString(Text, new Font("Arial", 9), Brushes.White, new Point(18, 0));
        }

    }


}


