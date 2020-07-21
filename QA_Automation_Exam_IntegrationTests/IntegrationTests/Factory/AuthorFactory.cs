using IntegrationTests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Factory
{
    public static class AuthorFactory
    {
        public static Author CreateAuthorWithId()
        {
            var GuidId = Guid.NewGuid();

            return new Author
            {
                Id = GuidId,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = DateTime.Now.ToString(),
                Genre = "TestGenre"
            };
        }
    }
}
