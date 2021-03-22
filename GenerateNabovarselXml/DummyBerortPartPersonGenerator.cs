using Newtonsoft.Json;
using no.kxml.skjema.dibk.nabovarselPlan;
using System.Collections.Generic;

namespace GenerateNabovarselXml
{
    public class DummyBerortPartPersonGenerator
    {

        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            var retVal = new List<BeroertPartType>();
            var personer = GetFnr();
            var navnOffset = 0;
            var personIndex = 0;

            var loopCount = 1;

            for (int i = 0; i < numberOf; i++)
            {
                if (i > personer.Count * loopCount - 1 - navnOffset)
                {
                    personIndex = 0;
                    navnOffset++;
                    loopCount++;
                }

                var personFnr = personer[personIndex].Ssn;
                var personNavn = personer[personIndex + navnOffset].Name;
                var adresse = personer[personIndex + navnOffset].Address;

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Privatperson",
                        kodeverdi = "Privatperson"
                    },
                    navn = personNavn,
                    foedselsnummer = personFnr,

                    adresse = new EnkelAdresseType()
                    {
                        adresselinje1 = adresse,
                        postnr = "3502",
                        poststed = "Hønefoss",
                        landkode = "no"
                    },
                    telefon = "12312399",
                    epost = "privat@person.test",
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
                                adresselinje1 = $"Storgata {i}",
                                postnr = "3502",
                                poststed = "Hønefoss"
                            }
                        }
                    }
                };
                retVal.Add(neigbour);
                personIndex++;
            }

            return retVal;
        }

        private static List<Person> GetFnr()
        {
            var result = System.IO.File.ReadAllText("encryptedfnr.json");
            return JsonConvert.DeserializeObject<List<Person>>(result);
        }
    }
}

