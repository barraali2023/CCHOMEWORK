
//  var evaluator = new LoanEvaluator.Core.LoanEvaluator();
using Xunit;
using LoanEvaluator.Core;

namespace LoanEvaluator.Tests
{
    public class LoanEvaluatorTests
    {

      
        //[الدخل غير كافي ]
       

        [Fact]
        public void Should_Return_NotEligible_When_IncomeIsBelowMinimum()
        {
            var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(1500, true, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        
        //    [ موظف - نقاط عالية - 0 معالين] ===>نفاط عالية===> Eligible
      

        [Fact]
        public void Should_Return_Eligible_For_Employed_With_HighCredit_And_NoDependents()
        {
           var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, true, 720, 0, false);
            Assert.Equal("Eligible", result);
        }

      
        //[ موظف - نقاط جيدة - 2 معالين]===>نقاط جبدة + عندو بيت ===> Review Manually
       

        [Fact]
        public void Should_Return_ReviewManually_For_Employed_With_MidCredit_And_TwoDependents()
        {
         var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, true, 700, 2, true);
            Assert.Equal("Review Manually", result);
        }

      
        // [ موظف - نقاط جيدة - أكثر من 2 معالين]===>>2 معالين===>Not Eligible
        

        [Fact]
        public void Should_Return_NotEligible_For_Employed_With_HighCredit_And_TooManyDependents()
        {
            var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, true, 700, 3, true);
            Assert.Equal("Not Eligible", result);
        }

       // [  موظف - نقاط متوسطة - يملك منزل]====>Review Manually
        
        

        [Fact]
        public void Should_Return_ReviewManually_For_Employed_With_MidCredit_And_OwnsHouse()
        {
          var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, true, 620, 1, true);
            Assert.Equal("Review Manually", result);
        }

       
        //[    موظف - نقاط متوسطة - لا يملك منزل]==>Not Eligible
       

        [Fact]
        public void Should_Return_NotEligible_For_Employed_With_MidCredit_WithoutHouse()
        {
           var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(5000, true, 620, 1, false);
            Assert.Equal("Not Eligible", result);
        }

      
        //[   غير موظف - نقاط عالية - دخل عالي - يملك بيت]===>Eligible
        

        [Fact]
        public void Should_Return_Eligible_For_Unemployed_With_ExcellentProfile()
        {
            var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 760, 1, true);
            Assert.Equal("Eligible", result);
        }

        
       // [   غير موظف - نقاط جيدة - بدون معالين]===>Review Manually
        

        [Fact]
        public void Should_Return_ReviewManually_For_Unemployed_With_GoodCredit_And_NoDependents()
        {
            var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, false, 700, 0, true);
            Assert.Equal("Review Manually", result);
        }

       
        // [ غير موظف - نقاط منخفضة] ===>Not Eligible
        

        [Fact]
        public void Should_Return_NotEligible_For_Unemployed_With_LowCredit()
        {
           var evaluator = new LoanEvaluator.Core.LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, false, 640, 2, true);
            Assert.Equal("Not Eligible", result);
        }
        
    }
}


