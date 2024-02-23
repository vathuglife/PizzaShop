using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaoVietAnh.Asm2.Repo.Entities
{
    public partial class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Type { get; set; }
    }
}
