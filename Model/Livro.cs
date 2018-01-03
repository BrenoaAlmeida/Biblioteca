
namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Livros")]
    public partial class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public int Estoque { get; set; }
        public int Editora_Id { get; set; }        
            
        [ForeignKey("Editora_Id")]
        public virtual Editora Editora { get; set; }

        public virtual ICollection<Leitor> Leitor { get; set; }
    }
}
