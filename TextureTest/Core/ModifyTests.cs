using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Texture.Core {
    [TestClass]
    public class ModifyTests {
        [TestMethod("Sets and gets static properties")]
        public void Modify_StaticProperties_ShouldSetAndGetValues() {
            Modify.Range.Hue = 0.5f;
            Modify.Range.Saturation = 0.6f;
            Modify.Range.Value = 0.7f;
            Modify.Adjust.Saturation = 0.8f;
            Modify.Adjust.Value = 0.9f;
            Modify.Mode.Expand = true;
            Modify.Mode.Rock = false;
            Modify.Mode.Line = true;
            Modify.Pen.Alpha = 0.4f;
            Modify.Pen.Width = 2.0f;
            Assert.AreEqual(0.5f, Modify.Range.Hue);
            Assert.AreEqual(0.6f, Modify.Range.Saturation);
            Assert.AreEqual(0.7f, Modify.Range.Value);
            Assert.AreEqual(0.8f, Modify.Adjust.Saturation);
            Assert.AreEqual(0.9f, Modify.Adjust.Value);
            Assert.IsTrue(Modify.Mode.Expand);
            Assert.IsFalse(Modify.Mode.Rock);
            Assert.IsTrue(Modify.Mode.Line);
            Assert.AreEqual(0.4f, Modify.Pen.Alpha);
            Assert.AreEqual(2.0f, Modify.Pen.Width);
        }
    }
}