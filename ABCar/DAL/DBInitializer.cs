using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ABCar.DAL.Repositories;
using ABCar.Models.EntityModels;
using ABCar.Models.EntityModels.Korisnici;
using ABCar.Models.EntityModels.Vozila;
using ABCar.Models.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ABCar.DAL
{
    public static class DBInitializer
    {
        internal static MojDBContext GetDBInstance()=>new HttpContextAccessor().HttpContext.RequestServices.GetRequiredService<MojDBContext>();
        //{
        //    var httpConAccessor=new HttpContextAccessor();
        //    var httpContext = httpConAccessor.HttpContext;
        //    var db = httpContext.RequestServices.GetRequiredService<MojDBContext>();
        //    return db;
        //}

        public static void Seed(MojDBContext db)
        {
            if (!db.MarkaVozila.Any())
            {
                // vrsta karoserije
                db.TipVozila.AddRange(new List<TipVozila>
                {
                    new TipVozila{Naziv = "Limuzina"},
                    new TipVozila{Naziv = "Limuzina"},
                    new TipVozila{Naziv = "Malo auto"},
                    new TipVozila{Naziv = "Karavan"},
                    new TipVozila{Naziv = "Monovolumen"},
                    new TipVozila{Naziv = "Kombi"},
                    new TipVozila{Naziv = "Terenac"},
                    new TipVozila{Naziv = "Kabriolet"},
                    new TipVozila{Naziv = "Sportski"},
                    new TipVozila{Naziv = "Off-road"},
                    new TipVozila{Naziv = "Caddy"},
                    new TipVozila{Naziv = "Oldtimer"}
                });


                // broj brzina
                db.BrojBrzina.AddRange(new List<BrojBrzina>
                {
                    new BrojBrzina{Naziv = "3+R"},
                    new BrojBrzina{Naziv = "4+R"},
                    new BrojBrzina{Naziv = "5+R"},
                    new BrojBrzina{Naziv = "6+R"},
                    new BrojBrzina{Naziv = "7+R"},
                    new BrojBrzina{Naziv = "8+R"},
                    new BrojBrzina{Naziv = "9+R"}
                });


                // vrsta svjetla
                db.VrstaSvjetla.AddRange(new List<VrstaSvjetla>
                {
                    new VrstaSvjetla{Naziv = "Halogena"},
                    new VrstaSvjetla{Naziv = "Xenon"},
                    new VrstaSvjetla{Naziv = "LED"}
                });

                // marka vozila
                db.MarkaVozila.AddRange(new List<MarkaVozila>
                {
                    new MarkaVozila{Id = 0, Naziv = "Alfa Romeo", LogoImagePath = null},
                    new MarkaVozila{Id = 1, Naziv = "Aston Martin", LogoImagePath = null},
                    new MarkaVozila{Id = 2, Naziv = "Audi", LogoImagePath = "/images/MarkeAutomobilaLogo/Audi.jpg"},
                    new MarkaVozila{Id = 3, Naziv = "Škoda", LogoImagePath = "/images/MarkeAutomobilaLogo/Skoda.jpg"},
                    new MarkaVozila{Id = 4, Naziv = "Bentley", LogoImagePath = "/images/MarkeAutomobilaLogo/Bentley.jpg"},
                    new MarkaVozila{Id = 5, Naziv = "BMW", LogoImagePath = "/images/MarkeAutomobilaLogo/BMW.jpg"},
                    new MarkaVozila{Id = 6, Naziv = "Chevrolet", LogoImagePath = null},
                    new MarkaVozila{Id = 7, Naziv = "Dacia", LogoImagePath = null},
                    new MarkaVozila{Id = 8, Naziv = "Fiat", LogoImagePath = "/images/MarkeAutomobilaLogo/Fiat.jpg"},
                    new MarkaVozila{Id = 9, Naziv = "Ferrari", LogoImagePath = null},
                    new MarkaVozila{Id = 10, Naziv = "Ford", LogoImagePath = "/images/MarkeAutomobilaLogo/Ford.jpg"},
                    new MarkaVozila{Id = 11, Naziv = "Honda", LogoImagePath = null},
                    new MarkaVozila{Id =12, Naziv = "Hummer", LogoImagePath = null},
                    new MarkaVozila{Id =13, Naziv = "Hyundai", LogoImagePath = null},
                    new MarkaVozila{Id =14, Naziv = "Lada", LogoImagePath = null},
                    new MarkaVozila{Id = 15, Naziv = "Lancia", LogoImagePath = null},
                    new MarkaVozila{Id = 16, Naziv = "Land Rover", LogoImagePath = "/images/MarkeAutomobilaLogo/LandRover.jpg"},
                    new MarkaVozila{Id = 17, Naziv = "Mercedes-Benz", LogoImagePath = "/images/MarkeAutomobilaLogo/Mercedes-Benz.jpg"},
                    new MarkaVozila{Id = 18, Naziv = "Peugeot", LogoImagePath = "/images/MarkeAutomobilaLogo/Peugeot.jpg"},
                    new MarkaVozila{Id = 19, Naziv = "Opel", LogoImagePath = "/images/MarkeAutomobilaLogo/Opel.jpg"},
                    new MarkaVozila{Id = 20, Naziv = "Porsche", LogoImagePath = "/images/MarkeAutomobilaLogo/Porsche.jpg"},
                    new MarkaVozila{Id = 21, Naziv = "Renault", LogoImagePath = "/images/MarkeAutomobilaLogo/Renault.jpg"},
                    new MarkaVozila{Id = 22, Naziv = "Seat", LogoImagePath = null},
                    new MarkaVozila{Id = 23, Naziv = "Tesla", LogoImagePath = "/images/MarkeAutomobilaLogo/Tesla.jpg"},
                    new MarkaVozila{Id = 24, Naziv = "Toyota", LogoImagePath = "/images/MarkeAutomobilaLogo/Toyota.jpg"},
                    new MarkaVozila{Id = 25, Naziv = "Volkswagen", LogoImagePath = "/images/MarkeAutomobilaLogo/Volkswagen.jpg"},
                    new MarkaVozila{Id = 26, Naziv = "Volvo", LogoImagePath = "/images/MarkeAutomobilaLogo/Volvo.jpg"}
                });

                    db.SaveChanges();

                // model vozila
                db.ModelVozila.AddRange(new List<ModelVozila>
                {
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 145"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 146"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 147"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 149"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 155"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 156"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfa 159"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Alfetta"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Giuilia"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 0, Naziv = "Giulietta"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "DB 7"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "DB 9"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "DBS"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "V 8"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "Vantage"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "Virage"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 1, Naziv = "Volante"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "TT"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "TT RS"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "TTS"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "100"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "200"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "80"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "90"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A1"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A2"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A3"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A4"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A5"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A6"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A7"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "A8"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "Q2"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "Q3"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "Q5"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "Q7"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "Q8"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "R8"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 2, Naziv = "V8"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Citigo"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Fabia"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Favorit"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Felicia"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Kodiaq"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Octavia"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Rapid"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Superb"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 3, Naziv = "Yeti"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Continental"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Azure"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Arnage"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Eight"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Turbo R"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 4, Naziv = "Turbo RT"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "M1"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "M3"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "M5"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "M6"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X1"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X2"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X3"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X4"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X5"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X6"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "X5 M"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "730"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "725"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 5, Naziv = "630"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Alero"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Astro"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Beretta"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Blazer"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Camaro"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Cavalier"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Epica"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Tacuma"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 6, Naziv = "Volt"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Dokker"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Duster"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Lodgy"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Logan"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Pick up"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 7, Naziv = "Sandero"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 8, Naziv = "Brava"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 8, Naziv = "Bravo"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 8, Naziv = "Dino"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 8, Naziv = "Panda"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 8, Naziv = "Punto"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "321"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "478"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "799"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "112"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "422"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "f8"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 9, Naziv = "568"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 10, Naziv = "Escape"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 10, Naziv = "Escort"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 10, Naziv = "Fiesta"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 10, Naziv = "Focus"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 10, Naziv = "Kuga"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "CR-V"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "CR-Z"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "Insight"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "Integra"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "Shuttle"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 11, Naziv = "Stream"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 12, Naziv = "H1"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 12, Naziv = "H2"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 12, Naziv = "H3"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 13, Naziv = "i10"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 13, Naziv = "i20"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 13, Naziv = "i30"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 13, Naziv = "i40"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 14, Naziv = "Kalina"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 14, Naziv = "Samara"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 14, Naziv = "Niva"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 14, Naziv = "Nova"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 15, Naziv = "Beta"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 15, Naziv = "Dedra"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 15, Naziv = "Delta"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 15, Naziv = "Flavia"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 16, Naziv = "Defender"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 16, Naziv = "Discovery"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 16, Naziv = "Range Rover"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc22"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc24"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc25"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc26"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc27"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc28"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 17, Naziv = "Merc29"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 18, Naziv = "Ascona"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 18, Naziv = "Astra"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 18, Naziv = "Corsa"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "203"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "204"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "205"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "304"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "306"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "307"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 19, Naziv = "407"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 20, Naziv = "Carrera"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 20, Naziv = "Cayenne"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 20, Naziv = "Cayman"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 20, Naziv = "Panamera"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 21, Naziv = "Clio"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 21, Naziv = "Coupe"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 21, Naziv = "Laguna"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 21, Naziv = "Megane"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 22, Naziv = "Alhambra"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 22, Naziv = "Ibiza"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 22, Naziv = "Cordoba"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 22, Naziv = "Leon"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 23, Naziv = "Model S"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 23, Naziv = "Model X"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 24, Naziv = "Avalon"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 24, Naziv = "Carina"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 24, Naziv = "Tundra"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 24, Naziv = "Versa"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf I"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf II"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf III"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf IV"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf V"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf VI"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Golf VII"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Passat 5"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Passat 5+"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Passat CC"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Bora"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Tiguan"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Tuareg"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 25, Naziv = "Turan"},

                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 26, Naziv = "V40"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 26, Naziv = "V50"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 26, Naziv = "V60"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 26, Naziv = "V70"},
                    new ModelVozila {Duzina_m = (float) 3.5, Tezina_t = (float) 4.3, MarkaId = 26, Naziv = "V90"}

                });

                db.SaveChanges();


                // emisioni standard
                db.EmisioniStandard.AddRange(new List<EmisioniStandard>
                {
                    new EmisioniStandard {Naziv = "Euro 0"},
                    new EmisioniStandard {Naziv = "Euro 1"},
                    new EmisioniStandard {Naziv = "Euro 2"},
                    new EmisioniStandard {Naziv = "Euro 3"},
                    new EmisioniStandard {Naziv = "Euro 4"},
                    new EmisioniStandard {Naziv = "Euro 5"},
                    new EmisioniStandard {Naziv = "Euro 6"}
                });


                // vrsta mjenjaca
                db.VrstaMjenjaca.AddRange(new List<VrstaMjenjaca>
                {
                    new VrstaMjenjaca {Naziv = "Automatik"},
                    new VrstaMjenjaca {Naziv = "Polu-automatik"},
                    new VrstaMjenjaca {Naziv = "Manuelni"}
                });


                // vrsta motora
                db.VrstaMotora.AddRange(new List<VrstaMotora>
                {
                    new VrstaMotora {Naziv = "Dizel"},
                    new VrstaMotora {Naziv = "Benzin"},
                    new VrstaMotora {Naziv = "Plin"},
                    new VrstaMotora {Naziv = "Hibrid"},
                    new VrstaMotora {Naziv = "Elektro"}
                });

                // broj vrata
                db.BrojVrata.AddRange(new List<BrojVrata>
                {
                    new BrojVrata {Naziv = "2+1"},
                    new BrojVrata {Naziv = "4+1"}
                });


                // boja
                db.Boja.AddRange(new List<Boja>
                {
                    new Boja {Naziv = "Bež"},
                    new Boja {Naziv = "Bijela"},
                    new Boja {Naziv = "Bordo"},
                    new Boja {Naziv = "Crna"},
                    new Boja {Naziv = "Crvena"},
                    new Boja {Naziv = "Ljubičasta"},
                    new Boja {Naziv = "Narandžasta"},
                    new Boja {Naziv = "Plava"},
                    new Boja {Naziv = "Siva"},
                    new Boja {Naziv = "Smeđa"},
                    new Boja {Naziv = "Srebrena"},
                    new Boja {Naziv = "Zelena"},
                    new Boja {Naziv = "Zlatna"},
                    new Boja {Naziv = "Žuta"}
                });


                // vrsta pogona
                db.VrstaPogona.AddRange(new List<VrstaPogona>
                {
                    new VrstaPogona {Naziv = "Prednji"},
                    new VrstaPogona {Naziv = "Zadnji"},
                    new VrstaPogona {Naziv = "4x4"}
                });

                //db.Administrator.Add(new Administrator
                //{
                //    Email = "admin@gmail.com",
                //    Ime="Administrator",
                //    Prezime = "Administrator",
                //    KorisnickiRacun = new KorisnickiRacun
                //    {
                //        DatumRegistracije = DateTime.Today,
                //        KorisnickoIme = "admin",
                //        Lozinka = "o//CFXcGbjX+mGRsjxvLFLZx2exKOvIaV5qyaKeVz8s=",
                //        Salt= Encoding.ASCII.GetBytes("0x19130790AC098398DDD6D058BF6FE490"),
                //        TipKorisnika = TipKorisnika.Administrator
                //    }
                //});



                db.SaveChanges();

                //var path = Directory.GetCurrentDirectory() + "\\DAL\\DATA\\InsertScript.sql";
                ////path = Directory.GetParent(path).FullName + "\\DAL\\DATA\\InsertScript.sql";

                //var script = File.ReadAllText(path);

                //db.Database.ExecuteSqlCommand(script);
                //db.SaveChanges();

            }
        }

        
    }
}
