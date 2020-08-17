using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Models
{
    public class QuestionVM: IMapFrom<Question>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionTypes QuestionType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionVM>();
        }
    }
}
