using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public interface IDal: IDisposable
    {
        void DeleteCreateDatabase();
        List<Sejour> ObtientTousLesSejours();
        int CreerSejour(string lieu, string telephone);
        void ModifierSejour(int id, string lieu, string telephone);
        void ModifierSejour(Sejour sejour);
        void SupprimerSejour(int id);
    }
}
