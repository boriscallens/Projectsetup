using System.Collections.Generic;
using System.Globalization;
using Projectsetup.Domain.Services.Labels;

namespace Projectsetup.Domain.Repositories
{
    public interface ILabelRepository
    {
        IEnumerable<Label> GetLabelsFor(CultureInfo culture);
    }
}
