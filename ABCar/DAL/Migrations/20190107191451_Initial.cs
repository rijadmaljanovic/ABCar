using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrojBrzina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojBrzina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrojVrata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojVrata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmisioniStandard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmisioniStandard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiRacun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    TipKorisnika = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiRacun", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarkaVozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LogoImagePath = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaVozila", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipVozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipVozila", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaMjenjaca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaMjenjaca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaMotora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaMotora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPogona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPogona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaSvjetla",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaSvjetla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    KorisnickiRacunId = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    KorisnickiRacunId = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupac_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerifikacijskiToken",
                columns: table => new
                {
                    GUID = table.Column<string>(nullable: false),
                    DatumLogiranja = table.Column<DateTime>(nullable: false),
                    KorisnickiRacunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerifikacijskiToken", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_VerifikacijskiToken_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    KorisnickiRacunId = table.Column<int>(nullable: false),
                    Prezime = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_KorisnickiRacun_KorisnickiRacunId",
                        column: x => x.KorisnickiRacunId,
                        principalTable: "KorisnickiRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelVozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duzina_m = table.Column<float>(nullable: false),
                    MarkaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Tezina_t = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVozila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelVozila_MarkaVozila_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "MarkaVozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ABS = table.Column<bool>(nullable: false),
                    AUX = table.Column<bool>(nullable: false),
                    Akcija = table.Column<float>(nullable: true),
                    Alarm = table.Column<bool>(nullable: false),
                    AluFelge = table.Column<bool>(nullable: false),
                    AutoKuka = table.Column<bool>(nullable: false),
                    AutomatskaKlima = table.Column<bool>(nullable: false),
                    Bluetooth = table.Column<bool>(nullable: false),
                    BojaId = table.Column<int>(nullable: false),
                    BrojBrzinaId = table.Column<int>(nullable: false),
                    BrojPrethodnihVlasnika = table.Column<int>(nullable: true),
                    BrojSjedecihMjesta = table.Column<int>(nullable: false),
                    BrojVrataId = table.Column<int>(nullable: false),
                    CD = table.Column<bool>(nullable: false),
                    CentralnoKljucanje = table.Column<bool>(nullable: false),
                    Cijena = table.Column<float>(nullable: false),
                    DaljinskoKljucanje = table.Column<bool>(nullable: false),
                    DvozonskaKlima = table.Column<bool>(nullable: false),
                    ESP = table.Column<bool>(nullable: false),
                    ElPodesavanjeRetrovizora = table.Column<bool>(nullable: false),
                    ElPodesavanjeSjedista = table.Column<bool>(nullable: false),
                    ElPodizaciProzora = table.Column<bool>(nullable: false),
                    ElZastitaProtivKradje = table.Column<bool>(nullable: false),
                    EmisioniStandardId = table.Column<int>(nullable: false),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    KoznaSjedista = table.Column<bool>(nullable: false),
                    Kubikaza = table.Column<float>(nullable: false),
                    Maglenke = table.Column<bool>(nullable: false),
                    Mat = table.Column<bool>(nullable: false),
                    MehanickaZastitaProtivKradje = table.Column<bool>(nullable: false),
                    Metalik = table.Column<bool>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    NaslonjacZaRuku = table.Column<bool>(nullable: false),
                    Navigacija = table.Column<bool>(nullable: false),
                    Novo = table.Column<bool>(nullable: false),
                    ObicnaKlima = table.Column<bool>(nullable: false),
                    PanoramaKrov = table.Column<bool>(nullable: false),
                    ParkingAsistent = table.Column<bool>(nullable: false),
                    ParkingSenzor = table.Column<bool>(nullable: false),
                    PotrosnjaPo100km = table.Column<float>(nullable: true),
                    PredjeniKilometri = table.Column<float>(nullable: true),
                    Prodano = table.Column<bool>(nullable: false),
                    PutnoRacunalo = table.Column<bool>(nullable: false),
                    RegistrovanDo = table.Column<DateTime>(nullable: true),
                    Siber = table.Column<bool>(nullable: false),
                    SifraVozila = table.Column<int>(nullable: false),
                    SmartStopSistem = table.Column<bool>(nullable: false),
                    SnagaMotoraKS = table.Column<int>(nullable: false),
                    SnagaMotoraKW = table.Column<float>(nullable: false),
                    Tempomat = table.Column<bool>(nullable: false),
                    TipVozilaId = table.Column<int>(nullable: false),
                    TipkeNaVolanu = table.Column<bool>(nullable: false),
                    USB = table.Column<bool>(nullable: false),
                    VelicinaFelgi = table.Column<float>(nullable: false),
                    VrstaMjenjacaId = table.Column<int>(nullable: false),
                    VrstaMotoraId = table.Column<int>(nullable: false),
                    VrstaPogonaId = table.Column<int>(nullable: false),
                    VrstaSvjetlaId = table.Column<int>(nullable: false),
                    ZatamnjenaStakla = table.Column<bool>(nullable: false),
                    ZracniJastukBocni = table.Column<bool>(nullable: false),
                    ZracniJastukPrednji = table.Column<bool>(nullable: false),
                    brojacZaSlike = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vozilo_Boja_BojaId",
                        column: x => x.BojaId,
                        principalTable: "Boja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_BrojBrzina_BrojBrzinaId",
                        column: x => x.BrojBrzinaId,
                        principalTable: "BrojBrzina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_BrojVrata_BrojVrataId",
                        column: x => x.BrojVrataId,
                        principalTable: "BrojVrata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_EmisioniStandard_EmisioniStandardId",
                        column: x => x.EmisioniStandardId,
                        principalTable: "EmisioniStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_ModelVozila_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelVozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_TipVozila_TipVozilaId",
                        column: x => x.TipVozilaId,
                        principalTable: "TipVozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_VrstaMjenjaca_VrstaMjenjacaId",
                        column: x => x.VrstaMjenjacaId,
                        principalTable: "VrstaMjenjaca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_VrstaMotora_VrstaMotoraId",
                        column: x => x.VrstaMotoraId,
                        principalTable: "VrstaMotora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_VrstaPogona_VrstaPogonaId",
                        column: x => x.VrstaPogonaId,
                        principalTable: "VrstaPogona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vozilo_VrstaSvjetla_VrstaSvjetlaId",
                        column: x => x.VrstaSvjetlaId,
                        principalTable: "VrstaSvjetla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nabavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    DatumNabavke = table.Column<DateTime>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nabavka_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nabavka_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodaja_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prodaja_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlikeVozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(nullable: true),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlikeVozila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlikeVozila_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoziloFavorit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KupacId = table.Column<int>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoziloFavorit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoziloFavorit_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoziloFavorit_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Vidjeno = table.Column<bool>(nullable: false),
                    VoziloFavoritId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifikacija_VoziloFavorit_VoziloFavoritId",
                        column: x => x.VoziloFavoritId,
                        principalTable: "VoziloFavorit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_KorisnickiRacunId",
                table: "Administrator",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickiRacunId",
                table: "Kupac",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVozila_MarkaId",
                table: "ModelVozila",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_VoziloId",
                table: "Nabavka",
                column: "VoziloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_ZaposlenikId",
                table: "Nabavka",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacija_VoziloFavoritId",
                table: "Notifikacija",
                column: "VoziloFavoritId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodaja_VoziloId",
                table: "Prodaja",
                column: "VoziloId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodaja_ZaposlenikId",
                table: "Prodaja",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_SlikeVozila_VoziloId",
                table: "SlikeVozila",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_VerifikacijskiToken_KorisnickiRacunId",
                table: "VerifikacijskiToken",
                column: "KorisnickiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_BojaId",
                table: "Vozilo",
                column: "BojaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_BrojBrzinaId",
                table: "Vozilo",
                column: "BrojBrzinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_BrojVrataId",
                table: "Vozilo",
                column: "BrojVrataId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_EmisioniStandardId",
                table: "Vozilo",
                column: "EmisioniStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_ModelId",
                table: "Vozilo",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_TipVozilaId",
                table: "Vozilo",
                column: "TipVozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VrstaMjenjacaId",
                table: "Vozilo",
                column: "VrstaMjenjacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VrstaMotoraId",
                table: "Vozilo",
                column: "VrstaMotoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VrstaPogonaId",
                table: "Vozilo",
                column: "VrstaPogonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VrstaSvjetlaId",
                table: "Vozilo",
                column: "VrstaSvjetlaId");

            migrationBuilder.CreateIndex(
                name: "IX_VoziloFavorit_KupacId",
                table: "VoziloFavorit",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_VoziloFavorit_VoziloId",
                table: "VoziloFavorit",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_KorisnickiRacunId",
                table: "Zaposlenik",
                column: "KorisnickiRacunId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Nabavka");

            migrationBuilder.DropTable(
                name: "Notifikacija");

            migrationBuilder.DropTable(
                name: "Prodaja");

            migrationBuilder.DropTable(
                name: "SlikeVozila");

            migrationBuilder.DropTable(
                name: "VerifikacijskiToken");

            migrationBuilder.DropTable(
                name: "VoziloFavorit");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "KorisnickiRacun");

            migrationBuilder.DropTable(
                name: "Boja");

            migrationBuilder.DropTable(
                name: "BrojBrzina");

            migrationBuilder.DropTable(
                name: "BrojVrata");

            migrationBuilder.DropTable(
                name: "EmisioniStandard");

            migrationBuilder.DropTable(
                name: "ModelVozila");

            migrationBuilder.DropTable(
                name: "TipVozila");

            migrationBuilder.DropTable(
                name: "VrstaMjenjaca");

            migrationBuilder.DropTable(
                name: "VrstaMotora");

            migrationBuilder.DropTable(
                name: "VrstaPogona");

            migrationBuilder.DropTable(
                name: "VrstaSvjetla");

            migrationBuilder.DropTable(
                name: "MarkaVozila");
        }
    }
}
