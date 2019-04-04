// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Form.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Design
{

    #region " Design Form "
    [ToolboxItem(false)]
    public class DesignForm : ContainerControl
    {

        

        #region " Initialisation de variable "

        private bool Locked = false;

        private Point Position;
        Color Couleur_Ecriture = Color.FromArgb(70, 70, 70);

        Color Couleur_BackColor = Color.FromArgb(25, 25, 25);
        Color Couleur_Degrade1 = Color.FromArgb(35, 35, 35);

        Color Couleur_Degrade2 = Color.FromArgb(25, 25, 25);

        Color Couleur_BordureExt = Color.Black;
        Color Couleur_BordureInt1_Haut = Color.FromArgb(74, 74, 74);
        Color Couleur_BordureInt1_Bas = Color.FromArgb(39, 39, 39);

        Color Couleur_BordureInt2 = Color.FromArgb(43, 43, 43);
        Color Couleur_Separation1 = Color.Black;
        Color Couleur_Separation2 = Color.FromArgb(0, 255, 0);

        Color Couleur_Separation3 = Color.Black;

        int Hauteur_Barre = 33;
        #endregion

        #region " Gestion du New "

        public DesignForm()
        {
            Dock = DockStyle.Fill;
            Font = new Font("Verdana", 10, FontStyle.Regular);
            SendToBack();
            DoubleBuffered = true;
            Padding = new Padding(2, 36, 2, 2);

        }

        #endregion

        #region " Propriétés "

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        #endregion

        #region " Gestion et création du design "

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.Default;

            //BACKGROUND

            e.Graphics.Clear(Couleur_BackColor);

            //HAUT

            Rectangle Rectangle_Haut = new Rectangle(0, 0, Width, Hauteur_Barre);
            LinearGradientBrush Haut_Brush = new LinearGradientBrush(Rectangle_Haut, Couleur_Degrade1, Couleur_Degrade2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(Haut_Brush, Rectangle_Haut);
            Haut_Brush.Dispose();

            //ECRITURE

            StringFormat StringFormat = new StringFormat();
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Near;

            Rectangle Rectangle_Ecriture = new Rectangle(15, 0, Width - 15, Hauteur_Barre);

            e.Graphics.DrawString(Text, Font, new SolidBrush(Couleur_Ecriture), Rectangle_Ecriture, StringFormat);
            StringFormat.Dispose();

            //BORDURE INT1

            Rectangle Rectangle_BordureInt1 = new Rectangle(1, 1, Width - 3, Hauteur_Barre - 4);
            Rectangle Rectangle_BordureInt1_AvecBordure = new Rectangle(0, 0, Width - 1, Hauteur_Barre - 2);

            LinearGradientBrush Brush_BordureInt1 = new LinearGradientBrush(Rectangle_BordureInt1_AvecBordure, Couleur_BordureInt1_Haut, Couleur_BordureInt1_Bas, LinearGradientMode.Vertical);
            e.Graphics.DrawRectangle(new Pen(Brush_BordureInt1, 1), Rectangle_BordureInt1);

            //BORDURE INT2

            Rectangle Rectangle_BordureInt2 = new Rectangle(1, Hauteur_Barre + 2, Width - 3, Height - Hauteur_Barre - 4);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureInt2, 1), Rectangle_BordureInt2);

            //SEPARATION

            Point Separation_Point1 = new Point(0, Hauteur_Barre);
            Point Separation_Point2 = new Point(Width, Hauteur_Barre);

            LinearGradientBrush Separation_Brush = new LinearGradientBrush(Separation_Point1, Separation_Point2, Color.Black, Color.Black);

            ColorBlend ColorBlend = new ColorBlend();
            ColorBlend.Colors = new Color[] {
            Couleur_Separation1,
            Couleur_Separation2,
            Couleur_Separation3
        };
            ColorBlend.Positions = new float[] {
            0,
            0.5f,
            1
        };

            Separation_Brush.InterpolationColors = ColorBlend;

            e.Graphics.DrawLine(new Pen(Separation_Brush, 2), Separation_Point1, Separation_Point2);

            Separation_Brush.Dispose();

            //BORDURE EXT1

            Rectangle Rectangle_BordureExt1 = new Rectangle(0, 0, Width - 1, Hauteur_Barre - 2);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureExt, 1), Rectangle_BordureExt1);

            //BORDURE EXT2

            Rectangle Rectangle_BordureExt2 = new Rectangle(0, Hauteur_Barre + 1, Width - 1, Height - Hauteur_Barre - 2);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureExt, 1), Rectangle_BordureExt2);

        }

        #endregion

        #region " Gestion des actions "

        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle Rectangle = new Rectangle(0, 0, Width, Hauteur_Barre);
            if ((Rectangle.Contains(e.Location)))
            {
                Locked = true;
                Position = e.Location;
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Locked = false;
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if ((Locked))
            {
                Parent.FindForm().Location = new Point(Cursor.Position.X - Position.X, Cursor.Position.Y - Position.Y);
            }
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        #endregion
    }

    #endregion
    
}


