using System;
using System.Collections.Generic;
using System.Linq;

namespace FacebookAppLogic
{
    public class FilterEvents
    {
        public Func<iEvent, bool> filterStrategyMethod { get; set; }
        public Func<iEvent, long> sortStrategyMethod { get; set; }

        public FilterEvents()
        {

        }

        public ICollection<iEvent> FilterAndSortByUserSelection(List<iEvent> i_Events, int i_TimeSelection, int i_GuestsConfirmationsSelection)
        {
            ICollection<iEvent> filteredEventsByUserSelections = i_TimeSelection != (int)eTimeSelection.All ? getFilteredListByTime(i_Events, i_TimeSelection) : i_Events;

            if (i_GuestsConfirmationsSelection != (int)eGuestsConfirmation.All) // The user selected to sort by Attending/ Interested/ Declined/ Maybe guests amount
            {
                setSortStrategyMethod(i_GuestsConfirmationsSelection);
                filteredEventsByUserSelections = filteredEventsByUserSelections.OrderByDescending(sortStrategyMethod).ToList();
            }

            return filteredEventsByUserSelections;
        }

        private List<iEvent> getFilteredListByTime(List<iEvent> i_Events, int i_TimeSelection)
        {
            List<iEvent> filteredEventsListByTime = new List<iEvent>();

            setFilterStrategyMethod(i_TimeSelection);

            foreach (iEvent fbEvent in i_Events)
            {
                if (filterStrategyMethod(fbEvent))
                {
                    filteredEventsListByTime.Add(fbEvent);
                }
            }

            return filteredEventsListByTime;
        }

        private void setSortStrategyMethod(int i_GuestsConfirmationsSelection)
        {
            switch (i_GuestsConfirmationsSelection)
            {
                case (int)eGuestsConfirmation.Attending:
                    sortStrategyMethod = userEvent => userEvent.AttendingCount;
                    break;
                case (int)eGuestsConfirmation.Interested:
                    sortStrategyMethod = userEvent => userEvent.InterestedCount;
                    break;
                case (int)eGuestsConfirmation.Declined:
                    sortStrategyMethod = userEvent => userEvent.DeclinedCount;
                    break;
                case (int)eGuestsConfirmation.Maybe:
                    sortStrategyMethod = userEvent => userEvent.MaybeCount;
                    break;
                default:
                    break;
            }
        }

        private void setFilterStrategyMethod(int i_TimeSelection)
        {
            switch (i_TimeSelection)
            {
                case (int)eTimeSelection.Today:
                    filterStrategyMethod = fbEvent => fbEvent.StartTime.Date == DateTime.Now.Date;
                    break;
                case (int)eTimeSelection.InTheNext7Days:
                    filterStrategyMethod = fbEvent => DateTime.Today.AddDays(7) >= fbEvent.StartTime &&
                    (DateTime.Now <= fbEvent.StartTime || DateTime.Equals(fbEvent.StartTime, DateTime.Today));
                    break;
                case (int)eTimeSelection.ThisMonth:
                    filterStrategyMethod = fbEvent => fbEvent.StartTime.Month == DateTime.Now.Month &&
                    fbEvent.StartTime.Year == DateTime.Now.Year;
                    break;
                default:
                    break;
            }
        }
    }
}
