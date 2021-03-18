using no.kxml.skjema.dibk.nabovarselPlan;
using System;
using System.Collections.Generic;

namespace GenerateNabovarselXml
{
    public class BerortPartOrganisasjonGenerator
    {

        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            var retVal = new List<BeroertPartType>();
            var personer = GetOrganisasjon();
            
            for (int i = 0; i < numberOf; i++)
            {
                var random = new Random();
                var person = personer[random.Next(0, personer.Count)];

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Foretak",
                        kodeverdi = "Foretak"
                    },
                    navn =  person.Item1,
                    organisasjonsnummer = person.Item2,
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

        private static List<Tuple<string, string>> GetOrganisasjon()
        {
            var retVal = new List<Tuple<string, string>>();
            //Plan
            retVal.Add(new Tuple<string, string>("LØTEN OG BORGEN", "810064412"));
            retVal.Add(new Tuple<string, string>("KRANGLE VELFORENING", "910041126"));
            retVal.Add(new Tuple<string, string>("FANA OG HAFSLO REVISJON", "910297937"));
            retVal.Add(new Tuple<string, string>("VELFORENINGEN FOR ULVER", "910015966"));
            retVal.Add(new Tuple<string, string>("LØTEN OG BORGEN", "810064412"));
            retVal.Add(new Tuple<string, string>("INGØY OG STANGVIK", "911043289"));
            retVal.Add(new Tuple<string, string>("FANA OG HAFSLO REVISJON", "910297937"));

            retVal.Add(new Tuple<string, string>("STATSRIV", "910017233"));
            retVal.Add(new Tuple<string, string>("KARDEMOMME BY", "910016520"));
            retVal.Add(new Tuple<string, string>("INNLANDSVERKET", "910017489"));
            retVal.Add(new Tuple<string, string>("BYGG OG RIVNINGSDIREKTORATET", "910043242"));
            retVal.Add(new Tuple<string, string>("SAUETILSYNET", "910444611"));
            retVal.Add(new Tuple<string, string>("FYLKESMANNEN I MJØSA", "910065645"));

            //Bygg
            retVal.Add(new Tuple<string, string>("BYGGMESTER BOB", "910065149"));
            retVal.Add(new Tuple<string, string>("GRAV OG SPRENG", "910065157"));
            retVal.Add(new Tuple<string, string>("SNEKKERGUTTA", "910065165"));
            retVal.Add(new Tuple<string, string>("ARKITEKT FLINK", "910065203"));
            retVal.Add(new Tuple<string, string>("BYGGFIRMA PER JALLA", "910065211"));
            retVal.Add(new Tuple<string, string>("MURE KOMMUNE", "910065246"));
            retVal.Add(new Tuple<string, string>("SNEKKRE KOMMUNE", "910065254"));
            retVal.Add(new Tuple<string, string>("LIME KOMMUNE", "910065289"));
            retVal.Add(new Tuple<string, string>("KLIPPE KOMMUNE", "910065297"));
            retVal.Add(new Tuple<string, string>("BANKE KOMMUNE", "910065300"));

            return retVal;
        }
    }

    
}

