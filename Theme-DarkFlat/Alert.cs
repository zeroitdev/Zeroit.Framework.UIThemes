// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Alert.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    public class DarkFlatAlertBox : Control
    {
        /// <summary>
        /// How to use: FlatAlertBox.ShowControl(Kind, String, Interval)
        /// </summary>
        /// <remarks></remarks>

        #region  Variables

        private int W;
        private int H;
        private _Kind K;
        private string _Text;
        private MouseState State = MouseState.None;
        private int X;
        private Timer T = new Timer();

        #endregion

        #region  Properties

        [Flags()]
        public enum _Kind
        {
            Success,
            Error,
            Info
        }

        #region  Options

        [Category("Options")]
        public _Kind kind
        {
            get
            {
                return K;
            }
            set
            {
                K = value;
            }
        }

        [Category("Options")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (_Text != null)
                {
                    _Text = value;
                }
            }
        }

        [Category("Options")]
        public new bool Visible
        {
            get
            {
                return base.Visible == false;
            }
            set
            {
                base.Visible = value;
            }
        }

        #endregion

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 42;
        }

        public void ShowControl(_Kind Kind, string Str, int Interval)
        {
            K = Kind;
            Text = Str;
            this.Visible = true;
            T = new Timer();
            T.Interval = Interval;
            T.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            T.Enabled = false;
            T.Dispose();
        }

        #region  Mouse States

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Visible = false;
        }

        #endregion

        #endregion

        #region  Colors

        private Color SuccessColor = Color.FromArgb(60, 85, 79);
        private Color SuccessText = Color.FromArgb(35, 169, 110);
        private Color ErrorColor = Color.FromArgb(87, 71, 71);
        private Color ErrorText = Color.FromArgb(254, 142, 122);
        private Color InfoColor = Color.FromArgb(70, 91, 94);
        private Color InfoText = Color.FromArgb(97, 185, 186);

        #endregion

        public DarkFlatAlertBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
            Size = new Size(576, 42);
            Location = new Point(10, 61);
            Font = new Font("Segoe UI", 10);
            Cursor = Cursors.Hand;
            SubscribeToEvents();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(0, 0, W, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            
            if (K == _Kind.Success)
            {
                //-- Base
                Helpers.G.FillRectangle(new SolidBrush(SuccessColor), Base);

                //-- Ellipse
                Helpers.G.FillEllipse(new SolidBrush(SuccessText), new Rectangle(8, 9, 24, 24));
                Helpers.G.FillEllipse(new SolidBrush(SuccessColor), new Rectangle(10, 11, 20, 20));

                //-- Checked Sign
                Helpers.G.DrawString("ü", new Font("Wingdings", 22), new SolidBrush(SuccessText), new Rectangle(7, 7, W, H), Helpers.NearSF);
                Helpers.G.DrawString(Text, Font, new SolidBrush(SuccessText), new Rectangle(48, 12, W, H), Helpers.NearSF);

                //-- X button
                Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 30, H - 29, 17, 17));
                Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(SuccessColor), new Rectangle(W - 28, 16, W, H), Helpers.NearSF);

                switch (State) // -- Mouse Over
                {
                    case MouseState.Over:
                        Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 28, 16, W, H), Helpers.NearSF);
                        break;
                }

            }
            //ORIGINAL LINE: Case _Kind.Error
            else if (K == _Kind.Error)
            {
                //-- Base
                Helpers.G.FillRectangle(new SolidBrush(ErrorColor), Base);

                //-- Ellipse
                Helpers.G.FillEllipse(new SolidBrush(ErrorText), new Rectangle(8, 9, 24, 24));
                Helpers.G.FillEllipse(new SolidBrush(ErrorColor), new Rectangle(10, 11, 20, 20));

                //-- X Sign
                Helpers.G.DrawString("r", new Font("Marlett", 16), new SolidBrush(ErrorText), new Rectangle(6, 11, W, H), Helpers.NearSF);
                Helpers.G.DrawString(Text, Font, new SolidBrush(ErrorText), new Rectangle(48, 12, W, H), Helpers.NearSF);

                //-- X button
                Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(ErrorColor), new Rectangle(W - 30, 17, W, H), Helpers.NearSF);

                switch (State)
                {
                    case MouseState.Over: // -- Mouse Over
                        Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 15, W, H), Helpers.NearSF);
                        break;
                }

            }
            //ORIGINAL LINE: Case _Kind.Info
            else if (K == _Kind.Info)
            {
                //-- Base
                Helpers.G.FillRectangle(new SolidBrush(InfoColor), Base);

                //-- Ellipse
                Helpers.G.FillEllipse(new SolidBrush(InfoText), new Rectangle(8, 9, 24, 24));
                Helpers.G.FillEllipse(new SolidBrush(InfoColor), new Rectangle(10, 11, 20, 20));

                //-- Info Sign
                Helpers.G.DrawString("¡", new Font("Segoe UI", 20F, FontStyle.Bold), new SolidBrush(InfoText), new Rectangle(12, -4, W, H), Helpers.NearSF);
                Helpers.G.DrawString(Text, Font, new SolidBrush(InfoText), new Rectangle(48, 12, W, H), Helpers.NearSF);

                //-- X button
                Helpers.G.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(W - 32, H - 29, 17, 17));
                Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(InfoColor), new Rectangle(W - 30, 17, W, H), Helpers.NearSF);

                switch (State)
                {
                    case MouseState.Over: // -- Mouse Over
                        Helpers.G.DrawString("r", new Font("Marlett", 8), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(W - 30, 17, W, H), Helpers.NearSF);
                        break;
                }
            }


            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }


        private bool EventsSubscribed = false;

        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            T.Tick += T_Tick;
        }

    }

}



