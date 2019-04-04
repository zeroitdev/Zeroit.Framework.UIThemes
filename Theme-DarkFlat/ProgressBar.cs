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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    public class DarkFlatProgressBar : Control
    {
        #region  Variables

        private int W;
        private int H;
        private int _Value = 0;
        private int _Maximum = 100;

        #endregion

        #region  Properties

        #region  Control

        [Category("Control")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                
                if (value < _Value)
                {
                    _Value = value;
                }
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
                
                if (value > _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }
                _Value = value;
                Invalidate();
            }
        }

        #endregion

        #region  Colors

        [Category("Colors")]
        public Color ProgressColor
        {
            get
            {
                return _ProgressColor;
            }
            set
            {
                _ProgressColor = value;
            }
        }

        [Category("Colors")]
        public Color DarkerProgress
        {
            get
            {
                return _DarkerProgress;
            }
            set
            {
                _DarkerProgress = value;
            }
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

        #region  Colors

        private Color _BaseColor = Color.FromArgb(60, 60, 60);
        private Color _ProgressColor = Color.FromArgb(0, 170, 220);
        private Color _DarkerProgress = Color.FromArgb(0, 170, 220);

        #endregion

        public DarkFlatProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(50, 50, 50);
            Height = 30;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(0, 24, W, H);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();
            GraphicsPath GP3 = new GraphicsPath();

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            //-- Progress Value
            int iValue = Convert.ToInt32(_Value / (double)_Maximum * Width);

            switch (Value)
            {
                case 0:
                    //-- Base
                    Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    Helpers.G.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                case 100:
                    //-- Base
                    Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                    //--Progress
                    Helpers.G.FillRectangle(new SolidBrush(_ProgressColor), new Rectangle(0, 24, iValue - 1, H - 1));
                    break;
                default:
                    //-- Base
                    Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);

                    //--Progress
                    GP.AddRectangle(new Rectangle(0, 24, iValue - 1, H - 1));
                    Helpers.G.FillPath(new SolidBrush(_ProgressColor), GP);

                    //-- Hatch Brush
                    HatchBrush HB = new HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor);
                    Helpers.G.FillRectangle(HB, new Rectangle(0, 24, iValue - 1, H - 1));

                    //-- Balloon
                    Rectangle Balloon = new Rectangle(iValue - 18, 0, 34, 16);
                    GP2 = Helpers.RoundRec(Balloon, 4);
                    Helpers.G.FillPath(new SolidBrush(_BaseColor), GP2);

                    //-- Arrow
                    GP3 = Helpers.DrawArrow(iValue - 9, 16, true);
                    Helpers.G.FillPath(new SolidBrush(_BaseColor), GP3);

                    //-- Value > You can add "%" > value & "%"
                    Helpers.G.DrawString(Value.ToString(), new Font("Segoe UI", 10), new SolidBrush(_ProgressColor), new Rectangle(iValue - 11, -2, W, H), Helpers.NearSF);
                    break;
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }

    }

}



