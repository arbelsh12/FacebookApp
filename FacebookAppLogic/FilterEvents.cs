using System;
using System.Collections.Generic;
using System.Linq;

namespace FacebookAppLogic
{
    public class FilterEvents
    {
        public FilterEvents()
        {

        }

        public ICollection<iEvent> FilterAndSortByUserSelection(List<iEvent> i_Events, int i_TimeSelection, int i_GuestsConfirmationsSelection)
        {
            ICollection<iEvent> filteredEventsByUserSelections = i_TimeSelection != (int)eTimeSelection.All ? getFilteredListByTime(i_Events, i_TimeSelection) : i_Events;

            if (i_GuestsConfirmationsSelection != (int)eGuestsConfirmation.All) // The user selected to sort by Attending/ Interested/ Declined/ Maybe guests amount
            {
                switch (i_GuestsConfirmationsSelection)
                {
                    case (int)eGuestsConfirmation.Attending:
                        filteredEventsByUserSelections = filteredEventsByUserSelections.OrderByDescending(userEvent => userEvent.AttendingCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Interested:
                        filteredEventsByUserSelections = filteredEventsByUserSelections.OrderByDescending(userEvent => userEvent.InterestedCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Declined:
                        filteredEventsByUserSelections = filteredEventsByUserSelections.OrderByDescending(userEvent => userEvent.DeclinedCount).ToList();
                        break;
                    case (int)eGuestsConfirmation.Maybe:
                        filteredEventsByUserSelections = filteredEventsByUserSelections.OrderByDescending(userEvent => userEvent.MaybeCount).ToList();
                        break;
                    default:
                        break;
                }
            }

            return filteredEventsByUserSelections;
        }

        private List<iEvent> getFilteredListByTime(List<iEvent> i_Events, int i_TimeSelection)
        {
            List<iEvent> filteredEventsListByTime = new List<iEvent>(); ;

            if (i_TimeSelection == (int)eTimeSelection.Today)
            {
                foreach (iEvent fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Date == DateTime.Now.Date)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.InTheNext7Days)
            {
                foreach (iEvent fbEvent in i_Events)
                {
                    bool isEventInNext7Days = DateTime.Today.AddDays(7) >= fbEvent.StartTime && (DateTime.Now <= fbEvent.StartTime || DateTime.Equals(fbEvent.StartTime, DateTime.Today));

                    if (isEventInNext7Days)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }
            else if (i_TimeSelection == (int)eTimeSelection.ThisMonth)
            {
                foreach (iEvent fbEvent in i_Events)
                {
                    if (fbEvent.StartTime.Month == DateTime.Now.Month && fbEvent.StartTime.Year == DateTime.Now.Year)
                    {
                        filteredEventsListByTime.Add(fbEvent);
                    }
                }
            }

            return filteredEventsListByTime;
        }
    }
}
