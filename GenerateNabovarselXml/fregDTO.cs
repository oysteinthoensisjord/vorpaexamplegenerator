using Newtonsoft.Json;
using System.Collections.Generic;

namespace GenerateNabovarselXml
{
    public class FregDTO
    {
        public int Treff { get; set; }
        public int Rader { get; set; }
        public int Offset { get; set; }
        public int NesteSide { get; set; }
        public int Seed { get; set; }
        
        public List<Dokument> DokumentListe { get; set; }
        public FregDTO()
        {
            DokumentListe = new List<Dokument>();
        }
    }
    public class Dokument {
        public string SisteHendelse { get; set; }
        public string BostedsAdresse { get; set; }
        public string AdresseBeskyttelse { get; set; }
        public string VisningNavn { get; set; }
        public string PersonStatus { get; set; }
        public string Kjoenn { get; set; }
        public string Identifikator { get; set; }
        public string Sivilstand { get; set; }
    }
}