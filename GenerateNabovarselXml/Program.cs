using Dibk.Ftpb.Common.Datamodels;
using GenerateNabovarselXml.Vorpa;
using GenerateNabovarselXml.VorpaPlussH;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GenerateNabovarselXml
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            bool closeApp = false;
            Console.WriteLine("**************** Nabovarsel generator ****************");

            //Console.WriteLine("Krypterer fødselsnummer");
            //var ef = new EncryptFnr();
            //await ef.Encrypt();

            //var skjema = SuppleringAvSoeknad.SuppleringGenerator.Generate();

            //WriteFilesToDisk(skjema, "jons-skjema.xml");

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

                GenerateVorpaPlussH(neighboursCount);

                Console.WriteLine("  -- DONE");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") closeApp = true;
            }

            return;
        }

        private static void GenerateVorpaPlussH(int neighboursCount)
        {
            var t = new VorpaPlussHGenerator();
            var planvarsel = t.NyttNabovarsel(neighboursCount);

            WriteFilesToDisk(planvarsel, $"planvarsel-{neighboursCount}"); ;
        }

        private static void GenerateVorpa(int neighboursCount)
        {
            var t = new NabovarselPlanExampleGenerator();
            var nabovarsel = t.NyttNabovarsel(neighboursCount);

            var vorpa = BerorteparterSplitter.SplitBerørteParter(nabovarsel);

            WriteFilesToDisk(vorpa.VorpaMainForm, $"vorpa-{neighboursCount}");

            WriteFilesToDisk(vorpa.VorpaBerorteParter, $"vorpa-bp-{neighboursCount}");
        }

        private static void WriteFilesToDisk(object xmlClass, string fileName)
        {
            var content = SerializeWithNoWhitespaces(xmlClass);
            File.WriteAllText($@"c:\temp\{fileName}.xml", content);
        }

        public static string SerializeWithNoWhitespaces(object form)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.NewLineHandling = NewLineHandling.None;

            var serializer = new XmlSerializer(form.GetType());
            var stringWriter = new Utf8StringWriter();

            using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, form);
            }

            return stringWriter.ToString();
        }
    }
}