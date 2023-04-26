using MoneyApp;

namespace Money.Tests
{
    public class CategoryInFileTests
    {

        [Test]
        public void TwoCategories_AreDifferentObjects()
        {
            var foodCategory = new CategoryInFile("food", "food.txt");
            var educationCategory = new CategoryInFile("education", "education.txt");

            Assert.AreNotSame(foodCategory, educationCategory);
        }

    }
}