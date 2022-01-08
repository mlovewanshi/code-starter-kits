using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class BonusFrameScoreCalculatorFixture
    {
        private BonusFrameScoreCalculator bonusFrameScoreCalculator = new BonusFrameScoreCalculator();

        [TestMethod]
        public void Should_Test_Get_Score_For_Frame()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(6);
            frame.AddPins(3);
            Assert.AreEqual(9, bonusFrameScoreCalculator.GetTotalScore(frame, null));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Frame_For_Spare()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(6);
            frame.AddPins(4);
            frame.AddPins(8);
            Assert.AreEqual(18, bonusFrameScoreCalculator.GetTotalScore(frame, null));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Frame_For_All_Strike()
        {
            var frame = new BonusFrame(1);
            frame.AddPins(10);
            frame.AddPins(10);
            frame.AddPins(10);
            Assert.AreEqual(30, bonusFrameScoreCalculator.GetTotalScore(frame, null));
        }
    }
}
