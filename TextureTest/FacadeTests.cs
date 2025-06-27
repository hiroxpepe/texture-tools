using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Texture {
    [TestClass()]
    public class FacadeTests {
        [TestMethod("Executes facade operation")]
        public void ExecuteTest() {
            Facade.Execute();
        }
    }
}