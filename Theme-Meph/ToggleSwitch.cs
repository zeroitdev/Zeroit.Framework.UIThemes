// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ToggleSwitch.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Meph
{

    [DefaultEvent("CheckedChanged")]
    public class MephToggleSwitch : Control
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
            Height = 24;
            Width = 50;
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

        public MephToggleSwitch() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(50, 24);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle onoffRect = new Rectangle(0, 0, Width - 1, Height - 1);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            G.Clear(Color.Transparent);

            LinearGradientBrush bodyGrad = new LinearGradientBrush(onoffRect, Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(bodyGrad, Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(15, 15, 15)), Draw.RoundRect(onoffRect, 4));
            G.DrawPath(new Pen(Color.FromArgb(50, 50, 50)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4));

            if (Checked)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(80, Color.Green)), Draw.RoundRect(new Rectangle(4, 2, 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle(2, 2, 25, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("On", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(16, Height - 12), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }
            else
            {
                G.FillPath(new SolidBrush(Color.FromArgb(60, Color.Red)), Draw.RoundRect(new Rectangle((Width / 2) - 7, 2, Width - 25, Height - 5), 4));
                G.FillPath(new SolidBrush(Color.FromArgb(35, 35, 35)), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(new Rectangle((Width / 2) - 5, 2, Width - 23, Height - 5), 4));
                switch (State)
                {
                    case MouseState.None:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Over:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.White, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                    case MouseState.Down:
                        G.DrawString("Off", new Font("Tahoma", 8, FontStyle.Regular), Brushes.Silver, new Point(34, Height - 11), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }

}


