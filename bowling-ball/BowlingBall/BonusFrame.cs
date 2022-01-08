using System.Linq;

namespace BowlingBall
{
    public class BonusFrame: BaseFrame
    {

        public BonusFrame(int id) : base(id)
        {
          
        }

        public override void AddPins(int pins)
        {
            PinCounts.Add(pins);

            if ((IsSpare() || IsStrike()) && PinCounts.Count() < Constants.MAX_ROLL_IN_A_BONUS_FRAME
                || PinCounts.Count() < Constants.MAX_ROLL_IN_A_FRAME)
            {
                Status = FrameStatus.InProgess;
                return;
            }
            else
            {
                Status = FrameStatus.Close;
            }
        }

     }
}