using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookAppLogic
{
    public class FilterMockEvents
    {
        private const int k_NotSelected = -1;

        public FilterMockEvents()
        {

        }

        public ICollection<MockEvent> FilterAndSortByUserSelection(List<MockEvent> i_Events, int i_TimeSelection, int i_GuestsConfirmationsSelection)
        {
            ICollection<MockEvent> filteredEventsByUserSelection = null;

            if (i_TimeSelection != k_NotSelected && i_TimeSelection != (int)eTimeSelection.All) // The user selected the events that accurs today/in the next 7 days/this month
            {
                filteredEventsByUserSelection = getFilteredListByTime(i_Events, i_TimeSelection);
            }
            else //The user selected all his events or didn't select a "time" filter
            {
                filteredEventsByUserSelection = i_Events;

                if (i_TimeSelection == (int)eTimeSelection.All && i_GuestsConfirmationsSelection == (int)eGuestsConfirmation.All)
                {
                    return filteredEventsByUserSelection;
                }
            }

            if (i_GuestsConfirmationsSelection != k_NotSelected && i_GuestsConfirmationsSelection != (int)eGuestsConfirmation.All) // The user selected to sort by Attending/ Interested/ Declined/ Maybe guests amount
            {
                switch (i_GuestsConfirmationsSelection)
                {
                    case (int)eGuestsConfirmation.Attending:
                        filteredEventsByUserSelection = filteredEventsByUserSelection.OrderByDescending(userEvent => userEvent.AttendingCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Interested:
                        filteredEventsByUserSelection = filteredEventsByUserSelection.OrderByDescending(userEvent => userEvent.InterestedCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Declined:
                        filteredEventsByUserSelection = filteredEventsByUserSelection.OrderByDescending(userEvent => userEvent.DeclinedCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Maybe:
                        filteredEventsByUserSelection = filteredEventsByUserSelection.OrderByDescending(userEvent => userEvent.MaybeCount).ToList();
                        break;
                    default:
                        break;
                }
            }

            return filteredEventsByUserSelection;
        }

        private List<MockEvent> getFilteredListByTime(List<MockEvent> i_Events, int i_TimeSelection)
        {
            List<MockEvent> filteredEventsListByTime = new List<MockEvent>();

            if (i_TimeSelection == (int)eTimeSelection.Today)
            {
                foreach (MockEvent fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Date == DateTime.Now.Date)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.InTheNext7Days)
            {
                foreach (MockEvent fbEvent in i_Events)
                {
                    bool isEventInNext7Days = DateTime.Now.AddDays(7) >= fbEvent.StartTime && DateTime.Now <= fbEvent.StartTime;

                    if (isEventInNext7Days)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.ThisMonth)
            {
                foreach (MockEvent fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Month == DateTime.Now.Month)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }

            return filteredEventsListByTime;
        }
    }
}
