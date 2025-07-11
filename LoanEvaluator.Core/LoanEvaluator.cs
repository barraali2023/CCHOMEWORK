// namespace LoanApp
// {
//     public class LoanEvaluator
//     {
//         public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
//         {
// if (income < 2000)    1
//                 return "Not Eligible";
//             if (hasJob)
//             {
//                 if (creditScore >= 700)
//                 {
//                     if (dependents == 0)
//                         return "Eligible";
//                     else if (dependents <= 2)
//                         return "Review Manually";
//                     else
//                         return "Not Eligible";
//                 }
//                 else if (creditScore >= 600)
//                 {
//                     if (ownsHouse)
//                         return "Review Manually";
//                     else
//                         return "Not Eligible";
//                 }
//                 else
//                 {
//                     return "Not Eligible";
//                 }
//             }
//             else
//             {
//                 if (creditScore >= 750 && income > 5000 && ownsHouse)
//                     return "Eligible";
//                 else if (creditScore >= 650 && dependents == 0)
//                     return "Review Manually";
//                 else
//                     return "Not Eligible";
//             }
//         }
//     }
// }

// my homework



namespace LoanEvaluator.Core
{

    public class LoanEvaluator
    {
        public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (!IsIncomeEligible(income))
                return "Not Eligible";

            if (hasJob)
                return EvaluateEmployedApplicant(creditScore, dependents, ownsHouse);

            return EvaluateUnemployedApplicant(income, creditScore, dependents, ownsHouse);
        }

        private bool IsIncomeEligible(int income) => income >= 2000;

        private string EvaluateEmployedApplicant(int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 700)
            {
                if (dependents == 0) return "Eligible";
                else if (dependents <= 2) return "Review Manually";
                else return "Not Eligible";
            }
            else if (creditScore >= 600)
                return ownsHouse ? "Review Manually" : "Not Eligible";

            return "Not Eligible";
        }

        private string EvaluateUnemployedApplicant(int income, int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";
            else if (creditScore >= 650 && dependents == 0)
                return "Review Manually";
            else
                return "Not Eligible";
        }
    }
}



// if (income < 2000)                       // 1
// if (hasJob)                              // 2
//     if (creditScore >= 700)              // 3
//         if (dependents == 0)             // 4
//         else if (dependents <= 2)        // 5
//     else if (creditScore >= 600)         // 6
//         if (ownsHouse)                   // 7
// else                                     // 8
//     if (creditScore >= 750 && income > 5000 && ownsHouse) // 9 ← مركّب (3 نقاط)
//     else if (creditScore >= 650 && dependents == 0)       // 10 ← مركّب (2 نقاط)
