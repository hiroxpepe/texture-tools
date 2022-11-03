using Microsoft.VisualStudio.TestTools.UnitTesting;

using Checkered;

namespace CheckeredTest {
    [TestClass()]
    public class FacadeTests {
#nullable enable
        [TestMethod()]
        public void ExecuteTest() {
            Facade.Execute();
        }
    }
}
