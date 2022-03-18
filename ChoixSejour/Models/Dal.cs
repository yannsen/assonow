using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class Dal: IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Sejour> ObtientTousLesSejours()
        {
            return _bddContext.Sejours.ToList();
        }

        public int CreerSejour(string lieu, string telephone)
        {
            Sejour sejour = new Sejour { Lieu = lieu, Telephone = telephone };
            _bddContext.Sejours.Add(sejour);
            _bddContext.SaveChanges();
            return sejour.Id;
        }

        public void ModifierSejour(int id, string lieu, string telephone)
        {
            Sejour sejour = _bddContext.Sejours.Find(id);

            if (sejour != null)
            {
                sejour.Lieu = lieu;
                sejour.Telephone = telephone;
                _bddContext.SaveChanges();
            }
        }

        public void ModifierSejour(Sejour sejour)
        {
            if (sejour != null)
            {
                _bddContext.Sejours.Update(sejour);
                _bddContext.SaveChanges();
            }
        }
        public void SupprimerSejour(int id)
        {
            Sejour sejour = _bddContext.Sejours.Find(id);
            if (sejour != null)
            {
                _bddContext.Sejours.Remove(sejour);
                _bddContext.SaveChanges();
            }
        }
        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
