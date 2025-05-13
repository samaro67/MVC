using Microsoft.EntityFrameworkCore;

namespace Bilisim.EFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            var ctx = new OkulDBContext();
            try
            {
                var ogr = new Ogrenci { Ad = "Ali", Soyad = "Veli" };
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();              

            }
            catch(Exception)
            {
                
                Console.WriteLine("bir hata olustu");
            }
            finally 
            {
                ctx.Dispose();
            }
            */

            /*
            //insort örnegi
            using (var ctx = new OkulDBContext())
            {
                var ogr = new Ogrenci { Ad = "Ali", Soyad = "Veli" };
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();

            }

            */
            /*
            //update örnegi
            using (var ctx = new OkulDBContext()) 
            {
               var ogr = ctx.Ogrenciler.Find(3);
                if (ogr != null)
                {
                    ogr.Soyad = "Demirci";
                    ctx.Entry(ogr).State = EntityState.Modified;
                    int sonuc = ctx.SaveChanges();
                    Console.WriteLine(sonuc > 0 ? "basarılı" : "basarasız");

                }
            }
            */
            //select ornegi
            /*
            using (var ctx = new OkulDBContext())
            {
                var lst = ctx.Ogrenciler.ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"ad:{item.Ad} soyad:{item.Soyad}\n");
                }

            }
            */
            /*
            //ad bilgisine göre select
            using (var ctx = new OkulDBContext())
            {
               var lst =  ctx.Ogrenciler.Where(o => o.Ad == "Ali").ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine($"ad:{item.Ad} soyad:{item.Soyad}\n");
                }

            }

            */


            //delete örnegi
            using (var ctx = new OkulDBContext())
            {
                var ogr =ctx.Ogrenciler.Find(2);
                if (ogr!=null)
                {
                    ctx.Ogrenciler.Remove(ogr);
                    int sonuc = ctx.SaveChanges();
                    Console.WriteLine(sonuc > 0 ? "basarılı" : "basarasız");
                }
                else
                {
                    Console.WriteLine("ogrenci bulunamadı");
                }
            }

        }
    }
}

//GARBACE COLLECTOR
//using blokları icerisinde üretilen yönetikmeyen kaynaklar,using blokları dısına cıkarıldıgında 
