using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace GuitarBazar.Models
{
    public static class SellerDAL
    {
        public static List<string> SellerNameList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (Seller seller in DB.Sellers.OrderBy(c => c.Name))
            {
                list.Add(seller.Name);
            }
            return list;
        }
        public static List<string> SellerIdList(this GuitarBazarDBEntities DB)
        {
            List<string> list = new List<string>();
            foreach (Seller seller in DB.Sellers.OrderBy(c => c.Name))
            {
                list.Add(seller.Id.ToString());
            }
            return list;
        }

        public static Seller addSeller(this GuitarBazarDBEntities DB, Seller seller)
        {
            seller = DB.Sellers.Add(seller);
            DB.SaveChanges();
            return seller;
        }

        public static bool UpdateSeller(this GuitarBazarDBEntities DB, Seller seller)
        {
            DB.Entry(seller).State = EntityState.Modified;
            DB.SaveChanges();
            return true;
        }

        public static bool RemoveSeller(this GuitarBazarDBEntities DB, Seller seller)
        {
            Seller sellerToDelete = DB.Sellers.Find(seller.Id);
            DB.Sellers.Remove(sellerToDelete);
            DB.SaveChanges();
            return true;
        }
    }
}