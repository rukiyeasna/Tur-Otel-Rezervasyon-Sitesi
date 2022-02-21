using System;
using System.Collections.Generic;
using System.Text;
using TS.Business.Interfaces;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public List<AppUser> GetirHepsi()
        {
            return _appUserDal.GetirHepsi();
        }

        public AppUser GetirIdile(int id)
        {
            return _appUserDal.GetirIdile(id);
        }

        public void Guncelle(AppUser table)
        {
            _appUserDal.Guncelle(table);
        }

        public void Kaydet(AppUser table)
        {
            _appUserDal.Kaydet(table);
        }

        public void Sil(AppUser table)
        {
            _appUserDal.Sil(table);
        }
    }
}
