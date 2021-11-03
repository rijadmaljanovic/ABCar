using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.AspNetCore.Http;

namespace ABCar.Business.Helpers
{
    public static class SlikeHelpers
    {
        public static void UploadPhotoToRoot(Vozilo vozilo,string brojac,IFormFile photoFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Automobili", vozilo.Model.Marka.Naziv, vozilo.Model.Naziv, vozilo.Id.ToString() + brojac + "." + photoFile.FileName.Split(".")[1]);
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Automobili", vozilo.Model.Marka.Naziv, vozilo.Model.Naziv));
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                photoFile.CopyTo(stream);
            }
        }

        public static void DeletePhotoFromRoot(SlikaVozila slika)
        {
            var slikaPath = slika.ImgPath.Split("/");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Automobili", slikaPath[3], slikaPath[4], slikaPath[5]);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}
