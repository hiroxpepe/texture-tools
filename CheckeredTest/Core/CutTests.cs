using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static Checkered.Core.Cut;

namespace Checkered.Core {
    [TestClass()]
    public class CutTests {
#nullable enable
        [TestMethod()]
        public void CountXTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountX");
            AreEqual(3, result);
        }
        [TestMethod()]
        public void CountYTest1() {
            Cut ob = NewCutDefault();
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountY");
            AreEqual(3, result);
        }
        [TestMethod()]
        public void CountXTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountX");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountYTest2() {
            Cut ob = NewCutBySlice(slice_count_x: 0, slice_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountY");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountXTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountX");
            AreEqual(2, result);
        }
        [TestMethod()]
        public void CountYTest3() {
            Cut ob = NewCutBySlice(slice_count_x: 1, slice_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountY");
            AreEqual(2, result);
        }
        [TestMethod()]
        public void CountXTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountX");
            AreEqual(0, result);
        }
        [TestMethod()]
        public void CountYTest4() {
            Cut ob = NewCutByPiece(piece_count_x: 0, piece_count_y: 0);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountY");
            AreEqual(0, result);
        }
        [TestMethod()]
        public void CountXTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountX");
            AreEqual(1, result);
        }
        [TestMethod()]
        public void CountYTest5() {
            Cut ob = NewCutByPiece(piece_count_x: 1, piece_count_y: 1);
            object? result = new PrivateObject(ob: ob).Invoke(method_name: "_getCountY");
            AreEqual(1, result);
        }
    }
}