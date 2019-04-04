// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Design
{


    #region " Design Button "

    public class DesignButton : Control
    {

        

        #region " Initialisation de variable "


        Color Couleur_Ecriture = Color.FromArgb(170, 170, 170);
        Color Couleur_Degrade1_None = Color.FromArgb(40, 40, 40);

        Color Couleur_Degrade2_None = Color.FromArgb(20, 20, 20);
        Color Couleur_Degrade1_Over = Color.FromArgb(46, 46, 46);

        Color Couleur_Degrade2_Over = Color.FromArgb(26, 26, 26);
        Color Couleur_Degrade1_Down = Color.FromArgb(37, 37, 37);

        Color Couleur_Degrade2_Down = Color.FromArgb(18, 18, 18);

        Color Couleur_BordureExt = Color.Black;
        Color Couleur_BordureInt_Haut_None = Color.FromArgb(53, 53, 53);

        Color Couleur_BordureInt_Bas_None = Color.FromArgb(34, 34, 34);
        Color Couleur_BordureInt_Haut_Over = Color.FromArgb(58, 58, 58);

        Color Couleur_BordureInt_Bas_Over = Color.FromArgb(39, 39, 39);
        Color Couleur_BordureInt_Haut_Down = Color.FromArgb(50, 50, 50);

        Color Couleur_BordureInt_Bas_Down = Color.FromArgb(32, 32, 32);

        Etat Etat_Bouton = Etat.None;
        #endregion

        #region " Initialisation des Enum "

        public enum Etat : int
        {
            None,
            Over,
            Down
        }

        #endregion

        #region " Gestion du New "

        public DesignButton()
        {
            this.Size = new Size(130, 40);
            Font = new Font("Verdana", 9, FontStyle.Regular);
            DoubleBuffered = true;
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

            //GESTION DES ETATS

            Color Couleur_Degrade1 = new Color();
            Color Couleur_Degrade2 = new Color();

            Color Couleur_BordureInt_Haut = new Color();
            Color Couleur_BordureInt_Bas = new Color();

            switch (Etat_Bouton)
            {
                case Etat.None:
                    Couleur_Degrade1 = Couleur_Degrade1_None;
                    Couleur_Degrade2 = Couleur_Degrade2_None;

                    Couleur_BordureInt_Haut = Couleur_BordureInt_Haut_None;
                    Couleur_BordureInt_Bas = Couleur_BordureInt_Bas_None;
                    break;
                case Etat.Over:
                    Couleur_Degrade1 = Couleur_Degrade1_Over;
                    Couleur_Degrade2 = Couleur_Degrade2_Over;

                    Couleur_BordureInt_Haut = Couleur_BordureInt_Haut_Over;
                    Couleur_BordureInt_Bas = Couleur_BordureInt_Bas_Over;
                    break;
                case Etat.Down:
                    Couleur_Degrade1 = Couleur_Degrade1_Down;
                    Couleur_Degrade2 = Couleur_Degrade2_Down;

                    Couleur_BordureInt_Haut = Couleur_BordureInt_Haut_Down;
                    Couleur_BordureInt_Bas = Couleur_BordureInt_Bas_Down;
                    break;
            }

            //BACKGROUND

            Rectangle Rectangle_Haut = new Rectangle(0, 0, Width, Height);

            LinearGradientBrush Haut_Brush = new LinearGradientBrush(Rectangle_Haut, Couleur_Degrade1, Couleur_Degrade2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(Haut_Brush, Rectangle_Haut);
            Haut_Brush.Dispose();

            //ECRITURE

            StringFormat StringFormat = new StringFormat();
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Center;

            Rectangle Rectangle_Ecriture = new Rectangle(0, 0, Width, Height);

            e.Graphics.DrawString(Text, Font, new SolidBrush(Couleur_Ecriture), Rectangle_Ecriture, StringFormat);

            //BORDURE INT

            Rectangle Rectangle_BordureInt = new Rectangle(1, 1, Width - 3, Height - 3);
            Rectangle Rectangle_BordureInt_AvecBordure = new Rectangle(0, 0, Width - 1, Height - 1);

            LinearGradientBrush Brush_BordureInt = new LinearGradientBrush(Rectangle_BordureInt_AvecBordure, Couleur_BordureInt_Haut, Couleur_BordureInt_Bas, LinearGradientMode.Vertical);
            e.Graphics.DrawRectangle(new Pen(Brush_BordureInt, 1), Rectangle_BordureInt);

            //BORDURE EXT

            Rectangle Rectangle_BordureExt = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(new Pen(Couleur_BordureExt, 1), Rectangle_BordureExt);
        }

        #endregion

        #region " Gestion des actions "

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Etat_Bouton = Etat.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            Etat_Bouton = Etat.None;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Etat_Bouton = Etat.Down;
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Etat_Bouton = Etat.Over;
            Invalidate();
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


