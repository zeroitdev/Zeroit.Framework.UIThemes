// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoListbox : Control
    {
        public ListBox lstbox = new ListBox();
        private string[] __Items = { "" };

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            lstbox.Size = new Size(Width - 6, Height - 6);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            lstbox.BackColor = BackColor;
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            lstbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            lstbox.Font = Font;
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            lstbox.Focus();
        }

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
                lstbox.Items.Clear();
                Invalidate();
                lstbox.Items.AddRange(value);
                Invalidate();
            }
        }
        public object SelectedItem
        {
            get
            {
                return lstbox.SelectedItem;
            }
        }
        public void DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.Graphics.DrawString(lstbox.Items[e.Index].ToString(), e.Font, new SolidBrush(lstbox.ForeColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch
            {
            }
        }
        public void AddRange(object[] Items)
        {
            lstbox.Items.Remove("");
            lstbox.Items.AddRange(Items);
            Invalidate();
        }
        public void AddItem(object Item)
        {
            lstbox.Items.Add(Item);
            Invalidate();
        }
        public void NewListBox()
        {
            lstbox.Size = new Size(126, 96);
            lstbox.BorderStyle = BorderStyle.None;
            lstbox.DrawMode = DrawMode.OwnerDrawVariable;
            lstbox.Location = new Point(4, 4);
            lstbox.ForeColor = Color.FromArgb(216, 216, 216);
            lstbox.BackColor = Color.FromArgb(38, 38, 38);
            lstbox.Items.Clear();
        }

        public MpontuoListbox() : base()
        {

            NewListBox();
            Controls.Add(lstbox);

            Size = new Size(131, 101);
            BackColor = Color.FromArgb(38, 38, 38);
            DoubleBuffered = true;
            SubscribeToEvents();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(37, 37, 37)), new Rectangle(1, 1, Width - 2, Height - 2));
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(30, 30, 30))), 2, 2, Width - 3, 2);
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            lstbox.DrawItem += DrawItem;
        }

    }
}

