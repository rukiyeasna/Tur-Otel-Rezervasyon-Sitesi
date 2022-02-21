using System;
using System.Collections.Generic;
using System.Text;
using TS.DataAccess.Interfaces;
using TS.Entities.Concrete;

namespace TS.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfImagesRepository : EfGenericRepository<Images>, IImagesDal
    {
    }
}
