using SQLite;

namespace jjitalaS5.Models
{
    [SQLite.Table("Persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
