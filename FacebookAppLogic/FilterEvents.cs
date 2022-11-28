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

        enum TimeSelection
        {
            Today,
            InTheNext7Days,
            ThisMonth
        }

        enum GuestsConfirmations
        {
            Attending,
            Interested,
            Declined,
            Maybe
        }

        public ICollection<Event> FilterAndSortByUserSelection(List<Event> i_events, int i_timeSelection, int i_guestsConfirmationsSelection)
        {
            ICollection<Event> sortedEventsByAttendersAmount = i_timeSelection != k_NotSelected ? getFilteredListByTime(i_events, i_timeSelection) : i_events;

            if (i_guestsConfirmationsSelection != k_NotSelected)
            {
                if (i_guestsConfirmationsSelection == (int)GuestsConfirmations.Attending)
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.AttendingCount).ToArray();
                }
                else if (i_guestsConfirmationsSelection == (int)GuestsConfirmations.Interested)
                {
                    sortedEventsByAttendersAmount.OrderBy(userEvent => userEvent.InterestedCount).ToArray();
                }
                else if (i_guestsConfirmationsSelection == (int)GuestsConfirmations.Declined)
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

        private List<Event> getFilteredListByTime(List<Event> i_events, int i_timeSelection)
        {
            List<Event> filteredEventsListByTime = i_events;

            if (i_timeSelection == (int)TimeSelection.Today)
            {
                foreach (Event fbEvent in i_events)
                {
                    if (fbEvent.StartTime.Value.Date != DateTime.Now.Date)
                    {
                        filteredEventsListByTime.Remove(fbEvent);
                    }
                }
            }
            else if (i_timeSelection == (int)TimeSelection.InTheNext7Days)
            {
                foreach (Event fbEvent in i_events)
                {
                    bool isEventInNext7Days = DateTime.Now.AddDays(7) <= fbEvent.StartTime.Value;

                    if (isEventInNext7Days)
                    {
                        filteredEventsListByTime.Remove(fbEvent);
                    }
                }
            }
            else if (i_timeSelection == (int)TimeSelection.ThisMonth)
            {
                foreach (Event fbEvent in i_events)
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
