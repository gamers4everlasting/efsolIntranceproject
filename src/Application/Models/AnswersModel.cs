using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Models
{
    public class AnswersModel: IMapFrom<UserAnswers>
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Answer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AnswersModel, UserAnswers>().ForMember(x => x.UserId,
                x => x.MapFrom((src, dst, _, context) => context.Options.Items["UserId"]));
        }
    }
}
