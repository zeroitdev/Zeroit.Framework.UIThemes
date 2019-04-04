// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueComboBox : ComboBox
    {
        private int _startIndex = 0;
        private int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
                try
                {
                    SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public void ReplaceItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                    e.Graphics.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                }
                else
                {
                    e.Graphics.FillPath(new SolidBrush(Color.FromArgb(72, 72, 72)), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                    e.Graphics.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                }
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            }
            catch
            {
            }
        }

        public UniqueComboBox() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            DropDownStyle = ComboBoxStyle.DropDownList;
            StartIndex = 0;
            ItemHeight = 25;
            DoubleBuffered = true;
            Width = 200;
            SubscribeToEvents();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(2, 2, Width - 5, Height - 5);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.FillPath(new SolidBrush(Color.FromArgb(89, 87, 85)), Draw.RoundRect(outerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(outerrect, 3));
            g.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(innerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
            g.SetClip(Draw.RoundRect(innerrect, 3));
            g.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(innerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
            g.ResetClip();
            g.DrawLine(Pens.White, Width - 9, 10, Width - 22, 10);
            g.DrawLine(Pens.White, Width - 9, 11, Width - 22, 11);
            g.DrawLine(Pens.White, Width - 9, 15, Width - 22, 15);
            g.DrawLine(Pens.White, Width - 9, 16, Width - 22, 16);
            g.DrawLine(Pens.White, Width - 9, 20, Width - 22, 20);
            g.DrawLine(Pens.White, Width - 9, 21, Width - 22, 21);
            g.DrawLine(new Pen(Color.FromArgb(255, 255, 255)), new Point(Width - 29, 7), new Point(Width - 29, Height - 7));
            g.DrawLine(new Pen(Color.FromArgb(255, 255, 255)), new Point(Width - 30, 7), new Point(Width - 30, Height - 7));
            try
            {
                g.DrawString(Text, new Font("Verdana", 10F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), innerrect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            catch (Exception ex)
            {
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.DrawItem += ReplaceItem;
        }

    }

}