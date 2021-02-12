using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UserQuestionsController : ApiController
    {
        /// <summary>
        /// Get all questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<QuestionVM>> GetQuestions()
        {
            return await Mediator.Send(new GetQuestionsQuery());
        }

        /// <summary>
        /// Create or update existing answer on a question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<ActionResult> Update(PutAnswersCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Endpoint to create a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns>userId</returns>
        [HttpPost]
        public async Task<ActionResult<long>> AddUser(AddUserCommand command)
        {
            return await Mediator.Send(command);
            
        }

    }
}