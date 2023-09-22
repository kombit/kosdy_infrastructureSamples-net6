using Kombit.InfrastructureSamples.VirksomhedService;
using Kombit.InfrastructureSamples.Token;
using System.IdentityModel.Tokens;
using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.SoapCore;

namespace Kombit.InfrastructureSamples.Virksomhed
{
    /// <summary>
    /// Class for handling requests to VirksomhedService
    /// </summary>
    public class Virksomhed {

        private GenericXmlSecurityToken token;
        private VirksomhedPortType channelWithIssuedToken;

        /// <summary>
        /// Searches for a Virksomhed object based on CVR number and returns UUID
        /// </summary>
        /// <param name="authorityCvr">CVR number to search for</param>
        /// <returns>UUID for the Virksomhed object</returns>
        public string GetVirksomhedUuid(string authorityCvr)
        { 
            var soegOutput = Soeg(authorityCvr);

            var virksomhedUuidList = soegOutput.IdListe;

            if (virksomhedUuidList == null || virksomhedUuidList.Length == 0)
                return "";  
        
            return virksomhedUuidList[0];
        }

        /// <summary>
        /// Searches for a Virksomhed object based on CVR number and returns SoegOutput.
        /// Uses the SOEG operation in VirksomhedService
        /// </summary>
        /// <param name="authorityCvr">CVR number to search for</param>
        /// <returns>Search output for Virksomhed object</returns>
        internal SoegOutputType Soeg(string authorityCvr){
            soegRequest request = new soegRequest(
                RequestHeader,
                new SoegInputType1()
                {
                    AttributListe = new EgenskabType[]
                    {
                        new EgenskabType
                        {
                            CVRNummerTekst = authorityCvr
                        }
                    },
                    TilstandListe = new TilstandListeType(),
                    RelationListe = new RelationListeType()
                }                  
            );

            soegResponse soegResponse = Port.soegAsync(request).Result;
            return soegResponse.SoegOutput; 
        }

        #region Port and token helper classes

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or if the token has expired
        /// </summary>
        private VirksomhedPortType Port
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
        private VirksomhedPortType CreatePort()
        {
            StsTokenServiceConfiguration stsConfiguration = TokenFetcher.getTokenConfiguration(ConfigVariables.ConfigurationSectionNameForVirksomhed);
            token = TokenFetcher.getToken(stsConfiguration);
            return FederatedChannelFactoryExtensions.CreateChannelWithIssuedToken<VirksomhedPortType>(token, stsConfiguration);
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
