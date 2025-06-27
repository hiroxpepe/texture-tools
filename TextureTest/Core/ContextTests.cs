using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Drawing;

namespace Texture.Core {
    [TestClass]
    public class ContextTests {
        [TestMethod("Invokes OnDo event")]
        public void Context_Do_ShouldInvokeOnDoEvent() {
            Rectangle rect = new Rectangle(0, 0, 256, 256);
            Param[] paramArray = {
                new Param(5, 0.5, "Red", "Blue", "Green", 0.8f, 10),
                new Param(6, 0.6, "Yellow", "Purple", "Orange", 0.9f, 15)
            };
            bool eventInvoked = false;
            Context.OnDo += (sender, e) => {
                eventInvoked = true;
                Assert.AreEqual("file_path", e.Name);
            };
            bool result = Context.Do(rect, paramArray, use_layer2: true);
            Assert.IsTrue(result);
            Assert.IsTrue(eventInvoked);
        }

        [TestMethod("Throws exception for invalid rectangle")]
        [ExpectedException(typeof(System.Exception))]
        public void Context_Do_ShouldThrowExceptionForInvalidRectangle() {
            Rectangle rect = new Rectangle(-1, -1, -256, -256); // Invalid rectangle
            Param[] paramArray = {
                new Param(5, 0.5, "Red", "Blue", "Green", 0.8f, 10),
                new Param(6, 0.6, "Yellow", "Purple", "Orange", 0.9f, 15)
            };
            Context.Do(rect, paramArray, use_layer2: true);
        }

        [TestMethod("Handles single layer")]
        public void Context_Do_ShouldHandleSingleLayer() {
            Rectangle rect = new Rectangle(0, 0, 256, 256);
            Param[] paramArray = {
                new Param(5, 0.5, "Red", "Blue", "Green", 0.8f, 10),
                new Param(6, 0.6, "Yellow", "Purple", "Orange", 0.9f, 15)
            };
            bool result = Context.Do(rect, paramArray, use_layer2: false);
            Assert.IsTrue(result);
        }
    }
}