// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Element
{

    public class ElementProgressBar : Control
    {

        #region " Variables "
        private int _Value = 0;
        #endregion
        private int _Maximum = 100;

        #region " Properties "
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

        private Color _ProgressColor = Color.FromArgb(231, 75, 60);
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set { _ProgressColor = value; }
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

        public ElementProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            //G.Clear(BackColor);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;

            G.Clear(Parent.BackColor);
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
            G.DrawRectangle(new Pen(Color.LightGray), new Rectangle(0, 0, Width, Height));
            G.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 0, ProgVal, Height));
            G.InterpolationMode = (InterpolationMode)7;
        }
    }


}


