using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploExclusoes
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeleteSimples();
            //DeleteComplexo();
            DeleteCascataViaCodigo();
        }

        private static void DeleteCascataViaCodigo()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var cert = ctx.Certificacoes.Where(x => x.IdProfessor == 123);

                foreach (var item in cert)
                {
                    ctx.Certificacoes.Remove(item);
                }

                var professor = ctx.Professores.First(x => x.IdPessoa == 12345);
                ctx.Professores.Remove(professor);

                var pessoa = ctx.Pessoas.First(x => x.ID == 12345);
                ctx.Pessoas.Remove(pessoa);

                ctx.SaveChanges();
            }
        }

        private static void DeleteComplexo()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var pessoa = ctx.Pessoas.First(x => x.ID == 123);

                ctx.Pessoas.Remove(pessoa);

                ctx.SaveChanges();
            }
        }

        private static void DeleteSimples()
        {
            using (ClarifyDBEntities ctx = new ClarifyDBEntities())
            {
                var certificacao = ctx.Certificacoes.First(x => x.ID == 8);

                ctx.Certificacoes.Remove(certificacao);

                ctx.SaveChanges();
            }
        }
    }
}
