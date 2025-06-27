using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Drawing;
using static Texture.Draw.Cropped;

namespace Texture.Draw {
    [TestClass()]
    public class CroppedTests {
        [TestMethod("Handles same rectangle")]
        public void sliceTest1() {
            Rectangle src = new(x: 0, y: 0, width: 256, height: 256);
            Rectangle dest = new(x: 0, y: 0, width: 256, height: 256);
            Cropped ob = NewCropped(src: src, dest: dest);
            Rectangle result = ob.Do();
            Rectangle expected = new(x: 0, y: 0, width: 256, height: 256);
            AreEqual(expected, result);
        }

        [TestMethod("Crops destination by source")]
        public void sliceTest2() {
            Rectangle src = new(x: 0, y: 0, width: 256, height: 256);
            Rectangle dest = new(x: 0, y: 0, width: 384, height: 384);
            Cropped ob = NewCropped(src: src, dest: dest);
            Rectangle result = ob.Do();
            Rectangle expected = new(x: 64, y: 64, width: 256, height: 256);
            AreEqual(expected, result);
        }
    }
}