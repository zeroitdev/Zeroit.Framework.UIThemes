// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="YesNoBar.cs" company="Zeroit Dev Technologies">
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
    [DefaultEvent("IndexChanged")]
    public class MpontuoYesNoBar : ThemeControl
    {
        public delegate void IndexChangedEventHandler(object sender, EventArgs e);
        public event IndexChangedEventHandler IndexChanged;
        private new Color ForeColor = Color.FromArgb(66, 130, 181);
        private bool _VaL = false;

        public bool Value
        {
            get
            {
                return _VaL;
            }
            set
            {
                _VaL = value;
                Invalidate();
            }
        }

        public MpontuoYesNoBar()
        {
            AllowTransparent();
            Size s = new Size(73, 20);
            Size = s;
            MaximumSize = s;
            MinimumSize = s;
            SubscribeToEvents();
        }

        public override void PaintHook()
        {
            G.Clear(Parent.BackColor);
            G.FillRectangle(new SolidBrush(Parent.BackColor), 0, 0, Width, Height);
            G.FillRectangle(Brushes.Lime, 0, 0, Convert.ToInt32(Width / 2), Height);
            G.FillRectangle(Brushes.Red, Convert.ToInt32(Width / 2), 0, Convert.ToInt32(Width - Width / 2), Height);
            if (_VaL)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), Convert.ToInt32(Width / 2), 0, Convert.ToInt32(Width - Width / 2) + 2, Height);
                G.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), Convert.ToInt32(Width / 2), 0, Convert.ToInt32(Width - Width / 2), Height);
                G.DrawString("Yes", Font, new SolidBrush(ForeColor), 8, 4);
            }
            else
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, 0, Convert.ToInt32(Width / 2) + 2, Height);
                G.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), 0, 0, Convert.ToInt32(Width / 2), Height);
                G.DrawString("No", Font, new SolidBrush(ForeColor), 44, 4);
            }
            // G.DrawRectangle(New Pen(Color.FromArgb(50, 50, 50)), 0, 0, Width - 1, Height - 1)
            DrawBorders(new Pen(Color.FromArgb(0, 0, 0)), new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(0, 0, Width, Height));
        }

        private void YesNoBar_click(object sender, System.EventArgs e)
        {
            _VaL = !_VaL;
            if (IndexChanged != null)
                IndexChanged(sender, e);
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Click += YesNoBar_click;
        }

    }
}

