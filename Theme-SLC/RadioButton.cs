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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCRadioButton"
    [DefaultEvent("CheckedChanged")]
    public class SLCRadionButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public SLCRadionButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.White;

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Brushes.Red);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;

                if (_Checked)
                {
                    InvalidateParent();
                }

                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        private void InvalidateParent()
        {
            if (Parent == null)
                return;

            foreach (Control C in Parent.Controls)
            {
                if ((!object.ReferenceEquals(C, this)) && (C is SLCRadionButton))
                {
                    ((SLCRadionButton)C).Checked = false;
                }
            }
        }


        private GraphicsPath GP1;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;

        private Pen P2;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = default(Graphics);
            G = e.Graphics;


            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = new GraphicsPath();
            GP1.AddEllipse(0, 2, Height - 5, Height - 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            // G.FillPath(PB1, GP1)

            G.DrawEllipse(P1, 4, 4, Height - 11, Height - 11);
            // G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)

            if (_Checked)
            {
                GraphicsPath GPF = new GraphicsPath();
                GPF.AddEllipse(new Rectangle((int)(Height - 18.5), Height - 19, 12, 12));
                PathGradientBrush PB3 = default(PathGradientBrush);
                PB3 = new PathGradientBrush(GPF);
                PB3.CenterPoint = new Point((int)(Height - 18.5), Height - 20);
                PB3.CenterColor = Color.FromArgb(56, 142, 196);
                PB3.SurroundColors = new Color[] { Color.FromArgb(64, 106, 140) };
                PB3.FocusScales = new PointF(0.9f, 0.9f);


                G.FillPath(PB3, GPF);

                G.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
                G.SetClip(GPF);
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle(Height - 16, Height - 18, 6, 6));
                G.ResetClip();
            }

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);


            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseDown(e);
        }

    }
    #endregion

}

