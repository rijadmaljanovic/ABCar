using System;
using System.Collections.Generic;
using System.Text;
using ABCar.Business.Helpers;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.Shared;
using ABCar.Models.ViewModels;

namespace ABCar.Business
{
    public class NabavkaOperations
    {
        private readonly NabavkaRepository nabavkaRepository;
        private readonly VoziloOperations voziloOperations;
        private readonly SlikeOperations slikeOperations;

        public NabavkaOperations()
        {
            nabavkaRepository = new NabavkaRepository();
            voziloOperations = new VoziloOperations();
            slikeOperations=new SlikeOperations();
        }


        public void AddNabavka(UrediVoziloVM model,int zaposlenikId)
        {
            var vozilo = model.Vozilo;
            voziloOperations.Add(vozilo);

            slikeOperations.AddSlike(model.PhotosFormFiles,vozilo.Id);

            nabavkaRepository.Add(new Nabavka
            {
                VoziloId = vozilo.Id,
                Cijena = model.NabavnaCijena??0,
                DatumNabavke = DateTime.Today,
                ZaposlenikId = zaposlenikId
            });

        }


        public void UrediNabavku(UrediVoziloVM model)
        {
            var vozilo = model.Vozilo;
            voziloOperations.Update(vozilo);

            var nabavka = nabavkaRepository.GetNabavkaByVoziloId(vozilo.Id);
            nabavka.Cijena = model.NabavnaCijena ?? 0;
            nabavkaRepository.Update(nabavka);

        }
    }
}
