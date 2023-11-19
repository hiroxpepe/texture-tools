// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Core {
    /// <summary>
    /// edge class
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Edge {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields [nouns, noun phrases]

        protected float _length;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        protected Edge(int length) {
            _length = (float) length;
        }

        public static Edge NewEdge(int length) {
            return new(length);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, noun phrase, adjective] 

        public float Length { get => _length; }
    }

    public class Width : Edge {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Width(int length) : base(length) {
        }

        public static Edge NewWidth(int length) {
            return new Width(length);
        }
    }

    public class Height : Edge {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        Height(int length) : base(length) {
        }

        public static Edge NewHeight(int length) {
            return new Height(length);
        }
    }
}