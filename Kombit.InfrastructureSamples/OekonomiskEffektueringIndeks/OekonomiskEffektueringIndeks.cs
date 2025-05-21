using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.SoapCore;
using Kombit.InfrastructureSamples.OekonomiskEffektueringIndeksService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombit.InfrastructureSamples.OekonomiskEffektueringIndeks
{
    public class OekonomiskEffektueringIndeks
    {
        private GenericXmlSecurityToken token;
        private OekonomiskEffektueringPortType port;


        public fjernResponse fjern()
        {
            fjernRequest fjernRequest = new fjernRequest()
            {
                FjernInput = new UuidNoteInputType()
                {
                    UUIDIdentifikator = ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR
                },
                RequestHeader = RequestHeader
            };

            return Port.fjern(fjernRequest);

        }


        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private OekonomiskEffektueringPortType Port
        {
            get
            {
                if (port == null || TokenFetcher.IsTokenExpired(token))
                {
                    port = CreatePort();
                }

                return port;
            }
            set
            {
                port = value;
            }
        }
        /// <summary>
        /// Creates the port by getting a token, setting the endpoint and loading the certificates.
        /// </summary>
        /// <returns></returns>
        private OekonomiskEffektueringPortType CreatePort()
        {
            StsTokenServiceConfiguration stsConfiguration = TokenFetcher.getTokenConfiguration(ConfigVariables.ConfigurationSectionNameForOekonomiskEffektuering);
            token = TokenFetcher.getToken(stsConfiguration);
            return FederatedChannelFactoryExtensions.CreateChannelWithIssuedToken<OekonomiskEffektueringPortType>(token, stsConfiguration);
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

