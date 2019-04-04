// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GrayBlue
{
    public class GrayBlueCombo : ComboBox
    {
        public GrayBlueCombo()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            SubscribeToEvents();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            ItemHeight = 20;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);

            LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135));
            G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(2, 1), new Point(Width - 2, 1));
            G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 3));
            BackgroundGradient.Dispose();

            Rectangle TriangleRectangle = new Rectangle(Width - 16, Height / 2 - 2, 8, 4);

            List<Point> TrianglePoints = new List<Point>();
            TrianglePoints.Add(new Point(TriangleRectangle.X, TriangleRectangle.Y));
            TrianglePoints.Add(new Point(TriangleRectangle.X + TriangleRectangle.Width, TriangleRectangle.Y));
            TrianglePoints.Add(new Point((int)(TriangleRectangle.X + TriangleRectangle.Width / 2.0), TriangleRectangle.Y + TriangleRectangle.Height));

            G.FillPolygon(Brushes.White, TrianglePoints.ToArray());

            try
            {
                if (Items.Count > 0)
                {
                    if (!(SelectedIndex == -1))
                    {
                        G.DrawString(GetItemText(Items[SelectedIndex]), Font, Brushes.Black, new Rectangle(5, -1, Width - 20, Height), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        G.DrawString(GetItemText(Items[SelectedIndex]), Font, Brushes.White, new Rectangle(5, 0, Width - 20, Height), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                    }
                    else
                    {
                        G.DrawString(GetItemText(Items[0]), Font, Brushes.Black, new Rectangle(5, -1, Width - 20, Height), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                        G.DrawString(GetItemText(Items[0]), Font, Brushes.White, new Rectangle(5, 0, Width - 20, Height), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                    }
                }
            }
            catch
            {
                //Something went wrong, so we do nothing.
            }
        }


        public void ReplaceItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics G = e.Graphics;

            try
            {
                G.FillRectangle(DesignFunctions.ToBrush(95, 95, 95), e.Bounds);
                G.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.LightGray, new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 1), Color.FromArgb(75, 130, 195), Color.FromArgb(40, 80, 135));
                    G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1, 3));
                    G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(e.Bounds.X, e.Bounds.Y + 1), new Point(e.Bounds.Width - 1, e.Bounds.Y + 1));
                    G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1, 3));
                    G.DrawPath(Pens.Black, DesignFunctions.RoundRect(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 2, 3));

                    G.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.White, new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), new StringFormat { LineAlignment = StringAlignment.Center });
                }
            }
            catch
            {
                //Uh oh
            }
        }

        protected override void OnSelectedItemChanged(System.EventArgs e)
        {
            base.OnSelectedItemChanged(e);

            Invalidate();
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
