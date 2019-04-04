// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="BlackShades.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.Form.UIThemes.BlackShades
{
    
    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    #region " GLOBAL FUNCTIONS "

    class Draw
    {
        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
    }

    #endregion


    public class BlackShadesNetForm : ContainerControl
    {

        #region " Control Help - Movement & Flicker Control "
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;

        private int pos = 0;
        private void minimBtnClick(object sender, EventArgs e)
        {
            ParentForm.FindForm().WindowState = FormWindowState.Minimized;
        }
        private void closeBtnClick(object sender, EventArgs e)
        {
            if (CloseButtonExitsApp)
            {
                System.Environment.Exit(0);
            }
            else
            {
                ParentForm.FindForm().Close();
            }
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            ParentForm.FindForm().Text = Text;
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
        }
        private bool _closesEnv = false;
        public bool CloseButtonExitsApp
        {
            get { return _closesEnv; }
            set
            {
                _closesEnv = value;
                Invalidate();
            }
        }

        private bool _minimBool = true;
        public bool MinimizeButton
        {
            get { return _minimBool; }
            set
            {
                _minimBool = value;
                Invalidate();
            }
        }

        #endregion

        private TopButton withEventsField_minimBtn;
        public TopButton minimBtn
        {
            get { return withEventsField_minimBtn; }
            set
            {
                if (withEventsField_minimBtn != null)
                {
                    withEventsField_minimBtn.Click -= minimBtnClick;
                }
                withEventsField_minimBtn = value;
                if (withEventsField_minimBtn != null)
                {
                    withEventsField_minimBtn.Click += minimBtnClick;


                    Refresh();
                }
            }
        }


        private TopButton withEventsField_closeBtn;
        public TopButton closeBtn
        {
            get { return withEventsField_closeBtn; }
            set
            {
                if (withEventsField_closeBtn != null)
                {
                    withEventsField_closeBtn.Click -= closeBtnClick;
                }
                withEventsField_closeBtn = value;
                if (withEventsField_closeBtn != null)
                {
                    withEventsField_closeBtn.Click += closeBtnClick;
                }

                Refresh();
            }

        }
        public BlackShadesNetForm() : base()
        {
            Dock = DockStyle.Fill;
            MoveHeight = 25;
            Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold);
            ForeColor = Color.FromArgb(142, 152, 156);
            DoubleBuffered = true;

            //Controls.Add(closeBtn);

            //closeBtn.Refresh();
            //minimBtn.Refresh();
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            withEventsField_closeBtn = new TopButton { Location = new Point(Width - 27, 7) };
            withEventsField_minimBtn = new TopButton { Location = new Point(Width - 44, 7) };
            const int curve = 7;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            if (_minimBool)
            {
                Controls.Add(minimBtn);
            }
            else
            {
                Controls.Remove(minimBtn);
            }

            minimBtn.Location = new Point(Width - 44, 7);
            closeBtn.Location = new Point(Width - 27, 7);

            G.SmoothingMode = SmoothingMode.Default;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Color TransparencyKey = this.ParentForm.TransparencyKey;
            Draw d = new Draw();
            base.OnPaint(e);

            G.Clear(TransparencyKey);

            G.FillPath(new SolidBrush(Color.FromArgb(42, 47, 49)), d.RoundRect(ClientRectangle, curve));


            //DRAW GRADIENTED BORDER
            LinearGradientBrush innerGradLeft = new LinearGradientBrush(new Rectangle(1, 1, Width / 2 - 1, Height - 3), Color.FromArgb(102, 108, 112), Color.FromArgb(204, 216, 224), 0f);
            LinearGradientBrush innerGradRight = new LinearGradientBrush(new Rectangle(1, 1, Width / 2 - 1, Height - 3), Color.FromArgb(204, 216, 224), Color.FromArgb(102, 108, 112), 0f);
            G.DrawPath(new Pen(innerGradLeft), d.RoundRect(new Rectangle(1, 1, Width / 2 + 3, Height - 3), curve));
            G.DrawPath(new Pen(innerGradRight), d.RoundRect(new Rectangle(Width / 2 - 5, 1, Width / 2 + 3, Height - 3), curve));


            G.FillPath(new SolidBrush(Color.FromArgb(42, 47, 49)), d.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), curve));


            LinearGradientBrush topGradLeft = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, 25), Color.FromArgb(42, 46, 48), Color.FromArgb(93, 98, 101), 0f);
            LinearGradientBrush topGradRight = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, 25), Color.FromArgb(93, 98, 101), Color.FromArgb(42, 46, 48), 0f);
            G.FillPath(topGradLeft, d.RoundRect(new Rectangle(2, 2, Width / 2 + 2, 25), curve));
            G.FillPath(topGradRight, d.RoundRect(new Rectangle(Width / 2 - 3, 2, Width / 2 - 1, 25), curve));

            G.FillRectangle(new SolidBrush(Color.FromArgb(42, 47, 49)), new Rectangle(2, 23, Width - 5, 10));

            G.DrawPath(new Pen(Color.FromArgb(42, 46, 48)), d.RoundRect(new Rectangle(2, 2, Width - 5, Height - 5), curve));
            G.DrawPath(new Pen(Color.FromArgb(9, 11, 12)), d.RoundRect(ClientRectangle, curve));

            G.DrawString(Text, Font, Brushes.White, new Rectangle(curve, curve - 2, Width - 1, 22), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

    public class TopButton : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public TopButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 8.25f);
            Size = new Size(15, 11);
            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Size = new Size(15, 11);
            G.Clear(Color.FromArgb(49, 53, 55));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    LinearGradientBrush border = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 90);
                    G.FillPath(bodyGrad, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
                case MouseState.Over:
                    LinearGradientBrush border1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border1, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad1 = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 90);
                    G.FillPath(bodyGrad1, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(200, 0, 186, 255)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
                case MouseState.Down:
                    LinearGradientBrush border2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border2, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad2 = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 135);
                    G.FillPath(bodyGrad2, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}
