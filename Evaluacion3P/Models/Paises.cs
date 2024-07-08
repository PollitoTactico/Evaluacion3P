using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion3P.Models
{

    [SQLite.Table("Paises")]
    public class Paises
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subregion { get; set; }
        public string Status { get; set; }

        public string JoseSanchez { get; set; } 
    }
}
