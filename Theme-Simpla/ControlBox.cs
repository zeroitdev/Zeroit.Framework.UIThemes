// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Simpla
{

    public class SimplaControlBox : Control
    {
        public SimplaControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(52, 26);
            DoubleBuffered = true;
        }
        #region " MouseStates "
        MouseState State = MouseState.None;
        int X;
        Rectangle MinBtn = new Rectangle(0, 0, 32, 25);
        Rectangle CloseBtn = new Rectangle(33, 0, 65, 25);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (X > MinBtn.X & X < MinBtn.X + 32)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, 64, 25);
            Rectangle InnerRect = new Rectangle(1, 1, 62, 23);


            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Marlett", 10, FontStyle.Bold);

            //G.CompositingQuality = CompositingQuality.HighQuality
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (State)
            {
                case MouseState.None:
                    G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    if (X > MinBtn.X & X < MinBtn.X + 32)
                    {
                        G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(95, Color.Green)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(95, Color.Red)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Down:
                    G.DrawString("r", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", drawFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

