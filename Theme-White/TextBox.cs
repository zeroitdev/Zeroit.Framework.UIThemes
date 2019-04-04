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

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteTextBox : TextBox
    {

        public WhiteTextBox()
        {
            this.ForeColor = Color.DarkBlue;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.Text = this.Name;
        }
    }


}

