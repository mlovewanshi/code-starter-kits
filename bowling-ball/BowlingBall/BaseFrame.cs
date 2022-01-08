using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class BaseFrame: IFrame
    {
        public int Id { get; set; }
        public FrameStatus Status { get; set; }
        public List<int> PinCounts { get; set; }

        public BaseFrame(int id)
        {
            Id = id;
            Status = FrameStatus.New;
            PinCounts = new List<int>();
        }

        public virtual void AddPins(int pins)
        {
            PinCounts.Add(pins);

            if (IsStrike() || PinCounts.Count() == Constants.MAX_ROLL_IN_A_FRAME)
            {
                Status = FrameStatus.Close;
            }
            else
            {
                Status = FrameStatus.InProgess;
            }
        }

        public bool IsStrike()
        {
            return PinCounts.LastOrDefault() == Constants.MAX_FRAME_COUNT;
        }

        public bool IsSpare()
        {
            return PinCounts.Count() == Constants.MAX_ROLL_IN_A_FRAME && PinCounts.Sum() == Constants.PIN_COUNT;
        }

        public bool IsClosed()
        {
            return Status == FrameStatus.Close;
        }
    }
}