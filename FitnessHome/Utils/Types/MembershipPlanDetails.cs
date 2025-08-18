using System.Collections.Generic;

namespace fitness_home.Utils.Types
{
    /// <summary>
    /// Represents a membership plan offered by fitness home.
    /// </summary>
    public class MembershipPlanDetails
    {
        public int PlanId { get; set; }
        public int TrainerId { get; set; }
        public string PlanName { get; set; }
        public decimal MonthlyFee { get; set; }
        public List<string> Benefits { get; set; }

        public MembershipPlanDetails() { }
    }
}