using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public interface iEvent
    {
        string m_Name { get; }
        DateTime m_StartTime { get; }
        long m_AttendingCount { get; }
        long m_InterestedCount { get; }
        long m_DeclinedCount { get; }
        long m_MaybeCount { get; }
    }
}
