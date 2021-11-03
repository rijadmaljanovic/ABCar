using System;
using System.Collections.Generic;
using System.Text;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Vozila;

namespace ABCar.Business
{
    public class ProdajaOperations
    {
        public ProdajaRepository prodajaRepository { get; set; }
        public VoziloRepository voziloRepository { get; set; }

        public ProdajaOperations()
        {
            prodajaRepository=new ProdajaRepository();
            voziloRepository=new VoziloRepository();
        }

        public void AddProdaja(int voziloId, float iznos, int zaposlenikId)
        {
            var prodaja = new Prodaja
            {
                Datum = DateTime.Today,
                Iznos = iznos,
                VoziloId = voziloId,
                ZaposlenikId = zaposlenikId
            };

            prodajaRepository.Add(prodaja);

            voziloRepository.SetVoziloProdano(voziloId);
        }
    }
}
