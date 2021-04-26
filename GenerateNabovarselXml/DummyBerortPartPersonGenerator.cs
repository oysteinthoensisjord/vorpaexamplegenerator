using Newtonsoft.Json;
using no.kxml.skjema.dibk.nabovarselPlan;
using System;
using System.Collections.Generic;

namespace GenerateNabovarselXml
{
    public class DummyBerortPartPersonGenerator
    {

        private static List<string> _usedFnrs;
        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            _usedFnrs = new List<string>();

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

                var personEncryptedFnr = personer[personIndex].EncryptedSsn;
                var personNavn = personer[personIndex + navnOffset].Name;
                var adresse = personer[personIndex + navnOffset].Address;
                _usedFnrs.Add(personer[personIndex].Ssn);

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Privatperson",
                        kodeverdi = "Privatperson"
                    },
                    navn = personNavn,
                    foedselsnummer = personEncryptedFnr,

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

            LogUsedFnr();
            return retVal;
        }

        private static void LogUsedFnr()
        {
            var fileContent = JsonConvert.SerializeObject(_usedFnrs);
            var filename = $@"c:\temp\{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}-used-fnrs.json";
            Console.WriteLine($"    -- Used fnrs stored to {filename}");

            System.IO.File.WriteAllText(filename, fileContent);
        }

        private static List<Person> GetFnr()
        {
            var result = System.IO.File.ReadAllText("encryptedfnr.json");
            return JsonConvert.DeserializeObject<List<Person>>(result);
        }
    }
}

