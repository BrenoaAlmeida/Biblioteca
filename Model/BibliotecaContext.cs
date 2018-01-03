using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace Model
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbConnection connection)
            : base(connection , true)
        {
        }

        public BibliotecaContext()
            : base("BibliotecaContext")
        {
        }
        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<Leitor> Leitores { get; set; }
        public virtual DbSet<Bibliotecario> Bibliotecarios { get; set; }
    }
}


//public class BloggingContext : DbContext 
//{ 
    //public BloggingContext() 
   //     : base("BloggingDatabase") 
  //  { 
 //   } 
//}