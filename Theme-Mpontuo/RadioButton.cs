// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoRadio : ThemeControl
    {
        private Color OuterColor = Color.FromArgb(25, 25, 25);
        private Color InnerColor = Color.FromArgb(59, 59, 59);
        private Color TC = Color.FromArgb(66, 130, 181);
        private Color CheckColor = Color.FromArgb(132, 192, 240);
        private Color BC = Color.FromArgb(40, 40, 40);
        public delegate void CheckChangedEventHandler();
        public event CheckChangedEventHandler CheckChanged;
        private int _index = 0;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                Invalidate();
            }
        }
        public override void PaintHook()
        {
            G.Clear(BC);
            DrawText(HorizontalAlignment.Left, TC, 17);
            switch (_Checked)
            {
                case true:
                    G.FillEllipse(new SolidBrush(CheckColor), 1, 1, 12, 12);
                    break;
                case false:
                    G.FillEllipse(new SolidBrush(BC), 1, 1, 12, 12);
                    break;
            }
            G.DrawEllipse(new Pen(new SolidBrush(OuterColor)), 0, 0, 14, 14);
            G.DrawEllipse(new Pen(new SolidBrush(InnerColor)), 1, 1, 12, 12);
        }

        public MpontuoRadio()
        {
            AllowTransparent();
            ForeColor = Color.White;
            Size S = new Size(22, 16);
            Size = S;
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            Font = new Font("Verdana", 8); //remove if using 1.51
            SubscribeToEvents();
        }

        public void tcc(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void RemoveCheck()
        {
            foreach (Control Ctrl in Parent.Controls)
            {
                if (Ctrl is MpontuoRadio)
                {
                    if (Ctrl.Handle == this.Handle)
                    {
                        continue;
                    }
                    if (!(((MpontuoRadio)Ctrl).Index == this.Index))
                    {
                        continue;
                    }
                    ((MpontuoRadio)Ctrl).Checked = false;
                }
            }
        }

        private bool _Checked = false;
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                if (value == _Checked)
                {
                    return;
                }
                _Checked = value;
                Invalidate();
                if (CheckChanged != null)
                    CheckChanged();
            }
        }

        public void changeCheck(object sender, EventArgs e)
        {
            _Checked = true;
            RemoveCheck();
        }

        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.TextChanged += tcc;
            this.Click += changeCheck;
        }

    }
}

