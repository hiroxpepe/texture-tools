// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Windows.Forms;

namespace Texture.Win64 {
    /// <summary>
    /// the application
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    static class Program {
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}