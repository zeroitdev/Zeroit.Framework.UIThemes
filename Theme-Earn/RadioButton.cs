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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Earn
{
    [DefaultEvent("CheckedChanged")]
    public class EarnRadiobutton : ThemeControl154
    {
        private int X;

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        protected override void OnCreation()
        {
            InvalidateControls();
        }

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is EarnRadiobutton)
                {
                    ((EarnRadiobutton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        Brush TextColor;
        Pen CircleColor;
        Pen Outline;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            CircleColor = GetPen("Circle");
            Outline = GetPen("Outline");
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)(this.CreateGraphics().MeasureString(Text, Font).Width);
            this.Width = 20 + textSize + 5;
        }

        protected override void PaintHook()
        {
            Color c1 = Color.FromArgb(130, 208, 73);
            Color c2 = Color.FromArgb(79, 178, 52);
            G.Clear(Color.FromArgb(240, 240, 240));
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                G.DrawEllipse(Outline, new Rectangle(3, 3, 12, 12));
                G.FillEllipse(new SolidBrush(Color.FromArgb(79, 178, 52)), new Rectangle(6, 6, 6, 6));
            }
            else
            {
                G.DrawEllipse(Outline, new Rectangle(3, 3, 12, 12));
            }
            G.DrawString(Text, Font, TextColor, new Point(22, 2));
        }

        public EarnRadiobutton()
        {
            SetColor("Text", Color.FromArgb(75, 77, 89));
            SetColor("Circle", Color.FromArgb(214, 214, 214));
            SetColor("Outline", Color.FromArgb(75, 77, 89));
        }
    }


}

