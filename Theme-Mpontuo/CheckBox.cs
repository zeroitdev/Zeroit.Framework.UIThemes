// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
    public class MpontuoCheck : ThemeControl
    {
        private bool _CheckedState;
        public bool CheckedState
        {
            get
            {
                return _CheckedState;
            }
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }
        public MpontuoCheck()
        {
            Size = new Size(100, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
            C1 = Color.FromArgb(132, 192, 240);
            C2 = Color.FromArgb(65, 65, 65);
            C3 = Color.FromArgb(132, 192, 240);
            C4 = Color.FromArgb(65, 65, 65);
            C5 = Color.FromArgb(35, 35, 35);
            C6 = Color.FromArgb(40, 40, 40);
            P1 = Color.FromArgb(25, 25, 25);
            P2 = Color.FromArgb(59, 59, 59);
            B1 = Color.FromArgb(66, 130, 181);
            SubscribeToEvents();
        }
        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Color P1;
        private Color P2;
        private Color B1;

        public override void PaintHook()
        {
            G.Clear(C6);
            switch (CheckedState)
            {
                case true:
                    DrawGradient(C1, C2, 3, 3, 10, 9, 90);
                    DrawGradient(C3, C4, 4, 4, 10, 7, 90);
                    break;
                case false:
                    DrawGradient(C5, C5, 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(new Pen(new SolidBrush(P1)), 0, 0, 14, 14);
            G.DrawRectangle(new Pen(new SolidBrush(P2)), 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, (B1), 17, 0);
            DrawCorners(C6, new Rectangle(0, 0, 13, 13));
        }
        public void changeCheck(object sender, EventArgs e)
        {
            switch (CheckedState)
            {
                case true:
                    CheckedState = false;
                    break;
                case false:
                    CheckedState = true;
                    break;
            }
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Click += changeCheck;
        }

    }
}

