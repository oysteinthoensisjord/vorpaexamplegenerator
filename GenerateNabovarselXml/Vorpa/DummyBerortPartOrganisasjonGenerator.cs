using Newtonsoft.Json;
using no.kxml.skjema.dibk.nabovarselPlan;
using System;
using System.Collections.Generic;

namespace GenerateNabovarselXml.Vorpa
{
    public class DummyBerortPartOrganisasjonGenerator
    {

        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            var retVal = new List<BeroertPartType>();
            var orgs = GetNumbers();

            for (int i = 0; i < numberOf; i++)
            {
                var random = new Random();
                var orgnr = orgs[random.Next(0, orgs.Count)];

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Foretak",
                        kodeverdi = "Foretak"
                    },
                    navn = $"Superforetak {i}",
                    organisasjonsnummer = orgnr,
                    kontaktperson = new KontaktpersonType() { navn = $"Kontaktperson Navn {i}", epost = "kontakt@person.test" },

                    adresse = new EnkelAdresseType()
                    {
                        adresselinje1 = $"Foretaksgata {i}",
                        postnr = "3502",
                        poststed = "Hønefoss",
                        landkode = "no"
                    },
                    telefon = "12312399",
                    epost = "test@test.test",
                    systemReferanse = $"ref-{i}",
                    gjelderEiendom = new[]
                    {
                        new GjelderEiendomType()
                        {
                            eiendomsidentifikasjon = new MatrikkelnummerType()
                            {
                                kommunenummer = "5001",
                                gaardsnummer = $"11{i}",
                                bruksnummer = $"1{i}",
                                festenummer = "0",
                                seksjonsnummer = "0"

                            },
                            adresse = new EiendommensAdresseType()
                            {
                                adresselinje1 = $"Foretaksgata {i}",
                                postnr = "3502",
                                poststed = "Hønefoss"
                            }
                        }
                    }
                };
                retVal.Add(neigbour);
            }

            return retVal;
        }

        private static List<string> GetNumbers()
        {
            var result = System.IO.File.ReadAllText("genererte_fnr.json");
            return JsonConvert.DeserializeObject<List<string>>(result);
        }
    }


}

