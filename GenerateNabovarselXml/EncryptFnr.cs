using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenerateNabovarselXml
{
    public class EncryptFnr
    {
        private List<Person> _personer = new List<Person>();

        private void LoadSourceFreg()
        {
            var fileContent = System.IO.File.ReadAllText("eksport-freg-2021-03-18T13_38_19.339Z.json");
            var fregDTO  = JsonConvert.DeserializeObject<FregDTO>(fileContent);

            _personer = fregDTO.DokumentListe.Select(s => new Person() { Ssn = s.Identifikator, Name = s.VisningNavn, Address = s.BostedsAdresse }).ToList();

        }

        public async Task Encrypt()
        {
            LoadSourceFreg();
            //var encryptedFnrs = new List<Person>();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57262");

            foreach (var fnr in _personer)
            {
                var result = await client.GetStringAsync($"api/GetEncryptedString/{fnr.Ssn}");                                
                var encryptedId = result.Replace("\"", "");
                fnr.EncryptedSsn = encryptedId;
            }

            var fileContent = JsonConvert.SerializeObject(_personer);

            System.IO.File.WriteAllText($@"c:\temp\encryptedfnr.json", fileContent);
        }
    }
}
