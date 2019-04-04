// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBoxPretty.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ghost
{

    public class GhostListBoxPretty : ThemeControl154
    {
        private ListBox withEventsField_LBox = new ListBox();
        public ListBox LBox
        {
            get { return withEventsField_LBox; }
            set
            {
                if (withEventsField_LBox != null)
                {
                    withEventsField_LBox.DrawItem -= DrawItem;
                }
                withEventsField_LBox = value;
                if (withEventsField_LBox != null)
                {
                    withEventsField_LBox.DrawItem += DrawItem;
                }
            }
        }
        private string[] __Items = { "" };
        public string[] Items
        {
            get
            {
                return __Items;
                Invalidate();
            }
            set
            {
                __Items = value;
                LBox.Items.Clear();
                Invalidate();
                LBox.Items.AddRange(value);
                Invalidate();
            }
        }

        public string SelectedItem
        {
            get { return LBox.SelectedItem.ToString(); }
        }

        public GhostListBoxPretty()
        {
            Controls.Add(LBox);
            Size = new Size(131, 101);

            LBox.BackColor = Color.FromArgb(0, 0, 0);
            LBox.BorderStyle = BorderStyle.None;
            LBox.DrawMode = DrawMode.OwnerDrawVariable;
            LBox.Location = new Point(3, 3);
            LBox.ForeColor = Color.White;
            LBox.ItemHeight = 20;
            LBox.Items.Clear();
            LBox.IntegralHeight = false;
            Invalidate();
        }
        protected override void ColorHook()
        {
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            LBox.Width = Width - 4;
            LBox.Height = Height - 4;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            G.DrawRectangle(Pens.Black, 0, 0, Width - 2, Height - 2);
            G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), 1, 1, Width - 3, Height - 3);
            LBox.Size = new Size(Width - 5, Height - 5);
        }
        public void DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (String.Compare(e.State.ToString(), "Selected,") > 0)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                Rectangle x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
                Rectangle x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2) - 2));
                LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
                HatchBrush H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black), Color.Transparent);
                e.Graphics.FillRectangle(G1, x2);
                G1.Dispose();
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
                e.Graphics.FillRectangle(H, x2);
                G1.Dispose();
                e.Graphics.DrawString(" " + LBox.Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }
            else
            {
                e.Graphics.DrawString(" " + LBox.Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 2);
            }
        }
        public void AddRange(object[] Items)
        {
            LBox.Items.Remove("");
            LBox.Items.AddRange(Items);
            Invalidate();
        }
        public void AddItem(object Item)
        {
            LBox.Items.Remove("");
            LBox.Items.Add(Item);
            Invalidate();
        }
    }


}
