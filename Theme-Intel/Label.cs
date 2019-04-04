// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{

    public class iLabel : Label
    {

        public iLabel()
        {
            BackColor = Color.Transparent;
            ForeColor = Color.Silver;
            Font = new Font("Verdana", 8);
        }

    }


}


