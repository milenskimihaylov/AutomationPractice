using IntegrationTests.Models;
using System;

namespace IntegrationTests.Factory
{
    public static class BookFactory
    {
        public static Book CreateBook()
        {
            var GuidId = Guid.NewGuid();

            return new Book
            {
                Id = GuidId,
                Title = "TestTitle",
                Description = "TestDescription",
                AuthorId = GuidId
            };
        }
    }
}
