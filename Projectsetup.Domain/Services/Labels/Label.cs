using System.Globalization;

namespace Projectsetup.Domain.Services.Labels
{
    public class Label
    {
        public Label(CultureInfo culture)
        {
            Culture = culture;
        }

        public CultureInfo Culture { get; private set; }
    }
}
