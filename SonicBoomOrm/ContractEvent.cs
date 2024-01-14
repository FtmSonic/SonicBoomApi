using SonicBoomDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicBoomOrm
{
    public class ContractEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContractEventId { get; set; }
        public int ContractId { get; set; }
        [Column(TypeName = "jsonb")]
        public string Call { get; set; }
        public string TransactionHash { get; set; }
        [Column(TypeName = "jsonb")]
        public string Result { get; set; }
        public bool Success { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
