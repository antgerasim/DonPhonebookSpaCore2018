﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Don2018.PhonebookSpa.PhoneBook.People;

namespace Don2018.PhonebookSpa.PhoneBook.Phones
{
    [Table("PbPhones")]
    public class Phone : CreationAuditedEntity<long>
    {
        public const int MaxNumberLength = 16;

        //[ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public virtual int  PersonId { get; set; }

        [Required]
        public virtual PhoneType Type { get; set; }

        [Required]
        [MaxLength(MaxNumberLength)]
        public virtual string Number { get; set; }
    }
}