// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NamelessRadioButton : ThemeControl154
    {
        private bool _Checked;
        int X;
        #region "Properties"
        private Color MainColor = Color.FromArgb(20, 20, 20);
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


        public Color Color
        {
            get { return MainColor; }
            set
            {
                MainColor = value;
                this.Invalidate();
            }
        }
        #endregion
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

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
                if (!object.ReferenceEquals(C, this) && C is NamelessRadioButton)
                {
                    ((NamelessRadioButton)C).Checked = false;
                }
            }
        }
        public NamelessRadioButton()
        {
            // Size = New Size(152, 14)
            // MinimumSize = New Size(152, 14)
            // MaximumSize = New Size(152, 14)
            DoubleBuffered = true;
            LockHeight = 14;
        }

        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            //G.Clear(this.Color);
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.DrawEllipse(new Pen(Color.FromArgb(150, 150, 150)), new Rectangle(0, 0, Height - 2, Height - 1));
            LinearGradientBrush EllGrad = new LinearGradientBrush(new Rectangle(0, 0, Height - 2, Height), Color.DimGray, Color.Black, 90);
            G.FillEllipse(EllGrad, new Rectangle(0, 0, Height - 2, Height - 1));


            if (Checked)
            {
                LinearGradientBrush CKelGrd = new LinearGradientBrush(new Rectangle(2, 2, 8, 8), Color.White, Color.Black, 90);
                G.FillEllipse(CKelGrd, new Rectangle(2, 2, 8, 8));
            }



            DrawText(Brushes.White, HorizontalAlignment.Left, 16, 1);

        }


    }


}