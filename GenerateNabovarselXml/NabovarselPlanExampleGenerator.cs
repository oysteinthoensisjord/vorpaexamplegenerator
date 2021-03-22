using System;
using System.Collections.Generic;
using no.kxml.skjema.dibk.nabovarselPlan;

namespace GenerateNabovarselXml
{
    public class NabovarselPlanExampleGenerator
    {
        public NabovarselPlanType NyttNabovarsel(int numberOfGeneratedNeighbours)
        {
            var nabovarselPlan = new NabovarselPlanType();

            //            Encryption.Encryption encrypt = new Encryption.Encryption();

            var neigbours = new List<BeroertPartType>();

            //Split number of neighbors
            var foretak = numberOfGeneratedNeighbours * 0.0;
            var personer = numberOfGeneratedNeighbours - foretak;

            var berortePersoner = DummyBerortPartPersonGenerator.GenerateBeroerteParter((int)personer);
            var berorteForetak = BerortPartOrganisasjonGenerator.GenerateBeroerteParter((int)foretak);

            neigbours.AddRange(berorteForetak);
            neigbours.AddRange(berortePersoner);


            nabovarselPlan.kommunenavn = "Ringerike";
            nabovarselPlan.metadata = new MetadataType
            {
                fraSluttbrukersystem = "Fellestjenester bygg og plan testmotor"
            };

            nabovarselPlan.forslagsstiller = new PartType()
            {
                partstype = new KodeType
                {
                    kodeverdi = "Foretak",
                    kodebeskrivelse = "Foretak"
                },
                organisasjonsnummer = "910467905",
                navn = "BRYGGJA OG RANHEIM AS",
                adresse = new EnkelAdresseType()
                {
                    adresselinje1 = "Sentrum",
                    poststed = "Hønefoss",
                    postnr = "3502"
                },
                telefon = "98839131",
                epost = "norah@bye.no",
                kontaktperson = new KontaktpersonType()
                {
                    navn = "Kari Nordmann",
                    telefonnummer = "98839131",
                    mobilnummer = "98839131",
                    epost = "tine@arkitektum.no"
                }
            };

            nabovarselPlan.eiendomByggested = new[]
            {
                new EiendomType()
                {
                    adresse = new EiendommensAdresseType
                    {
                        adresselinje1 = "Gata 19",
                        landkode = "NO",
                        postnr = "3502",
                        poststed = "Hønefoss"
                    },
                    eiendomsidentifikasjon = new MatrikkelnummerType
                    {
                        gaardsnummer = "318",
                        bruksnummer = "97",
                        festenummer = "0",
                        seksjonsnummer = "0",
                        kommunenummer = "3007"
                    },
                    kommunenavn = "Ringerike"
                }
            };

            nabovarselPlan.gjeldendePlan = new[]
            {
                new GjeldendePlanType()
                {
                    navn = "Reguleringsplan for Hønefoss",
                    plantype = new KodeType()
                    {
                        kodeverdi = "RP",
                        kodebeskrivelse = "Reguleringsplan"
                    }
                }
            };

            nabovarselPlan.beroerteParter = neigbours.ToArray();
        

        nabovarselPlan.planforslag = new PlanType()
        {
            plannavn = $"VORPA-generator {DateTime.Now}",
                hjemmesidePlanforslag = new[]
                {
                    "www.kommunensHjemmeside.no",
                    "www.planforslag.no"
                },
                arealplanId = "464",
                kravKonsekvensUtredning = false,
                kravKonsekvensUtredningSpecified = true,
                begrunnelseKU = "Begrunnelse for hvorfor det ikke er krav om konsekvensutredning.",
                hjemmesidePlanprogram = "www.planprogram.no",
                planHensikt =
                    "I tråd med områdereguleringsplanens målsettinger om å skape et levende og attraktivt " +
                    "bysentrum i Hønefoss, ønskes området detaljregulert for å legge til rette for et " +
                    "bærekraftig og realistisk byutviklingsprosjekt.  Aktuelle funksjoner er utvidelse av hotell/konferansesenter, serveringsteder, " +
                    "handel og boliger. Eksisterende kulturmiljø vil være et viktig tema i planarbeidet. " +
                    "Det er ikke krav om planprogram eller konsekvensutredning i tilknytning til planforslaget.",
                fristForInnspill = new DateTime(2020, 08, 01),
                fristForInnspillSpecified = true,
                saksgangOgMedvirkning = "Saksgang og medvirkning....",
                
                plantype = new KodeType
                {
                    kodeverdi = "35",
                    kodebeskrivelse = "Detaljregulering"
                },
                kommunensSaksnummer = new SaksnummerType()
                {
                    saksaar = "2020",
                    sakssekvensnummer = "11111"
                }
                };

        nabovarselPlan.signatur = new SignaturType
            {
                signaturdato = new DateTime(2019, 09, 18),
                signaturdatoSpecified = true,
                signertAv = "",
                signertPaaVegneAv = "",
            };

            return nabovarselPlan;
        }
    }
}