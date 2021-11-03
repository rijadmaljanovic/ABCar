using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ABCar.Models.EntityModels.Vozila
{
    public class Vozilo
    {
        public int Id { get; set; }

        public int brojacZaSlike { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public float? Cijena { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name="Godina proizvodnje")]
        public int GodinaProizvodnje { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name = "Broj sjedecih mjesta")]
        public int BrojSjedecihMjesta { get; set; }

        [Display(Name = "Potrosnja na 100km")]
        public float? PotrosnjaPo100km { get; set; }

        [Display(Name = "Registrovano do")]
        [DataType(DataType.Date)]
        public DateTime? RegistrovanDo { get; set; }

        [Display(Name = "Broj prethodnih vlasnika")]
        public int? BrojPrethodnihVlasnika { get; set; }

        [Display(Name = "Predjeni kilometri")]
        public float? PredjeniKilometri { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name = "Sifra vozila")]
        public int? SifraVozila { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name = "Snaga motora (kW)")]
        public float? SnagaMotoraKW { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name = "Snaga motora (hp/KS)")]
        public int? SnagaMotoraKS { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public float? Kubikaza { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        [Display(Name = "Velicina felgi")]
        public float VelicinaFelgi { get; set; }

        public float? Akcija { get; set; }







        // FK properties

        [Required(ErrorMessage = "MODEL AUTOMOBILA OBAVEZNO POLJE!")]
        public int? ModelId { get; set; }
        public ModelVozila Model { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int VrstaMotoraId { get; set; }
        [Display(Name = "Vrsta motora")]
        public VrstaMotora VrstaMotora { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int VrstaMjenjacaId { get; set; }
        [Display(Name = "Vrsta mjenjaca")]
        public VrstaMjenjaca VrstaMjenjaca { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int TipVozilaId { get; set; }
        [Display(Name = "Tip vozila")]
        public TipVozila TipVozila { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int BojaId { get; set; }
        public Boja Boja { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int BrojVrataId { get; set; }
        [Display(Name = "Broj vrata")]
        public BrojVrata BrojVrata { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int VrstaPogonaId { get; set; }
        [Display(Name = "Vrsta pogona")]
        public VrstaPogona VrstaPogona { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int EmisioniStandardId { get; set; }
        [Display(Name = "Emisioni standard")]
        public EmisioniStandard EmisioniStandard { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int VrstaSvjetlaId { get; set; }
        [Display(Name = "Vrsta svjetla")]
        public VrstaSvjetla VrstaSvjetla { get; set; }

        [Required(ErrorMessage = "Obavezno polje!")]
        public int BrojBrzinaId { get; set; }
        [Display(Name = "Broj brzina")]
        public BrojBrzina BrojBrzina { get; set; }






        // boolean properties

        public bool Novo { get; set; }
        public bool Prodano { get; set; }
        [Display(Name = "Obicna klima")]
        public bool ObicnaKlima { get; set; }
        [Display(Name = "Kozna sjedista")]
        public bool KoznaSjedista { get; set; }
        public bool ABS { get; set; }
        public bool Alarm { get; set; }
        [Display(Name = "Centralno kljucanje")]
        public bool CentralnoKljucanje { get; set; }
        [Display(Name = "Daljinsko kljucanje")]
        public bool DaljinskoKljucanje { get; set; }
        [Display(Name = "Zracni jastuk prednji")]
        public bool ZracniJastukPrednji { get; set; }
        [Display(Name = "Zracni jastuk bocni")]
        public bool ZracniJastukBocni { get; set; }
        public bool ESP { get; set; }
        public bool Bluetooth { get; set; }
        [Display(Name = "Naslonjac za ruku")]
        public bool NaslonjacZaRuku { get; set; }
        public bool Maglenke { get; set; }
        public bool Metalik { get; set; }
        public bool Mat { get; set; }
        [Display(Name = "Tipke na volanu")]
        public bool TipkeNaVolanu { get; set; }
        [Display(Name = "Putno racunalo")]
        public bool PutnoRacunalo { get; set; }
        public bool Tempomat { get; set; }
        [Display(Name = "El. podesavanje retrovizora")]
        public bool ElPodesavanjeRetrovizora { get; set; }
        [Display(Name = "Parking senzor")]
        public bool ParkingSenzor { get; set; }
        [Display(Name = "Parking asistent")]
        public bool ParkingAsistent { get; set; }
        [Display(Name = "El. podesavanje sjedista")]
        public bool ElPodesavanjeSjedista { get; set; }
        public bool Navigacija { get; set; }
        [Display(Name = "Automatska klima")]
        public bool AutomatskaKlima { get; set; }
        [Display(Name = "Dvozonska klima")]
        public bool DvozonskaKlima { get; set; }
        [Display(Name = "El. podizaci prozora")]
        public bool ElPodizaciProzora { get; set; }
        [Display(Name = "Alu felge")]
        public bool AluFelge { get; set; }
        public bool USB { get; set; }
        public bool CD { get; set; }
        public bool AUX { get; set; }
        [Display(Name = "Mehanicka zastita protiv kradje")]
        public bool MehanickaZastitaProtivKradje { get; set; }
        [Display(Name = "El. zastita protiv kradje")]
        public bool ElZastitaProtivKradje { get; set; }
        public bool Siber { get; set; }
        [Display(Name = "Zatamnjena stakla")]
        public bool ZatamnjenaStakla { get; set; }
        [Display(Name = "Auto kuka")]
        public bool AutoKuka { get; set; }
        [Display(Name = "Panorama krov")]
        public bool PanoramaKrov { get; set; }
        [Display(Name = "Smart-stop sistem")]
        public bool SmartStopSistem { get; set; }


    }
}
