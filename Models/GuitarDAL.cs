using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GuitarBazar.Models
{
    public static class GuitarDAL
    {
        public static List<string> GuitarConditionNameList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (Condition condition in DB.Conditions.OrderBy(c => c.Name))
            {
                list.Add(condition.Name);
            }
            return list;
        }
        public static List<string> GuitarConditionIdList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (Condition condition in DB.Conditions.OrderBy(c => c.Name))
            {
                list.Add(condition.Id.ToString());
            }
            return list;
        }
        public static List<string> GuitarTypeNameList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (GuitarType guitarType in DB.GuitarTypes.OrderBy(c => c.Name))
            {
                list.Add(guitarType.Name);
            }
            return list;
        }
        public static List<string> GuitarTypeIdList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (GuitarType guitarType in DB.GuitarTypes.OrderBy(c => c.Name))
            {
                list.Add(guitarType.Id.ToString());
            }
            return list;
        }
        public static List<string> TypeGuitarList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (var guitarType in DB.GuitarTypes.OrderBy(c => c.Name))
            {
                list.Add(guitarType.Name);
            }
            return list;
        }

        public static int GetCategoryIdByCondition(this GuitarBazarDBEntities DB, string name)
        {
            name = name.First().ToString().ToUpper() + name.Substring(1).ToLower();
            Condition category = DB.Conditions.Where(c => c.Name == name).FirstOrDefault();
            if (category == null)
            {
                category = new Condition();
                category.Name = name;
                category = DB.Conditions.Add(category);
                DB.SaveChanges();
            }
            return category.Id;
        }

        public static IEnumerable<Guitar> GetGuitare(this GuitarBazarDBEntities DB, int categorieId = 0)
        {
            if (categorieId != 0)
                return DB.Guitars.Where(n => n.Id == categorieId).OrderByDescending(n => n.Id);
            return DB.Guitars.OrderByDescending(n => n.AddDate);
        }


        public static Guitar AddGuitar(this GuitarBazarDBEntities DB, Guitar guitar)
        {
            guitar = DB.Guitars.Add(guitar);
            DB.SaveChanges();
            return guitar;
        }
        public static bool UpdateGuitar(this GuitarBazarDBEntities DB, Guitar guitar)
        {
            DB.Entry(guitar).State = EntityState.Modified;
            DB.SaveChanges();
            return true;
        }
        public static bool RemoveGuitar(this GuitarBazarDBEntities DB, Guitar guitar)
        {
            Guitar guitarToDelete = DB.Guitars.Find(guitar.Id);
            DB.Guitars.Remove(guitarToDelete);
            DB.SaveChanges();
            return true;
        }
    }
}