using EasyExpressions.Test.Extensions.Models;
using System.Collections.Generic;

namespace EasyExpressions.Test.Extensions.Mocks
{
    public static class PeopleMock
    {
        public static IEnumerable<People> GetPeoples()
        {
            return new List<People>
            {
                new People
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30
                }
            };
        }
    }
}
