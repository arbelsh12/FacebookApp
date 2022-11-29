using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public class FilterEvents
    {
        private const int k_NotSelected = -1;

        public FilterEvents()
        {

        }

        enum eTimeSelection
        {
            Today,
            InTheNext7Days,
            ThisMonth
        }

        enum eGuestsConfirmations
        {
            Attending,
            Interested,
            Declined,
            Maybe
        }

        public ICollection<Event> FilterAndSortByUserSelection(List<Event> i_Events, int i_TimeSelection, int i_GuestsConfirmationsSelection)
        {
            ICollection<Event> sortedEventsByAttendersAmount = i_TimeSelection != k_NotSelected ? getFilteredListByTime(i_Events, i_TimeSelection) : i_Events;

            if (i_GuestsConfirmationsSelection != k_NotSelected)
            {
                if (i_GuestsConfirmationsSelection == (int)eGuestsConfirmations.Attending)
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.AttendingCount).ToArray();
                }
                else if (i_GuestsConfirmationsSelection == (int)eGuestsConfirmations.Interested)
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.InterestedCount).ToArray();
                }
                else if (i_GuestsConfirmationsSelection == (int)eGuestsConfirmations.Declined)
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.DeclinedCount).ToArray();
                }
                else
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.MaybeCount).ToArray();
                }
            }

            return sortedEventsByAttendersAmount;
        }

        private List<Event> getFilteredListByTime(List<Event> i_Events, int i_TimeSelection)
        {
            List<Event> filteredEventsListByTime = i_Events;

            if (i_TimeSelection == (int)eTimeSelection.Today)
            {
                foreach (Event fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Value.Date != DateTime.Now.Date)
                    {
                        filteredEventsListByTime.Remove(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.InTheNext7Days)
            {
                foreach (Event fbEvent in i_Events)
                {
                    bool isEventInNext7Days = DateTime.Now.AddDays(7) <= fbEvent.StartTime.Value;

                    if (isEventInNext7Days)
                    {
                        filteredEventsListByTime.Remove(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.ThisMonth)
            {
                foreach (Event fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Value.Month != DateTime.Now.Month)
                    {
                        filteredEventsListByTime.Remove(fbEvent);
                    }
                }
            }

            return filteredEventsListByTime;
        }
    }
}
