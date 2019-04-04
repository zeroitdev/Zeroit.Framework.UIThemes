// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Sharp-Theme.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.Form.UIThemes.Sharp
{
    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    [ToolboxItem(false)]
    public class SharpTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"
        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }
        private MouseState State;

        int X;
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
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        #endregion
        public enum TxtState : byte
        {
            Close = 1,
            Minim = 2
        }
        private TxtState BtnTxt;
        public TxtState TopButtonTXT
        {
            get { return BtnTxt; }
            set
            {
                BtnTxt = value;
                Invalidate();
            }
        }
        public SharpTopButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 8.25f);
            Size = new Size(30, 20);

            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(bmp);

            G.Clear(BackColor);

            base.OnPaint(e);


            switch (State)
            {
                case MouseState.Over:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(170, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(170, 18, 32), Color.FromArgb(147, 156, 162), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(147, 156, 162), Color.FromArgb(170, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 175));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 175), Color.FromArgb(157, 166, 172), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(157, 166, 172), Color.FromArgb(0, 102, 175), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(39, 49, 59))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(159, 169, 179), Color.FromArgb(90, 90, 90), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(123, 133, 143))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.None:

                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(140, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(140, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(140, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 156));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 156), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(0, 102, 156), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(33, 43, 53))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(153, 163, 173), Color.FromArgb(85, 85, 85), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(103, 113, 123))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    break;
                case MouseState.Down:
                    if (BtnTxt == TxtState.Close)
                    {
                        G.Clear(Color.FromArgb(130, 18, 32));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(130, 18, 32), Color.FromArgb(117, 126, 132), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(117, 126, 132), Color.FromArgb(130, 18, 32), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;
                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(30, 40, 50))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 2), Color.FromArgb(151, 161, 171), Color.FromArgb(83, 83, 83), 90);
                        G.DrawRectangle(new Pen(InnerRect), new Rectangle(1, 1, Width - 3, Height - 3));
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(97, 107, 117))), 1, Height - 2, Width - 2, Height - 2);

                    }
                    else if (BtnTxt == TxtState.Minim)
                    {
                        G.Clear(Color.FromArgb(0, 102, 146));
                        LinearGradientBrush LGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Height / 2 - 2), Color.FromArgb(0, 102, 154), Color.FromArgb(132, 141, 147), 360);
                        G.FillRectangle(LGBOver, new Rectangle(2, 1, Width - 3, Height / 2 - 2));
                        LinearGradientBrush LGBOver1 = new LinearGradientBrush(new Rectangle(0, 1, Width - 2, Height / 2 - 2), Color.FromArgb(132, 141, 147), Color.FromArgb(0, 102, 154), 360);
                        G.FillRectangle(LGBOver1, new Rectangle(0, 1, Width / 2, Height / 2 - 2));

                        G.SmoothingMode = SmoothingMode.HighQuality;

                        //----- Borders -----
                        G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(37, 47, 57))), new Rectangle(0, 0, Width - 1, Height - 1));
                        LinearGradientBrush InnerRect1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(150, 150, 150), Color.FromArgb(127, 137, 147), 90);
                        G.DrawRectangle(new Pen(InnerRect1), new Rectangle(1, 1, Width - 3, Height - 3));
                    }

                    break;
            }
            switch (BtnTxt)
            {
                case TxtState.Close:
                    Size = new Size(30, 20);
                    G.DrawString("r", new Font("Marlett", 8.75f), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case TxtState.Minim:
                    Size = new Size(25, 20);
                    G.DrawString("0", new Font("Marlett", 12), new SolidBrush(Color.FromArgb(220, Color.White)), new Rectangle(1, -1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            //  G.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(40, 40, 40))), 0, 0, 29, 19)

            e.Graphics.DrawImage((Image)bmp.Clone(), 0, 0);
            G.Dispose();
            bmp.Dispose();
        }

    }

    public class SharpForm : ContainerControl
    {
        private int Header;
        private bool Cap;
        private Point MouseP = new Point(0, 0);
        private GraphicsPath path;
        protected Graphics G;
        protected Bitmap bmp;
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X;
            float y = r.Y;
            float w = r.Width;
            float h = r.Height;
            GraphicsPath rr5 = new GraphicsPath();
            rr5.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr5.AddLine(x + r1, y, x + w - r2, y);
            rr5.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr5.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr5.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr5.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr5.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr5.AddLine(x, y + h - r4, x, y + r1);
            return rr5;
        }
        
        
        #region " Control Help - Movement & Flicker Control "
        protected override void OnInvalidated(System.Windows.Forms.InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
            ParentForm.FindForm().Text = Text;
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
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, Header).Contains(e.Location))
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


        public SharpTopButton withEventsField_minimBtn;

        public SharpTopButton minimBtn
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
        private SharpTopButton withEventsField_closeBtn;
        public SharpTopButton closeBtn
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

        public bool Color2
        {
            get { return _Color2; }
            set
            {
                _Color2 = value;
                this.Refresh();
            }
        }

        private bool _Color2 = true;

        public SharpForm() : base()
        {
            Header = 25;
            Dock = DockStyle.Fill;
            DoubleBuffered = true;

            Controls.Add(closeBtn);

            withEventsField_minimBtn = new SharpTopButton
            {
                TopButtonTXT = SharpTopButton.TxtState.Minim,
                Location = new Point(Width - 60, 0)
            };

            withEventsField_closeBtn = new SharpTopButton
            {
                TopButtonTXT = SharpTopButton.TxtState.Close,
                Location = new Point(Width - 40, 0)
            };
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            closeBtn.Refresh();
            minimBtn.Refresh();
            bmp = new Bitmap(Width, Height);
            G = Graphics.FromImage(bmp);
            Color TransparencyKey = this.ParentForm.TransparencyKey;


            base.OnPaint(e);

            if (_minimBool)
            {
                Controls.Add(minimBtn);
            }
            else
            {
                Controls.Remove(minimBtn);
            }

            minimBtn.Location = new Point(Width - 60, 0);
            closeBtn.Location = new Point(Width - 40, 0);


            G.Clear(Color.FromArgb(43, 53, 63));
            //---- Sides--
            Rectangle LGBunderGrdrect = new Rectangle(1, Header, Width, 130);
            LinearGradientBrush LGBunderGrd = new LinearGradientBrush(LGBunderGrdrect, Color.FromArgb(43, 53, 63), Color.FromArgb(70, 79, 85), 90);
            G.FillRectangle(LGBunderGrd, LGBunderGrdrect);


            if (_Color2)
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Header / 2), Color.FromArgb(20, 30, 40), Color.FromArgb(135, Color.White), 360);
                G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Header / 2));
                LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(-1, 1, Width, Header / 2), Color.FromArgb(100, Color.White), Color.FromArgb(20, 30, 40), 360);
                G.FillRectangle(BTNLGB1, new Rectangle(-1, 1, Width / 2, Header / 2));
                Brush txtbrushCL2 = new SolidBrush(Color.FromArgb(250, 250, 250));
                G.DrawString(Text, Font, txtbrushCL2, new Rectangle(16, 6, Width - 1, 22), new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                });
            }
            else
            {
                LinearGradientBrush BTNLGBOver = new LinearGradientBrush(new Rectangle(2, 1, Width - 3, Header / 2), Color.FromArgb(35, 45, 55), Color.FromArgb(155, Color.White), 180);
                G.FillRectangle(BTNLGBOver, new Rectangle(2, 1, Width - 3, Header / 2));
                LinearGradientBrush BTNLGB1 = new LinearGradientBrush(new Rectangle(-1, 1, Width, Header / 2), Color.FromArgb(120, Color.White), Color.FromArgb(35, 45, 55), 180);
                G.FillRectangle(BTNLGB1, new Rectangle(-1, 1, Width / 2, Header / 2));
                Brush txtbrush = new SolidBrush(Color.FromArgb(210, 220, 230));
                G.DrawString(Text, Font, txtbrush, new Rectangle(16, 7, Width - 1, 22), new StringFormat
                {
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                });
            }





            Rectangle InerRecLGB = new Rectangle(11, 28, Width - 22, Height - 37);
            LinearGradientBrush InnerRecLGB = new LinearGradientBrush(InerRecLGB, Color.FromArgb(57, 67, 77), Color.FromArgb(60, 69, 75), 90);
            G.FillRectangle(InnerRecLGB, InerRecLGB);

            //----- InnerRect
            Pen P1 = new Pen(new SolidBrush(Color.FromArgb(23, 33, 43)));
            G.DrawRectangle(P1, 12, 29, Width - 25, Height - 40);
            Pen P2 = new Pen(new SolidBrush(Color.FromArgb(93, 103, 113)));
            G.DrawRectangle(P2, 11, 28, Width - 23, Height - 38);



            LinearGradientBrush LGBunderGrd3 = new LinearGradientBrush(new Rectangle(0, Height - 9, Width / 2, 50), Color.FromArgb(40, 50, 60), Color.FromArgb(50, Color.White), 360);
            G.FillRectangle(LGBunderGrd3, 0, Height - 9, Width / 2, 50);
            LinearGradientBrush LGBunderGrd2 = new LinearGradientBrush(new Rectangle(Width / 2, Height - 9, Width / 2, Height), Color.FromArgb(40, 50, 60), Color.FromArgb(50, Color.White), 180);
            G.FillRectangle(LGBunderGrd2, Width / 2, Height - 9, Width / 2, Height);
            G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), Width / 2, Height - 9, Width / 2, Height);

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(137, 147, 157))), 1, 1, Width - 3, Height - 3);

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            G.DrawPath(Pens.Black, RoundRect(ClientRectangle, 0, 0, 0, 0));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(163, 173, 183))), 2, 1, Width - 3, 1);
            e.Graphics.DrawImage((Image)bmp.Clone(), 0, 0);
            bmp.Dispose();
            G.Dispose();

        }

    }
        
}


