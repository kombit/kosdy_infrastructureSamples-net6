using Kombit.InfrastructureSamples.Logging;
using Kombit.InfrastructureSamples.Token;

namespace Kombit.InfrastructureSamples
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                run = new Program().Run();
            }
        }

        private bool Run()
        {

            // Setup Log4Net configuration by loading it from configuration file. 
            // log4net is not necessary and is only being used for demonstration.
            Log4NetLogger.Initialize();

            // Class instances
            //var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();
            var klassifikation = new Klassifikation.Klasse();
            var organisation6 = new Organisation.Organisation();
            var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();


            // Prints user interface 
            Console.WriteLine("*************************************************************************************************");
            Console.WriteLine("Choose example:\n(1) Import Case\n(2) Search Case\n(3) Remove Case\n(4) Import, search and remove case\n(5) Search Organisation\n(6) Search Class \n(9) Get Token \n(0) Exit");
            Console.Write("\r\nChoose: ");

            switch (Console.ReadLine())
            {
                case "1":
                    //Import Case
                    sagdokumentIndeks.Importer(ConfigVariables.UUID);
                    return true;
                case "2":
                    // Search Case
                    sagdokumentIndeks.Fremsoeg(ConfigVariables.UUID);
                    return true;
                case "3":
                    // Remove Case
                    sagdokumentIndeks.Fjern(ConfigVariables.UUID);
                    return true;
                case "4":
                    // Collective running of example 1-3 
                    sagdokumentIndeks.Importer(ConfigVariables.UUID); // Should succeed with code 20.
                    sagdokumentIndeks.Fremsoeg(ConfigVariables.UUID); // Should succeed with code 20, because it has just been imported.
                    sagdokumentIndeks.Fjern(ConfigVariables.UUID);    // Should succeed with code 20.
                    return true;
                case "5":
                    // Search Virksomhed
                    organisation6.GetOrganisationByCvr(ConfigVariables.MYNDIGHEDS_CVR);
                    return true;
                case "6":
                    // Search Class
                    klassifikation.SoegKlasse(ConfigVariables.KLE_KLASSE);
                    klassifikation.SoegKlasse(ConfigVariables.KLE_HANDLINGSFACET);
                    return true;
                case "9":
                    // Get Token
                    TokenFetcher.getToken(ConfigVariables.ConfigurationSectionNameForKlassification);
                    return true;
                case "0":
                    // Exit
                    return false;
                default:
                    Console.WriteLine("Error: Enter valid input");
                    return true;
            }
        }
    }
}
