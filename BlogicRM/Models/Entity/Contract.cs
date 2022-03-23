using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogicRM.Models.Entity
{
    [Table(nameof(Contract))]
    public class Contract
    {
        [Key]
        public int ID { get; set; }

        public int EvidenceNumber { get; set; }

        public string Institution { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Consultant")]
        public int ConsultantID { get; set; }
        public Consultant Consultant { get; set; }

        //public ICollection<Consultant> Consultants { get; set; } 
        //TODO: many-to-many
        //(Unable to determine the relationship
        //represented by navigation 'Consultant.Contracts'
        //of type 'ICollection<Contract>'.)

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CloseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpiDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
       
    }
}
