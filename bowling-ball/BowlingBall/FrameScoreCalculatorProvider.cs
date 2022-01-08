namespace BowlingBall
{
    public class FrameScoreCalculatorProvider
    {
        public static IFrameScoreCalculator GetFrameScoreCalculator(IFrame frame)
        {
            if (frame is BonusFrame) { 
                return new BonusFrameScoreCalculator();
            }
            return new BaseFrameScoreCalculator();
            
        }
    }
}
