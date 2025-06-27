using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Texture {
    [TestClass]
    public class MapTests {
        [TestMethod("Behaves like a dictionary")]
        public void Map_ShouldBehaveLikeDictionary() {
            Map<string, int> map = new Map<string, int>();
            map.Add("Key1", 1);
            map.Add("Key2", 2);
            Assert.AreEqual(1, map["Key1"]);
            Assert.AreEqual(2, map["Key2"]);
            Assert.IsTrue(map.ContainsKey("Key1"));
            Assert.IsTrue(map.ContainsKey("Key2"));
            map.Remove("Key1");
            Assert.IsFalse(map.ContainsKey("Key1"));
        }
    }

    [TestClass]
    public class EvtArgsTests {
        [TestMethod("Initializes name in constructor")]
        public void EvtArgs_Constructor_ShouldInitializeName() {
            string name = "TestEvent";
            EvtArgs evtArgs = new EvtArgs(name);
            Assert.AreEqual(name, evtArgs.Name);
        }
    }
}