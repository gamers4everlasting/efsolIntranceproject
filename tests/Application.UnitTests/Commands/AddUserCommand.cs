using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using MediatR;
using NUnit.Framework;

namespace CleanArchitecture.Application.UnitTests.Commands
{

    public class CreateTodoItemTests : Testing
    {
        

        [Test]
        public async Task ShouldCreateNewUser()
        {
            var command = new AddUserCommand
            {
                FirstName = "Gosha",
                LastName = "Viktorov"
            };

            var user = await SendAsync(command);

            user.Should().Be(Unit.Value);
        } 
        
        [Test]
        public async Task ShouldGetAllQuestions()
        {

            var questions = await FindAsync<IEnumerable<QuestionVM>>();
            questions.Count().Should().Be(6);
            questions.First().Title.Should().Be("Введите имя: ");
        }
        
        [Test]
        public async Task AddAnswersToQuestions()
        {
            var command = new PutAnswersCommand
            {
                UserId = 1,
                AnswersList = new List<AnswersModel>
                {
                    new AnswersModel
                    {
                        Id = 0,
                        Answer = "Vicktor",
                        QuestionId = 1
                    }
                }
            };

            var responce = await SendAsync(command);
            responce.Should().Be(Unit.Value);
        }
    }
}
