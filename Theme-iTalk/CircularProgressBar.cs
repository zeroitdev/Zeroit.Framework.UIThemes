// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CircularProgressBar.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  Circular ProgressBar 

    public class iTalkProgressBar : Control
    {
        #region  Enums 

        public enum _ProgressShape
        {
            Round,
            Flat
        }

        #endregion
        #region  Variables 

        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private _ProgressShape ProgressShapeVal;

        #endregion
        #region  Custom Properties 

        public long Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        public Color ProgressColor1
        {
            get
            {
                return _ProgressColor1;
            }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor2
        {
            get
            {
                return _ProgressColor2;
            }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public _ProgressShape ProgressShape
        {
            get
            {
                return ProgressShapeVal;
            }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        public iTalkProgressBar()
        {
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            DoubleBuffered = true; // Reduce flicker
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Value)
        {
            this._Value += Value;
            Invalidate();
        }

        public void Decrement(int Value)
        {
            this._Value -= Value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Bitmap B = new Bitmap(Width, Height)) // Create an image buffer
            {
                using (Graphics G = Graphics.FromImage(B))
                {

                    G.SmoothingMode = SmoothingMode.AntiAlias;
                    G.Clear(BackColor);

                    using (LinearGradientBrush LGB = new LinearGradientBrush(ClientRectangle, _ProgressColor1, _ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen P = new Pen(LGB, 14F))
                        {

                            switch (ProgressShapeVal)
                            {
                                case _ProgressShape.Round:
                                    P.StartCap = LineCap.Round;
                                    P.EndCap = LineCap.Round;
                                    break;
                                case _ProgressShape.Flat:
                                    P.StartCap = LineCap.Flat;
                                    P.EndCap = LineCap.Flat;
                                    break;
                            }

                            G.DrawArc(P, Convert.ToInt32(35 / 2.0), Convert.ToInt32(35 / 2.0), Width - 35 - 2, Height - 35 - 2, -90, Convert.ToInt32((360 / (double)_Maximum) * _Value));
                        }
                    }

                    // Draw progress base/center object
                    using (LinearGradientBrush LGB = new LinearGradientBrush(ClientRectangle, Color.FromArgb(52, 52, 52), Color.FromArgb(52, 52, 52), LinearGradientMode.Vertical))
                    {
                        G.FillEllipse(LGB, 24, 24, Width - 24 * 2 - 1, Height - 24 * 2 - 1);
                    }

                    // Draw progress value
                    SizeF MS = G.MeasureString(Convert.ToString(Convert.ToInt32((100 / (double)_Maximum) * _Value)), Font);
                    G.DrawString(Convert.ToString(Convert.ToInt32((100 / (double)_Maximum) * _Value)), Font, Brushes.White, Convert.ToInt32(Width / 2 - MS.Width / 2.0), Convert.ToInt32(Height / 2 - MS.Height / 2.0));

                    e.Graphics.DrawImage(B, 0, 0); // Create the output
                                                   // Dispose drawing objects when finished
                    G.Dispose();
                    B.Dispose();
                }
            }
        }
    }

    #endregion
}