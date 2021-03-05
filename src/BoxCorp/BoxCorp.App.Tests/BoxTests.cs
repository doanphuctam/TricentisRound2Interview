using System.Collections.Generic;
using Jaq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoxCorp.App.Tests {
    [TestClass]
    public class BoxTests {
        [TestMethod]
        public void TestMethod1() {
            List<Box> boxes = new List<Box>();
            boxes.Add(new Box(2, 2, 6, 5, 0.8));
            boxes.Add(new Box(3, 3, 6, 4, 0.6));
            boxes.Add(new Box(2, 8, 4, 3, 0.9));
            boxes.Add(new Box(8, 9, 2, 2, 0.3));

            var program = new Program();
            int boxesLeft = program.SortBoxes
                (@"~/boxes.csv");
            Assert.AreEqual(boxesLeft, 1879);
        }
    }
}
