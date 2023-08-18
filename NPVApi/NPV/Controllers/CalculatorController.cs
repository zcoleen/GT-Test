using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NPV.Model;

namespace NPV.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        [HttpPost]
        public ActionResult<List<CashFlowDetail>> CalculateNPVAsync(List<double> cashFlows, double lowerBoundRate, double upperBoundRate, double incrementRate)
        {
            int Period = cashFlows.Count();
            List<CashFlowDetail> CashFlowDetails = new List<CashFlowDetail>();

            //Create Task for asynchronous call
            List<Task> task = new List<Task>();
            //Task.Run for immidiate response since we would be having multiple computations and looping
            Task t = Task.Run(() =>
            {
                for (int i = 0; i <= Period - 1; i++)
                {
                    List<PresentValue> presentValues = new List<PresentValue>();
                    double rate = lowerBoundRate;

                    do
                    {
                        presentValues.Add(new PresentValue
                        {
                            Rate = rate.ToString(),
                            Value = 1 / GetPresentValue(rate, i + 1) * cashFlows[i]
                        });
                        rate = rate + incrementRate;

                    }
                    while (rate <= upperBoundRate);
                    // Period 0 is initial Cashflow(or Investment)
                    CashFlowDetails.Add(new CashFlowDetail
                    {
                        CashFlow = cashFlows[i],
                        Period = i + 1,
                        PresentValues = presentValues
                    });

                }

            });

            task.Add(t);
            //Wait all task/s created
            Task.WaitAll(task.ToArray());

            return Ok(CashFlowDetails);
        }

        private double GetPresentValue(double rate, int period)
        {
            return Math.Pow(1 + rate / 100, period);

        }

    }
}
