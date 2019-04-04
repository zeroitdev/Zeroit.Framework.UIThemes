// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-16-2017
// ***********************************************************************
// <copyright file="Angel Theme.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Angel
{



    /// <summary>
    /// Class AngelTextBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [DefaultEvent("TextChanged")]
    public class AngelTextBox : Control
    {

        #region " Back End "

        #region " Declarations "
        /// <summary>
        /// The s
        /// </summary>
        private MouseState S = MouseState.None;
        /// <summary>
        /// The t
        /// </summary>
        private TextBox T;
        /// <summary>
        /// a
        /// </summary>
        private HorizontalAlignment A = HorizontalAlignment.Left;
        /// <summary>
        /// The l
        /// </summary>
        private int L = 32767;
        /// <summary>
        /// The r
        /// </summary>
        private bool R;
        /// <summary>
        /// The pw
        /// </summary>
        private bool Pw;
        #endregion
        /// <summary>
        /// The ml
        /// </summary>
        private bool ML;

        #region " Mouse States "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            S = MouseState.Down;
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            S = MouseState.Over;
            T.Focus();
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            S = MouseState.Over;
            T.Focus();
            Invalidate();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            S = MouseState.None;
            Invalidate();
        }

        #endregion

        #region " Properties "

        #region " Appearance "

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        [Category("Appearance")]
        public HorizontalAlignment TextAlign
        {
            get { return A; }
            set
            {
                A = value;
                if (T != null)
                {
                    T.TextAlign = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        [Category("Appearance")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (T != null)
                {
                    T.Text = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Category("Appearance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (T != null)
                {
                    T.Font = value;
                    T.Location = new Point(3, 5);
                    T.Width = Width - 6;

                    if (!ML)
                    {
                        Height = T.Height + 11;
                    }
                }
            }
        }

        #endregion

        #region " Behaviour "
        
        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>The maximum length.</value>
        [Category("Behavior")]
        public int MaxLength
        {
            get { return L; }
            set
            {
                L = value;
                if (T != null)
                {
                    T.MaxLength = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool ReadOnly
        {
            get { return R; }
            set
            {
                R = value;
                if (T != null)
                {
                    T.ReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use system password character].
        /// </summary>
        /// <value><c>true</c> if [use system password character]; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool UseSystemPasswordChar
        {
            get { return Pw; }
            set
            {
                Pw = value;
                if (T != null)
                {
                    T.UseSystemPasswordChar = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AngelTextBox"/> is multiline.
        /// </summary>
        /// <value><c>true</c> if multiline; otherwise, <c>false</c>.</value>
        [Category("Behavior")]
        public bool Multiline
        {
            get { return ML; }
            set
            {
                ML = value;
                if (T != null)
                {
                    T.Multiline = value;

                    if (value)
                    {
                        T.Height = Height - 11;
                    }
                    else
                    {
                        Height = T.Height + 11;
                    }

                }
            }
        }


        #endregion

        #endregion

        #region " Misc "

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl" /> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(T))
            {
                Controls.Add(T);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:BaseTextChanged" /> event.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = T.Text;
        }

        /// <summary>
        /// Handles the <see cref="E:BaseKeyDown" /> event.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                T.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                T.Copy();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            T.Location = new Point(5, 5);
            T.Width = Width - 10;

            if (ML)
            {
                T.Height = Height - 11;
            }
            else
            {
                Height = T.Height + 11;
            }

            base.OnResize(e);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AngelTextBox"/> class.
        /// </summary>
        public AngelTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            T = new TextBox();
            T.Font = new Font("Segoe UI", 10);
            T.Text = Text;
            T.BackColor = Color.FromArgb(10, 25, 38);
            T.ForeColor = Color.White;
            T.MaxLength = L;
            T.Multiline = ML;
            T.ReadOnly = R;
            T.UseSystemPasswordChar = Pw;
            T.BorderStyle = BorderStyle.None;
            T.Location = new Point(5, 5);
            T.Width = Width - 10;
            T.Cursor = Cursors.IBeam;
            if (ML)
            {
                T.Height = Height - 11;
            }
            else
            {
                Height = T.Height + 11;
            }
            T.TextChanged += OnBaseTextChanged;
            T.KeyDown += OnBaseKeyDown;
            Font = new Font("Segoe UI", 10);
        }

        #endregion

        #endregion
        
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(10, 25, 38));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(new Pen(Color.FromArgb(70, 103, 143)), new Rectangle(1, 1, Width - 3, Height - 3));
        }

    }

}