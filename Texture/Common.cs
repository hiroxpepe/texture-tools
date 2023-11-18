// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Collections.Generic;

namespace Texture {
    /// <summary>
    /// common classes
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>

    /// <summary>
    /// name of Dictionary is too long, it be named Map.
    /// </summary>
    /// <note>
    /// + used in the Checkered namespace. <br/>
    /// </note>
    public class Map<K, V> : Dictionary<K, V> {
    }

    /// <summary>
    /// changed event args.
    /// </summary>
    /// <note>
    /// + used in the Checkered namespace. <br/>
    /// </note>
    public class EvtArgs : EventArgs {
        public EvtArgs(string name) {
            Name = name;
        }
        public string Name { get; }
    }

    /// <summary>
    /// changed event handler.
    /// </summary>
    /// <note>
    /// + used in the Checkered namespace. <br/>
    /// </note>
    public delegate void Changed(object sender, EvtArgs e);
}