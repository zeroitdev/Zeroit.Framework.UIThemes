// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ChatBubbleRight.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.iTalk
{
    #region  Right Chat Bubble 

    public class iTalkChatBubbleR : Control
    {
        #region  Variables 

        private GraphicsPath Shape;
        private Color _TextColor = Color.FromArgb(52, 52, 52);
        private Color _BubbleColor = Color.FromArgb(192, 206, 215);
        private bool _DrawBubbleArrow = true;

        #endregion
        #region  Properties 

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

        public Color BubbleColor
        {
            get
            {
                return this._BubbleColor;
            }
            set
            {
                this._BubbleColor = value;
                this.Invalidate();
            }
        }

        public new bool DrawBubbleArrow
        {
            get
            {
                return _DrawBubbleArrow;
            }
            set
            {
                _DrawBubbleArrow = value;
                Invalidate();
            }
        }

        #endregion

        public iTalkChatBubbleR()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Size = new Size(152, 38);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(52, 52, 52);
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Shape = new GraphicsPath();

            Shape.AddArc(0, 0, 10, 10, 180, 90);
            Shape.AddArc(Width - 18, 0, 10, 10, -90, 90);
            Shape.AddArc(Width - 18, Height - 11, 10, 10, 0, 90);
            Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            Shape.CloseAllFigures();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(BackColor);

            G.FillPath(new SolidBrush(_BubbleColor), Shape); // Fill the body of the bubble with the specified color
            G.DrawString(Text, Font, new SolidBrush(ForeColor), (new Rectangle(6, 4, Width - 15, Height)));

            // Draw a polygon on the right side of the bubble
            if (_DrawBubbleArrow == true)
            {
                Point[] p = {
                    new Point(Width - 8, Height - 19),
                    new Point(Width, Height - 25),
                    new Point(Width - 8, Height - 30)
                };
                G.FillPolygon(new SolidBrush(_BubbleColor), p);
                G.DrawPolygon(new Pen(new SolidBrush(_BubbleColor)), p);
            }
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }

    #endregion
}