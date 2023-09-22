using Kombit.InfrastructureSamples.Klassifikation;


namespace Kombit.InfrastructureSamples.UnitTests
{

    [TestClass]
    public class ProgramTests
    {

        /// <summary>
        /// Removes any existing case before testing to ensure test of Importer does not fail 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();
            sagdokumentIndeks.Fjern(ConfigVariables.UUID);
        }

        /// <summary>
        /// Test method for SagdokumentIndeks
        /// The test ensures that scenarios 1-4 returns Statuskode 20 which equals OK. 
        /// </summary>
        [TestMethod]
        public void ImportFremsoegFjern_ShouldPassWithCode20()
        {
            //Arrange
            var sagdokumentIndeks = new SagDokumentIndeks.SagDokumentIndeks();
            //Act 
            SagDokumentIndeksService.importerResponse importerResp = sagdokumentIndeks.Importer(ConfigVariables.UUID);
            SagDokumentIndeksService.fremsoegResponse fremsoegResp = sagdokumentIndeks.Fremsoeg(ConfigVariables.UUID);
            SagDokumentIndeksService.fjernResponse fjernResp = sagdokumentIndeks.Fjern(ConfigVariables.UUID);
            //Assert
            Assert.AreEqual(importerResp.ImporterSagDokumentIndeksOutput.Items[0].StatusKode, "20");
            Assert.AreEqual(fremsoegResp.FremsoegSagDokumentIndeksOutput.StandardRetur.StatusKode, "20");
            Assert.AreEqual(fjernResp.FjernSagDokumentIndeksOutput.Items[0].StatusKode, "20");

        }

        /// <summary>
        /// Test method for Klassifikation
        /// The test ensures that scenarios 6 returns Statuskode 20 which equals OK. 
        /// </summary>
        [TestMethod]
        public void SoegKlasse_ShouldPassWithCode20()
        {
            //Arrange
            var klassifikation = new Klasse();
            //Act
            SoegOutputType soegOutputKLE_KLASSE = klassifikation.SoegKlasse(ConfigVariables.KLE_KLASSE);
            SoegOutputType soegOutput_KLE_HANDLINGSFACET = klassifikation.SoegKlasse(ConfigVariables.KLE_HANDLINGSFACET);
            //Assert
            Assert.AreEqual(soegOutputKLE_KLASSE.StandardRetur.StatusKode, "20");
            Assert.AreEqual(soegOutput_KLE_HANDLINGSFACET.StandardRetur.StatusKode, "20");
        }

        /// <summary>
        /// Test method for Organisation
        /// The test ensures that scenarios 5 returns does not returns null values when searching for the Organisation. 
        /// </summary>
        [TestMethod]
        public void GetOrganisationByCVR_ShouldPassWithoutReturningNull()
        {
            //Arrange
            var organisation = new Organisation.Organisation();
            //Act
            (string virksomhedUuid, string organisationUuid, string organisationNavn) = organisation.GetOrganisationByCvr(ConfigVariables.MYNDIGHEDS_CVR);
            //Assert
            Assert.IsNotNull(virksomhedUuid);
            Assert.IsNotNull(organisationUuid);
            Assert.IsNotNull(organisationNavn);
        }
    }
}
