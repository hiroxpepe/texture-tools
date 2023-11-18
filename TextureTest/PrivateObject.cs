// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;
using System.Reflection;

namespace Texture {
    /// <summary>
    /// PrivateObject for MSTest
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class PrivateObject {

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