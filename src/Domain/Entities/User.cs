using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public virtual ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
