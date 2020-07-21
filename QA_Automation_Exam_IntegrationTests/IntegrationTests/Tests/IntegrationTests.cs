using IntegrationTests.Factory;
using IntegrationTests.Models;
using NUnit.Framework;
using RestSharp;
using System;

namespace IntegrationTests
{
    [TestFixture]
    public class IntegrationTests : IntegrationBaseTest
    {
        private RestClient _restClient;
        private Author _author;
        private Author _postedAuthor;
        private Book _book;
        private Book _postedBook;

        public static object Converter { get; internal set; }

        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient();
            _restClient.BaseUrl = new Uri("https://libraryjuly.azurewebsites.net/");
            _author = AuthorFactory.CreateAuthorWithId();
            _book = BookFactory.CreateBook();
        }

        [Test]
        public void Test_A_PostBookForAuthor()
        {
            var response = PostNewAuthor(_author, _restClient);

            _postedAuthor = Author.FromJson(response.Content);

            var responseAfterPostingABook = PostBookForAuthor(_postedAuthor, _book, _restClient);

            _postedBook = Book.FromJson(responseAfterPostingABook.Content);

            Assert.IsTrue(responseAfterPostingABook.IsSuccessful);
            Assert.AreEqual(_postedBook.AuthorId, _postedAuthor.Id);
        }

        [Test]
        public void Test_B_GetBookForAuthor()
        {
            var responseAfterGetBookFromAuthor = GetBookForAuthor(_postedAuthor, _postedBook, _restClient);

            var returnedBook = Book.FromJson(responseAfterGetBookFromAuthor.Content);

            Assert.IsTrue(responseAfterGetBookFromAuthor.IsSuccessful);
            Assert.AreEqual(_postedBook.Id, returnedBook.Id);
            Assert.AreEqual(_postedBook.Title, returnedBook.Title);
            Assert.AreEqual(_postedBook.Description, returnedBook.Description);
        }

        [Test]
        public void Test_C_DeleteBookForAuthor()
        {
            var responseAfterDeletingABookFromAuthor = DeleteBookForAuthor(_postedAuthor, _postedBook, _restClient);

            Assert.IsTrue(responseAfterDeletingABookFromAuthor.IsSuccessful);
            Assert.AreEqual("NoContent", responseAfterDeletingABookFromAuthor.StatusCode.ToString());
        }
    }
}
