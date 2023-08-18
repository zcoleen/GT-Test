namespace NPV.Model
{
    public class CashFlowDetail
    {
        public int Period { get; set; }
        public double CashFlow { get; set; }
        public List<PresentValue> PresentValues { get; set; }
    }

    public class PresentValue
    {
        public string Rate { get; set; }
        public double Value { get; set; }
    }
}
