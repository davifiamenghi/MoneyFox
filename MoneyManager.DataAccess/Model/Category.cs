using PropertyChanged;
using SQLite.Net.Attributes;

namespace MoneyManager.DataAccess.Model
{
    [ImplementPropertyChanged]
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}