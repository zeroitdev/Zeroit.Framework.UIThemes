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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Deumos
{

    [DefaultEvent("CheckedChanged")]
    public class DeumosRadioButton : ThemeControl153
    {

        public DeumosRadioButton()
        {
            LockHeight = 16;

            SetColor("Gloss1", 38, Color.White);
            SetColor("Gloss2", 5, Color.White);
            SetColor("Checked1", Color.Transparent);
            SetColor("Checked2", 40, Color.White);
            SetColor("Unchecked1", 8, 8, 8);
            SetColor("Unchecked2", 16, 16, 16);
            SetColor("Glow", 5, Color.White);
            SetColor("Text", Color.White);
            SetColor("InnerOutline", Color.Black);
            SetColor("OuterOutline", 15, Color.White);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("Gloss1");
            C2 = GetColor("Gloss2");
            C3 = GetColor("Checked1");
            C4 = GetColor("Checked2");
            C5 = GetColor("Unchecked1");
            C6 = GetColor("Unchecked2");

            B1 = new SolidBrush(GetColor("Glow"));
            B2 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("InnerOutline"));
            P2 = new Pen(GetColor("OuterOutline"));
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Pen P1;
        private Pen P2;
        private SolidBrush B1;

        private SolidBrush B2;
        private Rectangle R1;
        private Rectangle R2;

        private LinearGradientBrush G1;
        protected override void PaintHook()
        {
            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;
            R1 = new Rectangle(4, 2, _Field - 8, (_Field / 2) - 1);
            R2 = new Rectangle(4, 2, _Field - 8, (_Field / 2));

            G1 = new LinearGradientBrush(R2, C1, C2, 90);
            G.FillEllipse(G1, R1);

            R1 = new Rectangle(2, 2, _Field - 4, _Field - 4);

            if (_Checked)
            {
                G1 = new LinearGradientBrush(R1, C3, C4, 90);
            }
            else
            {
                G1 = new LinearGradientBrush(R1, C5, C6, 90);
            }
            G.FillEllipse(G1, R1);

            if (State == MouseState.Over)
            {
                R1 = new Rectangle(2, 2, _Field - 4, _Field - 4);
                G.FillEllipse(B1, R1);
            }

            DrawText(B2, HorizontalAlignment.Left, _Field + 3, 0);

            G.DrawEllipse(P1, 2, 2, _Field - 4, _Field - 4);
            G.DrawEllipse(P2, 1, 1, _Field - 2, _Field - 2);

        }

        private int _Field = 16;
        public int Field
        {
            get { return _Field; }
            set
            {
                if (value < 4)
                    return;
                _Field = value;
                LockHeight = value;
                Invalidate();
            }
        }

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

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
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
                if (!object.ReferenceEquals(C, this) && C is DeumosRadioButton)
                {
                    ((DeumosRadioButton)C).Checked = false;
                }
            }
        }

    }


}


