using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UserQuestionsController : ApiController
    {
        public IActionResult Index()
        {
            return View();
        }
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
        [HttpPut]
        public async Task<ActionResult> Update(PutAnswersCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Endpoint to create a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

    }
}