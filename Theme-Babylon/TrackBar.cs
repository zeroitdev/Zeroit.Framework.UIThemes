// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Babylon
{
    #region  TrackBar 

    [DefaultEvent("ValueChanged")]
    public class BabylonTrackBar : Control
    {
        #region  Enums 

        public enum ValueDivisor : int
        {
            By1 = 1,
            By10 = 10,
            By100 = 100,
            By1000 = 1000
        }

        #endregion
        #region  Variables 

        private GraphicsPath PipeBorder;
        private GraphicsPath TrackBarHandle;
        private Rectangle TrackBarHandleRect;
        private Rectangle ValueRect;
        private LinearGradientBrush VlaueLGB;
        private LinearGradientBrush TrackBarHandleLGB;
        private bool Cap;
        private int ValueDrawer;

        private int _Minimum = 0;
        private int _Maximum = 10;
        private int _Value = 0;
        private Color _ValueColour = Color.FromArgb(224, 224, 224);
        private bool _DrawHatch = true;
        private bool _DrawValueString = false;
        private bool _JumpToMouse = false;
        private ValueDivisor DividedValue = ValueDivisor.By1;

        #endregion
        #region  Custom Properties 

        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {

                if (value >= _Maximum)
                {
                    value = _Maximum - 10;
                }
                if (_Value < value)
                {
                    _Value = value;
                }

                _Minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {

                if (value <= _Minimum)
                {
                    value = _Minimum + 10;
                }
                if (_Value > value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        public delegate void ValueChangedEventHandler();
        public event ValueChangedEventHandler ValueChanged;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    if (value < _Minimum)
                    {
                        _Value = _Minimum;
                    }
                    else
                    {
                        if (value > _Maximum)
                        {
                            _Value = _Maximum;
                        }
                        else
                        {
                            _Value = value;
                        }
                    }
                    Invalidate();
                    if (ValueChanged != null)
                        ValueChanged();
                }
            }
        }

        public ValueDivisor ValueDivison
        {
            get
            {
                return DividedValue;
            }
            set
            {
                DividedValue = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public float ValueToSet
        {
            get
            {
                return Convert.ToSingle((float)_Value / (float)DividedValue);
            }
            set
            {
                value = Convert.ToInt32(value * (float)DividedValue);
            }
        }

        public Color ValueColour
        {
            get
            {
                return _ValueColour;
            }
            set
            {
                _ValueColour = value;
                Invalidate();
            }
        }

        public bool DrawHatch
        {
            get
            {
                return _DrawHatch;
            }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }

        public bool DrawValueString
        {
            get
            {
                return _DrawValueString;
            }
            set
            {
                _DrawValueString = value;
                if (_DrawValueString == true)
                {
                    Height = 40;
                }
                else
                {
                    Height = 22;
                }
                Invalidate();
            }
        }

        public bool JumpToMouse
        {
            get
            {
                return _JumpToMouse;
            }
            set
            {
                _JumpToMouse = value;
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap == true && e.X > -1 && e.X < (Width + 1))
            {
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / Width));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ValueDrawer = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11));
                TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);
                Cap = TrackBarHandleRect.Contains(e.Location);
                if (_JumpToMouse)
                {
                    Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / Width));
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        #endregion

        public BabylonTrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            _DrawHatch = true;
            Size = new Size(80, 22);
            MinimumSize = new Size(37, 22);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_DrawValueString == true)
            {
                Height = 40;
            }
            else
            {
                Height = 22;
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            HatchBrush Hatch = new HatchBrush(HatchStyle.WideDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);

            G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            PipeBorder = RoundRectangle.RoundRect(1, 6, Width - 3, 8, 3);

            try
            {
                ValueDrawer = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11));
            }
            catch (Exception ex)
            {
            }

            TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 10, 20);

            G.SetClip(PipeBorder); // Set the clipping region of this Graphics to the specified GraphicsPath

            ValueRect = new Rectangle(1, 7, TrackBarHandleRect.X + TrackBarHandleRect.Width - 2, 7);
            VlaueLGB = new LinearGradientBrush(ValueRect, _ValueColour, _ValueColour, 90.0F);

            G.FillRectangle(VlaueLGB, ValueRect);

            if (_DrawHatch == true)
            {
                G.FillRectangle(Hatch, ValueRect);
            }

            G.ResetClip(); // Reset the clip region of this Graphics to an infinite region

            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), PipeBorder); // Draw pipe border

            TrackBarHandle = RoundRectangle.RoundRect(TrackBarHandleRect, 3);
            TrackBarHandleLGB = new LinearGradientBrush(ClientRectangle, SystemColors.Control, SystemColors.Control, 90.0F);

            // Fill the handle body with the specified color gradient
            G.FillPath(TrackBarHandleLGB, TrackBarHandle);
            // Draw handle borders
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), TrackBarHandle);

            if (_DrawValueString == true)
            {
                G.DrawString(ValueToSet.ToString(), Font, Brushes.Gray, 0, 25);
            }
        }
    }

    #endregion
}