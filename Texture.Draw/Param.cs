// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;

namespace Texture {
    /// <summary>
    /// parameter object for app.
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public class Param {

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Fields

        int _piece_count;
        
        double _crop;
        
        string _primary;
        
        string _secondary;
        
        string _accent;
        
        float _alpha;

        int _swing;

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor

        /// <summary>
        /// creates as a "note" notated parameter.
        /// </summary>
        public Param(int piece_count, double crop, string primary, string secondary, string accent, float alpha, int swing) {
            if (piece_count < 0) throw new ArgumentException("Piece count must be non-negative.");
            if (crop < 0 || crop > 1) throw new ArgumentException("Crop must be between 0 and 1.");
            if (string.IsNullOrWhiteSpace(primary)) throw new ArgumentException("Primary color must not be null or empty.");
            if (string.IsNullOrWhiteSpace(secondary)) throw new ArgumentException("Secondary color must not be null or empty.");
            if (string.IsNullOrWhiteSpace(accent)) throw new ArgumentException("Accent color must not be null or empty.");
            if (alpha < 0 || alpha > 1) throw new ArgumentException("Alpha must be between 0 and 1.");
            if (swing < 0) throw new ArgumentException("Swing must be non-negative.");

            _piece_count = piece_count;
            _crop = crop;
            _primary = primary;
            _secondary = secondary;
            _accent = accent;
            _alpha = alpha;
            _swing = swing;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties [noun, adjective]

        public int PieceCount { get => _piece_count; }
        
        public double Crop { get => _crop; }
        
        public string Primary { get => _primary; }
        
        public string Secondary { get => _secondary; }
        
        public string Accent { get => _accent; }
        
        public float Alpha { get => _alpha; }

        public int Swing { get => _swing; }
    }
}