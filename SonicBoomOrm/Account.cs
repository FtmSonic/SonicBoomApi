﻿using SonicBoomDto;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SonicBoomOrm
{
    [Index(nameof(Address), IsUnique = true)]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Address { get; set; }
        public string? RecoveryMail { get; set; }
        public SubscriptionLevel Subscription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastPayment { get; set; }
    }
}
