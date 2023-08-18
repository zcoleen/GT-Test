using Microsoft.AspNetCore.Mvc;
using NPV.Controllers;
using NPV.Model;

namespace NPV.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateNPV_SuccessResponses()
        {
            //Arrange
            var controller = new CalculatorController();
            double incrementRate = 0.25;
            double lowerBoundRate = 1;
            double upperBoundRate = 5;

            List<double> cashFlows = new List<double>
            {
                1000,2000,3000,4000,5000
            };
            
            //Execute
            var result = controller.CalculateNPVAsync(cashFlows, lowerBoundRate, upperBoundRate, 0.25);


            //Assert
            
            //Assert if proper type
            Assert.IsType<ActionResult<List<CashFlowDetail>>>(result);

            //Assert if returning successful response
            var objResult = (result.Result as ObjectResult);
            Assert.Equal(200, objResult?.StatusCode);

            
            var response = objResult?.Value as List<CashFlowDetail>;
            // Assert if getting the proper period by passed cashflow
            Assert.Equal(response?.Count, 5);

            //Assert if it is getting the proper rate by passed increment rate
            Assert.Contains("1.25", response.Select(x => x.PresentValues[1].Rate));
            Assert.Contains("2", response.Select(x => x.PresentValues[4].Rate)); 
        }
    }
}