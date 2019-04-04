// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Form.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Gray
{
    public class GrayForm : ContainerControl
    {

        public GrayForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(108, 108, 108);
            ForeColor = Color.White;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SendToBack();
            Parent.FindForm().TransparencyKey = Color.Fuchsia;
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
        }

        private Icon _ico;
        public Icon Icon
        {
            get { return _ico; }
            set
            {
                _ico = value;
                Invalidate();
            }
        }

        #region " Movement and Control Buttons"
        private bool Cap = false;

        private Point CapL;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (new Rectangle(0, 0, Width - 40, 25).Contains(e.Location))
            {
                Cap = true;
                CapL = e.Location;
            }
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
            Invalidate();
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
                Parent.Location = new Point(MousePosition.X - CapL.X, MousePosition.Y - CapL.Y);
            Invalidate();
        }
        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (new Rectangle(Width - 20, 5, 10, 10).Contains(PointToClient(MousePosition)))
            {
                Application.Exit();
            }
        }
        #endregion

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.Clear(BackColor);

            //Border
            G.DrawRectangle(Pens.DimGray, new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 2));

            //Title
            G.FillRectangle(DesignFunctions.ToBrush(78, 78, 78), new Rectangle(1, 1, Width - 2, 19));
            G.FillRectangle(DesignFunctions.ToBrush(20, Color.White), new Rectangle(1, 1, Width - 2, 10));

            G.DrawLine(DesignFunctions.ToPen(150, Color.Black), new Point(1, 19), new Point(Width - 2, 19));
            G.DrawLine(DesignFunctions.ToPen(50, Color.White), new Point(1, 20), new Point(Width - 2, 20));

            //Title Icon
            try
            {
                G.DrawIcon(_ico, new Rectangle(3, 3, 16, 16));
            }
            catch
            {
            }

            //Title Text
            G.DrawString(Text, Font, DesignFunctions.ToBrush(120, Color.Black), new Rectangle(1, 0, Width - 2, 19), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            G.DrawString(Text, Font, DesignFunctions.ToBrush(ForeColor), new Rectangle(1, 1, Width - 2, 19), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            try
            {
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(0, 0, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(Width - 1, 0, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(0, Height - 1, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(Width - 1, Height - 1, 1, 1));
            }
            catch
            {
            }

            G.SmoothingMode = SmoothingMode.AntiAlias;
            if (new Rectangle(Width - 20, 5, 10, 10).Contains(PointToClient(MousePosition)))
            {
                G.DrawLine(new Pen(Brushes.White, 2), new Point(Width - 20, 7), new Point(Width - 13, 13));
                G.DrawLine(new Pen(Brushes.White, 2), new Point(Width - 20, 13), new Point(Width - 13, 7));
                if (MouseButtons == MouseButtons.Left)
                {
                    G.DrawLine(new Pen(Brushes.DarkGray, 2), new Point(Width - 20, 7), new Point(Width - 13, 13));
                    G.DrawLine(new Pen(Brushes.DarkGray, 2), new Point(Width - 20, 13), new Point(Width - 13, 7));
                }
            }
            else
            {
                G.DrawLine(new Pen(Brushes.Gray, 2), new Point(Width - 20, 7), new Point(Width - 13, 13));
                G.DrawLine(new Pen(Brushes.Gray, 2), new Point(Width - 20, 13), new Point(Width - 13, 7));
            }
        }
    }


}


