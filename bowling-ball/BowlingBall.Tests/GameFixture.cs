using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }


        [TestMethod]
        public void All_One_game_score_should_be_20_test()
        {
            var game = new Game();
            Roll(game, 1, 20);
            Assert.AreEqual(20, game.GetScore());
        }


        [TestMethod]
        public void First_Frame_Spare_game_score_should_be_20_test()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            Roll(game, 0, 17);
            Assert.AreEqual(20, game.GetScore());
        }


        [TestMethod]
        public void First_Frame_Strike_game_score_should_be_30_test()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            Roll(game, 0, 16);
            Assert.AreEqual(30, game.GetScore());
        }

        [TestMethod]
        public void First_And_Second_Frame_Strike_game_score_should_be_55_test()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            Roll(game, 0, 14);
            Assert.AreEqual(55, game.GetScore());
        }


        [TestMethod]
        public void Bonus_Frame_All_Strike_game_score_should_be_20_test()
        {
            var game = new Game();
            Roll(game, 0, 18);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(30, game.GetScore());
        }

        [TestMethod]
        public void Bonus_Frame_All_Strike_And_9th_Frame_Strike_game_score_should_be_60_test()
        {
            var game = new Game();
            Roll(game, 0, 16);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(60, game.GetScore());
        }

        [TestMethod]
        public void Bonus_Frame_Spare_And_9th_Frame_Strike_game_score_should_be_39_test()
        {
            var game = new Game();
            Roll(game, 0, 16);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(9);
            Assert.AreEqual(39, game.GetScore());
        }

        [TestMethod]
        public void Bonus_Frame_Spare_And_Strike_game_score_should_be_20_test()
        {
            var game = new Game();
            Roll(game, 0, 18);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Test_Random_Game_No_Extra_Roll()
        {
            var game = new Game();

            Roll(game, new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.AreEqual(131, game.GetScore());
        }

        [TestMethod]
        public void Test_Random_Game_With_Spare_Then_Strike_At_End()
        {
            var game = new Game();

            Roll(game, new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, game.GetScore());
        }

        [TestMethod]
        public void Test_Random_Game_With_Three_Strike_At_End()
        {
            var game = new Game();

            Roll(game, new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.AreEqual(163, game.GetScore());
        }

        [TestMethod]
        public void Test_Random_Game_With_Three_Strike_In_Between()
        {
            var game = new Game();

            Roll(game, new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 });
            Assert.AreEqual(187, game.GetScore());
        }

        
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private void Roll(Game game, int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                game.Roll(pins[i]);
            }
        }
    }
}
