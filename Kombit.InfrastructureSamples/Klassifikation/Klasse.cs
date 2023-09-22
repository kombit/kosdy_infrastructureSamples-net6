using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.SoapCore;
using Kombit.InfrastructureSamples.Token;
using System.IdentityModel.Tokens;

namespace Kombit.InfrastructureSamples.Klassifikation
{
    /// <summary>
    /// Class for handling requests to KlasseService
    /// </summary>
    public class Klasse {

        private GenericXmlSecurityToken token;
        private KlassePortType channelWithIssuedToken;

        /// <summary>
        /// Demonstrates the use of the SOEG and LIST operations in KlassifikationService.
        /// First SOEG is used to find the Klasse UUID based on a brugervendt nøgle (key).
        /// Next LIST is used to get the full Klasse object based on the Klasse UUID found by searching.
        /// </summary>
        /// <returns>
        /// Prints the result to the console
        /// </returns>
        /// <param name="brugervendtNoegle">Key (brugervendt nøgle) to search for</param> 
        public SoegOutputType SoegKlasse(string brugervendtNoegle)
        {
            Console.WriteLine("\nSearch for class with key: {0} with the following result:", brugervendtNoegle);

            var soegOutput = Soeg(brugervendtNoegle);

            Console.WriteLine("* Status: {0}\n* Statustext: {1}", soegOutput.StandardRetur.StatusKode, soegOutput.StandardRetur.FejlbeskedTekst);

            // Chech if status == 20 (OK)
            if (soegOutput.StandardRetur.StatusKode != "20")
                return soegOutput;

            // Check if any UUID was found
            var uuids = soegOutput.IdListe; 
            if (uuids == null || uuids.Length == 0)
            { 
                Console.WriteLine("No result for {0}", brugervendtNoegle);
                return soegOutput; 
            } 

            // Call List with the found UUID(s)
            var listOutput = List(uuids);

            /// Print output (klassetitel) in the console 
            /// This examples assumes that only one object is returned
            var klasseUUID = listOutput.FiltreretOejebliksbillede[0].ObjektID.UUIDIdentifikator;
            var klasseTitel = listOutput.FiltreretOejebliksbillede[0].Registrering[0].AttributListe[0].TitelTekst;
            var klasseBrugervendtNoegle = listOutput.FiltreretOejebliksbillede[0].Registrering[0].AttributListe[0].BrugervendtNoegleTekst;

            // If there is more than one PubliceretStatus object, where ErPubliceretIndikator is true, dates are shown for the first element in the list
            var gyldigFra = listOutput.FiltreretOejebliksbillede[0].Registrering[0].TilstandListe[0].Virkning.FraTidspunkt.Item;
            var gyldigTil = listOutput.FiltreretOejebliksbillede[0].Registrering[0].TilstandListe[0].Virkning.TilTidspunkt.Item;

            Console.WriteLine("* UUID for the class: {0}\n* Titel for the class: {1}\n* Brugervendt nøgle: {2}", klasseUUID, klasseTitel, klasseBrugervendtNoegle);

            // This bool is used to check if a PubliceretStatus object exists, where ErPubliceretIndikator is true
            bool publiceretStatusIndikator = listOutput.FiltreretOejebliksbillede[0].Registrering[0].TilstandListe[0].ErPubliceretIndikator;

            // If a PubliceretStatus object exists where ErPubliceretIndikator is true does not exist, N/A is shown as output
            // If gyldigTil returns True, it means gyldighed is infinite
            if (publiceretStatusIndikator)
            {
                Console.WriteLine("\n* Gyldig fra: " + gyldigFra + "\n* Gyldig til: " + gyldigTil);
            }
            else
            {
                Console.WriteLine("\n* Gyldig fra: N/A" + "\n* Gyldig til: N/A");
            }
            return soegOutput;
        }

        /// <summary>
        /// Demonstrates the use of the SOEG and LIST operations in KlassifikationService.
        /// First SOEG is used to find the Klasse UUID based on a brugervendt nøgle (key).
        /// Next LIST is used to get the full Klasse object based on the Klasse UUID found by searching.
        /// </summary>
        /// <returns>
        /// A KeyValuePair with the UUID (key) and name of the Klasse (name) 
        /// </returns>
        /// <param name="brugervendtNoegle">Key (brugervendt nøgle) to search for</param> 
        internal KeyValuePair<string, string> GetKlasseUuidName(string brugervendtNoegle)
        {
            var soegOutput = Soeg(brugervendtNoegle);
             
            // Chech if status == 20 (OK)
            if (soegOutput.StandardRetur.StatusKode != "20")
                return new KeyValuePair<string, string>("", "");

            // Check if any UUID was found
            var uuids = soegOutput.IdListe;
            if (uuids == null || uuids.Length == 0)
                return new KeyValuePair<string, string>("", "");

            // Call List with the found UUID(s)
            var listOutput = List(uuids);

            /// This examples assumes that only one object is returned
            var klasseUUID = listOutput.FiltreretOejebliksbillede[0].ObjektID.UUIDIdentifikator;
            var klasseTitel = listOutput.FiltreretOejebliksbillede[0].Registrering[0].AttributListe[0].TitelTekst;

            return new KeyValuePair<string, string>(klasseUUID, klasseTitel);
         }

        /// <summary>
        /// Searches for a Klasse (class) object with a specific key (brugervendt nøgle).  
        /// Uses the SOEG operation in KlasseService
        /// </summary>
        /// <param name="brugervendtNoegle">The key to search for</param>
        /// <returns>Search output including UUID for the class</returns>
        internal SoegOutputType Soeg(string brugervendtNoegle){
            soegRequest request = new soegRequest(
                RequestHeader,
                new SoegInputType1()
                {
                    AttributListe = new EgenskabType[]
                    {
                        new EgenskabType
                        {
                            BrugervendtNoegleTekst = brugervendtNoegle
                        }
                    },
                    // Check this line after KLA6 is in production
                    TilstandListe = new PubliceretStatusType[0],
                    RelationListe = new RelationListeType()
                }
            );

            soegResponse soegResponse = Port.soegAsync(request).Result;
            return soegResponse.SoegOutput;

        }

        /// <summary>
        /// Retreieves all information about one or more Klasse object.  
        /// Uses the LIST operation in KlasseService
        /// </summary>
        /// <param name="uuids">UUIDs for the Klasse objects to list</param>
        /// <returns>List output containing all information about the requested objects</returns> 
        internal ListOutputType1 List(string[] uuids){
            listRequest request = new listRequest(
                RequestHeader,
                new ListInputType()
                {
                    UUIDIdentifikator = uuids
                }
            );

            listResponse listResponse = Port.listAsync(request).Result;
            return listResponse.ListOutput;

        }    

        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private KlassePortType Port {
            get {
                if (channelWithIssuedToken == null || TokenFetcher.IsTokenExpired(token)) {
                    channelWithIssuedToken = CreatePort();
                }

                return channelWithIssuedToken;
            }
            set {
                channelWithIssuedToken = value;
            }
        }

        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private KlassePortType CreatePort() {
            StsTokenServiceConfiguration stsConfiguration = TokenFetcher.getTokenConfiguration(ConfigVariables.ConfigurationSectionNameForKlassification);
            token = TokenFetcher.getToken(stsConfiguration);
            return FederatedChannelFactoryExtensions.CreateChannelWithIssuedToken<KlassePortType>(token, stsConfiguration);
        }

    /// <summary>
    /// Creates the request header which is simply a random UUID
    /// </summary>
        private RequestHeaderType RequestHeader {
            get {
                return new RequestHeaderType() {
                    TransactionUUID = Guid.NewGuid().ToString()
                };
            }
        }

        #endregion
    }
}
