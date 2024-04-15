using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateNabovarselXml.Vorpa
{
    public static class BerorteparterSplitter
    {
        public static VORPA SplitBerørteParter(no.kxml.skjema.dibk.nabovarselPlan.NabovarselPlanType mainForm)
        {
            var retVal = new VORPA();

            var externalXmlParties = mainForm.beroerteParter;
            mainForm.beroerteParter = new no.kxml.skjema.dibk.nabovarselPlan.BeroertPartType[0];

            //var externalXmlParties = mainForm.beroerteParter.Skip(1);
            //mainForm.beroerteParter = mainForm.beroerteParter.Take(1).ToArray();

            var berorteParter = externalXmlParties;
            var planvarselBeroerteParter = new no.kxml.skjema.dibk.planvarselBerorteParter.planvarselBeroerteParterType();
            var planvarselBeroerteParterList = new List<no.kxml.skjema.dibk.planvarselBerorteParter.BeroertPartType>();

            foreach (var part in berorteParter)
            {
                var berortPart = new no.kxml.skjema.dibk.planvarselBerorteParter.BeroertPartType()
                {
                    epost = part.epost,
                    navn = part.navn,
                    foedselsnummer = part.foedselsnummer,
                    organisasjonsnummer = part.organisasjonsnummer,
                    systemReferanse = part.systemReferanse,
                    telefon = part.telefon,
                    beskrivelseForVarsel = part.beskrivelseForVarsel
                };

                berortPart.partstype = new no.kxml.skjema.dibk.planvarselBerorteParter.KodeType()
                {
                    kodebeskrivelse = part.partstype.kodebeskrivelse,
                    kodeverdi = part.partstype.kodeverdi
                };

                if (part.kontaktperson != null)
                    berortPart.kontaktperson = new no.kxml.skjema.dibk.planvarselBerorteParter.KontaktpersonType()
                    {
                        epost = part.kontaktperson.epost,
                        mobilnummer = part.kontaktperson.mobilnummer,
                        navn = part.kontaktperson.navn,
                        telefonnummer = part.kontaktperson.telefonnummer
                    };

                if (part.adresse != null)
                    berortPart.adresse = new no.kxml.skjema.dibk.planvarselBerorteParter.EnkelAdresseType()
                    {
                        adresselinje1 = part.adresse.adresselinje1,
                        adresselinje2 = part.adresse.adresselinje2,
                        adresselinje3 = part.adresse.adresselinje3,
                        landkode = part.adresse.landkode,
                        postnr = part.adresse.postnr,
                        poststed = part.adresse.poststed
                    };


                var bpGjelderEiendommer = new List<no.kxml.skjema.dibk.planvarselBerorteParter.GjelderEiendomType>();

                foreach (var gjelderEiendom in part.gjelderEiendom.ToList())
                {
                    var bpGjelderEiendom = new no.kxml.skjema.dibk.planvarselBerorteParter.GjelderEiendomType()
                    {
                        bolignummer = gjelderEiendom.bolignummer,
                        bygningsnummer = gjelderEiendom.bygningsnummer,
                        kommunenavn = gjelderEiendom.kommunenavn
                    };

                    if (gjelderEiendom.adresse != null)
                        bpGjelderEiendom.adresse = new no.kxml.skjema.dibk.planvarselBerorteParter.EiendommensAdresseType()
                        {
                            gatenavn = gjelderEiendom.adresse.gatenavn,
                            adresselinje1 = gjelderEiendom.adresse.adresselinje1,
                            adresselinje2 = gjelderEiendom.adresse.adresselinje2,
                            adresselinje3 = gjelderEiendom.adresse.adresselinje3,
                            bokstav = gjelderEiendom.adresse.bokstav,
                            husnr = gjelderEiendom.adresse.husnr,
                            landkode = gjelderEiendom.adresse.landkode,
                            postnr = gjelderEiendom.adresse.postnr,
                            poststed = gjelderEiendom.adresse.poststed
                        };

                    if (gjelderEiendom.eiendomsidentifikasjon != null)
                        bpGjelderEiendom.eiendomsidentifikasjon = new no.kxml.skjema.dibk.planvarselBerorteParter.MatrikkelnummerType()
                        {
                            bruksnummer = gjelderEiendom.eiendomsidentifikasjon.bruksnummer,
                            festenummer = gjelderEiendom.eiendomsidentifikasjon.festenummer,
                            gaardsnummer = gjelderEiendom.eiendomsidentifikasjon.gaardsnummer,
                            kommunenummer = gjelderEiendom.eiendomsidentifikasjon.kommunenummer,
                            seksjonsnummer = gjelderEiendom.eiendomsidentifikasjon.seksjonsnummer
                        };

                    bpGjelderEiendommer.Add(bpGjelderEiendom);
                }
                berortPart.gjelderEiendom = bpGjelderEiendommer.ToArray();

                planvarselBeroerteParterList.Add(berortPart);
            }

            planvarselBeroerteParter.beroertPart = planvarselBeroerteParterList.ToArray();

            retVal.VorpaBerorteParter = planvarselBeroerteParter;
            retVal.VorpaMainForm = mainForm;

            return retVal;
        }
    }
}
