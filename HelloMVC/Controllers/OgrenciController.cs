using AspNetCoreGeneratedDocument;
using HelloMVC.Models;
using HelloMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class OgrenciController : Controller
    {
        static List<Ogrenci> ogrenciListesi = new List<Ogrenci>
{
    new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" },
    new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" }
};
        //
        public ViewResult Index()//Action
        {
            return View("AnaSayfa");
        }
        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogrenci = null;
            Ogretmen ogrt = null;

            if (id == 1)
            {
                ogrenci = new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" };
                ogrt = new Ogretmen { Id = 1, Ad = "Osman", Soyad = "Demir" };
            }
            else if (id == 2)
            {
                ogrenci = new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" };
                ogrt = new Ogretmen { Id = 2, Ad = "Cafer", Soyad = "Gündüz" };

            }
            ViewData["ogr"] = ogrenci;
            ViewBag.student = ogrenci;
            ViewBag.ogretmen = ogrt;

            var dto = new OgrenciDetayDTO { Ogrenci = ogrenci, Ogretmen = ogrt };
            return View(dto);
        }

        public ViewResult OgrenciListe()
        {
            //2 adet öğrenci nesnesi oluştur
            //Liste oluştur
            //Öğrencileri listeye ekle
            //Listeyi View'e gönder



            //Ogrenci ogrenci = new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" };
            //Ogrenci ogrenci1 = new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" };

            //List<Ogrenci> list = new List<Ogrenci>();
            //list.Add(ogrenci);
            //list.Add(ogrenci1);

            // var lst = new List<Ogrenci>
            {
                //  new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" },
                // new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" }
                return View(ogrenciListesi);
            }
            ;

            //ViewBag.ogrenciler = list;
            // return View(lst);
        }
        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogr)
        {
            // Yeni öğrenciye ID ver (otomatik artan ID)
            int yeniId = ogrenciListesi.Any() ? ogrenciListesi.Max(o => o.Ogrenciid) + 1 : 1;
            ogr.Ogrenciid = yeniId;

            // Listeye ekle
            ogrenciListesi.Add(ogr);

            // Liste sayfasına yönlendir
            return RedirectToAction("OgrenciListe");
        }

        // Güncelleme formunu göster
        [HttpGet]
        public IActionResult OgrenciGuncelle(int id)
        {
            var ogr = ogrenciListesi.FirstOrDefault(o => o.Ogrenciid == id);
            if (ogr == null)
            {
                return NotFound(); // Öğrenci bulunamazsa 404 dön
            }
            return View(ogr); // View'a mevcut öğrenci bilgilerini gönder
        }

        // Güncelleme işlemini alır
        [HttpPost]
        public IActionResult OgrenciGuncelle(Ogrenci ogr)
        {
            var eski = ogrenciListesi.FirstOrDefault(o => o.Ogrenciid == ogr.Ogrenciid);
            if (eski != null)
            {
                eski.Ad = ogr.Ad;
                eski.Soyad = ogr.Soyad;
            }
            return RedirectToAction("OgrenciListe");
        }

        // Silme işlemi
        public IActionResult OgrenciSil(int id)
        {
            var silinecek = ogrenciListesi.FirstOrDefault(o => o.Ogrenciid == id);
            if (silinecek != null)
            {
                ogrenciListesi.Remove(silinecek);
            }
            return RedirectToAction("OgrenciListe");
        }


    }
}
