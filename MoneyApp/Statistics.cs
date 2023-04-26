namespace MoneyApp
{
    public class Statistics
    {

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = double.MinValue;
            this.Min = double.MaxValue;
        }

        public double Min { get; private set; }
        public double Max { get; private set; }
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public double Average
        {
            get
            {
                return Math.Round(this.Sum / this.Count, 2);
            }
        }

        public void AddAmount(double amount)
        {
            this.Count++;
            this.Sum += amount;
            this.Min = Math.Min(amount, this.Min);
            this.Max = Math.Max(amount, this.Max);
        }
    }
}
