using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels.Vozila;
using Microsoft.AspNetCore.Http;

namespace ABCar.Business
{
    public class SlikeOperations
    {
        private readonly SlikeRepository slikeRepository;
        private readonly VoziloRepository voziloRepository;

        public SlikeOperations()
        {
            slikeRepository = new SlikeRepository();
            voziloRepository = new VoziloRepository();
        }

        public void AddSlike(List<IFormFile> photoFiles, int voziloId)
        {
            if (photoFiles == null)
                return;

            var vozilo = voziloRepository.GetVoziloMarkaModelById(voziloId);

            for (int i = 0; i < photoFiles.Count(); i++)
            {
                var brojac = voziloRepository.GetBrojacZaSlikeAndIncrementIt(voziloId).ToString();

                SlikeHelpers.UploadPhotoToRoot(vozilo,brojac,photoFiles[i]);

                slikeRepository.Add(new SlikaVozila
                {
                    ImgPath = "/images/Automobili/" + vozilo.Model.Marka.Naziv + "/" + vozilo.Model.Naziv + "/" + vozilo.Id + brojac + "." + photoFiles[i].FileName.Split(".")[1],
                    VoziloId = voziloId
                });
            }

        }

        public List<SlikaVozila> GetSlikeByVoziloId(int voziloId)
        {
            return slikeRepository.GetSlikeByVoziloId(voziloId);
        }

        public void RemoveSlika(int slikaId, int voziloId)
        {
            var vozilo = voziloRepository.GetVoziloMarkaModelById(voziloId);
            var slika = slikeRepository.GetSlikaById(slikaId);

            SlikeHelpers.DeletePhotoFromRoot(slika);

            slikeRepository.Remove(slika);

        }

        public void IzbrisiSveSlike(int voziloId)
        {
            var slike = slikeRepository.GetSlikeByVoziloId(voziloId);

            foreach (var item in slike)
                SlikeHelpers.DeletePhotoFromRoot(item);

            slikeRepository.IzbrisiSveSlike(voziloId);



        }
    }
}
