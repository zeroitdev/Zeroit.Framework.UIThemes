// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Toggle.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Redemption
{
    [DefaultEvent("CheckedChanged")]
    public class RedemptionToggle : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(60, 26);
        }
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        #endregion

        public RedemptionToggle() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Size = new Size(60, 26);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            int Curve = 4;

            G.Clear(BackColor);

            G.Clear(Color.Transparent);
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
            }
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 3), Curve));

            switch (Checked)
            {
                case false:
                    LinearGradientBrush CheckedBody = new LinearGradientBrush(new Rectangle(0, 0, 30, Height - 3), Color.FromArgb(72, 79, 87), Color.FromArgb(48, 52, 55), 90);
                    G.FillPath(CheckedBody, Draw.RoundRect(new Rectangle(0, 0, 30, Height - 3), Curve));
                    LinearGradientBrush CheckedBorderPen = new LinearGradientBrush(new Rectangle(0, 0, 30, Height - 3), Color.FromArgb(29, 34, 40), Color.FromArgb(33, 34, 38), 90);
                    G.DrawPath(new Pen(CheckedBorderPen), Draw.RoundRect(new Rectangle(0, 0, 30, Height - 3), Curve));
                    LinearGradientBrush CheckedBorderHighlight = new LinearGradientBrush(new Rectangle(1, 1, 28, Height - 5), Color.FromArgb(118, 123, 129), Color.FromArgb(66, 67, 71), 90);
                    G.DrawPath(new Pen(CheckedBorderHighlight), Draw.RoundRect(new Rectangle(1, 1, 28, Height - 5), Curve));
                    for (int i = 0; i <= 2; i++)
                    {
                        G.DrawLine(new Pen(Color.FromArgb(82, 86, 95)), new Point(7, 7 + (i * 4)), new Point(22, 7 + (i * 4)));
                        G.DrawLine(new Pen(Color.FromArgb(47, 50, 57)), new Point(7, 7 + (i * 4) + 1), new Point(22, 7 + (i * 4) + 1));
                    }

                    break;
                case true:
                    LinearGradientBrush CheckedBody1 = new LinearGradientBrush(new Rectangle(29, 0, 30, Height - 3), Color.FromArgb(145, 204, 238), Color.FromArgb(35, 137, 222), 90);
                    G.FillPath(CheckedBody1, Draw.RoundRect(new Rectangle(29, 0, 30, Height - 3), Curve));
                    LinearGradientBrush CheckedBorderPen1 = new LinearGradientBrush(new Rectangle(29, 0, 30, Height - 3), Color.FromArgb(21, 37, 52), Color.FromArgb(18, 37, 54), 90);
                    G.DrawPath(new Pen(CheckedBorderPen1), Draw.RoundRect(new Rectangle(29, 0, 30, Height - 3), Curve));
                    LinearGradientBrush CheckedBorderHighlight1 = new LinearGradientBrush(new Rectangle(30, 1, 28, Height - 5), Color.FromArgb(169, 228, 255), Color.FromArgb(53, 155, 240), 90);
                    G.DrawPath(new Pen(CheckedBorderHighlight1), Draw.RoundRect(new Rectangle(30, 1, 28, Height - 5), Curve));
                    for (int i = 0; i <= 2; i++)
                    {
                        G.DrawLine(new Pen(Color.FromArgb(109, 188, 244)), new Point(36, 7 + (i * 4)), new Point(51, 7 + (i * 4)));
                        G.DrawLine(new Pen(Color.FromArgb(40, 123, 199)), new Point(36, 7 + (i * 4) + 1), new Point(51, 7 + (i * 4) + 1));
                    }

                    break;
            }
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();

        }

    }

}

