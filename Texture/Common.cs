/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace Texture {
    /// <summary>
    /// common classes
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>

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
