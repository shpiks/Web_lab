using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Entities
{
    public class Phone
    {
        public int PhoneId { get; set; } // id телефона
        public string PhoneName { get; set; } // название телефона
        public string Description { get; set; } // описание телефона
        public double Price { get; set; } // размер экрана
        public string Image { get; set; } // имя файла изображения
        // Навигационные свойства
        /// <summary>
        //////
        ////// группа блюд (например, супы, напитки и т.д.)
        ////// </summary>///
        public int PhoneGroupId { get; set; }
        public PhoneGroup Group { get; set; }
    }
}
