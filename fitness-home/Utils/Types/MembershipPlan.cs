using System.Collections.Generic;

namespace fitness_home.Utils.Types
{
    /// <summary>
    /// Represents a membership plan offered by fitness home.
    /// </summary>
    public class MembershipPlan
    {
        public int PlanId { get; set; }
        public int TrainerId { get; set; }
        public string PlanName { get; set; }
        public decimal MonthlyFee { get; set; }
        public List<string> Benefits { get; set; }

        /// <summary>
        /// Initializes a new instance of the MembershipPlan class.
        /// </summary>
        /// <param name="planId">Membership plan ID.</param>
        /// <param name="trainerId">ID of the trainer associated with the plan.</param>
        /// <param name="planName">Name of the membership plan.</param>
        /// <param name="monthlyFee">Monthly fee for the membership plan.</param>
        /// <param name="benefits">List of benefits included in the membership plan.</param>
        public MembershipPlan(int planId, int trainerId, string planName, decimal monthlyFee)
        {
            PlanId = planId;
            TrainerId = trainerId;
            PlanName = planName;
            MonthlyFee = monthlyFee;
        }
    }
}