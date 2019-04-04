// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Zeroit.Framework.UIThemes.Atrocity
{

    public class TabControl : System.Windows.Forms.TabControl
    {
        //It may not be mine, but I tweaked the bugger out of the tabpage design.
        #region "This is not mine; it has been used under the MIT license. Expand to read"
        //Copyright (c) 2005 Mick Doherty : http://www.dotnetrix.co.uk
        //Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

        //The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

        //THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
        #endregion

        #region " Windows Form Designer generated code "

        public TabControl()
            : base()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        //UserControl1 overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #region " InterOP "

        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public Int32 HWND;
            public Int32 idFrom;
            public Int32 code;
            public string ToString()
            {
                return string.Format("Hwnd: {0}, ControlID: {1}, Code: {2}", HWND, idFrom, code);
            }
        }


        private const Int32 TCN_FIRST = (int)0xffddaL;


        private const Int32 TCN_SELCHANGING = (TCN_FIRST - 2);
        private const Int32 WM_USER = (int)0x400L;
        private const Int32 WM_NOTIFY = (int)0x4eL;

        private const Int32 WM_REFLECT = WM_USER + (int)0x1c00L;

        //private const ulong TCN_FIRST = 0xfffffffffffffddaL;


        //private const ulong TCN_SELCHANGING = (TCN_FIRST - 2);
        //private const ulong WM_USER = (int)0x400L;
        //private const ulong WM_NOTIFY = (int)0x4eL;

        //private const ulong WM_REFLECT = WM_USER + (int)0x1c00L;
        #endregion

        #region " BackColor Manipulation "

        //As well as exposing the property to the Designer we want it to behave just like any other 
        //controls BackColor property so we need some clever manipulation.
        private Color m_Backcolor = Color.Empty;
        [Browsable(true), Description("The background color used to display text and graphics in a control.")]
        public override Color BackColor
        {
            get
            {
                if (m_Backcolor.Equals(Color.Empty))
                {
                    if (Parent == null)
                    {
                        return Control.DefaultBackColor;
                    }
                    else
                    {
                        return Parent.BackColor;
                    }
                }
                return m_Backcolor;
            }
            set
            {
                if (m_Backcolor.Equals(value))
                    return;
                m_Backcolor = value;
                Invalidate();
                //Let the Tabpages know that the backcolor has changed.
                base.OnBackColorChanged(EventArgs.Empty);
            }
        }
        public bool ShouldSerializeBackColor()
        {
            return !m_Backcolor.Equals(Color.Empty);
        }
        public override void ResetBackColor()
        {
            m_Backcolor = Color.Empty;
            Invalidate();
        }

        #endregion

        protected override void OnParentBackColorChanged(System.EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnSelectedIndexChanged(System.EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            Rectangle r = this.ClientRectangle;
            if (TabCount <= 0)
                return;
            //Draw a custom background for Transparent TabPages
            r = SelectedTab.Bounds;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Font DrawFont = new Font(Font.FontFamily, 24, FontStyle.Regular, GraphicsUnit.Pixel);
            ControlPaint.DrawStringDisabled(e.Graphics, "", DrawFont, BackColor, r, sf);
            DrawFont.Dispose();
            //Draw a border around TabPage
            r.Inflate(3, 3);
            TabPage tp = TabPages[SelectedIndex];
            SolidBrush PaintBrush = new SolidBrush(tp.BackColor);
            e.Graphics.FillRectangle(PaintBrush, r);
            ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, ButtonBorderStyle.Outset);
            //Draw the Tabs
            for (int index = 0; index <= TabCount - 1; index++)
            {
                tp = TabPages[index];
                tp.Invalidate();
                tp.ForeColor = Color.FromArgb(0, 168, 198);
                tp.BackColor = Color.FromArgb(41, 41, 41);
                r = GetTabRect(index);
                ButtonBorderStyle bs = ButtonBorderStyle.Outset;
                if (index == SelectedIndex)
                    bs = ButtonBorderStyle.Inset;
                PaintBrush.Color = tp.BackColor;
                e.Graphics.FillRectangle(PaintBrush, r);
                ControlPaint.DrawBorder(e.Graphics, r, PaintBrush.Color, bs);
                PaintBrush.Color = tp.ForeColor;

                //Set up rotation for left and right aligned tabs
                if (Alignment == TabAlignment.Left | Alignment == TabAlignment.Right)
                {
                    float RotateAngle = 90;
                    if (Alignment == TabAlignment.Left)
                        RotateAngle = 270;
                    PointF cp = new PointF(r.Left + (r.Width / 2), r.Top + (r.Height / 2));
                    e.Graphics.TranslateTransform(cp.X, cp.Y);
                    e.Graphics.RotateTransform(RotateAngle);
                    r = new Rectangle(-(r.Height / 2), -(r.Width / 2), r.Height, r.Width);
                }
                //Draw the Tab Text
                if (tp.Enabled)
                {
                    e.Graphics.DrawString(tp.Text, Font, PaintBrush, r, sf);
                }
                else
                {
                    ControlPaint.DrawStringDisabled(e.Graphics, tp.Text, Font, tp.BackColor, r, sf);
                }

                e.Graphics.ResetTransform();

            }
            PaintBrush.Dispose();
        }

        [Description("Occurs as a tab is being changed.")]
        public event SelectedTabPageChangeEventHandler SelectedIndexChanging;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_NOTIFY))
            {
                NMHDR hdr = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                if (hdr.code == TCN_SELCHANGING)
                {
                    TabPage tp = TestTab(this.PointToClient(Cursor.Position));
                    if ((tp != null))
                    {
                        TabPageChangeEventArgs e = new TabPageChangeEventArgs(this.SelectedTab, tp);
                        if (SelectedIndexChanging != null)
                        {
                            SelectedIndexChanging(this, e);
                        }
                        if (e.Cancel || tp.Enabled == false)
                        {
                            m.Result = new IntPtr(1);
                            return;
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }

        private TabPage TestTab(Point pt)
        {
            for (int index = 0; index <= TabCount - 1; index++)
            {
                if (GetTabRect(index).Contains(pt.X, pt.Y))
                {
                    return TabPages[index];
                }
            }
            return null;
        }
        #region " EventArgs Class's "

        public class TabPageChangeEventArgs : EventArgs
        {

            private TabPage _Selected;
            private TabPage _PreSelected;

            public bool Cancel = false;
            public TabPage CurrentTab
            {
                get { return _Selected; }
            }

            public TabPage NextTab
            {
                get { return _PreSelected; }
            }

            public TabPageChangeEventArgs(TabPage CurrentTab, TabPage NextTab)
            {
                _Selected = CurrentTab;
                _PreSelected = NextTab;
            }

        }

        public delegate void SelectedTabPageChangeEventHandler(object sender, TabPageChangeEventArgs e);

        #endregion
    }
    
}

