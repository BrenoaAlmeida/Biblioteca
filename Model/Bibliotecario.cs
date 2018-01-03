using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Bibliotecarios")]
    public partial class Bibliotecario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
