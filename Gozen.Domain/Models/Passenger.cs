using Gozen.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Domain.Models
{
    public class Passenger
    {
        public Guid UniquePassengerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public eGender Gender { get; set; }
        public string DocumentNo { get; set; }
        public eDocumentType DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
