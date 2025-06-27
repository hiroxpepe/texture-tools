// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

using System;

namespace Texture {
    /// <summary>
    /// Provides parameter objects for the application.
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
        /// Initializes a parameter object with validation.
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

        /// <summary>
        /// Gets the piece count.
        /// </summary>
        public int PieceCount { get => _piece_count; }
        
        /// <summary>
        /// Gets the crop value.
        /// </summary>
        public double Crop { get => _crop; }
        
        /// <summary>
        /// Gets the primary color.
        /// </summary>
        public string Primary { get => _primary; }
        
        /// <summary>
        /// Gets the secondary color.
        /// </summary>
        public string Secondary { get => _secondary; }
        
        /// <summary>
        /// Gets the accent color.
        /// </summary>
        public string Accent { get => _accent; }
        
        /// <summary>
        /// Gets the alpha value.
        /// </summary>
        public float Alpha { get => _alpha; }

        /// <summary>
        /// Gets the swing value.
        /// </summary>
        public int Swing { get => _swing; }
    }
}