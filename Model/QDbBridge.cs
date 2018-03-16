using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecard.Model
{
    public class QDbBridge : DbContext
    {
        // WOWOCO: DEFAULT CONSTRUCTOR (JUST DO THIS!)
        public QDbBridge() { }

        // WOWOCO: CONSTRUCTOR (JUST DO THIS!)
        public QDbBridge(DbContextOptions<QDbBridge> options) : base(options) { }

        // WOWOCO: TABLE IN THE DATABASE; EACH TABLE GETS ITS OWN LINE.
        // public DbSet<ENTER-TABLENAME-HERE> ENTER-TABLENAME-HERE { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }

    }
}