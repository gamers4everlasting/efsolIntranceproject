using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands
{
    public class PutAnswersCommand : IRequest
    {
        public int UserId { get; set; }
        public List<AnswersModel> AnswersList { get; set; }
    }

    public class PutAnswersCommandHandler : IRequestHandler<PutAnswersCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PutAnswersCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PutAnswersCommand request, CancellationToken cancellationToken)
        {
            var ids = request.AnswersList.Where(x => x.Id != 0).Select(x => x.Id);
            var toAdd = request.AnswersList.Where(x => x.Id == 0);
            await _context.UserAnswers.AddRangeAsync(
                _mapper.Map<IEnumerable<AnswersModel>, IEnumerable<UserAnswers>>(toAdd,
                    opt => opt.Items["UserId"] = request.UserId),
                cancellationToken);
            var toUpdate = _context.UserAnswers.Where(x => ids.Contains(x.Id));
            foreach (var item in toUpdate)
            {
                item.Answer = item.Answer;
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}