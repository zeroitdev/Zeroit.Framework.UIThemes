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
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Metro
{

    [DefaultEvent("CheckedChanged")]
    public class MetroUIRadio : ThemeControl154
    {


        public MetroUIRadio()
        {
            //LockHeight = 30;
            SetColor("Text", Color.Black);
            SetColor("Backcolor", Color.White);
            Font = new Font("Segoe UI", 12);
            Width = 120;
        }

        private int X;
        private Color TextColor;

        private Color BG;
        protected override void ColorHook()
        {
            TextColor = GetColor("Text");
            BG = GetColor("Backcolor");
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void PaintHook()
        {
            G.Clear(BG);
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (_Checked)
            {
                G.DrawEllipse(new Pen(Color.Black), new Rectangle(new Point(0, 0), new Size(20, 20)));
                G.FillEllipse(new SolidBrush(Color.FromArgb(53, 157, 181)), new Rectangle(new Point(3, 3), new Size(14, 14)));
            }
            else
            {
                G.DrawEllipse(new Pen(Color.Black), new Rectangle(new Point(0, 0), new Size(20, 20)));
                //G.FillEllipse(New SolidBrush(Color.FromArgb(53, 157, 181)), New Rectangle(New Point(3, 3), New Size(14, 14)))
                DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 22, 0);
            }



            if (_Checked)
                DrawText(new SolidBrush(TextColor), HorizontalAlignment.Left, 22, 0);
        }

        private int _Field = 21;
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
                if (!object.ReferenceEquals(C, this) && C is MetroUIRadio)
                {
                    ((MetroUIRadio)C).Checked = false;
                }
            }
        }

    }

}


