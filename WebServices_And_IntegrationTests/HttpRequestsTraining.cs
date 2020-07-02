using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using WebServices_And_IntegrationTests.HttpModel;
using WebServices_And_IntegrationTests.Model;

namespace WebServices_And_IntegrationTests
{
    public class Tests : BaseTest
    {
        private RestClient _restClient;
        private List<Household> _household;
        private List<User> _user;
        private List<Book> _book;
        private List<HouseholdWishlist> _householdWishlist;
        private UserWishlist _userWishlist;
        private static long? _serialBookNumber;
        private static long? _serialUserNumber;
        private static long? _serialWishlistNumber;
        private static long? _serialHouseholdNumber;
        [SetUp]
        public void Setup()
        {
            _restClient = new RestClient();
            _restClient.BaseUrl = new Uri("http://localhost:3000");
            _restClient.AddDefaultHeader("G-Token", "ROM831ESV");
        }

        [Test]
        public void WebServiceTest()
        {
            //Creating new household and asserting the creation

            _household = GetAllHouseholds("/households", _restClient);
            if (_household.Count != 0 )
            {
                _serialHouseholdNumber = _household.LastOrDefault().Id;
            }
            else
            {
                _serialHouseholdNumber = 0;
            }
            
            IRestResponse response = CreateNewHousehold($"TestHousehold{ _serialHouseholdNumber + 1}", _restClient);

            Assert.IsTrue(response.IsSuccessful);

            _household = GetAllHouseholds("/households", _restClient);
            var newCreatedHouseholdId = _household.LastOrDefault().Id;

            Assert.AreEqual(_serialHouseholdNumber + 1, newCreatedHouseholdId);

            //Creating two different users and assigning two newly created books per user 
        
            _user = GetAllUsers("/users", _restClient);
            if (_user.Count != 0)
            {
                _serialUserNumber = _user.LastOrDefault().Id;
            }
            else
            {
                _serialUserNumber = 0;
            }
            
            _book = GetAllBooks("/books", _restClient);
            if (_book.Count != 0)
            {
                _serialBookNumber = _book.LastOrDefault().Id;
            }
            else
            {
                _serialBookNumber = 0;
            }

            //var lastCreatedBookId = _serialBookNumber;
            //var lastCreatedUserId = _serialUserNumber;

            for (int loopCreatedUsers = 0; loopCreatedUsers < 2; loopCreatedUsers++) // loop for creating 2 users
            {
                IRestResponse responseAfterCreatingAUser = CreateNewUser($"TestEmail{_serialUserNumber + 1}", 
                                                       $"TestFirstName{_serialUserNumber + 1}", 
                                                       $"TestLastName{_serialUserNumber + 1}", 
                                                       newCreatedHouseholdId, 
                                                       _restClient);

                Assert.IsTrue(responseAfterCreatingAUser.IsSuccessful);

                _serialUserNumber++;

                _user = GetAllUsers("/users", _restClient);
                _serialWishlistNumber = _user.LastOrDefault().WishlistId;

                for (int loopCreatedBooks = 0; loopCreatedBooks < 2; loopCreatedBooks++) // loop for creating 2 books per user
                {
                    IRestResponse responseAfterCreatingABook = CreateNewBook($"TestTitle{_serialBookNumber + 1}", 
                                                                             $"TestAuthor{_serialBookNumber + 1}", 
                                                                             DateTime.Now, 
                                                                             1234567 + _serialBookNumber + 1, 
                                                                             _restClient);

                    Assert.IsTrue(responseAfterCreatingABook.IsSuccessful);

                    _serialBookNumber++;

                    _book = GetAllBooks("/books", _restClient);
                    var currentCreatedBookId = _book.LastOrDefault().Id;

                    IRestResponse responseAfterAddingABookToAWishlist = AddBookToWishlist(_serialWishlistNumber, currentCreatedBookId, _restClient);

                    Assert.IsTrue(responseAfterAddingABookToAWishlist.IsSuccessful);
                }
            }

            //Getting the wishlist for the newly created household and asserting the books in the wishlist

            _householdWishlist = GetWishlistForHousehold($"/households/{newCreatedHouseholdId}/wishlistBooks", _restClient);

            AssertSameBooks(_book[_book.Count - 4], _householdWishlist[0]);
            AssertSameBooks(_book[_book.Count - 3], _householdWishlist[1]);
            AssertSameBooks(_book[_book.Count - 2], _householdWishlist[2]);
            AssertSameBooks(_book[_book.Count - 1], _householdWishlist[3]);

            //Getting the wishlist for each newly created user and asserting the books in these wishlists
            
            _userWishlist = GetWishlistForUser($"/wishlists/{_user[_user.Count - 2].Id}/books", _restClient);

            AssertSameBooks(_book[_book.Count - 4], _userWishlist.Books[0]);
            AssertSameBooks(_book[_book.Count - 3], _userWishlist.Books[1]);

            _userWishlist = GetWishlistForUser($"/wishlists/{_user[_user.Count - 1].Id}/books", _restClient);

            AssertSameBooks(_book[_book.Count - 2], _userWishlist.Books[0]);
            AssertSameBooks(_book[_book.Count - 1], _userWishlist.Books[1]);
        }

    }
} 