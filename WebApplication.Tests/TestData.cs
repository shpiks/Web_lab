using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Controllers;
using WebApplication.DAL.Data;
using WebApplication.DAL.Entities;
using Xunit;

namespace WebApplication.Tests
{
    public class TestData
    {
        public static void FillContext(ApplicationDbContext context)
        {
            context.PhoneGroups.Add(new PhoneGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Phone>
            {
                new Phone{ PhoneId = 1, PhoneGroupId=2},
                new Phone{ PhoneId = 2, PhoneGroupId=4},
                new Phone{ PhoneId = 3, PhoneGroupId=1},
                new Phone{ PhoneId = 4, PhoneGroupId=3},
                new Phone{ PhoneId = 5, PhoneGroupId=2},

            });
            context.SaveChanges();
        }
        public static List<Phone> GetPhonesList()
        {
            return new List<Phone>
            { 
                new Phone { PhoneId = 1, PhoneGroupId = 2},
                new Phone { PhoneId = 2, PhoneGroupId = 4},
                new Phone { PhoneId = 3, PhoneGroupId = 1},
                new Phone { PhoneId = 4, PhoneGroupId = 3},
                new Phone { PhoneId = 5, PhoneGroupId = 2}
            };
        }
        public static IEnumerable<object[]> Params()
        {             
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };         }
        }
}
