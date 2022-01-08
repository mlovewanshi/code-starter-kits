using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class BaseFrameFixture
    {
        [TestMethod]
        public void Should_Test_Status_Of_Frame()
        {
             var frame = new BaseFrame(1);
            Assert.IsFalse(frame.IsClosed());

            frame.Status = FrameStatus.InProgess;
            Assert.IsFalse(frame.IsClosed());

            frame.Status = FrameStatus.Close;
            Assert.IsTrue(frame.IsClosed());
        }

        [TestMethod]
        public void Should_Return_True_For_Strike()
        {

            var frame = new BaseFrame(1);
            frame.AddPins(10);
            
            Assert.IsTrue(frame.IsStrike());
        }

        [TestMethod]
        public void Should_Return_False_For_Not_Strike()
        {

            var frame = new BaseFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);

            Assert.IsFalse(frame.IsStrike());
        }

        [TestMethod]
        public void Should_Return_True_For_Spare()
        {

            var frame = new BaseFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);

            Assert.IsTrue(frame.IsSpare());
        }

        [TestMethod]
        public void Should_Return_True_For_No_Spare()
        {

            var frame = new BaseFrame(1);
            frame.AddPins(5);
            frame.AddPins(4);

            Assert.IsFalse(frame.IsSpare());
        }

        [TestMethod]
        public void Should_Return_Frame_Close_AndSum_10_For_Strike()
        {
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(1, frame.PinCounts.Count);
            Assert.AreEqual(10, frame.PinCounts.Sum());
        }

        [TestMethod]
        public void Should_Return_Frame_Close_And_Sum_9()
        {
            var frame = new BaseFrame(1);
            frame.AddPins(4);
            frame.AddPins(5);
            Assert.AreEqual(FrameStatus.Close, frame.Status);
            Assert.AreEqual(2, frame.PinCounts.Count);
            Assert.AreEqual(9, frame.PinCounts.Sum());
        }

    }
}
