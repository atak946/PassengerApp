using Gozen.Domain.Enums;
using System;

namespace Gozen.Application.Dtos
{
    public class PassengerDto
    {
        public Guid? UniquePassengerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public eGender Gender { get; set; }
        public string DocumentNo { get; set; }
        public eDocumentType DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
