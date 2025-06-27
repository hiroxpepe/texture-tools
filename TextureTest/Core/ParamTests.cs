using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Texture.Core {
    [TestClass]
    public class ParamTests {
        [TestMethod("Initializes properties in constructor")]
        public void Param_Constructor_ShouldInitializeProperties() {
            int pieceCount = 5;
            double crop = 0.5;
            string primary = "Red";
            string secondary = "Blue";
            string accent = "Green";
            float alpha = 0.8f;
            int swing = 10;
            Param param = new Param(pieceCount, crop, primary, secondary, accent, alpha, swing);
            Assert.AreEqual(pieceCount, param.PieceCount);
            Assert.AreEqual(crop, param.Crop);
            Assert.AreEqual(primary, param.Primary);
            Assert.AreEqual(secondary, param.Secondary);
            Assert.AreEqual(accent, param.Accent);
            Assert.AreEqual(alpha, param.Alpha);
            Assert.AreEqual(swing, param.Swing);
        }

        [TestMethod("Throws exception for invalid values in constructor")]
        [ExpectedException(typeof(ArgumentException))]
        public void Param_Constructor_ShouldThrowExceptionForInvalidValues() {
            int pieceCount = -1; // Invalid value
            double crop = -0.5;  // Invalid value
            string primary = ""; // Invalid value
            string secondary = ""; // Invalid value
            string accent = ""; // Invalid value
            float alpha = -0.8f; // Invalid value
            int swing = -10; // Invalid value
            Param param = new Param(pieceCount, crop, primary, secondary, accent, alpha, swing);
        }
    }
}