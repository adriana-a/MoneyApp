using System.IO.Enumeration;

namespace MoneyApp
{
    public abstract class CategoryBase : ICategory
    {
        public delegate void AmountAddedDelegate(object sender, EventArgs args);

        public abstract event AmountAddedDelegate AmountAdded;

        public string Name { get; }


        public CategoryBase(string name)
        {
            this.Name = name;
        }

        public abstract void AddAmount(float amount);

        public abstract void AddAmount(double amount);

        public abstract void AddAmount(decimal amount);

        public abstract void AddAmount(int amount);

        public abstract void AddAmount(string amount);

        public abstract Statistics GetStatistics();
    }
}
