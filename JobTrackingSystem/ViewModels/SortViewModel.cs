using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobTrackingSystem.ViewModels
{
    public class SortViewModel
    {
        public SortState DateOfTakingSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            DateOfTakingSort = sortOrder == SortState.dateOfTakingAsc ? SortState.dateofTakingDesc : SortState.dateOfTakingAsc;
            Current = sortOrder;
        }
    }
}
