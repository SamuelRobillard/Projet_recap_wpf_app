using Examen2.Pratique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Pratique.Data
{
    public interface ILivreDataProvider 
    {
        public Task<IEnumerable<Livre>?> GetAllAsync();
    }

    public class LivreDataProvider : ILivreDataProvider
    {
        public async Task<IEnumerable<Livre>?> GetAllAsync()
        {
            await Task.Delay(1000);

            // À décommenter puis retourner livres

            var livres = new List<Livre>
            {
                new Livre { Titre = "Clean Code", Description =  "alllo"}
            };
            

            return livres;
        }
    }
}
