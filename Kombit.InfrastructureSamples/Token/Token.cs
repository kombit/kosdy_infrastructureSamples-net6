
using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.WscCore.OioWsTrust;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens;

namespace Kombit.InfrastructureSamples.Token
{

    public static class TokenFetcher
    {

        /// <summary>
        /// Checks if a token is valid. 5 minutes added to be sure it is valid (can be changed)
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <returns>True of token is expired, false otherwise</returns>
        public static bool IsTokenExpired(SecurityToken token) {
            Console.WriteLine("TokenId:" + token.Id);
            return token.ValidTo > DateTime.Now.AddMinutes(5);
        }

        public static StsTokenServiceConfiguration getTokenConfiguration(string configurationSectionName)
        {
            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Bind the configuration to a custom class
            var wscConfiguration = new OioIdwsWcfConfigurationSection();
            configuration.GetSection("commonConfiguration").Bind(wscConfiguration, c => c.BindNonPublicProperties = true);
            configuration.GetSection(configurationSectionName).Bind(wscConfiguration, c => c.BindNonPublicProperties = true);
            StsTokenServiceConfiguration stsConfiguration = TokenServiceConfigurationFactory.CreateConfiguration(wscConfiguration);
            return stsConfiguration;
        }

        public static void getToken(string configurationSectionName)
        {
            Console.WriteLine("\nGet a token ");
            StsTokenServiceConfiguration stsConfiguration = getTokenConfiguration(configurationSectionName);
            GenericXmlSecurityToken token = getToken(stsConfiguration);
            Console.WriteLine("\nToken: " + token.TokenXml.InnerText);
        }

        public static GenericXmlSecurityToken getToken(StsTokenServiceConfiguration stsConfiguration)
        {
            IStsTokenService stsTokenService = new StsTokenServiceCache(stsConfiguration);
            GenericXmlSecurityToken token = (GenericXmlSecurityToken)stsTokenService.GetToken();
            return token;
        }

    }
}
