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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    public class ValleyProgressbar : Control
    {
        #region  Variables

        private int _Value = 0;
        private int _Maximum = 100;

        #endregion

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

        #region Events
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

        public ValleyProgressbar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;

            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(Color.FromArgb(223, 223, 223));
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);
           
            if (Value == 0)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            //ORIGINAL LINE: Case _Maximum
            else if (Value == _Maximum)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            //ORIGINAL LINE: Case Else
            else
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(223, 223, 223)), new Rectangle(0, 0, Width, Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(50, 124, 244)), new Rectangle(0, 0, ProgVal - 1, Height));
            }
            G.InterpolationMode = (InterpolationMode)7;
            base.OnPaint(e);


        }
    }
}


