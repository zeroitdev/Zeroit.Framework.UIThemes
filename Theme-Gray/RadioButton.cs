// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Gray
{
    public class GrayRadioButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler();
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;

                Invalidate();
                if (CheckedChanged != null)
                {
                    CheckedChanged();
                }
            }
        }

        public enum State
        {
            None,
            Over
        }


        private State MouseState;
        public GrayRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            Checked = false;
            Size = new Size(15, 15);
            MouseState = State.None;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.AntiAlias;

            if (Checked)
            {
                G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135)), new Rectangle(0, 0, Height - 1, Height - 1));
                G.FillEllipse(DesignFunctions.ToBrush(150, Color.Black), new Rectangle(4, 4, Height - 9, Height - 9));
            }
            else
            {
                if (MouseState == State.Over)
                {
                    G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135)), new Rectangle(0, 0, Height - 1, Height - 1));
                }
                else
                {
                    G.FillEllipse(new LinearGradientBrush(new Point(Height / 2, 0), new Point(Height / 2, Height), Color.FromArgb(127, 127, 127), Color.FromArgb(93, 93, 93)), new Rectangle(0, 0, Height - 1, Height - 1));
                }
            }

            G.DrawEllipse(DesignFunctions.ToPen(50, Color.White), new Rectangle(0, 1, Height - 1, Height - 2));
            G.DrawEllipse(Pens.Black, new Rectangle(0, 0, Height - 1, Height - 1));
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            if (!Checked)
                Checked = true;

            foreach (Control ctl in Parent.Controls)
            {
                if (ctl is GrayRadioButton)
                {
                    if (ctl.Handle == this.Handle)
                        continue;
                    if (ctl.Enabled)
                        ((GrayRadioButton)ctl).Checked = false;
                }
            }
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
    }


}


