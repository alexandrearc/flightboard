using System.ComponentModel.DataAnnotations.Schema;

namespace Flightboard.API.Models
{
    public class Airline
    {
        public Airline()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
