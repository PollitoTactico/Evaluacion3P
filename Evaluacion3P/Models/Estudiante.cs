using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion3P.Models
{
    [SQLite.Table("Estudiante")]
    internal class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string JoseSanchez { get; set; }
    }
}
