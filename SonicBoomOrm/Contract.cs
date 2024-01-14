using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SonicBoomDto;

namespace SonicBoomOrm
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        public int ProjectId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public ContractType ContractType { get; set; }
        public virtual Project Project { get; set; }
    }
}
