// Copyright (c) STUDIO MeowToon. All rights reserved.
// Licensed under the GPL v2.0 license. See LICENSE text in the project root for license information.

namespace Texture.Core {
    /// <summary>
    /// tool interface
    /// </summary>
    /// <company>STUDIO MeowToon</company>
    /// <author>Hiroyuki Adachi</author>
    public interface ITool {
        public void Draw(Point[] points);

        public void Draw(Point[] points, Color color);

        public void Fill(Point[] points);

        public void Fill(Point[] points, Color color);

        public void Fill(Point[] points, Color color, int img_idx);

        public void Fill(Point[] points, Color color, int img_idx, int cell_idx);

        public void Fill(Point[] points, Color color, int img_idx, int cell_idx, bool debug);

        public void Write(int img_idx);
    }
}