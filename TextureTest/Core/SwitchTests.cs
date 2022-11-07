using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static Texture.Draw.Switch;

namespace Texture.Core {
    [TestClass()]
    public class SwitchTests {
#nullable enable
        [TestMethod()]
        public void NextTest1() {
            InitIndex(count_x: 5, count_y: 5);
            int value;
            value = NextIndex(); AreEqual(0, value); //  0
            value = NextIndex(); AreEqual(1, value); //  1
            value = NextIndex(); AreEqual(0, value); //  2
            value = NextIndex(); AreEqual(1, value); //  3
            value = NextIndex(); AreEqual(0, value); //  4
            value = NextIndex(); AreEqual(1, value); //  5
            value = NextIndex(); AreEqual(0, value); //  6
            value = NextIndex(); AreEqual(1, value); //  7
            value = NextIndex(); AreEqual(0, value); //  8
            value = NextIndex(); AreEqual(1, value); //  9
            value = NextIndex(); AreEqual(0, value); // 10
        }
        [TestMethod()]
        public void NextTest2() {
            InitIndex(count_x: 4, count_y: 4);
            int value;
            value = NextIndex(); AreEqual(0, value); //  0
            value = NextIndex(); AreEqual(1, value); //  1
            value = NextIndex(); AreEqual(0, value); //  2
            value = NextIndex(); AreEqual(1, value); //  3
            value = NextIndex(); AreEqual(1, value); //  4
            value = NextIndex(); AreEqual(0, value); //  5
            value = NextIndex(); AreEqual(1, value); //  6
            value = NextIndex(); AreEqual(0, value); //  7
            value = NextIndex(); AreEqual(0, value); //  8
            value = NextIndex(); AreEqual(1, value); //  9
            value = NextIndex(); AreEqual(0, value); // 10
        }
        [TestMethod()]
        public void NextTest3() {
            InitIndex(count_x: 1, count_y: 1);
            int value;
            value = NextIndex(); AreEqual(0, value); //  0
        }
    }
}
