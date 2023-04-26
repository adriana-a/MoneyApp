namespace MoneyApp
{
    public interface ICategory
    {
        string Name { get; }
        void AddAmount(float amount);

        void AddAmount(double amount);
        
        void AddAmount(int amount);
        
        void AddAmount(decimal amount);
        
        void AddAmount(string amount);

        Statistics GetStatistics();
    }
}
