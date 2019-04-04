// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Positron
{

    public class PositronLabel : Label
    {
        public PositronLabel()
        {
            ForeColor = Color.FromArgb(100, 100, 100);
            BackColor = Color.Transparent;
            Font = new Font("Verdana", 8);
        }
    }

}

