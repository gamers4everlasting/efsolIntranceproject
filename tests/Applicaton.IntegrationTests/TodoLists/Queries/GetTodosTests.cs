using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Entities;

namespace CleanArchitecture.Application.IntegrationTests.TodoLists.Queries
{
    using static Testing;

    public class GetTodosTests : TestBase
    {
        [Test]
        public async Task ShouldReturnPriorityLevels()
        {
            var query = new GetTodosQuery();

            var result = await SendAsync(query);

            result.PriorityLevels.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldReturnAllListsAndItems()
        {
            await AddAsync(new Question
            {
                Title = "Shopping",
                Items =
                    {
                        new UserAnswers { Title = "Apples", Done = true },
                        new UserAnswers { Title = "Milk", Done = true },
                        new UserAnswers { Title = "Bread", Done = true },
                        new UserAnswers { Title = "Toilet paper" },
                        new UserAnswers { Title = "Pasta" },
                        new UserAnswers { Title = "Tissues" },
                        new UserAnswers { Title = "Tuna" }
                    }
            });

            var query = new GetTodosQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(1);
            result.Lists.First().Items.Should().HaveCount(7);
        }
    }
}
