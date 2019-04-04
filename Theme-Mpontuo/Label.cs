// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
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
    [Designer("System.Windows.Forms.Design.LabelDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class MpontuoLabel : ThemeControl
    {
        private string _txt;
        private new Color ForeColor = Color.FromArgb(66, 130, 181);
        public override void PaintHook()
        {
            G.Clear(Parent.BackColor);
            if (_auto)
            {
                ADF();
            }
            G.FillRectangle(new SolidBrush(Parent.BackColor), 0, 0, Width, Height);
            G.DrawString(_txt, Font, new SolidBrush(ForeColor), 0, 0);
        }

        public MpontuoLabel()
        {
            AllowTransparent();
            Size s = new Size(16, 20);
            Size = s;
            SubscribeToEvents();
        }

        public void ADF()
        {
            Graphics hinst = this.CreateGraphics();
            SizeF j = hinst.MeasureString(Text, Font);
            Size = new Size((int)j.Width, (int)j.Height);
        }
        [Editor(MultilineEditor, UITypeEditor)]
        public override string Text
        {
            get
            {
                return _txt;
            }
            set
            {
                _txt = value;
                Invalidate();
            }
        }

        private bool _auto = true;
        [ComVisible(true), Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return _auto;
            }
            set
            {
                _auto = value;
                Invalidate();
            }
        }

        public void ss(object sender, EventArgs e)
        {
            _txt = this.Text;
            //If _auto = True Then
            Invalidate();
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.TextChanged += ss;
        }

    }
}

