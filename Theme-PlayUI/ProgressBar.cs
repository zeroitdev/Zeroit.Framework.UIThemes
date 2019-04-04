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
#region  Imports

using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
	
#endregion
	
	

namespace Zeroit.Framework.UIThemes.PlayUI
{

    #region  ProgressBar

    public class PlayUIProgressBar : Control
    {

        #region  RoundRect

        private GraphicsPath CreateRoundPath;

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        #endregion
        #region  Custom Properties

        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }
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

                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                if (value > _Value)
                {
                    _Value = value;
                }

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
                if (value > _Maximum)
                {
                    value = Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        private Color _ValueColour = Color.FromArgb(42, 119, 220);
        [Category("Colours")]
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

        #endregion

        private double Percent;

        public PlayUIProgressBar()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(100, 10);
        }

        public void Increment(int value)
        {
            this._Value += value;
            Invalidate();
        }

        public void Deincrement(int value)
        {
            this._Value -= value;
            Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            this.Percent = (double)this._Value / (double)this._Maximum * 100;

            int Slope = 8;
            Rectangle MyRect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath BorderPath = CreateRound(MyRect, Slope);
            G.FillPath(new SolidBrush(Color.FromArgb(51, 52, 55)), BorderPath);

            ColorBlend ProgressBlend = new ColorBlend(3);
            ProgressBlend.Colors[0] = _ValueColour;
            ProgressBlend.Colors[1] = _ValueColour;
            ProgressBlend.Colors[2] = _ValueColour;
            ProgressBlend.Positions = new Single[] { 0, 0.5F, 1 };
            LinearGradientBrush LGB = new LinearGradientBrush(MyRect, Color.Black, Color.Black, 90.0F);
            LGB.InterpolationColors = ProgressBlend;

            Rectangle ProgressRect = new Rectangle(1, 1, (int)Math.Round(((double)this.Width / (double)this._Maximum * (double)this._Value - 3.0)), this.Height - 3);
            GraphicsPath ProgressPath = CreateRound(ProgressRect, Slope);

            if (Percent >= 1)
            {
                G.FillPath(LGB, ProgressPath);
            }

            try
            {
                G.DrawPath(new Pen(Color.FromArgb(51, 52, 55)), BorderPath);
            }
            catch (Exception)
            {
            }
        }
    }

    #endregion

}