using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Leitores")]
    public partial class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public string Senha { get; set; }
        public int Livro_Id { get; set; }

        [ForeignKey("Livro_Id")]
        public virtual Livro Livro { get; set; }


    }
}
