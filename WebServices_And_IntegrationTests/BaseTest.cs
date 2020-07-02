using RestSharp;
using System;
using System.Collections.Generic;
using WebServices_And_IntegrationTests.HttpModel;
using WebServices_And_IntegrationTests.Model;

namespace WebServices_And_IntegrationTests
{
    public class BaseTest
    {
        public IRestResponse CreateNewHousehold(string name, RestClient restClient)
        {
            var newHousehold = new Household() { Name = name };
            var requestCreateNewHousehold = new RestRequest("/households", Method.POST);
            requestCreateNewHousehold.AddParameter("application/json", newHousehold.ToJson(), ParameterType.RequestBody);
            IRestResponse response = restClient.Post(requestCreateNewHousehold);
            return response;
        }

        public List<Household> GetAllHouseholds(string resource, RestClient restClient)
        {
            var requestHouseholds = new RestRequest(resource);
            IRestResponse response = restClient.Get(requestHouseholds);
            List<Household> household = Household.FromJson(response.Content);
            return household;
        }

        public IRestResponse CreateNewUser(string email, string firstName, string lastName, long? householdId, RestClient restClient)
        {
            var newUser = new User() { Email = email, FirstName = firstName, LastName = lastName, HouseholdId = householdId };
            var requestCreateNewUser = new RestRequest("/users", Method.POST);
            requestCreateNewUser.AddParameter("application/json", newUser.ToJson(), ParameterType.RequestBody);
            IRestResponse response = restClient.Post(requestCreateNewUser);
            return response;
        }

        public List<User> GetAllUsers(string resource, RestClient restClient)
        {
            var requestUsers = new RestRequest(resource);
            IRestResponse response = restClient.Get(requestUsers);
            List<User> users = User.FromJson(response.Content);
            return users;
        }

        public IRestResponse CreateNewBook(string title, string author, DateTimeOffset? publicationDate, long? isbn, RestClient restClient)
        {
            var newBook = new Book() { Title = title, Author = author, PublicationDate = publicationDate, Isbn = isbn };
            var requestCreateNewBook = new RestRequest("/books", Method.POST);
            requestCreateNewBook.AddParameter("application/json", newBook.ToJson(), ParameterType.RequestBody);
            IRestResponse response = restClient.Post(requestCreateNewBook);
            return response;
        }

        public List<Book> GetAllBooks(string resource, RestClient restClient)
        {
            var requestBooks = new RestRequest(resource);
            IRestResponse response = restClient.Get(requestBooks);
            List<Book> books = Book.FromJson(response.Content);
            return books;
        }

        public IRestResponse AddBookToWishlist(long? wishlistId, long? bookId, RestClient restClient)
        {
            var requestAddBookToWishlist = new RestRequest($"/wishlists/{wishlistId}/books/{bookId}", Method.POST);
            IRestResponse response = restClient.Post(requestAddBookToWishlist);
            return response;
        }

        public List<HouseholdWishlist> GetWishlistForHousehold(string resource, RestClient restClient)
        {
            var requestWishlistForHousehold = new RestRequest(resource);
            IRestResponse response = restClient.Get(requestWishlistForHousehold);
            List<HouseholdWishlist> householdWishlist = HouseholdWishlist.FromJson(response.Content);
            return householdWishlist;
        }

        public UserWishlist GetWishlistForUser(string resource, RestClient restClient)
        {
            var requestWishlistForUser = new RestRequest(resource);
            IRestResponse response = restClient.Get(requestWishlistForUser);
            UserWishlist userWishlist = UserWishlist.FromJson(response.Content);
            return userWishlist;
        }

        public bool AssertSameBooks(Book bookFromTheList, HouseholdWishlist bookFromTheWishlist)
        {
            if (bookFromTheList.Title == bookFromTheWishlist.Title && bookFromTheList.Author == bookFromTheWishlist.Author && bookFromTheList.Isbn == bookFromTheWishlist.Isbn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AssertSameBooks(Book bookFromTheList, Book bookFromTheWishlist)
        {
            if (bookFromTheList.Title == bookFromTheWishlist.Title && bookFromTheList.Author == bookFromTheWishlist.Author && bookFromTheList.Isbn == bookFromTheWishlist.Isbn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
