using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppLogic
{
    public interface iEvent
    {
        string m_Name { get; set; }
        DateTime m_StartTime { get; set; }
        long m_AttendingCount { get; set; }
        long m_InterestedCount { get; set; }
        long m_DeclinedCount { get; set; }
        long m_MaybeCount { get; set; }
    }
}
