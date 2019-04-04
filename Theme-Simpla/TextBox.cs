// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Simpla
{

    public class SimplaTextBox : TextBox
    {

        public SimplaTextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            Font = new Font("Tahoma", 9, FontStyle.Bold);
            BackColor = Color.FromArgb(35, 35, 35);
            ForeColor = Color.WhiteSmoke;
        }
    }

}

