using Newtonsoft.Json;
using no.kxml.skjema.dibk.nabovarselPlan;
using System;
using System.Collections.Generic;

namespace GenerateNabovarselXml
{
    public class DummyBerortPartPersonGenerator
    {

        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            var retVal = new List<BeroertPartType>();
            var persons = GetFnr();
            
            for (int i = 0; i < numberOf; i++)
            {
                var random = new Random();
                var encryptedFnr = persons[random.Next(0, persons.Count)];

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Privatperson",
                        kodeverdi = "Privatperson"
                    },
                    navn = encryptedFnr.Name,
                    foedselsnummer = encryptedFnr.EncryptedSsn,

                    adresse = new EnkelAdresseType()
                    {
                        adresselinje1 = encryptedFnr.Address,
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

