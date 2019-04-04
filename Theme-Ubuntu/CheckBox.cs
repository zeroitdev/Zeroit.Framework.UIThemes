// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{

    [DefaultEvent("CheckedChanged")]
    public class UbuntuCheckBox : Control
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
            Height = 14;
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

        public UbuntuCheckBox() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.WhiteSmoke;
            ForeColor = Color.Black;
            Size = new Size(145, 16);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle checkBoxRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

            G.Clear(BackColor);

            LinearGradientBrush bodyGrad = new LinearGradientBrush(checkBoxRectangle, Color.FromArgb(102, 101, 96), Color.FromArgb(76, 75, 71), 90);
            G.FillRectangle(bodyGrad, bodyGrad.Rectangle);
            G.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, Height - 3, Height - 3));
            G.DrawRectangle(new Pen(Color.FromArgb(42, 47, 49)), checkBoxRectangle);

            Font drawFont = new Font("Tahoma", 10, FontStyle.Regular);
            Brush nb = new SolidBrush(Color.FromArgb(86, 83, 87));
            G.DrawString(Text, drawFont, nb, new Point(16, 7), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });


            if (Checked)
            {
                Rectangle chkPoly = new Rectangle(checkBoxRectangle.X + checkBoxRectangle.Width / 4, checkBoxRectangle.Y + checkBoxRectangle.Height / 4, checkBoxRectangle.Width / 2, checkBoxRectangle.Height / 2);
                Point[] Poly = {
                new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2),
                new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height),
                new Point(chkPoly.X + chkPoly.Width, chkPoly.Y)
            };
                G.SmoothingMode = SmoothingMode.HighQuality;
                Pen P1 = new Pen(Color.FromArgb(247, 150, 116), 2);
                LinearGradientBrush chkGrad = new LinearGradientBrush(chkPoly, Color.FromArgb(200, 200, 200), Color.FromArgb(255, 255, 255), 0f);
                for (int i = 0; i <= Poly.Length - 2; i++)
                {
                    G.DrawLine(P1, Poly[i], Poly[i + 1]);
                }
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();

        }

    }

}

