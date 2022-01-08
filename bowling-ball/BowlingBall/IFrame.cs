using System.Collections.Generic;

namespace BowlingBall
{
    public interface IFrame
    {
        int Id { get; set; }
        List<int> PinCounts { get; set; }
        void AddPins(int pinCount);
        bool IsStrike();
        bool IsSpare();
        bool IsClosed();
    }
}
