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
            All,
            Today,
            InTheNext7Days,
            ThisMonth
        }

        enum eGuestsConfirmations
        {
            All,
            Attending,
            Interested,
            Declined,
            Maybe
        }

        public ICollection<Event> FilterAndSortByUserSelection(List<Event> i_Events, int i_TimeSelection, int i_GuestsConfirmationsSelection)
        {
            ICollection<Event> filteredEventsByUserSelection = null;

            if (i_TimeSelection != k_NotSelected && i_TimeSelection != (int)eTimeSelection.All) // The user selected the events that accurs today/in the next 7 days/this month
            {
                filteredEventsByUserSelection = getFilteredListByTime(i_Events, i_TimeSelection);
            }
            else //The user selected all his events or didn't select a "time" filter
            {
                filteredEventsByUserSelection = i_Events;

                if (i_TimeSelection == (int)eTimeSelection.All && i_GuestsConfirmationsSelection == (int)eGuestsConfirmations.All)
                {
                    return filteredEventsByUserSelection;
                }
            }

            if (i_GuestsConfirmationsSelection != k_NotSelected && i_GuestsConfirmationsSelection != (int)eGuestsConfirmations.All) // The user selected to sort by Attending/ Interested/ Declined/ Maybe guests amount
            {
                switch (i_GuestsConfirmationsSelection)
                {
                    case (int)eGuestsConfirmations.Attending:
                        filteredEventsByUserSelection.OrderBy(userEvent => userEvent.AttendingCount).ToArray();
                        break;
                    case (int)eGuestsConfirmations.Interested:
                        filteredEventsByUserSelection.OrderBy(userEvent => userEvent.InterestedCount).ToArray();
                        break;
                    case (int)eGuestsConfirmations.Declined:
                        filteredEventsByUserSelection.OrderBy(userEvent => userEvent.DeclinedCount).ToArray();
                        break;
                    case (int)eGuestsConfirmations.Maybe:
                        filteredEventsByUserSelection.OrderBy(userEvent => userEvent.MaybeCount).ToArray();
                        break;
                    default:
                        break;
                }
            }

            return filteredEventsByUserSelection;
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
