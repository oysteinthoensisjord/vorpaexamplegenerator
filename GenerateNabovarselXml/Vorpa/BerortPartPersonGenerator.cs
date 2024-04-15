using no.kxml.skjema.dibk.nabovarselPlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateNabovarselXml.Vorpa
{
    public class BerortPartPersonGenerator
    {

        public static List<BeroertPartType> GenerateBeroerteParter(int numberOf)
        {
            var retVal = new List<BeroertPartType>();
            var personer = GetPersoner();

            for (int i = 0; i < numberOf; i++)
            {
                var random = new Random();
                var person = personer[random.Next(0, personer.Count)];

                var neigbour = new BeroertPartType()
                {
                    partstype = new KodeType()
                    {
                        kodebeskrivelse = "Privatperson",
                        kodeverdi = "Privatperson"
                    },
                    navn = person.Item1,
                    foedselsnummer = person.Item2,

                    adresse = new EnkelAdresseType()
                    {
                        adresselinje1 = $"Storgata {i}",
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

        private static List<Tuple<string, string>> GetPersoner()
        {
            var retVal = new List<Tuple<string, string>>();
            //Bygg
            retVal.Add(new Tuple<string, string>("Vigdis Vater", "UeO5triYvy3iYeQ24NWZebEiqSakfduMHVPy20BY4uhug18nQ7eKb8qHiJmUN46spi2XXIm09VW3UMk5mFCZB8CQQl8Yn3TdChqXg4VE6kSQF7kXuEgoVBTEBxs9rWI/9h96hBMWC67L458db88B6KTznvxo3ufLM4nKDvQ9ybk="));
            retVal.Add(new Tuple<string, string>("Tom Tømrer", "FWBb7YyyVmtOyozMWG800YYKjQYM9WDIk72JXkzTQdnA5DCOBQP+dGzLfTGUB1JJPvFXNluhw3/qQ1DD8Oy2W3M//LP5IKzlC7M5XQbYpVzBAz6jn0yjHPr4FF3A3r+3IsmpZwGCwhM3j9zYCYAQRx9Qf+VBZvar9AooUhfz370="));
            retVal.Add(new Tuple<string, string>("TORE TANG", "kdn2+NSCH0M69jJIJp3varQen263cvcMNFT3xP6OWM40oCA0Towb7TD/gpZgRCiT1S26BWoH5pNSaf+60nWk6Y2IVsdWoJROjR80GKIjrjp5fygKocJP4nVsUBO6jFUpGWNnhLdRGVCj5/29/oG5NBWN4l6L8B14RMjRxgt6DVM="));
            retVal.Add(new Tuple<string, string>("SINNA SNEKKERN", "zu82CzRCW/MrSfNrE1v2ejk/OZbcnDlJgU+2j+cVlfmLU1hWPGLJRX+sybEmFwjVvhd+Snr6uBpNl9iHJoX4TMOqZeaSALTNpiyiVz6opjJpcf0kySXqT6IdgxFWSSla3lblVJfCT0v0AHnMqeUR6rWikNCjtYeXQA3etxXFqSk="));
            retVal.Add(new Tuple<string, string>("HOPPE TUSSE", "w5OqCA5XhDMWqZeYJSGCuZbC7qGntbP49ZqH9LX6i2FYsxe6/d6rYZyVRYcIB29gw1TKkG1KiK+cqnFuhf7f6WqZz51sfMCPVlf59F69nsuManurUWgZ2xlZcmjQCtxbVtbY9iYd2QGqub7huRwqkfMAq3aG0ySwG1RfWq4GR+g="));
            retVal.Add(new Tuple<string, string>("SIRKEL SAG", "qAT2lTCgGVZIQblO0PyF6XcmBMot0ZpqV+AAaQmVHG93pY7BMJPL8lndJsV/h56k22k7u8jTyIXj+h3Do8Rj6jjqkwnHrNKXAyl+eS/EVDX+hGNp+FH9vZV5xtL3VIa3RoM9GQ+NgWCUURmFNs9Y7AA4X0IZweByvDNBBc+4kb4="));
            retVal.Add(new Tuple<string, string>("SNORRE RETT", "dW/gFf46ZjC02FPOPwH+3rjae8wcLDSchUh1XKoDYzdTssdRqbZIcno8n6mv+GoDThyc6ASqZJzFMJmnWNkIL8DBBRzMgITV5tCkXaTO4Bf84vTsBJ8k5nLoMwpLcGKmRMhi4hrbw7rf9Gpa5Sr2OZs+mMhuVs7oh0J5ouHywJo="));
            retVal.Add(new Tuple<string, string>("TOM BOLA", "EBUQktqQPEkSBagdUPgt7WhM8u1Kzt8VY95sB3v4QanCrlPMQguQfW09DYsMo6+plD6es7xWnVaVCl4nilxAmCATI1sPUC5mCmIDYRx0WDWfFORg8N4iqwHN7mWg3wiZV5gW/4H9SFRuFGPbjCysXlqg99GxQ+t3hWVwQqnAqsY="));
            retVal.Add(new Tuple<string, string>("JON DOE", "iY0khjRphyeHhkaftH6/2vRL2v6hHXnSgILy3mgig2eP8XYsNW0pu5CP+tyo0T7we+vSUk8xTir8ZrzORXreqObo9KKJiEWQsLn6905bu1OrOUL2hQgUnHwzUjoNTNn3+VAUK01T357WHVMKqV2q2p13V5PWAEEF7bCdvyt0rR8="));
            retVal.Add(new Tuple<string, string>("SYNNE SAGMO", "QjHmWslpgPJAZCi6M3KTu3/v9+8g5ZMdRl5H64UR4mluAr5drdEzUH3qRGfWFwfeuLsF6ZcHAODE0dEsWbsXuPggj0zBnjPVAQb1ISeNlMwB6COA/yNtkjUVg7UK1EHd3y7qtnxp6nqjWkdX6CQjGQV2MKV7DzhSodz8kwO4yU8="));
            retVal.Add(new Tuple<string, string>("RANDI NESLAND", "WLB5UcFabrboAHeKhcM4VyTysFXE1ItyxzyYyFKpyjvJ1IyySm0JIlEVfAnFt9wJKS7VYdYlmTj9nJLnK+1H1MhHrVK8bchmHY197Y90CXj0Qrh1Tavkx87mFiKoksVt6k3HepQKSTSUw+ovblgtEoodnLHoCRvgSe/X217JaD0="));
            retVal.Add(new Tuple<string, string>("ØIVIND SMESTAD", "p+Z4uWZ/ja+v8Z50P03Y0rPhl8mnONMQWHscPDK8N17Tn5nAS/Rfu8xmJt5GtQoeLMxQcyi1un8z8r0xL4Ny4L8SGhxuYi5tsjFtLYP54/bp77ySE+X8KhiMnckwu8Vhh+A7R5cSALH8k569YI4YytXjyoE0DWpZU9iXFFp1/c8="));
            retVal.Add(new Tuple<string, string>("ARNE RUNDE", "NsV++pokgDWXXRHXlrrexhMIdfSEKIxHfYujht38UMlLwc8UntUOv/dod2J7/D4s3wRGqP3vfhEMXXU+83nJ6l2pgxGWOp+NbFmA6kYYbY+H5+xEV1uy0cTo+xr8YlamBIs7iC1B1wxomLVuEgqYwqYjuSvJzx3ZblyYEdWqks0="));
            retVal.Add(new Tuple<string, string>("PHILLIP SELVIK", "c2iY5qwfDdb7tNb6JxdDPbjaYIJlTNuZE2jVHYwWB2DCc8pZt6Vw5TLXDppsLFG9nQCWV5GeCuQd1BOIkaAILFWM3i3V0Eeu8oB+th1UNkRqf69U5HNp/BTzsY9BnyExqcQezU9ShpuY30xQEBzgUzE593/rcNYzpYMAlTREQ/o="));
            retVal.Add(new Tuple<string, string>("LUDVIG MOHOLT", "RuIMemhsaaduQjmr0OKWkRxPyZxP17dO1Bn0ZGXa+VRChMWoqH7d1hm6stN646fPOaI1rheBaXF0vQ103lsTsGnUPR0Ecx8DhDqzqPm6TaJQbPWTbohco5uImw+vt2bJioK2MJIuVd+CYciHRcrEpZXs3KylugIZYl1ggpYdBjs="));
            retVal.Add(new Tuple<string, string>("PREBEN NAAS", "eijqUZ9rtxU7SVI7mqqfjrABNAH/jLRNeAT2qhlD7oC0SrWORoM++qU5XT34cGZ327I1qHhcu6kTu5nt+74nPuNFRvHHFPO1rzd80upSCSobO7Poqf1NWZqcWPPXld06jfarDdhCeVtLFUq1tYeXN88Lkp6j2u/7W7LRDS+gBB0="));
            retVal.Add(new Tuple<string, string>("MARKUS SKARET", "utyi7pDn2CIh393clhwAks/oDOrhr1l0Nq4mKA9oSRx7mBgzAbDnOkea6WtC7L02bTOVQpDH+rkM5PxsZjbBb6At9pi+l7wCYyTGBWxVBnWJ9FM8sGq1Zye1NpWxQ4jO097ogA+KNj/tD2CdFsRMQDK2tAJKoJk6KTzRjzrDpds="));
            retVal.Add(new Tuple<string, string>("ARI ARNTSEN", "A/WMPx/ysxUScfTe+qmLH9RlRGogjgJJeKtM+0QcE+VAQr0+Dof7TD12vvDmIKxwSb5nI39SwfZi1mNlybskXHs1Auo95e5Crv3utLyaGZ4Bu5rMe+Qt3shaF28hH5IyVZpTzX+j6/mtD3UCiI2na3L6ekEjGdODLUKNj6zn0QQ="));
            retVal.Add(new Tuple<string, string>("ULRIKKE HEGGSET", "IZ2VqczizpJ64kjkQXwRP4kJi6/k5GFezXnnqujpoJov+j5qXIoI4tFduNwIyFn8+9bt+W+cLw9r/O5KBWlLisNMZs9pfjyZw5XbygYjA21KkVi0QmF7SYeGPaAl5dPm320FfTxdyXvOqkUqS93RaBpUPal0f0tQBaaw3Jn4CMg="));
            retVal.Add(new Tuple<string, string>("SCOTT OWREN", "g8fM0ydNhOZvaIATKztEm6lyYL0AwHkGlufLLPnMzqvoJ7/NobJWmHuf01yu43SUuOJmprLZByJB89JRs7vO72DoB9eSkl1VR3Z8OTTroLHPxa1wxkOPqyTe4DvznvUOeXlh+18g6LprQQ+VhfeH06rmZ7my2qzNn57Xlj4uKVk="));

            //Plan
            retVal.Add(new Tuple<string, string>("FRIDTJOF KJEILEN", "O27pttgxGgACfN35p+e2ShoW0IXpfejTKl45UkpIJy4v4XHnBK2dsOupKNyJVXtnMneKZxpAv7hZoSjpMJbL05uyq67SZsCmzGWHRzo9C/TsRUAqpnC+C1WWMyTVt0A5NTwcfHT+/VZwa8fssIkMJJ7NpAPpx1YLFQOULNLQzv8="));
            retVal.Add(new Tuple<string, string>("FILLIP RUDOLFSEN", "o6WhvWhguohjtWtE2LdAWltiHu2xBSumNw+cTpDi+fupxd/TnE3rZiWSGPx483QfmOZK60w7vMbngweX//QuaafsxKfjoxZnHcnTMdPDDYSq8haSWcA60d0Pnys9xNDh/E38XEwEH16i4XIIlmlx10qO36srfC8iHTy/av8aib0="));
            retVal.Add(new Tuple<string, string>("RASMUS HONNINGSVÅG", "NALuQM75H6m/Eo6AUTUbRVGMB7sYoDdsVDIFXqqH06m8JCifKpSh/rosyArLQAf97gs1awg+2NlVQp9fm9jaj5xTPHG6IjKoQwZF/IbATyUjLGe/rrkWQXLap8AV3FX7tyG1cet5VlTL7dc6kCU8IZasqAT8h2EtjbSnMrjfQNQ="));
            retVal.Add(new Tuple<string, string>("JOHN ALLUM", "x1L2HzLJI4MK05+xXt0aWrOvp/tQUIkBO0fqzNwX+qI61EZ0KNMtaOiXBZmNVjo5flYto5XdPAqKs1+O59KmKQC/JAqbF3FF6PJpHq3NsFzgPCB5i9pLY9rDuO32kfxa7hHCG6o16qlHBP9EGQhNzk2yAT9+YfButyWaTDdBLuk="));
            retVal.Add(new Tuple<string, string>("AKSEL MOLDESTAD", "MUTfr92qysHB4XxKgeNvTn1G849eJvh2x48xCN3N15c7pkgU6N+2P7eLMKi5hp6QEnfzjM0e/q3BnOmpkjZ5lIYNuh4t0IDWyfEDzsg70HXLnVhRZr4nLSqkzEwDmUvIJeuOsctjrKacTdzalLu1gPuwM9rSFPMndvUjvkVGbdw="));
            retVal.Add(new Tuple<string, string>("AGNES HOLMBERG", "RAyadVat5n5g1yuKUtcD7VLyv+dEKqUabRD4MIRSOtWBoKEXq4hmgb60veucg/qRMQ2ywtT2E2u4W9OjpMnY+DmZK1M/JUXvk20i0PV9HwzpOnzOXdU+YxlYdyWZRv4CY6fWmqp9HuHSmgGqlu4DH979K7/93nl5YDCsrIDyQwA="));

            return retVal;
        }
    }


}

