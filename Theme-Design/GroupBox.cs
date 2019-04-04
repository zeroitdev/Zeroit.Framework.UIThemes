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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Design
{

    #region " Design GroupBox "

    public class DesignGroupBox : ContainerControl
    {
              
        #region " Initialisation de variable "

        Color Couleur_Ecriture = Color.DarkGray;

        Color Couleur_BackColor = Color.FromArgb(27, 27, 27);
        Color Couleur_Degrade1 = Color.FromArgb(39, 39, 39);

        Color Couleur_Degrade2 = Color.FromArgb(24, 24, 24);

        Color Couleur_BordureExt = Color.Black;
        Color Couleur_BordureInt1_Haut = Color.FromArgb(52, 52, 52);
        Color Couleur_BordureInt1_Bas = Color.FromArgb(37, 37, 37);

        Color Couleur_BordureInt2 = Color.FromArgb(43, 43, 43);

        Color Couleur_Separation = Color.Black;

        int Hauteur_Barre = 25;
        #endregion

        #region " Gestion du New "

        public DesignGroupBox()
        {
            this.Size = new Size(172, 108);
            Font = new Font("Verdana", 8.25f, FontStyle.Regular);
            DoubleBuffered = true;
            Padding = new Padding(2, 27, 2, 2);
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

            Rectangle Rectangle_Ecriture = new Rectangle(9, 2, Width - 9, Hauteur_Barre - 2);

            e.Graphics.DrawString(Text, Font, new SolidBrush(Couleur_Ecriture), Rectangle_Ecriture, StringFormat);
            StringFormat.Dispose();

            //BORDURE INT1

            Rectangle Rectangle_BordureInt1 = new Rectangle(1, 1, Width - 3, Hauteur_Barre - 2);
            Rectangle Rectangle_BordureInt1_AvecBordure = new Rectangle(0, 0, Width - 1, Hauteur_Barre);

            LinearGradientBrush Brush_BordureInt1 = new LinearGradientBrush(Rectangle_BordureInt1_AvecBordure, Couleur_BordureInt1_Haut, Couleur_BordureInt1_Bas, LinearGradientMode.Vertical);
            e.Graphics.DrawRectangle(new Pen(Brush_BordureInt1, 1), Rectangle_BordureInt1);

            //BORDURE INT2

            Rectangle Rectangle_BordureInt2 = new Rectangle(1, Hauteur_Barre, Width - 3, Height - Hauteur_Barre - 2);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureInt2, 1), Rectangle_BordureInt2);

            //SEPARATION

            Point Separation_Point1 = new Point(0, Hauteur_Barre);
            Point Separation_Point2 = new Point(Width, Hauteur_Barre);

            e.Graphics.DrawLine(new Pen(Couleur_Separation, 1), Separation_Point1, Separation_Point2);

            //BORDURE EXT

            Rectangle Rectangle_BordureExt = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureExt, 1), Rectangle_BordureExt);

        }

        #endregion

        #region " Gestion des actions "

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        #endregion

    }

    #endregion
    
}


