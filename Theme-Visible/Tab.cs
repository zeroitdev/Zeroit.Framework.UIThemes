// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VITabControl : TabControl
    {
        private int OldIndex;
        private int _Speed = 10;
        public int Speed
        {
            get
            {
                return _Speed;
            }
            set
            {
                if (value > 20 || value < -20)
                {
                    MessageBox.Show("Speed needs to be in between -20 and 20.");
                }
                else
                {
                    _Speed = value;
                }
            }
        }
        private Color LightBlack = Color.FromArgb(18, 18, 18);
        private Color LighterBlack = Color.FromArgb(21, 21, 21);
        private LinearGradientBrush DrawGradientBrush;
        private LinearGradientBrush DrawGradientBrush2;
        private LinearGradientBrush DrawGradientBrushPen;
        private LinearGradientBrush DrawGradientBrushTab;
        private Color _ControlBColor;
        public Color TabTextColor
        {
            get
            {
                return _ControlBColor;
            }
            set
            {
                _ControlBColor = value;
                Invalidate();
            }
        }

        public VITabControl() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabTextColor = Color.White;
            Alignment = TabAlignment.Top;
            ItemSize = new Size(25, 30);
            SizeMode = TabSizeMode.FillToRight;
            DrawMode = TabDrawMode.OwnerDrawFixed;
        }
        public void DoAnimationScrollDown(Control Control1, Control Control2)
        {
            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));
            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }
            int Slide = Control1.Height - (Control1.Height % _Speed);
            int a = 0;
            
            for (a = 0; a <= Slide; a += _Speed)
            {
                G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(0, a - Control2.Height, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(0, a - Control2.Height, Control2.Width, Control2.Height));
            SelectedTab = (TabPage)Control2;
            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }
            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.FromArgb(18, 18, 18));
            Rectangle ItemBounds = new Rectangle();
            SolidBrush TextBrush = new SolidBrush(Color.Empty);
            SolidBrush TabBrush = new SolidBrush(Color.Black);
            for (int TabItemIndex = 0; TabItemIndex < this.TabCount; TabItemIndex++)
            {
                ItemBounds = this.GetTabRect(TabItemIndex);
                e.Graphics.FillRectangle(TabBrush, ItemBounds);
                Pen BorderPen = null;
                if (TabItemIndex == SelectedIndex)
                {
                    BorderPen = new Pen(Color.Black, 1F);
                }
                else
                {
                    BorderPen = new Pen(Color.Black, 1F);
                }
                Rectangle rPen = new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 0, ItemBounds.Width - 4, ItemBounds.Height - 2);
                e.Graphics.DrawRectangle(BorderPen, rPen);
                //Dim B1 As Brush = New HatchBrush(HatchStyle.Percent10, Color.FromArgb(35, 35, 35), Color.FromArgb(10, 10, 10))
                Brush B1 = new LinearGradientBrush(rPen, Color.FromArgb(15, 15, 15), Color.FromArgb(24, 24, 24), LinearGradientMode.Vertical);

                e.Graphics.FillRectangle(B1, rPen);

                BorderPen.Dispose();
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                if (this.SelectedIndex == TabItemIndex)
                {
                    TextBrush.Color = TabTextColor;
                }
                else
                {
                    TextBrush.Color = Color.Gray;
                }
                e.Graphics.DrawString(this.TabPages[TabItemIndex].Text, this.Font, TextBrush, (RectangleF)(this.GetTabRect(TabItemIndex)), sf);
                try
                {
                    this.TabPages[TabItemIndex].BackColor = Color.FromArgb(15, 15, 15);

                }
                catch
                {
                }
            }
            try
            {
                foreach (TabPage Page in this.TabPages)
                {
                    Page.BorderStyle = BorderStyle.None;
                }
            }
            catch
            {
            }
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(255, Color.Black))), 2, 0, Width - 3, Height - 3);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(LighterBlack)), new Rectangle(3, 2, Width - 5, Height - 7));
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(255, Color.Black))), 2, 2, Width - 2, 2);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35))), 0, 0, 1, 1);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 2, Height - 2, Width + 1, Height - 2);

        }
        protected override void OnSelecting(System.Windows.Forms.TabControlCancelEventArgs e)
        {
            if (OldIndex < e.TabPageIndex)
            {
                DoAnimationScrollUp(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
            else
            {
                DoAnimationScrollDown(TabPages[OldIndex], TabPages[e.TabPageIndex]);
            }
        }

        protected override void OnDeselecting(System.Windows.Forms.TabControlCancelEventArgs e)
        {
            OldIndex = e.TabPageIndex;
        }
        public void DoAnimationScrollUp(Control Control1, Control Control2)
        {
            Graphics G = Control1.CreateGraphics();
            Bitmap P1 = new Bitmap(Control1.Width, Control1.Height);
            Bitmap P2 = new Bitmap(Control2.Width, Control2.Height);
            Control1.DrawToBitmap(P1, new Rectangle(0, 0, Control1.Width, Control1.Height));
            Control2.DrawToBitmap(P2, new Rectangle(0, 0, Control2.Width, Control2.Height));

            foreach (Control c in Control1.Controls)
            {
                c.Hide();
            }
            int Slide = Control1.Height - (Control1.Height % _Speed);
            int a = 0;
            for (a = 0; a >= -Slide; a -= _Speed)
            {
                G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
                G.DrawImage(P2, new Rectangle(0, a + Control2.Height, Control2.Width, Control2.Height));
            }
            a = Control1.Width;
            G.DrawImage(P1, new Rectangle(0, a, Control1.Width, Control1.Height));
            G.DrawImage(P2, new Rectangle(0, a + Control2.Height, Control2.Width, Control2.Height));

            SelectedTab = (TabPage)Control2;

            foreach (Control c in Control2.Controls)
            {
                c.Show();
            }

            foreach (Control c in Control1.Controls)
            {
                c.Show();
            }
        }
    }
}


