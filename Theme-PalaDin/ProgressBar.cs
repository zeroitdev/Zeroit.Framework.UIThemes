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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PaladinProgressBar : ThemeControl154
    {
        private Timer GlowAnimation = new Timer();
        private Color _GlowColor = Color.FromArgb(90, 255, 255, 255);
        private bool _Animate = true;
        private Int32 _Value = 0;
        private Color _HighlightColor = Color.Silver;
        private Color _BackgroundColor = Color.FromArgb(150, 150, 150);
        #region "Properties"
        private Color _StartColor = Color.FromArgb(110, 110, 110);
        public Color Color
        {
            get { return _StartColor; }
            set
            {
                _StartColor = value;
                this.Invalidate();
            }
        }
        public bool Animate
        {
            get { return _Animate; }
            set
            {
                _Animate = value;
                if (value == true)
                {
                    GlowAnimation.Start();
                }
                else
                {
                    GlowAnimation.Stop();
                }
                this.Invalidate();
            }
        }
        public Color GlowColor
        {
            get { return _GlowColor; }
            set
            {
                _GlowColor = value;
                this.Invalidate();
            }
        }
        public Int32 Value
        {
            get { return _Value; }
            set
            {
                if (value > 100 | value < 0)
                    return;
                _Value = value;
                if (value < 100)
                    GlowAnimation.Start();
                if (value == 100)
                    GlowAnimation.Stop();
                this.Invalidate();
            }
        }
        public Color BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                this.Invalidate();
            }
        }
        public Color HighlightColor
        {
            get { return _HighlightColor; }
            set
            {
                _HighlightColor = value;
                this.Invalidate();
            }
        }
        #endregion

        public PaladinProgressBar()
        {
            if (!InDesignMode())
            {
                GlowAnimation.Interval = 15;
                if (Value < 100)
                    GlowAnimation.Start();

                GlowAnimation.Tick += GlowAnimation_Tick;
            }
        }
        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        protected override void ColorHook()
        {
        }


        private int _mGlowPosition = -325;

        protected override void PaintHook()
        {


            //   -------------------Draw Background for the MBProgressBar--------------------
            Rectangle BackRectangle = this.ClientRectangle;
            BackRectangle.Width = BackRectangle.Width - 1;
            BackRectangle.Height = BackRectangle.Height - 1;
            GraphicsPath GrafP = RoundRect(BackRectangle, 2, 2, 2, 2);
            G.FillPath(new SolidBrush(this.BackgroundColor), GrafP);


            //--------------------Draw Background Shadows for MBProgrssBar------------------
            Rectangle BGSH = new Rectangle(2, 2, 10, this.Height - 5);
            LinearGradientBrush LGBS = new LinearGradientBrush(BGSH, Color.FromArgb(0, 30, 60, 50), Color.Transparent, LinearGradientMode.Horizontal);
            G.FillRectangle(LGBS, BGSH);
            Rectangle BGSRectangle = new Rectangle(this.Width - 12, 2, 10, this.Height - 5);
            LinearGradientBrush LG = new LinearGradientBrush(BGSH, Color.FromArgb(150, 150, 150), Color.FromArgb(0, 10, 30, 20), LinearGradientMode.Horizontal);
            G.FillRectangle(LG, BGSRectangle);


            //----------------------Draw MBProgressBar--------------------	
            Rectangle ProgressRect = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            ProgressRect.Width = Convert.ToInt32((Value * 1f / (100) * this.Width));
            G.FillRectangle(new SolidBrush(this.Color), ProgressRect);


            //----------------------Draw Shadows for MBProgressBar------------------
            Rectangle SHRect = new Rectangle(1, 2, 15, this.Height - 3);
            LinearGradientBrush LGSHP = new LinearGradientBrush(SHRect, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend BColor = new ColorBlend(3);
            BColor.Colors = new Color[] {
            Color.Gray,
            Color.FromArgb(40, 0, 0, 0),
            Color.Transparent
        };
            BColor.Positions = new float[] {
            0f,
            0.2f,
            1f
        };
            LGSHP.InterpolationColors = BColor;

            SHRect.X = SHRect.X - 1;
            G.FillRectangle(LGSHP, SHRect);

            Rectangle Rect1 = new Rectangle(this.Width - 3, 2, 15, this.Height - 3);
            Rect1.X = Convert.ToInt32((Value * 1f / (100) * this.Width) - 14);
            LinearGradientBrush LGSH1 = new LinearGradientBrush(Rect1, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend BColor1 = new ColorBlend(3);
            BColor1.Colors = new Color[] {
            Color.Transparent,
            Color.FromArgb(70, 0, 0, 0),
            Color.Transparent
        };
            BColor1.Positions = new float[] {
            0f,
            0.8f,
            1f
        };
            LGSH1.InterpolationColors = BColor1;

            G.FillRectangle(LGSH1, Rect1);


            //-------------------------Draw Highlight for MBProgressBar-----------------
            Rectangle HLRect = new Rectangle(1, 1, this.Width - 1, 6);
            GraphicsPath HLGPa = RoundRect(HLRect, 2, 2, 0, 0);
            G.SetClip(HLGPa);
            LinearGradientBrush HLGBS = new LinearGradientBrush(HLRect, Color.White, Color.FromArgb(128, Color.White), LinearGradientMode.Vertical);
            G.FillPath(HLGBS, HLGPa);
            G.ResetClip();
            Rectangle HLrect2 = new Rectangle(1, this.Height - 8, this.Width - 1, 6);
            GraphicsPath bp1 = RoundRect(HLrect2, 0, 0, 2, 2);
            G.SetClip(bp1);
            LinearGradientBrush bg1 = new LinearGradientBrush(HLrect2, Color.Transparent, Color.FromArgb(100, this.HighlightColor), LinearGradientMode.Vertical);
            G.FillPath(bg1, bp1);
            G.ResetClip();


            //--------------------Draw Inner Sroke for MBProgressBar--------------
            Rectangle Rect20 = this.ClientRectangle;
            Rect20.X = Rect20.X + 1;
            Rect20.Y = Rect20.Y + 1;
            Rect20.Width -= 3;
            Rect20.Height -= 3;
            GraphicsPath Rect15 = RoundRect(Rect20, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(100, Color.Black)), Rect15);



            //------------------------Draw Glow for MBProgressBar-----------------------
            Rectangle GlowRect = new Rectangle(_mGlowPosition, 0, 60, 30);
            LinearGradientBrush GlowLGBS = new LinearGradientBrush(GlowRect, Color.Gray, Color.Transparent, LinearGradientMode.Horizontal);
            ColorBlend BColor3 = new ColorBlend(4);
            BColor3.Colors = new Color[] {
            Color.Transparent,
            this.GlowColor,
            this.GlowColor,
            Color.Transparent
        };
            BColor3.Positions = new float[] {
            0f,
            0.5f,
            0.6f,
            1f
        };
            GlowLGBS.InterpolationColors = BColor3;
            Rectangle clip = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            clip.Width = Convert.ToInt32((Value * 1f / (100) * this.Width));
            G.SetClip(clip);
            G.FillRectangle(GlowLGBS, GlowRect);
            G.ResetClip();


            //-----------------------Draw Outer Stroke on the Control----------------------------
            Rectangle StrokeRect = this.ClientRectangle;
            StrokeRect.Width = StrokeRect.Width - 1;
            StrokeRect.Height = StrokeRect.Height - 1;
            GraphicsPath GGH = RoundRect(StrokeRect, 2, 2, 2, 2);
            G.DrawPath(new Pen(Color.FromArgb(160, 160, 160)), GGH);
            DrawCorners(Color.FromArgb(150, 150, 150), ClientRectangle);

        }
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X;
            float y = r.Y;
            float w = r.Width;
            float h = r.Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }
        private void GlowAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Animate)
            {
                _mGlowPosition += 4;
                if (_mGlowPosition > this.Width)
                {
                    _mGlowPosition = -10;
                    this.Invalidate();
                }


            }
            else
            {
                GlowAnimation.Stop();

                _mGlowPosition = -50;
            }
        }
    }

}

