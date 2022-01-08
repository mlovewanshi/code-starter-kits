namespace BowlingBall
{
    public class FrameProvider
    {
       public static IFrame GetFrame(int frameNumber)
        {
            if (frameNumber == Constants.MAX_FRAME_COUNT)
            {
              return  new BonusFrame(frameNumber);
            }
            
            return new BaseFrame(frameNumber);
            
        }
    }
}
