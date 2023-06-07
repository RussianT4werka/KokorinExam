using System;
using System.Collections.Generic;

namespace KokorinExam.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[]? Photo { get; set; } = null!;
    }
}
