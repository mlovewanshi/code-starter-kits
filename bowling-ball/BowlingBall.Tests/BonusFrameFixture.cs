using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class BonusFrameFixture
    {
        [TestMethod]
        public void Should_Test_Status_Of_Frame()
        {
             var frame = new BonusFrame(1);
            Assert.IsFalse(frame.IsClosed());

            frame.Status = FrameStatus.InProgess;
            Assert.IsFalse(frame.IsClosed());

            frame.Status = FrameStatus.Close;
            Assert.IsTrue(frame.IsClosed());
        }

        [TestMethod]
        public void Should_Return_True_For_Strike()
        {

            var frame = new BonusFrame(1);
            frame.AddPins(10);
            
            Assert.IsTrue(frame.IsStrike());
        }

        [TestMethod]
        public void Should_Return_False_For_Not_Strike()
        {

            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);

            Assert.IsFalse(frame.IsStrike());
        }

        [TestMethod]
        public void Should_Return_True_For_Spare_And_False_For_Frame_Close()
        {

            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);

            Assert.IsTrue(frame.IsSpare());
            Assert.IsFalse(frame.IsClosed());
        }

        [TestMethod]
        public void Should_Return_True_For_No_Spare_And_True_For_Frame_Close()
        {

            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(4);

            Assert.IsFalse(frame.IsSpare());
            Assert.IsTrue(frame.IsClosed());
        }

        [TestMethod]
        public void Should_Return_Frame_InProgess_And_Sum_10_For_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(10);
            Assert.AreEqual(FrameStatus.InProgess, frame.Status);
            Assert.AreEqual(1, frame.PinCounts.Count);
            Assert.AreEqual(10, frame.PinCounts.Sum());
        }


        [TestMethod]
        public void Should_Return_Frame_InProgess_And_Sum_20_For_Second_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(10);
            frame.AddPins(10);
            Assert.AreEqual(FrameStatus.InProgess, frame.Status);
            Assert.AreEqual(2, frame.PinCounts.Count);
            Assert.AreEqual(20, frame.PinCounts.Sum());
        }

        [TestMethod]
        public void Should_Return_Frame_Close_And_Sum_30_For_Third_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(10);
            frame.AddPins(10);
            frame.AddPins(10);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(3, frame.PinCounts.Count);
            Assert.AreEqual(30, frame.PinCounts.Sum());
        }

        [TestMethod]
        public void Should_Return_Frame_Close_And_Sum_9()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(4);
            frame.AddPins(5);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(2, frame.PinCounts.Count);
            Assert.AreEqual(9, frame.PinCounts.Sum());
        }

        [TestMethod]
        public void Should_Return_Frame_InProgess_And_Sum_10_For_Spare()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);
            Assert.AreEqual(FrameStatus.InProgess, frame.Status);
            Assert.AreEqual(2, frame.PinCounts.Count);
            Assert.AreEqual(10, frame.PinCounts.Sum());
        }

        [TestMethod]
        public void Should_Return_Frame_Completed_And_Sum_20_For_Spare_And_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);
            frame.AddPins(10);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(3, frame.PinCounts.Count);
            Assert.AreEqual(20, frame.PinCounts.Sum());
        }
        [TestMethod]
        public void Should_Return_Frame_Completed_And_Sum19_For_Spare_And_Non_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);
            frame.AddPins(9);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(3, frame.PinCounts.Count);
            Assert.AreEqual(19, frame.PinCounts.Sum());
        }
    }
}
