using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {

            if (!context.Questions.Any())
            {
                context.Questions.AddRange(new List<Question>
                {
                    new Question{Title = "Введите имя: ", QuestionType = QuestionTypes.SingleLineTextBox},
                    new Question{Title = "Введите возраст: ", QuestionType = QuestionTypes.SingleLineTextBox},
                    new Question{Title = "Введите пол: ", QuestionType = QuestionTypes.SingleSelect},
                    new Question{Title = "Введите дату рождения: ", QuestionType = QuestionTypes.DateTimePicker},
                    new Question{Title = "Введите семейное положение: ", QuestionType = QuestionTypes.SingleSelect},
                    new Question{Title = "Любите ли вы программировать: ", QuestionType = QuestionTypes.YesOrNo}
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
