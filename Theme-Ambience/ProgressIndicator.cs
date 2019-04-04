﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressIndicator.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ambience
{

    #region Progress Indicator

    public class AmbianceProgressIndicator : Control
    {

        #region Variables

        private readonly SolidBrush BaseColor = new SolidBrush(Color.FromArgb(76, 76, 76));
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.Gray);

        private readonly Timer AnimationSpeed = new Timer();
        private PointF[] FloatPoint;
        private BufferedGraphics BuffGraphics;
        private int IndicatorIndex;
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        #endregion
        #region Custom Properties

        public Color P_BaseColor
        {
            get { return BaseColor.Color; }
            set { BaseColor.Color = value; }
        }

        public Color P_AnimationColor
        {
            get { return AnimationColor.Color; }
            set { AnimationColor.Color = value; }
        }

        public int P_AnimationSpeed
        {
            get { return AnimationSpeed.Interval; }
            set { AnimationSpeed.Interval = value; }
        }

        #endregion
        #region EventArgs

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

        public AmbianceProgressIndicator()
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
            Stack<PointF> stack = new Stack<PointF>();
            PointF startingFloatPoint = new PointF(((float)this.Width) / 2f, ((float)this.Height) / 2f);
            for (float i = 0f; i < 360f; i += 45f)
            {
                this.SetValue(startingFloatPoint, (int)Math.Round((double)((((double)this.Width) / 2.0) - 15.0)), (double)i);
                PointF endPoint = this.EndPoint;
                endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
                stack.Push(endPoint);
            }
            this.FloatPoint = stack.ToArray();
        }

        private void UpdateGraphics()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                Size size2 = new Size(this.Width + 1, this.Height + 1);
                this.GraphicsContext.MaximumBuffer = size2;
                this.BuffGraphics = this.GraphicsContext.Allocate(this.CreateGraphics(), this.ClientRectangle);
                this.BuffGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BuffGraphics.Graphics.Clear(this.BackColor);
            int num2 = this.FloatPoint.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.IndicatorIndex == i)
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
                }
                else
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, 15f, 15f);
                }
            }
            this.BuffGraphics.Render(e.Graphics);
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
