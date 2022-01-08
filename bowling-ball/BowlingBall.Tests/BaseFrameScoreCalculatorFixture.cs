using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class BaseFrameScoreCalculatorFixture
    {
        private BaseFrameScoreCalculator baseFrameScoreCalculator = new BaseFrameScoreCalculator();


        [TestMethod]
        public void Should_Test_Get_Score_For_Frame()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(6);
            frame.AddPins(3);
            frames.Add(frame);
            Assert.AreEqual(9, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Spare_Frame()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(6);
            frame.AddPins(4);
            frames.Add(frame);

            var frame2 = new BaseFrame(2);
            frame2.AddPins(7);
            frame2.AddPins(2);
            frames.Add(frame2);

            Assert.AreEqual(17, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Spare_Frame_And_Second_Frame_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(6);
            frame.AddPins(4);
            frames.Add(frame);

            var frame2 = new BaseFrame(2);
            frame2.AddPins(10);
            frames.Add(frame2);

            Assert.AreEqual(20, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Strike_Frame()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame2 = new BaseFrame(2);
            frame2.AddPins(6);
            frame2.AddPins(3);
            frames.Add(frame2);

            Assert.AreEqual(19, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Strike_Frame_AndSecond_Frame_Also_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame2 = new BaseFrame(2);
            frame2.AddPins(10);
            frames.Add(frame2);

            var frame3 = new BaseFrame(3);
            frame3.AddPins(6);
            frame3.AddPins(3);
            frames.Add(frame3);

            Assert.AreEqual(26, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }


        [TestMethod]
        public void Should_Test_Get_Score_For_Strike_Frame_With_Next_Two_Frame_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame2 = new BaseFrame(2);
            frame2.AddPins(10);
            frames.Add(frame2);

            var frame3 = new BaseFrame(3);
            frame3.AddPins(10);
            frames.Add(frame3);

            Assert.AreEqual(30, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }


        [TestMethod]
        public void Should_Test_Get_Score_For_Second_Last_Strike_Frame()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame2 = new BonusFrame(2);
            frame2.AddPins(10);
            frame2.AddPins(9);
            frames.Add(frame2);

            Assert.AreEqual(29, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Second_Last_Strike_Frame_With_BonusFrame_All_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame2 = new BonusFrame(2);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frames.Add(frame2);

            Assert.AreEqual(30, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Third_Last_Strike_Frame_With_BonusFrame_All_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(10);
            frames.Add(frame);

            var frame3 = new BaseFrame(1);
            frame3.AddPins(10);
            frames.Add(frame3);

            var frame2 = new BonusFrame(2);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frames.Add(frame2);

            Assert.AreEqual(30, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }


        [TestMethod]
        public void Should_Test_Get_Score_For_Second_Last_Spare_Frame()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);
            frames.Add(frame);

            var frame2 = new BonusFrame(2);
            frame2.AddPins(10);
            frame2.AddPins(9);
            frames.Add(frame2);

            Assert.AreEqual(20, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

        [TestMethod]
        public void Should_Test_Get_Score_For_Second_Last_Spare_With_Bonus_Frame_All_Strike()
        {
            var frames = new List<IFrame>();
            var frame = new BaseFrame(1);
            frame.AddPins(5);
            frame.AddPins(5);
            frames.Add(frame);

            var frame2 = new BonusFrame(2);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frame2.AddPins(10);
            frames.Add(frame2);

            Assert.AreEqual(20, baseFrameScoreCalculator.GetTotalScore(frame, frames));
        }

    }
}
