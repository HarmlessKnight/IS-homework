using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Domain.Domain_Models
{
    public class Ticket: BaseEntity
    {
        [Required]
        public string MovieTitle { get; set; }

        public string MovieImage { get; set; }

        public double Price { get; set; }

        public string Genre { get; set; }

        public class DateAndTime
        {
            public DateTime DateTime { get; set; }

            public DateAndTime(DateTime dateTime)
            {
                DateTime = dateTime;
            }
        }

        public DateTime DateTime { get; set; }


        public ICollection<TicketsInSC> ticketsinsc { get; set; }

    }
}
