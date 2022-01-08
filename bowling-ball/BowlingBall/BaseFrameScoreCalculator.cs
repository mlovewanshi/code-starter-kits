using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class BaseFrameScoreCalculator: IFrameScoreCalculator
    {
        public int GetTotalScore(IFrame currentFrame, IList<IFrame> frames)
        {
            var totalScore = currentFrame.PinCounts.Sum();
            
            var nextFrame = frames.FirstOrDefault(x => x.Id == currentFrame.Id + 1);

            if (currentFrame.IsStrike())
            {
                totalScore += GetTotalScoreOfNextTwoRolls(nextFrame, frames);
            }

            else if (currentFrame.IsSpare())
            {
                totalScore += nextFrame.PinCounts.FirstOrDefault();
            }

            return totalScore;
        }

        public int GetTotalScoreOfNextTwoRolls(IFrame nextFrame, IList<IFrame> frames)
        {
           
            if (nextFrame is BonusFrame || !nextFrame.IsStrike())
            {
                return nextFrame.PinCounts.Take(2).Sum();
            }

            var nextToNextFrame = frames.FirstOrDefault(x => x.Id == nextFrame.Id + 1);

            return nextFrame.PinCounts.FirstOrDefault() + nextToNextFrame.PinCounts.FirstOrDefault();
        
        }
    }
}
