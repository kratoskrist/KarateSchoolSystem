using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Defines behavior for objects that can generate a report
    /// </summary>
    public interface IReportable
    {
        string GenerateReport();
    }
}
