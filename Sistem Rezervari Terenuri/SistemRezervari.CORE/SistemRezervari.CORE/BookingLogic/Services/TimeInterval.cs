namespace SistemRezervari.CORE.BookingLogic.Services;

public class TimeInterval
{
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }
    public bool Overlaps(TimeInterval other)
        => this.Start < other.End && other.Start < this.End;
}