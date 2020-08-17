using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Queries;

namespace CleanArchitecture.WebUI.Controllers
{
    public class UserQuestionsController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<QuestionVM>> GetQuestions()
        {
            return await Mediator.Send(new GetQuestionsQuery());
        }

        [HttpPut]
        public async Task<ActionResult> Update(PutAnswersCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

    }
}