using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.SoapCore;
using Kombit.InfrastructureSamples.OrganisationService;
using Kombit.InfrastructureSamples.Token;
using System.IdentityModel.Tokens;

namespace Kombit.InfrastructureSamples.Organisation
{
    public class Organisation
    {
        private GenericXmlSecurityToken token;
        private OrganisationPortType channelWithIssuedToken;

        /// <summary>
        /// Demonstrates how to find the Organisation object related to a Virksomhed object with a given CVR-number. 
        /// First the SOEG operation in VirksomhedService is used to find the Virksomhed object which holds the CVR-number.
        /// Next the SOEG operation in OrganisationService is used to find the Organisation object related to the Virksomhed object.
        /// Finally the LAES operation in OrganisationService is used to read the full Organisation object
        /// </summary>
        /// <param name="authorityCVR">CVR for the authority</param>
        /// <returns>Prints the output to the console and returns output so it can be used in testing the method</returns>
        public (string,string,string) GetOrganisationByCvr(string authorityCVR)
        {
            Console.WriteLine("\nSearching for organization with CVR {0} with the following result:", authorityCVR);

            // CVR is an attribute on Virksomhed 
            // In order to find the Organisation by CVR we first need to find the UUID for the Virksomhed which has the CVR
            var virksomhed = new Virksomhed.Virksomhed();
            var virksomhedUuid = virksomhed.GetVirksomhedUuid(authorityCVR);

            // Next we use the SOEG operation to find the UUID for the Organisation related to the Virksomhed 
            var organisation = GetOrganisationUuidName(virksomhedUuid);

            Console.WriteLine(" *Virksomhed UUID: {0}\n *Organisation UUID: {1}\n *Organisation Name: {2}\n", virksomhedUuid, organisation.Key, organisation.Value);

            return (virksomhedUuid,organisation.Key,organisation.Value);
        }

        /// <summary>
        /// Demonstrates how to find the Organisation object related to a Virksomhed object with a given CVR-number. 
        /// First the SOEG operation in VirksomhedService is used to find the Virksomhed object which holds the CVR-number.
        /// Next the SOEG operation in OrganisationService is used to find the Organisation object related to the Virksomhed object.
        /// Finally the LAES operation in OrganisationService is used to read the full Organisation object
        /// </summary>
        /// <param name="authorityCVR">CVR for the authority</param>
        /// <returns>A KeyValuePair with the Organisation UUID (key) and Organisation name (name)</returns>
        public KeyValuePair<string, string> GetOrganisationUuidName(string virksomhedUuid)
        {
            var soegOutput = Soeg(virksomhedUuid);

            if (soegOutput.IdListe == null || soegOutput.IdListe.Length == 0)
                return new KeyValuePair<string, string>("", "");

            // Chech if status == 20 (OK)
            if (soegOutput.StandardRetur.StatusKode != "20")
                return new KeyValuePair<string, string>("", "");

            // Check if any UUID was found
            var uuids = soegOutput.IdListe;
            if (uuids == null || uuids.Length == 0)
                return new KeyValuePair<string, string>("", "");

            // Call List with the found UUID(s)
            var laesOutput = Laes(uuids[0]);

            var organisationUUID = laesOutput.FiltreretOejebliksbillede.ObjektType.UUIDIdentifikator;
            var organisationNavn = laesOutput.FiltreretOejebliksbillede.Registrering[0].AttributListe.Egenskab[0].OrganisationNavn;

            return new KeyValuePair<string, string>(organisationUUID, organisationNavn);
        }

        /// <summary>
        /// Searches for an Organisation object related to a given Virksomhed object.
        /// Uses the SOEG operation in OrganisationService
        /// </summary>
        /// <param name="virksomhedUuid">UUID for the Virksomhed object to search for</param>
        /// <returns>Search output including UUID for the Organisation object</returns> 
        internal SoegOutputType Soeg(string virksomhedUuid){
            soegRequest request = new soegRequest(
                RequestHeader,
                new SoegInputType1()
                {
                    AttributListe = new AttributListeType(),
                    TilstandListe = new TilstandListeType(),
                    RelationListe = new RelationListeType()
                    {
                        Virksomhed = new VirksomhedRelationType
                        {
                            ReferenceID = new UnikIdType
                            {
                                Item = virksomhedUuid,
                                ItemElementName = ItemChoiceType.UUIDIdentifikator

                            }
                        }
                    }
                }
            );

            soegResponse soegResponse = Port.soegAsync(request).Result;
            return soegResponse.SoegOutput;
        }


        /// <summary>
        /// Retreieves all information about an Organisation object.  
        /// Uses the LAES operation in OrganisationService
        /// </summary>
        /// <param name="organisationUuid">UUID for the Organisation object to retreive</param>
        /// <returns>Laes output containing all information about the requested object</returns> 
        internal LaesOutputType Laes(string organisationUuid){
            laesRequest request = new laesRequest(
                RequestHeader,
                new LaesInputType()
                {
                    UUIDIdentifikator = organisationUuid
                }
            );

            laesResponse laesResponse = Port.laesAsync(request).Result;
            return laesResponse.LaesOutput;
        }

        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private OrganisationPortType Port
        {
            get
            {
                if (channelWithIssuedToken == null || TokenFetcher.IsTokenExpired(token))
                {
                    channelWithIssuedToken = CreatePort();
                }

                return channelWithIssuedToken;
            }
            set
            {
                channelWithIssuedToken = value;
            }
        }


        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private OrganisationPortType CreatePort()
        {
            StsTokenServiceConfiguration stsConfiguration = TokenFetcher.getTokenConfiguration(ConfigVariables.ConfigurationSectionNameForOrganisation);
            token = TokenFetcher.getToken(stsConfiguration);
            return FederatedChannelFactoryExtensions.CreateChannelWithIssuedToken<OrganisationPortType>(token, stsConfiguration);
        }

        /// <summary>
        /// Creates the request header which is simply a random UUID
        /// </summary>
        private RequestHeaderType RequestHeader
        {
            get
            {
                return new RequestHeaderType()
                {
                    TransactionUUID = Guid.NewGuid().ToString()
                };
            }
        }

        #endregion
    }
}
