using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class BonusFrameScoreCalculator: IFrameScoreCalculator
    {
        public int GetTotalScore(IFrame currentFrame, IList<IFrame> frames)
        {
            return currentFrame.PinCounts.Sum();
        }
    }
}
