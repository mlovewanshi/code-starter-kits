using System.Collections.Generic;

namespace BowlingBall
{
    public interface IFrameScoreCalculator
    {
        int GetTotalScore(IFrame currentFrame, IList<IFrame> frames);
    }
}
