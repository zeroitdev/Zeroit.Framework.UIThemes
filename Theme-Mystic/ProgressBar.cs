// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Mystic
{
    public class MysticProgressBar : Control
    {

        #region " Variables "

        private int _Value = 0;

        private int _Maximum = 100;
        #endregion

        #region " Control "
        [Category("Control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 0;
                        Invalidate();
                        break;
                    default:
                        return _Value;
                        Invalidate();
                        break;
                }
            }
            set
            {

                if (value == _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }

                #region Old Code
                //            switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					Invalidate();
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }
        #endregion

        #region " Events "
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 25;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 25;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }
        #endregion

        public MysticProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(Color.FromArgb(32, 37, 41));
            int _Progress = Convert.ToInt32(_Value / _Maximum * Width);
            G.FillRectangle(new SolidBrush(Color.FromArgb(0, 163, 123)), new Rectangle(0, 0, _Progress - 1, Height));
            for (int i = 0; i <= _Progress - 1; i += 16)
            {
                G.DrawLine(new Pen(Color.FromArgb(0, 124, 95), 8), i, 0 - 2, i + 20, Height + 2);
            }
            G.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(80, Color.White), Color.FromArgb(100, Color.Black)), new Rectangle(0, 0, _Progress - 1, Height));
            G.FillRectangle(new SolidBrush(Color.FromArgb(32, 37, 41)), new Rectangle(_Progress - 1, 0, Width - _Progress, Height));

            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, Height - 1, 1, 1));

            G.InterpolationMode = (InterpolationMode)7;
        }
    }

}

