using System.Collections.Generic;
using ABCar.Models.ViewModels;

namespace ABCar.Models.ViewModels
{
    public class PonudaVM : List<VoziloZaPonudu>
    {
        public List<VoziloZaPonudu> ListaVozila { get; set; }
        public bool PrikazanaSvaVozila { get; set; }
    }
}