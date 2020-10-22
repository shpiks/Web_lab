using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Entities
{
   public class PhoneGroup
    {
        public int PhoneGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary> 
        /// /// Навигационное свойство 1-ко-многим    
        /// /// </summary> 
        /// 
        public List<Phone> Phones { get; set; } 
    }
}
