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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    public class LoyalProgressBar : Control
    {

        #region " Back End "

        #region " Variables "
        private int _Value = 0;
        #endregion
        private int _Maximum = 100;

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
                //            switch (value) {
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

        #region " Properties "
        private Color _ProgressColor = Color.FromArgb(102, 51, 153);
        [Category("Header Properties")]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set
            {
                _ProgressColor = value;
                Invalidate();
            }
        }
        #endregion

        public LoyalProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (Parent.BackColor == Color.FromArgb(40, 40, 40))
            {
                G.Clear(Color.FromArgb(35, 35, 35));
            }
            else
            {
                G.Clear(Color.FromArgb(40, 40, 40));
            }
            int _Progress = Convert.ToInt32(_Value / _Maximum * Width);
            G.DrawRectangle(new Pen(Color.FromArgb(18, 18, 18)), 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 0, _Progress - 1, Height));
            G.DrawLine(new Pen(Color.FromArgb(30, Color.White)), new Point(0, 0), new Point(_Progress - 1, 0));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(Width - 1, 0, 1, 1));
            G.DrawLine(new Pen(Color.FromArgb(70, Color.Black)), new Point(0, Height), new Point(_Progress - 1, Height));
            G.InterpolationMode = (InterpolationMode)7;
        }
    }

}


