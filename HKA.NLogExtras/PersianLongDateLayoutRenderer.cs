using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace HKA.NLogExtras;

[LayoutRenderer("persianlongdate")]
[ThreadAgnostic]
public class PersianLongDateLayoutRenderer : LayoutRenderer
{
    readonly PersianCalendar _pc = new();

    /// <summary>
    /// Gets or sets a value indicating whether to output UTC time instead of local time.
    /// </summary>
    /// <docgen category='Rendering Options' order='10' />
    [DefaultValue(false)]
    public bool UniversalTime { get; set; }

    /// <summary>
    /// Renders the current short date string (yyyy-MM-dd) and appends it to the specified <see cref="StringBuilder" />.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/> to append the rendered data to.</param>
    /// <param name="logEvent">Logging event.</param>
    protected override void Append(StringBuilder builder, LogEventInfo logEvent)
    {
        DateTime ts = logEvent.TimeStamp;

        //Not sure if UniversalTime makes sense for PersianCalendar.  Do you?
        if (UniversalTime)
        {
            ts = ts.ToUniversalTime();
        }

        builder.Append(string.Format("{0}-{1}-{2}-{3}:{4:D2}-{5:D2}-{6:D2}.{7:D3}",
            _pc.GetDayOfWeek(ts),
            _pc.GetYear(ts),
            _pc.GetMonth(ts),
            _pc.GetDayOfMonth(ts),
            _pc.GetHour(ts),
            _pc.GetMinute(ts),
            _pc.GetSecond(ts),
            _pc.GetMilliseconds(ts)));
    }
}
