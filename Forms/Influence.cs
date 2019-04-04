// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Influence.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Form.UIThemes.Influence
{
    
    enum MouseState : byte
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


    public class InfluenceTheme : ContainerControl
    {

        #region " Control Help - Movement & Flicker Control "
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;
        private int pos = 0;
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

        private bool _minimBool;
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

        private InfluenceTopButton withEventsField_minimBtn;
        public InfluenceTopButton minimBtn
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
                }
            }
        }
        private InfluenceTopButton withEventsField_closeBtn;
        public InfluenceTopButton closeBtn
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
            }

        }
        public InfluenceTheme()
            : base()
        {
            withEventsField_minimBtn = new InfluenceTopButton
            {
                ButtonIcon = InfluenceTopButton.ButtonType.Minim,
                Location = new Point(Width - 81, 0)
            };

            withEventsField_closeBtn = new InfluenceTopButton
            {
                ButtonIcon = InfluenceTopButton.ButtonType.Close,
                Location = new Point(Width - 52, 0)
            };

            Dock = DockStyle.Fill;
            MoveHeight = 25;
            Font = new Font("Verdana", 8.25f);
            DoubleBuffered = true;
            Controls.Add(closeBtn);

            closeBtn.Refresh();
            minimBtn.Refresh();
        }

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


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {


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

            minimBtn.Location = new Point(Width - 81, 0);
            closeBtn.Location = new Point(Width - 52, 0);

            G.SmoothingMode = SmoothingMode.HighSpeed;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Color TransparencyKey = this.ParentForm.TransparencyKey;
            Draw d = new Draw();
            base.OnPaint(e);

            G.Clear(TransparencyKey);

            G.FillPath(new SolidBrush(Color.FromArgb(20, 20, 20)), d.RoundRect(ClientRectangle, 2));


            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 1, 25), Color.FromArgb(40, 40, 40), Color.FromArgb(29, 29, 29), 90);

            G.FillPath(g1, d.RoundRect(new Rectangle(0, 2, Width - 1, 25), 2));
            G.FillPath(h1, d.RoundRect(new Rectangle(0, 2, Width - 1, 25), 2));

            LinearGradientBrush s1 = new LinearGradientBrush(g1.Rectangle, Color.FromArgb(15, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillRectangle(s1, new Rectangle(1, 1, Width - 1, 13));

            G.DrawLine(new Pen(Color.FromArgb(75, Color.White)), 1, 1, Width - 1, 1);

            G.DrawLine(new Pen(Color.FromArgb(18, 18, 18)), 1, 26, Width - 1, 26);

            G.DrawRectangle(new Pen(Color.FromArgb(37, 37, 37)), new Rectangle(1, 27, Width - 3, Height - 29));

            G.DrawPath(Pens.Black, d.RoundRect(ClientRectangle, 2));

            G.DrawString(Text, Font, Brushes.Black, new Rectangle(8, 8, Width - 1, 10), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(8, 9, Width - 1, 11), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

    public class InfluenceTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"
        public enum ButtonType : byte
        {
            Blank = 0,
            Close = 1,
            Minim = 2
        }

        private MouseState State = MouseState.None;
        private ButtonType _type = ButtonType.Blank;
        public ButtonType ButtonIcon
        {
            get { return _type; }
            set
            {
                _type = value;
                Invalidate();
            }
        }

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
        #endregion

        public InfluenceTopButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8.25f);
            Size = new Size(43, 21);
            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    LinearGradientBrush g1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g1, g1.Rectangle);
                    HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h1, g1.Rectangle);
                    LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s1, s1.Rectangle);
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Over:
                    LinearGradientBrush g11 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g11, g11.Rectangle);
                    HatchBrush h11 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h11, g11.Rectangle);
                    LinearGradientBrush s11 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s11, s11.Rectangle);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Down:
                    LinearGradientBrush g12 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
                    G.FillRectangle(g12, g12.Rectangle);
                    HatchBrush h12 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillRectangle(h12, g12.Rectangle);
                    LinearGradientBrush s12 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillRectangle(s12, s12.Rectangle);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(150, 97, 94, 90)), new Rectangle(0, 1, Width - 1, Height - 3));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }

            switch (_type)
            {
                case ButtonType.Close:
                    Size = new Size(43, 21);
                    G.DrawString("r", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case ButtonType.Minim:
                    Size = new Size(30, 21);
                    G.DrawString("0", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle((int)1.5, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
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

