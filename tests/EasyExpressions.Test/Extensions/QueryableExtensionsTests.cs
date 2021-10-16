using EasyExpressions.Test.Extensions.Models;
using EasyExpressions.Extensions;
using System;
using System.Linq.Expressions;

using Xunit;
using FluentAssertions;
using EasyExpressions.Test.Extensions.Mocks;
using System.Linq;

namespace EasyExpressions.Test.Extensions
{
    public class QueryableExtensionsTests
    {
        private Expression<Func<People, bool>> filter;
        public QueryableExtensionsTests()
        {
            filter = x => true;
        }

        [Fact]
        public void FilterByFirstAndLastNameValidateNotEmpty()
        {
            #region Arrange

            string firstName = "John";
            string lastName = "Doe";

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.And(x => x.LastName.Equals(lastName));

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(1, "Failed test of filter by first and last name");

            #endregion
        }

        [Fact]
        public void FilterByFirstAndLastNameAndAgeValidateNotEmpty()
        {
            #region Arrange

            string firstName = "John";
            string lastName = "Doe";
            int? age = 30;

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.And(x => x.LastName.Equals(lastName));

            if (age.HasValue)
                filter = filter.And(x => x.Age == age.Value);

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(1, "Failed test of filter by first and last name and age");

            #endregion
        }


        [Fact]
        public void FilterByFirstAndLastNameValidateEmpty()
        {
            #region Arrange

            string firstName = "John";
            string lastName = "Monroe";

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.And(x => x.LastName.Equals(lastName));

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(0, "Failed test of filter by first and last name");

            #endregion
        }

        [Fact]
        public void FilterByFirstAndLastNameAndAgeValidateEmpty()
        {
            #region Arrange

            string firstName = "John";
            string lastName = "Doe";
            int? age = 28;

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.And(x => x.LastName.Equals(lastName));

            if (age.HasValue)
                filter = filter.And(x => x.Age == age.Value);

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(0, "Failed test of filter by first and last name and age");

            #endregion
        }

        [Fact]
        public void FilterByFirstOrLastNameValidateNotEmpty()
        {
            #region Arrange

            string firstName = "James";
            string lastName = "Doe";

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.Or(x => x.LastName.Equals(lastName));

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(1, "Failed test of filter by first and last name");

            #endregion
        }

        [Fact]
        public void FilterByFirstOrLastNameOrAgeValidateNotEmpty()
        {
            #region Arrange

            string firstName = "James";
            string lastName = "Monroe";
            int? age = 30;

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.Or(x => x.LastName.Equals(lastName));

            if (age.HasValue)
                filter = filter.Or(x => x.Age == age.Value);

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(1, "Failed test of filter by first and last name and age");

            #endregion
        }

        [Fact]
        public void FilterByFirstOrLastNameValidateEmpty()
        {
            #region Arrange

            string firstName = "James";
            string lastName = "Monroe";

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.Or(x => x.LastName.Equals(lastName));

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(0, "Failed test of filter by first and last name");

            #endregion
        }

        [Fact]
        public void FilterByFirstOrLastNameOrAgeValidateEmpty()
        {
            #region Arrange

            string firstName = "James";
            string lastName = "Monroe";
            int? age = 28;

            filter = x => x.FirstName.Equals(firstName);

            #endregion

            #region Act

            if (!string.IsNullOrEmpty(lastName))
                filter = filter.Or(x => x.LastName.Equals(lastName));

            if (age.HasValue)
                filter = filter.Or(x => x.Age == age.Value);

            var result = PeopleMock.GetPeoples().AsQueryable().Where(filter).ToList();

            #endregion

            #region Assert

            result.Count().Should().Be(0, "Failed test of filter by first and last name and age");

            #endregion
        }
    }
}
