// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Gray
{
    public class GrayCheck : Control
    {

        #region " Properties "

        public event CheckChangedEventHandler CheckChanged;
        public delegate void CheckChangedEventHandler();
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;

                Invalidate();
                if (CheckChanged != null)
                {
                    CheckChanged();
                }
            }
        }

        #endregion

        public enum State
        {
            None,
            Over,
            Down
        }


        private State MouseState;
        public GrayCheck()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            MouseState = State.None;
            Size = new Size(15, 15);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);

            LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.Transparent, Color.Transparent);


            switch (MouseState)
            {
                case State.None:
                    if (Checked)
                    {
                        BackgroundGradient.LinearColors = new Color[] {
                        Color.FromArgb(75, 130, 195),
                        Color.FromArgb(40, 80, 135)
                    };
                    }
                    else
                    {
                        BackgroundGradient.LinearColors = new Color[] {
                        Color.FromArgb(127, 127, 127),
                        Color.FromArgb(93, 93, 93)
                    };
                    }
                    break;
                case State.Over:
                    BackgroundGradient.LinearColors = new Color[] {
                    Color.FromArgb(75, 130, 195),
                    Color.FromArgb(40, 80, 135)
                };
                    break;
                case State.Down:
                    BackgroundGradient.LinearColors = new Color[] {
                    Color.FromArgb(55, 110, 175),
                    Color.FromArgb(40, 80, 135)
                };
                    break;
            }

            G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 2));

            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (Checked)
            {
                Rectangle c = new Rectangle(3, 2, Width - 7, Height - 7);
                G.DrawLine(new Pen(Brushes.Black, 2), new Point(c.X, c.Y + c.Height / 2), new Point(c.X + c.Width / 2, c.Y + c.Height));
                G.DrawLine(new Pen(Brushes.Black, 2), new Point(c.X + c.Width / 2, c.Y + c.Height), new Point(c.X + c.Width, c.Y));
            }

            G.SmoothingMode = SmoothingMode.None;

            G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(2, 1), new Point(Width - 3, 1));
            G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 2));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 2));

            BackgroundGradient.Dispose();
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = State.None;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = State.Down;
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            Checked = !Checked;
        }
    }


}


