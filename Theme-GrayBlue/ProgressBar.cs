// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GrayBlue
{
    public class GrayBlueProgressBar : Control
    {
        #region  Properties 

        private int _minimum;
        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;

                if (value > _maximum)
                {
                    _maximum = value;
                }
                if (value > _value)
                {
                    _value = value;
                }

                Invalidate();
            }
        }

        private int _maximum;
        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;

                if (_maximum < 1)
                {
                    _maximum = 1;
                }

                if (value < _minimum)
                {
                    _minimum = value;
                }
                if (value < _value)
                {
                    _value = value;
                }

                Invalidate();
            }
        }

        public delegate void ValueChangedEventHandler();
        public event ValueChangedEventHandler ValueChanged;
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < _minimum)
                {
                    _value = _minimum;
                }
                else if (value > _maximum)
                {
                    _value = _maximum;
                }
                else
                {
                    _value = value;
                }

                Invalidate();
                if (ValueChanged != null)
                    ValueChanged();
            }
        }

        #endregion

        public GrayBlueProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            _maximum = 100;
            _minimum = 0;
            _value = 0;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);

            G.FillPath(DesignFunctions.ToBrush(85, 85, 85), DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));

            LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135));

            G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(0, 1, (Width - 1) * _value / _maximum, Height - 3, 3));
            G.DrawPath(DesignFunctions.ToPen(150, Color.Black), DesignFunctions.RoundRect(0, 1, (Width - 1) * _value / _maximum, Height - 3, 3));

            if (_value > 0)
            {
                G.SmoothingMode = SmoothingMode.AntiAlias;

                G.SetClip(DesignFunctions.RoundRect(0, 0, (Width - 1) * _value / _maximum - 1, Height - 1, 3));
                for (var i = 0; i <= (Width - 1) * _value / _maximum; i += 25)
                {
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(35, Color.White)), 10F), new Point(i, 0 - 5), new Point(i + 25, Height + 10));
                }
                G.ResetClip();

                G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(2, 1), new Point((Width - 3) * _value / _maximum - 3, 1));

                G.SmoothingMode = SmoothingMode.None;
            }

            G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 3));
        }
    }
}
