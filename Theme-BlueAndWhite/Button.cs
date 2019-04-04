// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.BlueWhite
{



    public class BaWGUIButton : Control
    {
        #region " Declarations "
        private int State;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush ActiveGB;
        private LinearGradientBrush ActiveContourGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Rectangle R1;
        private Rectangle R2;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private StringFormat CSF = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
            
        };
        #endregion

        public BaWGUIButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Arial", 12);
            Size = new Size(130, 45);

            P1 = new Pen(Color.FromArgb(185, 185, 185));
            // P2 is in the OnResize event.
            // P3 is in the OnResize event.
            P4 = new Pen(Color.FromArgb(135, 182, 233));
            B1 = new SolidBrush(Color.FromArgb(114, 114, 114));
            B2 = new SolidBrush(Color.FromArgb(246, 247, 250));
            B3 = new SolidBrush(Color.FromArgb(25, 55, 82));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = 2;
            Invalidate();

            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            State = 1;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            State = 0;
            Invalidate();

            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = 1;
            Invalidate();

            base.OnMouseUp(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();

                R1 = new Rectangle(0, 0, Width, Height);
                R2 = new Rectangle(0, 1, Width, Height);

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(249, 249, 249), Color.FromArgb(222, 222, 222), 90);
                ActiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(171, 210, 244), Color.FromArgb(84, 153, 228), 90);
                ActiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(121, 180, 235), Color.FromArgb(70, 137, 201), 90);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 1, Width, Height), Color.FromArgb(97, 162, 228), Color.FromArgb(114, 173, 233), 90);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(74, 141, 208), Color.FromArgb(114, 173, 230), 90);

                P2 = new Pen(ActiveContourGB);
                P3 = new Pen(PressedContourGB);

                var _with1 = Shape;
                _with1.AddArc(0, 0, 10, 10, 180, 90);
                _with1.AddArc(Width - 11, 0, 10, 10, -90, 90);
                _with1.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                _with1.AddArc(0, Height - 11, 10, 10, 90, 90);
                _with1.CloseAllFigures();
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with2 = e.Graphics;
            _with2.SmoothingMode = SmoothingMode.HighQuality;

            switch (State)
            {
                case 0:
                    //Inactive
                    _with2.FillPath(InactiveGB, Shape);
                    _with2.DrawPath(P1, Shape);
                    _with2.DrawString(Text, Font, B1, R1, CSF);
                    break;
                case 1:
                    //Active
                    _with2.FillPath(ActiveGB, Shape);
                    _with2.DrawPath(P2, Shape);
                    _with2.DrawString(Text, Font, Brushes.DarkSlateGray, R2, CSF);
                    _with2.DrawString(Text, Font, B2, R1, CSF);
                    break;
                case 2:
                    //Pressed
                    _with2.FillPath(PressedGB, Shape);
                    _with2.DrawPath(P3, Shape);
                    _with2.DrawLine(P4, 1, 1, Width - 2, 1);
                    _with2.DrawString(Text, Font, Brushes.White, R2, CSF);
                    _with2.DrawString(Text, Font, B3, R1, CSF);
                    break;
            }

            base.OnPaint(e);
        }
    }
    

}


