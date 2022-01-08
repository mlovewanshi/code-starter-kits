using System.Collections.Generic;
using System.Linq;
namespace BowlingBall
{
    public class Game
    {
        private readonly List<IFrame> frames;

        public Game()
        {
            frames = new List<IFrame>();
        }

        public void Roll(int pins)
        {
            var frame = GetFrame();

            frame.AddPins(pins);
        }

        private IFrame GetFrame()
        {
            var frame = frames.LastOrDefault();

            if (frame == null || frame.IsClosed())
            {
                frame =  FrameProvider.GetFrame(frames.Count + 1);
                frames.Add(frame);
            }

            return frame;
        }

        public int GetScore() => frames.Sum(x => FrameScoreCalculatorProvider.GetFrameScoreCalculator(x).GetTotalScore(x, frames));

    }
}
