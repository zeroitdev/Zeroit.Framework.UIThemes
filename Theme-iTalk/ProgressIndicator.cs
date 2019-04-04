// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressIndicator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  Progress Indicator 

    public class iTalkProgressIndicator : Control
    {
        #region  Variables 

        private readonly SolidBrush BaseColor = new SolidBrush(Color.DarkGray);
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.DimGray);
        private readonly Timer AnimationSpeed = new Timer();

        private PointF[] FloatPoint;
        private BufferedGraphics BuffGraphics;
        private int IndicatorIndex;
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        #endregion
        #region  Custom Properties 

        public Color P_BaseColor
        {
            get
            {
                return BaseColor.Color;
            }
            set
            {
                BaseColor.Color = value;
            }
        }

        public Color P_AnimationColor
        {
            get
            {
                return AnimationColor.Color;
            }
            set
            {
                AnimationColor.Color = value;
            }
        }

        public int P_AnimationSpeed
        {
            get
            {
                return AnimationSpeed.Interval;
            }
            set
            {
                AnimationSpeed.Interval = value;
            }
        }

        #endregion
        #region  EventArgs 

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeed.Enabled = this.Enabled;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeed.Tick += AnimationSpeed_Tick;
            AnimationSpeed.Start();
        }

        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (IndicatorIndex.Equals(0))
            {
                IndicatorIndex = FloatPoint.Length - 1;
            }
            else
            {
                IndicatorIndex -= 1;
            }
            this.Invalidate(false);
        }

        #endregion

        public iTalkProgressIndicator()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(80, 80);
            SetPoints();
            AnimationSpeed.Interval = 100;
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        private void SetPoints()
        {
            var FPStack = new Stack<PointF>();
            PointF centerPoint = new PointF(this.Width / 2.0F, this.Height / 2.0F);
            float i = 0F;

            while (i < 360.0F)
            {
                SetValue(centerPoint, Convert.ToInt32(this.Width / 2.0 - 15), i);
                PointF FP = EndPoint;
                FP = new PointF(FP.X - 15 / 2.0F, FP.Y - 15 / 2.0F);
                FPStack.Push(FP);
                i += 360.0F / 8;
            }
            FloatPoint = FPStack.ToArray();
        }

        private void UpdateGraphics()
        {
            if (this.Width > 0 && this.Height > 0)
            {
                GraphicsContext.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                BuffGraphics = GraphicsContext.Allocate(this.CreateGraphics(), this.ClientRectangle);
                BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BuffGraphics.Graphics.Clear(this.BackColor);

            for (int i = 0; i < FloatPoint.Length; i++)
            {
                if (IndicatorIndex == i)
                {
                    BuffGraphics.Graphics.FillEllipse(AnimationColor, FloatPoint[i].X, FloatPoint[i].Y, 15, 15);
                }
                else
                {
                    BuffGraphics.Graphics.FillEllipse(BaseColor, FloatPoint[i].X, FloatPoint[i].Y, 15, 15);
                }
            }
            BuffGraphics.Render(e.Graphics);
        }

        private double Rise;
        private double Run;
        private PointF _StartingFloatPoint;

        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            double CircleRadian = Math.PI * Angle / 180.0;

            _StartingFloatPoint = StartingFloatPoint;
            Rise = AssignValues(ref Run, Length);
            Rise = Math.Sin(CircleRadian) * Rise;
            Run = Math.Cos(CircleRadian) * Run;
        }

        private PointF EndPoint
        {
            get
            {
                float LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
                float LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

                return new PointF(LocationY, LocationX);
            }
        }
    }

    #endregion
}