using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public interface iEvent
    {
        string Name { get; }
        DateTime StartTime { get; }
        long AttendingCount { get; }
        long InterestedCount { get; }
        long DeclinedCount { get; }
        long MaybeCount { get; }
    }
}
