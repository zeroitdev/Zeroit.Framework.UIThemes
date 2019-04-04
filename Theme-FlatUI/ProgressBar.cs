// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
using System.ComponentModel;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{
    public class FlatProgressBar : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private int _Value = 0;

        private int _Maximum = 100;
        #endregion

        #region " Properties"

        #region " Control"

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

        #region " Colors"

        [Category("Colors")]
        public Color ProgressColor
        {
            get { return _ProgressColor; }
            set { _ProgressColor = value; }
        }

        [Category("Colors")]
        public Color DarkerProgress
        {
            get { return _DarkerProgress; }
            set { _DarkerProgress = value; }
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 42;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _ProgressColor = _FlatColor;

        private Color _DarkerProgress = Color.FromArgb(23, 148, 92);
        #endregion

        public FlatProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
            Height = 42;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(0, 24, W, H);
            dynamic GP = default(GraphicsPath);
            dynamic GP2 = default(GraphicsPath);
            GraphicsPath GP3 = new GraphicsPath();

            var _with15 = G;
            _with15.SmoothingMode = SmoothingMode.HighQuality;
            _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with15.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with15.Clear(BackColor);

            //-- Progress Value
            int iValue = Convert.ToInt32(_Value / _Maximum * Width);

            switch (Value)
            {
                case 0:
                    //-- Base
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    _with15.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                case 100:
                    //-- Base
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    _with15.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                default:
                    //-- Base
                    _with15.FillRectangle(new SolidBrush(_BaseColor), Base);

                    //--Progress
                    GP.AddRectangle(new Rectangle(0, 24, iValue - 1, H - 1));
                    _with15.FillPath(new SolidBrush(_ProgressColor), GP);

                    //-- Hatch Brush
                    HatchBrush HB = new HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor);
                    _with15.FillRectangle(HB, new Rectangle(0, 24, iValue - 1, H - 1));

                    //-- Balloon
                    Rectangle Balloon = new Rectangle(iValue - 18, 0, 34, 16);
                    GP2 = Helpers.RoundRec(Balloon, 4);
                    _with15.FillPath(new SolidBrush(_BaseColor), GP2);

                    //-- Arrow
                    GP3 = Helpers.DrawArrow(iValue - 9, 16, true);
                    _with15.FillPath(new SolidBrush(_BaseColor), GP3);

                    //-- Value > You can add "%" > value & "%"
                    _with15.DrawString(Value.ToString(), new Font("Segoe UI", 10), new SolidBrush(_ProgressColor), new Rectangle(iValue - 11, -2, W, H), NearSF);
                    break;
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }


}

