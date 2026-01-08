using System.Globalization;
using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Searcher (Cauta terenuri libere pe baza criterilor)
public class FieldCatalogService : IFieldCatalogService
{
    private readonly List<Rezervare> _reservationList;
    private readonly List<Teren> _fieldList;
    private List<Teren>? _filteredFieldList;
    
    public FieldCatalogService(IFileRepository repository)
    {
        _reservationList = repository.IncarcaRezervari();
        _fieldList = repository.IncarcaTerenuri();
        _filteredFieldList = new();
    }

    public List<Teren>? SearchFieldsBySport(string sportType)
    {
        _filteredFieldList = _fieldList
            .Where(f => f.TipSport == sportType).ToList();

        return _filteredFieldList.Count != 0 ? _filteredFieldList : null;
    }

    public List<Teren>? SearchFieldsByDate(string date)
    {
        if(_filteredFieldList == null)
            return null;
        
        _filteredFieldList = _filteredFieldList.Where(f => GetAvailableSlots(f.Id, date) != null).ToList();
        
        return _filteredFieldList.Any() ? _filteredFieldList : null;
    }

    public List<string>? GetAvailableSlots(Guid fieldId, string date)
    {
        var field = _fieldList.Find(f => f.Id == fieldId);

        if (field == null) // Daca terenul nu exista
            return new List<string>();
        
        var dateOnly = String2DateOnly(date);

        var durataStandard = field.durata_standard;

        var rawBlockedPeriodsString = field.intervale_indisponibile;
        
        var functioningPeriod = Period2TimeInterval(field.program_de_functionare);

        List<TimeInterval> blockedPeriods;
        
        var reservationsOnFieldAndDate = _reservationList
            .Where(r => r.TerenId == fieldId && DateOnly.FromDateTime(r.DataInceput) == dateOnly)
            .OrderBy(r => r.DataInceput)
            .ToList();
        
        List<TimeInterval> reservedPeriods = reservationsOnFieldAndDate
            .Select(r => new TimeInterval 
            { 
                Start = TimeOnly.FromDateTime(r.DataInceput), 
                End = TimeOnly.FromDateTime(r.DataSfarsit) 
            })
            .ToList();

        // Verificare daca intervale_indisponibile e "none" sau null
        if (string.IsNullOrWhiteSpace(rawBlockedPeriodsString) || rawBlockedPeriodsString.Equals("none", StringComparison.OrdinalIgnoreCase))
        {
            blockedPeriods = new List<TimeInterval>();
        }
        else
        {
            blockedPeriods = rawBlockedPeriodsString
                .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(t => TimeOnly.ParseExact(t, "HH:mm", CultureInfo.InvariantCulture))
                .Chunk(2)
                .Where(pair => pair.Length == 2)
                .Select(pair => new TimeInterval 
                { 
                    Start = pair[0], 
                    End = pair[1] 
                })
                .ToList();
        }

        // Combinăm perioadele rezervate și blocate
        var allUnavailablePeriods = reservedPeriods.Concat(blockedPeriods).ToList();
        
        var freePeriods = GenerateFreeSlots(functioningPeriod, durataStandard);
        
        // Eliminăm perioadele rezervate și blocate din perioadele libere
        freePeriods = freePeriods
            .Where(fp => !allUnavailablePeriods.Any(rp => fp.Overlaps(rp)))
            .ToList();          

        // Convertire din lista de TimeInterval in lista de string
        var freePeriodsStrings = freePeriods
            .Select(fp => TimeInterval2String(fp))
            .ToList();
        
        return freePeriodsStrings.Any() ? freePeriodsStrings : null;
    }
    
    private DateOnly String2DateOnly(string date)
        => DateOnly.ParseExact(date, "dd/MM/yyyy", null);
    
    private TimeInterval Period2TimeInterval(string period)
    {
        // Interval acceptat "10:00-22:00"
        var times = period.Split('-');
    
        return new TimeInterval
        {
            Start = TimeOnly.ParseExact(times[0].Trim(), "HH:mm", CultureInfo.InvariantCulture),
            End   = TimeOnly.ParseExact(times[1].Trim(), "HH:mm", CultureInfo.InvariantCulture)
        };
    }

    private string TimeInterval2String(TimeInterval interval)
        => interval.Start.ToString("HH:mm") + "-" + interval.End.ToString("HH:mm");
    
    private List<TimeInterval> GenerateFreeSlots(TimeInterval functioningPeriod, int durataStandard)
    {
        List<TimeInterval> freePeriods = new();
        TimeOnly startTime = functioningPeriod.Start;
        TimeOnly endProgram = functioningPeriod.End;

        while (startTime.AddMinutes(durataStandard) > startTime)
        {
            TimeOnly endTime = startTime.AddMinutes(durataStandard);
            
            if (endTime > endProgram && endProgram != TimeOnly.MinValue)
                break;

            freePeriods.Add(new TimeInterval { Start = startTime, End = endTime });
            startTime = endTime;

            if (startTime == endProgram) break;
        }
        return freePeriods;
    }
}