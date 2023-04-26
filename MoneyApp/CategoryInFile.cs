using System.IO.Enumeration;

namespace MoneyApp
{
    public class CategoryInFile : CategoryBase
    {
        public string FileName { get; }

        public override event AmountAddedDelegate AmountAdded;

        public CategoryInFile(string name, string fileName)
            : base(name)
        {
            this.FileName = fileName;
        }


        public override void AddAmount(float amount)
        {
            this.AddAmount((double)amount);
        }

        public override void AddAmount(double amount)
        {
            var amountRounded = Math.Round(amount, 2);
            if ((double)amount > 0)
            {

                using (var writer = File.AppendText(FileName))
                {
                    writer.WriteLine(amountRounded);
                    AmountAdded(this, new EventArgs());
                }
            }

            else
            {
                throw new Exception("Amount cannot be lower than 0 and has more than two decimal places");
            }
        }

        public override void AddAmount(int amount)
        {
            this.AddAmount((double)amount);
        }

        public override void AddAmount(decimal amount)
        {
            this.AddAmount((double)amount);
        }

        public override void AddAmount(string amount)
        {
            if (double.TryParse(amount, out double amountAsDouble))
            {
                this.AddAmount(amountAsDouble);
            }

            else
            {
                throw new Exception("Amount can be added only as double (number with two decimal places");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists($"{FileName}"))
            {
                using (var reader = File.OpenText($"{FileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var amount = double.Parse(line);
                        statistics.AddAmount(amount);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }

        public void ShowStatistics(CategoryInFile category)
        {
            Console.WriteLine($"Category {category.Name}");
            Console.WriteLine($"Max value: {category.GetStatistics().Max}");
            Console.WriteLine($"Min value: {category.GetStatistics().Min}");
            Console.WriteLine($"Sum of values: {category.GetStatistics().Sum}");
            Console.WriteLine($"Average value: {category.GetStatistics().Average}");
            Console.WriteLine("=========================");
        }
    }
}
