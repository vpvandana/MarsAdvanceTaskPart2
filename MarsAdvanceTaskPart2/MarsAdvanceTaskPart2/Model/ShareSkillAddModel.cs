using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvanceTaskPart2.Model
{
    public class ShareSkillAddModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        public string SubCatagory { get; set; }
        public string[] CatagoryTags { get; set; }
        public string ServiceType { get; set; }
        public string LocationType { get; set; }
        public string AvailableStartDate { get; set; }
        public string[] AvailableDays { get; set; }
        public string AvailableStartTime { get; set; }
        public string AvailableEndTime { get; set; }
        public string SkillTrade { get; set; }
        public string[] SkillExchangeTag { get; set; }
        public string CreditAmount { get; set; }
        public string Active { get; set; }
    }
}
