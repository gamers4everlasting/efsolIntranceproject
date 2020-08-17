using System.Collections.Generic;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
    public class Question
    {
        /// <summary>
        /// Question identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Question stored data
        /// </summary>
        public string Title { get; set; }

        public QuestionTypes QuestionType { get; set; }

        public virtual ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
