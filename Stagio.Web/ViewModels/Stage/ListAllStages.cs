using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stagio.Web.ViewModels.Stage
{
    public class ListAllStages
    {
        public List<ListNewStages> ListNewStages { get; set; }
        public List<ListNewStages> ListStagesAccepted { get; set; }
        public List<ListNewStages> ListStagesRefused{ get; set; }
        public List<ListNewStages> ListStagesRemoved { get; set; }
    }
}