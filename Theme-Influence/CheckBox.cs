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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Influence
{
    [DefaultEvent("CheckedChanged")]
    public class InfluenceCheckBox : Control
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
            Height = 16;
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

        public InfluenceCheckBox()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Size = new Size(145, 16);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            Rectangle checkBoxRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

            G.Clear(BackColor);

            switch (Checked)
            {
                case false:
                    LinearGradientBrush g1 = new LinearGradientBrush(checkBoxRectangle, Color.FromArgb(10, 10, 10), Color.FromArgb(16, 16, 16), 90);
                    G.FillPath(g1, d.RoundRect(checkBoxRectangle, 2));
                    G.DrawPath(new Pen(Color.FromArgb(80, 97, 94, 90)), d.RoundRect(new Rectangle(1, 1, Height - 3, Height - 3), 2));
                    G.DrawPath(Pens.Black, d.RoundRect(checkBoxRectangle, 2));
                    break;
                case true:
                    LinearGradientBrush g11 = new LinearGradientBrush(checkBoxRectangle, Color.FromArgb(10, 10, 10), Color.FromArgb(16, 16, 16), 90);
                    G.FillPath(g11, d.RoundRect(checkBoxRectangle, 2));
                    HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillPath(h1, d.RoundRect(new Rectangle(0, 0, Height - 1, Height - 2), 2));
                    LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Height - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillPath(s1, d.RoundRect(new Rectangle(0, 0, Height - 1, Height / 2 - 1), 2));
                    G.DrawPath(new Pen(Color.FromArgb(80, 97, 94, 90)), d.RoundRect(new Rectangle(1, 1, Height - 3, Height - 3), 2));
                    G.DrawPath(Pens.Black, d.RoundRect(checkBoxRectangle, 2));

                    Rectangle chkPoly = new Rectangle(checkBoxRectangle.X + checkBoxRectangle.Width / 4, checkBoxRectangle.Y + checkBoxRectangle.Height / 4, checkBoxRectangle.Width / 2, checkBoxRectangle.Height / 2);
                    Point[] Poly = {
                    new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                    new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                    new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
                };
                    if (Checked)
                    {
                        G.SmoothingMode = SmoothingMode.HighQuality;
                        Pen P1 = new Pen(Color.FromArgb(250, 255, 255, 255), 2);
                        for (int i = 0; i <= Poly.Length - 2; i++)
                        {
                            G.DrawLine(P1, Poly[i], Poly[i + 1]);
                        }
                    }

                    break;
            }

            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(16, 1), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();

        }

    }

}

