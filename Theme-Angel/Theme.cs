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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Angel
{



    #region " Enums "      
    /// <summary>
    /// Enum MouseState
    /// </summary>
    public enum MouseState
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The over
        /// </summary>
        Over = 1,
        /// <summary>
        /// Down
        /// </summary>
        Down = 2
    }

    /// <summary>
    /// Enum Alignment
    /// </summary>
    public enum Alignment
    {
        /// <summary>
        /// The left
        /// </summary>
        Left = 0,
        /// <summary>
        /// The centre
        /// </summary>
        Centre = 1,
        /// <summary>
        /// The right
        /// </summary>
        Right = 2
    }

    /// <summary>
    /// Enum State
    /// </summary>
    enum State
    {
        /// <summary>
        /// The enabled
        /// </summary>
        Enabled = 0,
        /// <summary>
        /// The disabled
        /// </summary>
        Disabled = 1
    }

    #endregion

    /// <summary>
    /// Class AngelTheme.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    [ToolboxItem(false)]
    public class AngelTheme : ContainerControl
    {

        #region " Back End "

        #region " Declarations "
        /// <summary>
        /// The h
        /// </summary>
        private int H = 52;
        /// <summary>
        /// The d
        /// </summary>
        private bool D = false;
        /// <summary>
        /// The p
        /// </summary>
        private Point P;
        #endregion
        /// <summary>
        /// a
        /// </summary>
        private Alignment A = Alignment.Left;

        #region " Mouse States "
        
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            D = false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (new Rectangle(0, 0, Width, H).Contains(e.Location) && e.Button == MouseButtons.Left)
            {
                P = e.Location;
                D = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (D == true)
            {
                ParentForm.Location = new Point(MousePosition.X - P.X, MousePosition.Y - P.Y);
            }
        }

        #endregion

        #region " Properties "

        #region " Appearance "
        /// <summary>
        /// Gets or sets the text alignment.
        /// </summary>
        /// <value>The text alignment.</value>
        [Category("Appearance")]
        public Alignment TextAlignment
        {
            get { return A; }
            set
            {
                A = value;
                Invalidate();
            }
        }

        #endregion

        #endregion

        #region " Misc "

        /// <summary>
        /// Called when [create control].
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Parent.FindForm().AllowTransparency = true;
            Parent.FindForm().TransparencyKey = Color.Fuchsia;
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(17, 33, 47);
            Dock = DockStyle.Fill;
            Font = new Font("Segoe UI", 12);
            Invalidate();
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
            G.Clear(Color.Black);
            G.DrawRectangle(new Pen(Color.FromArgb(10, 33, 55)), new Rectangle(0, 0, Width - 1, H));
            G.FillRectangle(new LinearGradientBrush(new Point(1, 1), new Point(1, H), Color.FromArgb(75, 168, 218), Color.FromArgb(33, 112, 177)), new Rectangle(1, 1, Width - 2, H - 1));
            G.FillRectangle(new LinearGradientBrush(new Point(2, 2), new Point(2, H - 1), Color.FromArgb(54, 131, 203), Color.FromArgb(26, 86, 145)), new Rectangle(2, 2, Width - 4, H - 3));
            G.DrawRectangle(new Pen(Color.FromArgb(27, 48, 66)), new Rectangle(1, H + 1, Width - 3, Height - H - 3));
            G.FillRectangle(new SolidBrush(Color.FromArgb(17, 33, 47)), new Rectangle(2, H + 1, Width - 4, Height - H - 3));

            StringFormat F = new StringFormat { LineAlignment = StringAlignment.Center };
            switch (A)
            {
                case Alignment.Left:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(8, 0, Width, H), F);
                    break;
                case Alignment.Centre:
                    F.Alignment = StringAlignment.Center;
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 0, Width - 1, H), F);
                    break;
                case Alignment.Right:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(Width - TextRenderer.MeasureText(Text, Font).Width - 8, 0, TextRenderer.MeasureText(Text, Font).Width + 8, H), F);
                    break;
            }

        }

    }
    
}