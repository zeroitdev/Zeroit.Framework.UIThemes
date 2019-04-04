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
using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FireFox.Helpers;

namespace Zeroit.Framework.UIThemes.FireFox
{
    [DefaultEvent("CheckedChanged")]
    public class FirefoxRadioButton : Control
    {

        #region " Public "
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);
        #endregion

        #region " Private "
        private MouseState State;
        private Color ETC;

        private Graphics G;
        private bool _EnabledCalc;
        private bool _Checked;
        #endregion
        private bool _Bold;

        #region " Properties "

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public new bool Enabled
        {
            get { return EnabledCalc; }
            set
            {
                _EnabledCalc = value;
                Invalidate();
            }
        }

        [DisplayName("Enabled")]
        public bool EnabledCalc
        {
            get { return _EnabledCalc; }
            set
            {
                Enabled = value;
                Invalidate();
            }
        }

        public bool Bold
        {
            get { return _Bold; }
            set
            {
                _Bold = value;
                Invalidate();
            }
        }

        #endregion

        #region " Control "

        public FirefoxRadioButton()
        {
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(66, 78, 90);
            Font = Theme.GlobalFont;
            Size = new Size(160, 27);
            Enabled = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);

            if (Enabled)
            {
                ETC = Color.FromArgb(66, 78, 90);

                switch (State)
                {

                    case MouseState.Over:
                    case MouseState.Down:

                        using (Pen P = new Pen(Color.FromArgb(34, 146, 208)))
                        {
                            G.DrawEllipse(P, new Rectangle(2, 2, 22, 22));
                        }


                        break;
                    default:

                        using (Pen P = new Pen(Helpers.GreyColor(190)))
                        {
                            G.DrawEllipse(P, new Rectangle(2, 2, 22, 22));
                        }


                        break;
                }


                if (Checked)
                {
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(34, 146, 208)))
                    {
                        G.FillEllipse(B, new Rectangle(7, 7, 12, 12));
                    }

                }

            }
            else
            {
                ETC = Helpers.GreyColor(170);

                using (Pen P = new Pen(Helpers.GreyColor(210)))
                {
                    G.DrawEllipse(P, new Rectangle(2, 2, 22, 22));
                }


                if (Checked)
                {
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(34, 146, 208)))
                    {
                        G.FillEllipse(B, new Rectangle(7, 7, 12, 12));
                    }

                }

            }

            using (SolidBrush B = new SolidBrush(ETC))
            {

                if (Bold)
                {
                    G.DrawString(Text, Theme.GlobalFont, B, new Point(32, 4));
                }
                else
                {
                    G.DrawString(Text, Theme.GlobalFont, B, new Point(32, 4));
                }

            }


        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);


            if (Enabled)
            {

                if (!Checked)
                {
                    foreach (Control C in Parent.Controls)
                    {
                        if (C is FirefoxRadioButton)
                        {
                            ((FirefoxRadioButton)C).Checked = false;
                        }
                    }

                }

                Checked = true;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, e);
                }
            }

            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

    }

}


