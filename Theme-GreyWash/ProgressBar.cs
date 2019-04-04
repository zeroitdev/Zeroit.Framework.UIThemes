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

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashProgressBar : Control
    {
        #region  Properties 

        private int _Maximum;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
                Invalidate();
            }
        }

        private int _Minimum;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                Invalidate();
            }
        }

        #endregion

        public GreywashProgressBar()
        {
            Maximum = 100;
            Minimum = 0;
            Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;
            G.DrawRectangle(new Pen(Color.DarkGray), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(0, 0, Width - 1, Height - 1));
            
            if (_Value > 2)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
            }
            
            else if (_Value > 0)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
                G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new Rectangle(0, 0, Convert.ToInt32(Value / Maximum * Width), Height));
            }
        }

    }

}
