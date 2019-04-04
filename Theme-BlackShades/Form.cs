// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BlackShades
{
    

    [ToolboxItem(false)]
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

        private BlackShadesNetTopButton withEventsField_minimBtn;
        public BlackShadesNetTopButton minimBtn
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


        private BlackShadesNetTopButton withEventsField_closeBtn;
        public BlackShadesNetTopButton closeBtn
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
            withEventsField_closeBtn = new BlackShadesNetTopButton { Location = new Point(Width - 27, 7) };
            withEventsField_minimBtn = new BlackShadesNetTopButton { Location = new Point(Width - 44, 7) };
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
    
}
