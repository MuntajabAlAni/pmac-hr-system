using System;
using System.Linq;
using System.Collections.Generic;
using HR_PMAC_BACK.Domain.Entities.Rewards;

namespace HR_PMAC_BACK.Domain.Services
{
    /// <summary>
    /// مسؤول عن التحقق من سياسات المكافآت
    /// لا يمكن تجاوز مليون دينار كمجموع مكافآت في السنة الواحدة
    /// </summary>
    public class RewardPolicyService
    {
        private const decimal MaxYearlyAmount = 1_000_000m;

        public void ValidateYearlyLimit(
            Guid employeeId,
            int year,
            decimal newAmount,
            IEnumerable<EmployeeReward> existingRewards)
        {
            var totalForYear = existingRewards
                .Where(r => r.EmployeeId == employeeId && r.Year == year)
                .Sum(r => r.Amount);

            if (totalForYear + newAmount > MaxYearlyAmount)
                throw new InvalidOperationException(
                    "لا يمكن تجاوز مليون دينار كمجموع مكافآت في السنة الواحدة.");
        }
    }
}