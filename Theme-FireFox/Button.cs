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
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FireFox.Helpers;

namespace Zeroit.Framework.UIThemes.FireFox
{

    public class FirefoxButton : Control
    {

        #region " Private "
        private MouseState State;
        private Color ETC;

        private Graphics G;
        #endregion
        private bool _EnabledCalc;

        #region " Properties "

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

        #endregion

        #region " Control "

        public FirefoxButton()
        {
            DoubleBuffered = true;
            Enabled = true;
            ForeColor = Color.FromArgb(56, 68, 80);
            Font = Theme.GlobalFont;
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
                ETC = Color.FromArgb(56, 68, 80);

                switch (State)
                {

                    case MouseState.None:

                        using (SolidBrush B = new SolidBrush(Helpers.GreyColor(245)))
                        {
                            G.FillRectangle(B, new Rectangle(1, 1, Width - 2, Height - 2));
                        }


                        Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(193));

                        break;
                    case MouseState.Over:

                        using (SolidBrush B = new SolidBrush(Helpers.GreyColor(232)))
                        {
                            G.FillRectangle(B, new Rectangle(1, 1, Width - 2, Height - 2));
                        }


                        Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(193));

                        break;
                    default:

                        using (SolidBrush B = new SolidBrush(Helpers.GreyColor(212)))
                        {
                            G.FillRectangle(B, new Rectangle(1, 1, Width - 2, Height - 2));
                        }


                        Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(193));

                        break;
                }

            }
            else
            {
                ETC = Helpers.GreyColor(170);

                using (SolidBrush B = new SolidBrush(Helpers.GreyColor(245)))
                {
                    G.FillRectangle(B, new Rectangle(1, 1, Width - 2, Height - 2));
                }

                Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 2, Helpers.GreyColor(223));

            }

            Helpers.CenterString(G, Text, Theme.GlobalFont, ETC, Helpers.FullRectangle(Size, false));

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Down;
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
            base.OnMouseEnter(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

    }


}


