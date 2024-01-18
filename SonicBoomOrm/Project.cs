using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicBoomOrm
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public string ApiKey { get; set; }
        public string ReadOnlyApiKey { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<Contract> Contract { get; set; }

    }
}
