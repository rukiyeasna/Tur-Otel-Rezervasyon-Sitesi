using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.Entities.Concrete;

namespace TS.Web.Areas.Member.Models
{
    public class FavoriListViewModel
    {
        public int Id { get; set; }
        public TurBilgileri TurBilgileris { get; set; }
        public int TurId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppUserId { get; set; }
    }
}
