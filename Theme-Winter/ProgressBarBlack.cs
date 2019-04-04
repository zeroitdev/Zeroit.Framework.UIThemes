// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBarBlack.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Winter
{

    public class WinterProgressBarBlack : Control
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

                //			switch (value) {
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
        
        public WinterProgressBarBlack()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;

            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;

            G.Clear(Color.FromArgb(180, 194, 212));

            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);

            G.FillRectangle(new SolidBrush(Color.FromArgb(17, 17, 17)), new Rectangle(0, 0, ProgVal - 1, Height));
            G.FillRectangle(new SolidBrush(Color.FromArgb(67, 68, 69)), new Rectangle(0, 0, ProgVal - 1, Height / 2));

            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(0, 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 1, 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(0, Height - 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(1, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 1, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 1, Height - 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(211, 222, 228)), new Rectangle(Width - 2, Height - 1, 1, 1));

            G.InterpolationMode = (InterpolationMode)7;
        }
    }

}

