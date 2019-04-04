// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
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

