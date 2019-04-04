// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="DropdownButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    public class TheEmpireDropdownButton : ComboBox
    {

        #region "CreateRound"
        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }
        #endregion

        #region "Mouse states"
        private MouseStates State;
        public enum MouseStates
        {
            None = 0,
            Over = 1,
            Down = 2
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            State = MouseStates.Over;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            State = MouseStates.None;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = MouseStates.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = MouseStates.Over;
            Invalidate();
            base.OnMouseDown(e);
        }

        public new event ClickEventHandler Click;
        public new delegate void ClickEventHandler(object Sender, int ItemIndex);
        #endregion

        public TheEmpireDropdownButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            ForeColor = Color.White;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 23;
            Size = new Size(144, 30);
            Font = new Font("Segoe UI", 9);
            ForeColor = Color.White;
            BackColor = Color.FromArgb(200, 200, 200);
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.TextContrast = (int)0.1;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Brush LGB = default(Brush);
            switch (State)
            {
                case MouseStates.None:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(36, 36, 36), Color.FromArgb(25, 25, 25), 90f);
                    break;
                case MouseStates.Over:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(42, 42, 42), Color.FromArgb(25, 25, 25), 90f);
                    break;
                default:
                    LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(36, 36, 36), Color.FromArgb(18, 18, 18), 90f);
                    break;
            }
            if (!Enabled)
            {
                LGB = new SolidBrush(Color.FromArgb(55, 55, 55));
            }

            e.Graphics.FillPath(LGB, CreateRound(0, 0, Width - 1, Height - 1, 6));

            string TextToDraw = GetItemText(SelectedItem);
            if (string.IsNullOrEmpty(TextToDraw))
                TextToDraw = "...";
            e.Graphics.DrawString(TextToDraw, Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 10, Height), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            });

            Point[] P = {
            new Point(Width - 18, 12),
            new Point(Width - 10, 12),
            new Point(Width - 14, 17)
        };
            e.Graphics.FillPolygon(Brushes.White, P);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            Rectangle rect = new Rectangle();
            rect.X = e.Bounds.X;
            rect.Y = e.Bounds.Y;
            rect.Width = e.Bounds.Width - 1;
            rect.Height = e.Bounds.Height - 1;

            e.DrawBackground();
            if (e.State > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), new Font(Font.FontFamily, 8), Brushes.White, e.Bounds, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                });
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(36, 36, 36)), e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]).ToString(), new Font(Font.FontFamily, 8), Brushes.White, e.Bounds, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter
                });
            }
            e.Graphics.DrawLine(new Pen(Color.FromArgb(55, Color.Black)), new Point(e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 1), new Point(e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 1));
            base.OnDrawItem(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }


}