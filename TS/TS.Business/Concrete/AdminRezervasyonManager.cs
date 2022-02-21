using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class AdminRezervasyonManager : IAdminRezervasyonService
    {
        private readonly IAdminRezervasyonDal _adminRezervasyonDal;

        public AdminRezervasyonManager(IAdminRezervasyonDal adminRezervasyonDal)
        {
            _adminRezervasyonDal = adminRezervasyonDal;
        }

        public List<AdminRezervasyon> GetirHepsi()
        {
            return _adminRezervasyonDal.GetirHepsi();
        }

        public AdminRezervasyon GetirIdile(int id)
        {
            return _adminRezervasyonDal.GetirIdile(id);
        }

        public List<AdminRezervasyon> GetirTumTablolarla()
        {
            return _adminRezervasyonDal.GetirTumTablolarla();
        }

        public void Guncelle(AdminRezervasyon table)
        {
            _adminRezervasyonDal.Guncelle(table);
        }

        public void Kaydet(AdminRezervasyon table)
        {
            _adminRezervasyonDal.Kaydet(table);
        }

        public void Sil(AdminRezervasyon table)
        {
            _adminRezervasyonDal.Sil(table);
        }
    }
}
