using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace GenerateNabovarselXml
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool closeApp = false;
            Console.WriteLine("**************** Nabovarsel generator ****************");

            //Console.WriteLine("Krypterer fødselsnummer");
            //var ef = new EncryptFnr();
            //await ef.Encrypt();

            Console.WriteLine("Angi antall naboer det skal genereres XML for");

            while (!closeApp)
            {
                var inputNeighbours = Console.ReadLine();
                var neighboursCount = 0;
                while (!int.TryParse(inputNeighbours, out neighboursCount))
                {
                    Console.WriteLine("Skjønner ikkje hått du meiner.. skriv tal...");
                    inputNeighbours = Console.ReadLine();
                }

                    Console.WriteLine($"  -- Generates XML for {neighboursCount} neighbours");

                    var t = new NabovarselPlanExampleGenerator();
                    var nabovarsel = t.NyttNabovarsel(neighboursCount);

                var vorpa = BerorteparterSplitter.SplitBerørteParter(nabovarsel);

                WriteFilesToDisk(vorpa.VorpaMainForm, $"vorpa-{neighboursCount}");
                WriteFilesToDisk(vorpa.VorpaBerorteParter, $"vorpa-bp-{neighboursCount}");

                Console.WriteLine("  -- DONE");
                

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") closeApp = true;
            }

            return;
        }

        private static void WriteFilesToDisk(object xmlClass, string fileName)
        {
            var ser = new System.Xml.Serialization.XmlSerializer(xmlClass.GetType());

            XmlDocument xd = null;

            Console.WriteLine("  -- Serializes and saves file");
            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, xmlClass);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xd = new XmlDocument();
                    xd.Load(xtr);
                }
            }

            File.WriteAllText($@"c:\temp\{fileName}.xml", xd.OuterXml.ToString());
        }
    }
}
