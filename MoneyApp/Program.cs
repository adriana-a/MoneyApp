using MoneyApp;

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Hello in MoneyApp! You can collect here your daily amounts in file .txt and get statistics");
Console.WriteLine("==========================================================");
Console.WriteLine("Choose category to add amounts: \n" +
        "A - Food\n" +
        "B - Education\n" +
        "C - Recreation\n" +
        "D - Housing Fees\n" +
        "E - House Stuff\n" +
        "F - Clothes\n" +
        "G - Other\n" +
        "H - show statistics\n" +
        "X - close MoneyApp \n");

var foodCategory = new CategoryInFile("Food", "food_amounts.txt");
var educationCategory = new CategoryInFile("Education", "education_amounts.txt");
var recreationCategory = new CategoryInFile("Recreation", "recreation_amounts.txt");
var housingFeesCategory = new CategoryInFile("Housing Fees", "housing_fees__amounts.txt");
var houseStuffCategory = new CategoryInFile("House Stuff", "house_stuff_amounts.txt");
var clothesCategory = new CategoryInFile("Clothes", "clothes_amounts.txt");
var otherCategory = new CategoryInFile("Other", "other_amounts.txt");

bool appIsActive = true;

foodCategory.AmountAdded += CategoryAmountAdded;
educationCategory.AmountAdded += CategoryAmountAdded;
recreationCategory.AmountAdded += CategoryAmountAdded;
housingFeesCategory.AmountAdded += CategoryAmountAdded;
houseStuffCategory.AmountAdded += CategoryAmountAdded;
clothesCategory.AmountAdded += CategoryAmountAdded;
otherCategory.AmountAdded += CategoryAmountAdded;

void CategoryAmountAdded(object sender, EventArgs args)
{
    Console.WriteLine("(Amount is added)\n");
}


void AddToCategory(string name, ICategory category)
{
    Console.WriteLine($"{name} category\n");

    var statistics = category.GetStatistics();

    Console.WriteLine($"You already collect {statistics.Sum} PLN in this category");
    Console.WriteLine("Add amount");

    string amount = Console.ReadLine();

    try
    {
        category.AddAmount(amount);
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("==================================");
        Console.WriteLine($"Exception is catched: {e}");
        Console.WriteLine("==================================\n");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }

    Console.WriteLine("Choose category");
}

while (appIsActive)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    string input = Console.ReadLine().ToUpper();

    while (input != null)
    {
        if (input == "A")
        {
            AddToCategory("Food", foodCategory);
            input = Console.ReadLine().ToUpper();
        }


        else if (input == "B")
        {
            AddToCategory("Education", educationCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "C")
        {
            AddToCategory("Recreation", recreationCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "D")
        {
            AddToCategory("Housing fees", housingFeesCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "E")
        {
            AddToCategory("House stuff", houseStuffCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "F")
        {
            AddToCategory("Clothes", clothesCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "G")
        {
            AddToCategory("Other", otherCategory);
            input = Console.ReadLine().ToUpper();
        }

        else if (input == "H")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foodCategory.ShowStatistics(foodCategory);
            educationCategory.ShowStatistics(educationCategory);
            recreationCategory.ShowStatistics(recreationCategory);
            housingFeesCategory.ShowStatistics(housingFeesCategory);
            houseStuffCategory.ShowStatistics(houseStuffCategory);
            clothesCategory.ShowStatistics(clothesCategory);
            otherCategory.ShowStatistics(otherCategory);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            input = Console.ReadLine();
        }

        else if (input == "X")
        {
            appIsActive = false;
            break;
        }

        else
        {
            Console.WriteLine("Choose real category");
            input = Console.ReadLine().ToUpper();
        }
    }

    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Press any key to close MoneyApp");
    Console.ReadKey();
}




