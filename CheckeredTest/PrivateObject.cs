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
using System.Reflection;

namespace CheckeredTest {
    /// <summary>
    /// PrivateObject for MSTest
    /// </summary>
    /// <author>h.adachi (STUDIO MeowToon)</author>
    public class PrivateObject {
#nullable enable

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        private readonly object _ob;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        public PrivateObject(object ob) {
            _ob = ob;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // public Methods [verb, verb phrases]

        public object? Invoke(string method_name, params object[] args) {
            Type type = _ob.GetType();
            BindingFlags binding_flags = BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance;
            try {
                return type.InvokeMember(name: method_name, invokeAttr: binding_flags, binder: null, target: _ob, args: args);
            }
            catch (Exception ex) {
                throw ex.InnerException;
            }
        }

        public object? Invoke(string method_name) {
            Type type = _ob.GetType();
            BindingFlags binding_flags = BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance;
            try {
                return type.InvokeMember(name: method_name, invokeAttr: binding_flags, binder: null, target: _ob, args: null);
            }
            catch (Exception ex) {
                throw ex.InnerException;
            }
        }
    }
}
