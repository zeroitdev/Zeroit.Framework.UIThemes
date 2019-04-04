// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonNormal.cs" company="Zeroit Dev Technologies">
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
    #region  Normal Button

    public class PlayUIButtonNormal : Control
    {

        #region  Variables

        private int MouseState;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Rectangle R1;
        private Pen P1;
        private Pen P3;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private Color _TextColor; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.

        #endregion
        #region  Properties

        public StringAlignment TextAlignment
        {
            get
            {
                return this._TextAlignment;
            }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
                this.Invalidate();
            }
        }

        #endregion
        #region  EventArgs

        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion

        public PlayUIButtonNormal()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.FromArgb(255, 255, 255);
            Size = new Size(42, 24);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(Color.FromArgb(25, 26, 28)); // P1 = Border color
        }

        protected override void OnResize(System.EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {

                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(31, 31, 31), Color.FromArgb(30, 30, 30), 90.0F);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(26, 26, 26), Color.FromArgb(26, 26, 26), 90.0F);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(23, 23, 23), Color.FromArgb(23, 23, 23), 90.0F);

                P3 = new Pen(PressedContourGB);
            }

            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            switch (MouseState)
            {
                case 0: //Inactive
                    e.Graphics.FillPath(InactiveGB, Shape); // Fill button body with InactiveGB color gradient
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(39, 39, 39)), 2, 1, Width - 3, 1);
                    e.Graphics.DrawPath(P1, Shape); // Draw button border [InactiveGB]
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                    break;
                case 1: //Pressed
                    e.Graphics.FillPath(PressedGB, Shape); // Fill button body with PressedGB color gradient
                    e.Graphics.DrawPath(P3, Shape); // Draw button border [PressedGB]
                    e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = _TextAlignment, LineAlignment = StringAlignment.Center });
                    break;
            }
            base.OnPaint(e);
        }
    }

    #endregion
}