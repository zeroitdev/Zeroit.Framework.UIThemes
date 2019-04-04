// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Form.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BitDefender
{


    [ToolboxItem(false)]
    public class BitdefenderForm : ContainerControl
    {

        #region "Init"
        public BitdefenderForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            BackColor = Color.Fuchsia;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Parent.FindForm() != null)
            {
                Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
                Parent.FindForm().TransparencyKey = BackColor;
            }

        }

        #region "Property"

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate(new Rectangle(0, 0, Width, 70), false);
            }
        }



        private bool _DisableMax;
        public bool DisableControlboxMax
        {
            get { return _DisableMax; }
            set
            {
                _DisableMax = value;
                Invalidate(false);
            }
        }

        private bool _DisableMin;
        public bool DisableControlboxMin
        {
            get { return _DisableMin; }
            set
            {
                _DisableMin = value;
                Invalidate(false);
            }
        }

        private bool _DisableClose;
        public bool DisableControlboxClose
        {
            get { return _DisableClose; }
            set
            {
                _DisableClose = value;
                Invalidate(false);
            }
        }
        #endregion


        #region "Flag mouse"
        Point mouseOffset;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseOffset = new Point(-e.X, -e.Y);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            //#Zone " Move form "
            for (int x = 0; x <= Width - 1; x++)
            {
                for (int y = 0; y <= 30; y++)
                {
                    if (e.Button == MouseButtons.Left && e.Location.Equals(new Point(x, y)))
                    {
                        dynamic mousePos = Control.MousePosition;
                        mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                        Parent.FindForm().Location = mousePos;
                    }
                }
            }
            //#End Zone

            //#Zone " None mouse flag "
            MouseState = State.None;
            Cursor = Cursors.Default;
            //#End Zone

            //#Zone " minRect "
            Rectangle minRect = new Rectangle(Right - Padding - (controlSize.Width + 20), Padding, btnSize.Width, btnSize.Height);
            if (minRect.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
                MouseState = State.HoverMin;
            }
            //#End Zone

            //#Zone " maxRect "
            Rectangle maxRect = new Rectangle(minRect.X + 29, minRect.Y, btnSize.Width, btnSize.Height);
            if (maxRect.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
                MouseState = State.HoverMax;
            }
            //#End Zone

            //#Zone " closeRect "
            Rectangle closeRect = new Rectangle(maxRect.X + 29, minRect.Y, btnSize.Width, btnSize.Height);
            if (closeRect.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
                MouseState = State.HoverClose;
            }
            //#End Zone




        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Rectangle min = new Rectangle(Right - Padding - (controlSize.Width + 20), Padding, btnSize.Width, btnSize.Height);
            Rectangle max = new Rectangle(min.X + 29, min.Y, btnSize.Width, btnSize.Height);
            Rectangle close = new Rectangle(max.X + 29, max.Y, btnSize.Width, btnSize.Height);

            if (min.Contains(e.Location) && e.Button == MouseButtons.Left && !DisableControlboxMin)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }

            if (max.Contains(e.Location) && e.Button == MouseButtons.Left && !DisableControlboxMax)
            {
                switch (Parent.FindForm().WindowState)
                {
                    case FormWindowState.Maximized:
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                        break;
                    case FormWindowState.Normal:
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                        break;
                }

            }

            if (close.Contains(e.Location) && e.Button == MouseButtons.Left && !DisableControlboxClose)
            {
                Parent.FindForm().Close();
            }

        }

        #region "Draw mouse state"
        private enum State
        {
            None,
            HoverClose,
            HoverMax,
            HoverMin
        }
        private State _MouseState;
        private State MouseState
        {
            get { return _MouseState; }
            set
            {
                _MouseState = value;
                Invalidate(false);
            }
        }
        #endregion

        #endregion


        #endregion

        #region "Draw"

        #region "Init Draw Object"

        #region "Draw Object Declarations"
        private Graphics G;
        private new const int Padding = 10;
        //#Zone " Controlbox "
        private Size btnSize = new Size(27, 30);
        private Size controlSize;
        private GraphicsPath controlboxPath;
        //#End Zone

        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R4;
        private Rectangle R5;
        private Rectangle R6;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private GraphicsPath GP4;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private Pen P5;
        private Pen P6;
        private SolidBrush B1;
        private LinearGradientBrush LGB1;
        private LinearGradientBrush LGB2;
        private LinearGradientBrush LGB3;
        private LinearGradientBrush LGB4;
        private LinearGradientBrush LGB5;
        private LinearGradientBrush LGB6;
        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Color C7;
        private Color C8;
        private Color C9;

        private Color C10;

        private ContainerObjectDisposable containerDisposable = new ContainerObjectDisposable();
        #endregion


        private void Init(PaintEventArgs e)
        {
            G = e.Graphics;
            controlSize = new Size(86, btnSize.Height);
            //#Zone " Rectangle "
            R1 = new Rectangle(Padding, Padding, Width - Padding * 2, Height - Padding * 2);
            R2 = new Rectangle(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2);
            R4 = new Rectangle(Padding, Padding, Width, 20);
            R5 = new Rectangle(Right - Padding - (controlSize.Width + 20), Padding, controlSize.Width, controlSize.Height);
            R6 = new Rectangle(R5.X + 1, R5.Y + 1, R5.Width - 2, R5.Height - 2);
            //#End Zone

            //#Zone " Graphic path "
            GP1 = Helper.RoundRect(R1, 18);
            GP2 = Helper.RoundRect(R2, 18);
            //GP3 = ControlRect(R5, 9);
            //GP4 = ControlRect(R6, 9);

            GP3 = Helper.RoundRect(R5, 9);
            GP4 = Helper.RoundRect(R6, 9);
            controlboxPath = new GraphicsPath();
            containerDisposable.AddObjectRange(new GraphicsPath[]{
            GP1,
            GP2,
            GP3,
            GP4,
            controlboxPath
        });
            //#End Zone

            //#Zone " Brush "
            B1 = new SolidBrush(Color.FromArgb(32, 32, 32));
            containerDisposable.AddObject(B1);
            //#End Zone

            //#Zone " Color "
            C1 = Color.FromArgb(81, 81, 81);
            C2 = Color.FromArgb(43, 43, 43);
            C3 = Color.FromArgb(21, 21, 21);
            C4 = Color.FromArgb(10, 10, 10);
            C5 = Color.FromArgb(167, 167, 167);
            C6 = Color.FromArgb(83, 83, 83);
            C7 = Color.FromArgb(41, 41, 41);
            C8 = Color.FromArgb(33, 33, 33);
            C9 = Color.FromArgb(41, 41, 41);
            C10 = Color.FromArgb(77, 77, 77);
            //#End Zone

            //#Zone " Linear Gradient Brush "
            LGB1 = new LinearGradientBrush(R4, C1, C2, LinearGradientMode.Vertical);
            LGB2 = new LinearGradientBrush(R5, C6, C7, LinearGradientMode.Vertical);
            LGB3 = new LinearGradientBrush(R5, C8, C7, LinearGradientMode.Vertical);
            LGB4 = new LinearGradientBrush(new Point(R5.Left + 27, R5.Top + 2), new Point(R5.Left + 27, R5.Bottom - 2), C3, C4);
            LGB5 = new LinearGradientBrush(new Point(R5.Left + 28, R5.Top + 2), new Point(R5.Left + 28, R5.Bottom - 1), C5, C6);
            LGB6 = new LinearGradientBrush(R5, C9, C10, LinearGradientMode.Vertical);
            containerDisposable.AddObjectRange(new LinearGradientBrush[]{
            LGB1,
            LGB2,
            LGB3,
            LGB4,
            LGB5,
            LGB6
        });

            //#End Zone

            //#Zone " Pen "
            P1 = new Pen(Color.FromArgb(33, 33, 33));
            P2 = new Pen(Color.FromArgb(240, 240, 240));
            P3 = new Pen(LGB3);
            P4 = new Pen(new SolidBrush(Color.FromArgb(83, 83, 83)));
            P5 = new Pen(LGB4);
            P6 = new Pen(LGB5);
            containerDisposable.AddObjectRange(new Pen[]{
            P1,
            P2,
            P3,
            P4,
            P5,
            P6
        });
            //#End Zone


        }

        #endregion



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //'#Zone " DebugMode "
#if DEBUG
            //Dim ST As New Stopwatch : ST.Start()
#endif

            //#End Zone

            Init(e);

            //#Zone " Draw background"
            G.FillPath(B1, GP1);
            //#End Zone

            //#Zone " Draw header "
            G.SetClip(GP2);
            G.FillRectangle(LGB1, R4);
            G.ResetClip();
            //#End Zone

            //#Zone " Draw title "
            G.DrawString(Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.White, 27, 22);
            //#End Zone

            //#Zone " Draw border "
            G.DrawPath(P1, GP1);
            G.DrawPath(P2, GP2);
            //#End Zone

            //#Zone " Mouse state "
            switch (MouseState)
            {
                case State.HoverClose:
                    DrawControlBox_Close(G);
                    break;
                case State.HoverMax:
                    DrawControlBox_Max(G);
                    break;
                case State.HoverMin:
                    DrawControlBox_Min(G);
                    break;
                case State.None:
                    DrawControlBox(G);
                    break;
            }
            //#End Zone

            //#Zone " Dispose all draw object "
            containerDisposable.Dispose();
            //#End Zone

            //#Zone " DebugMode "
#if DEBUG
            //Debug.WriteLine(ST.Elapsed.ToString)
#endif

            //#End Zone

        }


        private void DrawControlBox(Graphics G)
        {
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(LGB2, GP3);
            G.DrawPath(P3, GP3);
            G.DrawPath(P4, GP4);
            //#Zone " If you want white line "
            G.DrawLine(P2, R5.Left, R5.Top + 1, R5.Right, R5.Top + 1);
            //#End Zone
            //#Zone " Fix     !important "
            G.DrawLine(P3, R5.Right, R5.Top, R5.Right, R5.Bottom - 4);
            G.DrawLine(P4, R6.Right, R6.Top + 1, R6.Right, R6.Bottom - 4);

            G.SmoothingMode = SmoothingMode.Default;

            G.FillRectangle(P3.Brush, new Rectangle(R5.X, R5.Y + 1, 1, 1));
            G.FillRectangle(P3.Brush, new Rectangle(R5.Right, R5.Top + 1, 1, 1));
            //#End Zone
            //#Zone " First line "
            G.DrawLine(P5, R5.Left + 29, R5.Top + 2, R5.Left + 29, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 30, R5.Top + 2, R5.Left + 30, R5.Bottom - 2);
            //#End Zone
            //#Zone " Second line "
            G.DrawLine(P5, R5.Left + 56, R5.Top + 2, R5.Left + 56, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 57, R5.Top + 2, R5.Left + 57, R5.Bottom - 2);
            //#End Zone



            //#Zone " close string "
            controlboxPath.AddString("r", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width + 20) + 2, Padding + 8), null);
            G.FillPath(Brushes.White, controlboxPath);
            G.DrawPath(Pens.Black, controlboxPath);
            //#End Zone

            //#Zone " max string "
            switch (Parent.FindForm().WindowState)
            {
                case FormWindowState.Maximized:
                    controlboxPath.AddString("2", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 4, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);

                    break;
                case FormWindowState.Normal:
                    controlboxPath.AddString("1", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 2, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);
                    break;
            }
            //#End Zone

            //#Zone " min string "
            controlboxPath.AddString("0", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 3 + 20) + 2, Padding + 8), null);
            G.DrawPath(Pens.Black, controlboxPath);
            G.FillPath(Brushes.White, controlboxPath);
            //#End Zone

        }

        private void DrawControlBox_Close(Graphics G)
        {
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(LGB2, GP3);

            G.SetClip(new Rectangle(Right - Padding - (btnSize.Width + 23) + 1, Padding, btnSize.Width + 3, btnSize.Height));
            G.FillPath(LGB6, GP3);
            G.ResetClip();

            G.DrawPath(P3, GP3);
            G.DrawPath(P4, GP4);

            //#Zone " If you want white line "
            G.DrawLine(P2, R5.Left, R5.Top + 1, R5.Right, R5.Top + 1);
            //#End Zone

            //#Zone " Fix     !important "
            G.DrawLine(P3, R5.Right, R5.Top, R5.Right, R5.Bottom - 4);
            G.DrawLine(P4, R6.Right, R6.Top + 1, R6.Right, R6.Bottom - 4);

            G.SmoothingMode = SmoothingMode.Default;

            G.FillRectangle(P3.Brush, new Rectangle(R5.X, R5.Y + 1, 1, 1));
            G.FillRectangle(P3.Brush, new Rectangle(R5.Right, R5.Top + 1, 1, 1));
            //#End Zone

            //#Zone " First line "
            G.DrawLine(P5, R5.Left + 29, R5.Top + 2, R5.Left + 29, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 30, R5.Top + 2, R5.Left + 30, R5.Bottom - 2);
            //#End Zone

            //#Zone " Second line "
            G.DrawLine(P5, R5.Left + 56, R5.Top + 2, R5.Left + 56, R5.Bottom - 2);
            //#End Zone

            //#Zone " close string "
            controlboxPath.AddString("r", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width + 20) + 2, Padding + 10), null);
            G.FillPath(Brushes.White, controlboxPath);
            G.DrawPath(Pens.Black, controlboxPath);
            //#End Zone

            //#Zone " max string "
            switch (Parent.FindForm().WindowState)
            {
                case FormWindowState.Maximized:
                    controlboxPath.AddString("2", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 4, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);

                    break;
                case FormWindowState.Normal:
                    controlboxPath.AddString("1", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 2, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);
                    break;
            }
            //#End Zone

            //#Zone " min string "
            controlboxPath.AddString("0", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 3 + 20) + 2, Padding + 8), null);
            G.DrawPath(Pens.Black, controlboxPath);
            G.FillPath(Brushes.White, controlboxPath);
            //#End Zone

        }

        private void DrawControlBox_Max(Graphics G)
        {
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(LGB2, GP3);

            G.SetClip(new Rectangle(Right - Padding - (btnSize.Width * 2 + 23) + 1, Padding, btnSize.Width, btnSize.Height));
            G.FillPath(LGB6, GP3);
            G.ResetClip();

            G.DrawPath(P3, GP3);
            G.DrawPath(P4, GP4);

            //#Zone " If you want white line "
            G.DrawLine(P2, R5.Left, R5.Top + 1, R5.Right, R5.Top + 1);
            //#End Zone

            //#Zone " Fix     !important "
            G.DrawLine(P3, R5.Right, R5.Top, R5.Right, R5.Bottom - 4);
            G.DrawLine(P4, R6.Right, R6.Top + 1, R6.Right, R6.Bottom - 4);

            G.SmoothingMode = SmoothingMode.Default;

            G.FillRectangle(P3.Brush, new Rectangle(R5.X, R5.Y + 1, 1, 1));
            G.FillRectangle(P3.Brush, new Rectangle(R5.Right, R5.Top + 1, 1, 1));
            //#End Zone

            //#Zone " First line "
            G.DrawLine(P5, R5.Left + 29, R5.Top + 2, R5.Left + 29, R5.Bottom - 2);
            //#End Zone

            //#Zone " Second line "
            G.DrawLine(P5, R5.Left + 56, R5.Top + 2, R5.Left + 56, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 57, R5.Top + 2, R5.Left + 57, R5.Bottom - 2);
            //#End Zone

            //#Zone " close string "
            controlboxPath.AddString("r", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width + 20) + 2, Padding + 8), null);
            G.FillPath(Brushes.White, controlboxPath);
            G.DrawPath(Pens.Black, controlboxPath);
            //#End Zone

            //#Zone " max string "
            switch (Parent.FindForm().WindowState)
            {
                case FormWindowState.Maximized:
                    controlboxPath.AddString("2", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 4, Padding + 10), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);

                    break;
                case FormWindowState.Normal:
                    controlboxPath.AddString("1", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 2, Padding + 10), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);
                    break;
            }
            //#End Zone

            //#Zone " min string "
            controlboxPath.AddString("0", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 3 + 20) + 2, Padding + 8), null);
            G.DrawPath(Pens.Black, controlboxPath);
            G.FillPath(Brushes.White, controlboxPath);
            //#End Zone
        }

        private void DrawControlBox_Min(Graphics G)
        {
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(LGB2, GP3);

            G.SetClip(new Rectangle(Right - Padding - (controlSize.Width + 20) + 1, Padding, btnSize.Width + 3, btnSize.Height));
            G.FillPath(LGB6, GP3);
            G.ResetClip();

            G.DrawPath(P3, GP3);
            G.DrawPath(P4, GP4);

            //#Zone " If you want white line "
            G.DrawLine(P2, R5.Left, R5.Top + 1, R5.Right, R5.Top + 1);
            //#End Zone

            //#Zone " Fix     !important "
            G.DrawLine(P3, R5.Right, R5.Top, R5.Right, R5.Bottom - 4);
            G.DrawLine(P4, R6.Right, R6.Top + 1, R6.Right, R6.Bottom - 4);

            G.SmoothingMode = SmoothingMode.Default;

            G.FillRectangle(P3.Brush, new Rectangle(R5.X, R5.Y + 1, 1, 1));
            G.FillRectangle(P3.Brush, new Rectangle(R5.Right, R5.Top + 1, 1, 1));
            //#End Zone

            //#Zone " First line "
            G.DrawLine(P5, R5.Left + 29, R5.Top + 2, R5.Left + 29, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 30, R5.Top + 2, R5.Left + 30, R5.Bottom - 2);
            //#End Zone

            //#Zone " Second line "
            G.DrawLine(P5, R5.Left + 56, R5.Top + 2, R5.Left + 56, R5.Bottom - 2);
            G.DrawLine(P6, R5.Left + 57, R5.Top + 2, R5.Left + 57, R5.Bottom - 2);

            //#End Zone

            //#Zone " close string "
            controlboxPath.AddString("r", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width + 20) + 2, Padding + 8), null);
            G.FillPath(Brushes.White, controlboxPath);
            G.DrawPath(Pens.Black, controlboxPath);
            //#End Zone

            //#Zone " max string "
            switch (Parent.FindForm().WindowState)
            {
                case FormWindowState.Maximized:
                    controlboxPath.AddString("2", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Regular), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 4, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);

                    break;
                case FormWindowState.Normal:
                    controlboxPath.AddString("1", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 2 + 20) + 2, Padding + 8), null);
                    G.DrawPath(Pens.Black, controlboxPath);
                    G.FillPath(Brushes.White, controlboxPath);
                    break;
            }
            //#End Zone

            //#Zone " min string "
            controlboxPath.AddString("0", new FontFamily("Webdings"), Convert.ToInt32(FontStyle.Bold), 15, new Point(Right - Padding - (btnSize.Width * 3 + 20) + 2, Padding + 10), null);
            G.DrawPath(Pens.Black, controlboxPath);
            G.FillPath(Brushes.White, controlboxPath);
            //#End Zone
        }


        private object ControlRect(Rectangle R, int radius)
        {
            GraphicsPath GP = new GraphicsPath();
            GP.AddArc(R.Right - radius, R.Bottom - radius, radius, radius, 0, 90);
            GP.AddArc(R.X, R.Bottom - radius, radius, radius, 90, 90);
            GP.AddLine(R.Left, R.Top, R.Right, R.Top);
            return GP;
        }


        #endregion

    }
    

}


