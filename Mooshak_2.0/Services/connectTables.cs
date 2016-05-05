using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshak_2._0.Models;
    
namespace Mooshak_2._0.Services
{
    public class connectTables
    {
        private ApplicationDbContext _Db;

        public connectTables()
        {
            _Db = new ApplicationDbContext();
        }
    }
}