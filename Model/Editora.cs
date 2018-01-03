namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Editoras")]
    public partial class Editora
    {
        public Editora()
        {
            this.Livro = new HashSet<Livro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }        

        public virtual ICollection<Livro> Livro { get; set; } 
    }
}
