using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Queries
{
    public class GetQuestionsQuery: IRequest<IEnumerable<QuestionVM>>
    {
    }
    public class GetQuestionsQueryHandler: IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetQuestionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<QuestionVM>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionVM>>(await _context.Questions.ToListAsync(cancellationToken));
        }
    }


}
