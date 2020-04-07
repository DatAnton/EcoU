using System;
using System.Collections;
using System.Collections.Generic;
namespace EcoU.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public List<CleaningPlan> CleaningPlans { get; set; }

        public static List<string> getRegions()
        {
            List<string> regions = new List<string>{
              "Автономная Республика Крым",
              "Винницкая область",
              "Волынская область",
              "Днепропетровская область",
              "Донецкая область",
              "Житомирская область",
              "Закарпатская область",
              "Запорожская область",
              "Ивано-Франковская область",
              "Киевская область",
              "Кировоградская область",
              "Луганская область",
              "Львовская область",
              "Николаевская область",
              "Одесская область",
              "Полтавская область",
              "Ровненская область",
              "Сумская область",
              "Тернопольская область",
              "Харьковская область",
              "Херсонская область",
              "Хмельницкая область",
              "Черкасская область",
              "Черниговская область",
              "Черновицкая область"
            };
            return regions;
        }
    }
}
