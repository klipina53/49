namespace _49_Lipina.Models
{
    public class Dishes
    {
        public int Id { get; set; }

        /// <summary> Категория
        public string Category { get; set; }

        /// <summary> Наименование блюда
        public string NameDish { get; set; }

        /// <summary> Стоимость
        public string Price {  get; set; }

        /// <summary> Иконка
        public string Icon { get; set; }

        /// <summary> Номер версии
        public int Version {  get; set; }
    }
}
