// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Alert.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderAlert : Control
    {

        #region " Drawing "

        private Graphics G;

        private Style _Alert;
        public bool Centered { get; set; }
        public bool Field { get; set; }

        public enum Style : byte
        {
            Notice = 0,
            Informations = 1,
            Warning = 2,
            Success = 3
        }

        public Style Alert
        {
            get { return _Alert; }
            set
            {
                _Alert = value;
                Invalidate();
            }
        }

        public SideWinderAlert()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            G.Clear(Parent.BackColor);

            switch (Alert)
            {

                case Style.Notice:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(188, 232, 241));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(217, 237, 247));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(217, 237, 247));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(188, 232, 241));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;

                case Style.Informations:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(251, 238, 213));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(252, 248, 227));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(252, 248, 227));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(251, 238, 213));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;
                case Style.Warning:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(238, 211, 215));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(242, 222, 222));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(242, 222, 222));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(238, 211, 215));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }

                    break;
                default:

                    if (Field)
                    {
                        Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(214, 233, 198));
                        Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(223, 240, 216));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), new Rectangle(20, 0, Width, Height));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                            }
                        }

                    }
                    else
                    {
                        Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(223, 240, 216));
                        Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(214, 233, 198));

                        if (Centered)
                        {
                            Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), Helpers.FullRectangle(Size, false));
                        }
                        else
                        {
                            using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                            {
                                G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                            }
                        }
                    }
                    break;
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!Field)
            {
                Height = 37;
            }
        }

        #endregion

    }

}