using AutoFixture;
using AutomationPractice.Models;

namespace AutomationPractice.Factories
{
    public static class AutomationPracticeFormFactory
    {
        public static AutomationPracticeFormModel CreateUser()
        {
            var fixture = new Fixture();

            return new AutomationPracticeFormModel
            {
                FirstName = "Pesho",
                LastName = "Goshev",
                Email = fixture.Create<string>() + "@gmail.com",
                Password = "peshogosho123",
                Address = fixture.Create<string>(),
                City = "Montana",
                State = "26",
                PostalCode = "12345",
                MobilePhone = "0123456789"
        };
        }

    }
}
