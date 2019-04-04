// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Design
{

    #region " Design ControlBox "

    public class DesignControlBox : Control
    {

        

        #region " Initialisation de variable "

        Color Couleur_Ecriture_None = Color.FromArgb(70, 70, 70);
        Color Couleur_Ecriture_Over = Color.FromArgb(150, 150, 150);

        Color Couleur_Ecriture_Down = Color.FromArgb(200, 200, 200);
        Etat Etat_Bouton = Etat.None;

        Point Position = new Point();
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

        public DesignControlBox()
        {
            this.Size = new Size(40, 20);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DoubleBuffered = true;
        }

        #endregion

        #region " Gestion et création du design "

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.Default;

            Point Point_Min = new Point(2, 4);
            Point Point_Close = new Point(22, 5);

            //GESTION DES ETATS

            Color Couleur_Ecriture = default(Color);

            switch (Etat_Bouton)
            {
                case Etat.None:
                    Couleur_Ecriture = Couleur_Ecriture_None;
                    break;
                case Etat.Over:
                    Couleur_Ecriture = Couleur_Ecriture_Over;
                    break;
                case Etat.Down:
                    Couleur_Ecriture = Couleur_Ecriture_Down;
                    break;
            }

            //ECRITURE

            if ((Position.X <= 20))
            {
                e.Graphics.DrawString("0", new Font("Marlett", 8), new SolidBrush(Couleur_Ecriture), Point_Min);
                e.Graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(Couleur_Ecriture_None), Point_Close);
            }
            else
            {
                e.Graphics.DrawString("0", new Font("Marlett", 8), new SolidBrush(Couleur_Ecriture_None), Point_Min);
                e.Graphics.DrawString("r", new Font("Marlett", 8), new SolidBrush(Couleur_Ecriture), Point_Close);
            }
        }

        #endregion

        #region " Gestion des actions "

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Position = e.Location;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if ((Position.X <= 20))
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
        }

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


