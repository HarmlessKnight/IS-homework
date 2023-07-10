using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Domain.Domain_Models
{
    public class EmailMessage: BaseEntity
    {
        public string Mailto { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public Boolean Status { get; set; }

    }
}
