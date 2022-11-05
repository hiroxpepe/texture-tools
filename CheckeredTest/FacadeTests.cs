using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkered {
    [TestClass()]
    public class FacadeTests {
#nullable enable
        [TestMethod()]
        public void ExecuteTest() {
            Facade.Execute();
        }
    }
}
