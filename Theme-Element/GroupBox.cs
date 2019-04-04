// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Element
{

    public class ElementGroupBox : ContainerControl
    {

        #region " Properties "
        private Color _SideColor = Color.FromArgb(231, 75, 60);
        public Color SideColor
        {
            get { return _SideColor; }
            set { _SideColor = value; }
        }

        #endregion

        public ElementGroupBox()
        {
            Size = new Size(200, 100);
            BackColor = Color.FromArgb(32, 32, 32);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(32, 32, 32));

            G.FillRectangle(new SolidBrush(_SideColor), new Rectangle(0, 0, 7, Height));
            G.DrawString(Text, new Font("Arial", 9), Brushes.White, new Point(10, 4));
        }
    }


}


