// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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
    public class MpontuoTextBox : ThemeControl
    {
        private TextBox tb1;
        public MpontuoTextBox()
        {
            tb1 = new TextBox();
            AllowTransparent();
            tb1.Parent = this;
            tb1.Size = new Size(new Point(100, 20));
            tb1.ForeColor = Color.FromArgb(66, 130, 181);
            tb1.BackColor = Color.FromArgb(50, 50, 50);
            tb1.BorderStyle = BorderStyle.FixedSingle;
            MinimumSize = new Size(0, 20);
            Size = MinimumSize;
            SubscribeToEvents();
        }

        public override void PaintHook()
        {
            G.Clear(Parent.BackColor);
        }

        public bool Multiline
        {
            get
            {
                return tb1.Multiline;
            }
            set
            {
                tb1.Multiline = value;
                Invalidate();
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return tb1.UseSystemPasswordChar;
            }
            set
            {
                tb1.UseSystemPasswordChar = value;
                Invalidate();
            }
        }

        public void s(object sender, EventArgs e)
        {
            if (tb1.Multiline == false)
            {
                Height = tb1.Height;
            }
        }

        private void res(object sender, EventArgs e)
        {
            tb1.Width = Width;
            tb1.Height = Height;
        }

        [Editor(MultilineEditor, UITypeEditor)]
        public override string Text
        {
            get
            {
                return tb1.Text;
            }
            set
            {
                tb1.Text = value;
                Invalidate();
            }
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Invalidated += s;
            this.SizeChanged += res;
        }

    }
}

