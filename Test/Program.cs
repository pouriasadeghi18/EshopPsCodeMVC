using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            EshopPsCodeEntities db = new EshopPsCodeEntities();
            Product p = new Product()
            {
                Title = "test",
                ShortDiscraption = "test",
                Price = 1,
                CreateTime = DateTime.Now,
                Text = "test",
                ImageName = "test.jpg"

            };
            
           
            Grouping g = new Grouping()
            {
                GroupingName = "test"
            };
            db.Grouping.Add(g);

            Product_Selected_Groups pg = new Product_Selected_Groups() {

                GroupID = 71,
                ID = 55,
                ProductID = 5,
            };
            db.Product_Selected_Groups.Add(pg);
            db.SaveChanges();

              

           


            

        }
    }
}
