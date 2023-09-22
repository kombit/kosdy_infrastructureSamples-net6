using System;
using System.Security.Cryptography.X509Certificates;

namespace Kombit.InfrastructureSamples {
     public static class ConfigVariables
    {

        #region Configuration section variables

        public const string ConfigurationSectionNameForKlassification = "oioIdwsKlassifikationConfiguration";
        public const string ConfigurationSectionNameForOrganisation = "oioIdwsOrganisationConfiguration";
        public const string ConfigurationSectionNameForVirksomhed = "oioIdwsVirksomhedConfiguration";
        public const string ConfigurationSectionNameForSagsDokumentIndeks = "oioIdwsSagsDokumentIndeksConfiguration";

        #endregion

        #region Variables which MUST BE MODIFIED before running the code examples

        // UUID and name of your it-system in Fælleskommunalt Administrationssystem
        public const string ANVENDER_SYSTEM_UUID = "ba537e12-8b0c-44b1-9de7-f75803a4e091"; // Change to the UUID of your system
        public const string ANVENDER_SYSTEM_NAVN = "STS testklient 29"; // Change to the name of your system

        // CVR and name of the municipality (myndighed) that will be used to test
        //public const string MYNDIGHEDS_CVR = "00000000"; // Change to your authority CVR
        //public const string MYNDIGHEDS_CVR = "99999999"; // Change to your authority CVR
        //public const string MYNDIGHEDS_NAVN = "Feddet kommune"; // Change to your authority name

        public const string MYNDIGHEDS_CVR = "11111111"; // Change to your authority CVR
        public const string MYNDIGHEDS_NAVN = "Korsbaek Kommune"; // Change to your authority name

        // UUID used for the test case
        public const string UUID = "11111111-2222-3333-4444-555555555555";  // Generate your own UUID and insert it here


        #endregion

        #region Variables used for the code examples - CAN be modified

        // All code examples are based on the same story and use the same variables
        // You CAN modify these variables if you want the examples to reflect another scenario

        public const string SAGS_NUMMER = "2020-123456789"; // Change to your case number. It should be unique for every case.
        public const string SAGS_TITEL = "Aftale om forebyggende hjemmebesøg"; // Change to your case title

        public static DateTime SAG_TIDSPUNKT = new DateTime(2014, 3, 23, 14, 54, 23, 234); // Change to your case registration date/time
        public static DateTime SAG_OPRETTET = new DateTime(2020, 5, 12, 12, 0, 0); // Change to your case creation date/time
        public static DateTime SAG_LUKKET = new DateTime(2020, 6, 2, 12, 0, 0); // Change to your case closing date/time

        public const string PRIMAER_BEHANDLER_UUID = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // Change to the UUID of the primary case worker
        public const string PRIMAER_BEHANDLER_NAVN = "Ulla Jakobsen"; // Change to the name of the primary case worker

        public const string ORGANISATIONS_ENHED_UUID = "1111aaaa-11aa-22bb-33cc-111111aaaaaa"; // Change to the UUID of the responsible authority
        public const string ORGANISATIONS_ENHED_NAVN = "Forebyggelsesteamet"; // Change to the name of the responsible authority

        public const string PRIMAER_PART_CPR = "urn:oio:cpr-nr:0123456789"; // Change to the CPR number of the primary client
        public const string PRIMAER_PART_NAVN = "Godtfred Lund"; // Change to the name of the primary client

        public const string KLE_KLASSE = "27.35.04"; // Change to the code of the primary class
        public const string KLE_HANDLINGSFACET = "G01"; // Change to the code of the handling class
        public const string HANDLINGS_KLASSE_FACET_TITEL = "KLE - handlingsfacet"; // Constant, not required although it is good practice
        public const string KLASSE_FACET_TITEL = "KLE Emneplan"; // Constant, not required although it is good practice

        public const string AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // UUID of the user responsible for the modification in the master system. In this case the user is the same as the primary case worker, but it could be another user. Used both for BrugerRef and AktoerRef.

        #endregion

        #region Variables used for the code examples - NOT to be modified

        // Relations are defined by a ROLE and a TYPE - each represented by a UUID
        // The code examples make use of the following relations, roles and types
        // These should NOT be modified
        // Please consult Fælleskommunalt Klassifikationssystem for a complete list of available relations, roles and types

        // Case owner (Ejer)
        public const string EJER_ROLLE_UUID = "9e979b84-b846-4472-8622-58007dc63c7e"; // Rolle = Ejer
        public const string EJER_ORGANISATION_TYPE_UUID = "bc6972cd-8f2b-4b9d-8d37-62916d6a71aa"; // Type = Organisation

        // The case responsible (Ansvarlig)
        public const string ANSVARLIG_ROLLE_UUID = "a1263342-d348-44ba-a566-233f37c4cb67"; // Rolle = Ansvarlig
        public const string ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID = "c5fc3b3b-5197-49ee-92e6-ae6ba1957174"; // Type = OrganisationsEnhed

        // The case primary case worker (Primaer behandler)
        public const string PRIMAER_BEHANDLER_ROLLE_UUID = "bf1f93ed-9441-4af4-835b-baeb201f3076"; // Rolle = Primær Behandler
        public const string BRUGER_TYPE_UUID = "85d65133-4b00-460d-992e-3984857b5768"; // Type = Bruger

        // The primary part (Primaer part)
        public const string PRIMAER_PART_ROLLE_UUID = "d839f26a-d4d1-4441-b2d6-3dbbb12a9404"; // Rolle = Primær Part
        public const string PERSON_TYPE_UUID = "c189ba35-de4b-4363-a8b7-67f1456cf56f"; // Type = Person

        // The primary class (Primaer klasse)
        public const string PRIMAER_KLASSE_ROLLE_UUID = "a86c6581-ec85-412d-a655-31a1f1d5b14f"; // Rolle = Primær Klasse
        public const string KLASSE_TYPE_UUID = "267235ea-526d-4a18-8001-f2a0e563eba1"; // Type = Klasse

        // The Handlingsklasse (Handlingsklasse)
        public const string HANDLINGSKLASSE_ROLLE_UUID = "05ef7011-11a7-4e4c-a46b-3de6aa457fc3"; // Rolle = Handlingsklasse

        // The Archive (Behandlingsarkiv)
        public const string BEHANDLINGSARKIV_ROLLE_UUID = "a330ac07-8687-45b9-9bf2-21137eb0dbb0"; // Rolle = Behandlingsarkiv
        public const string ARKIV_TYPE_UUID = "94c2f5bb-649f-4a90-9b17-87fc74204b5a"; // Type = Arkiv

        // The master IT-system (IT-system Master)
        public const string MASTER_UUID = "251c24fd-57b0-4afc-9d73-b063d1957eb3"; // Rolle = Master
        public const string IT_SYSTEM_TYPE_UUID = "29fe1da2-897a-46cd-b635-b9be8e0bffd6"; // Type = IT-system

        // The sender IT-sytem (IT-system Afsender)
        public const string AFSENDER_TYPE_UUID = "1b3c6a6d-e977-4491-9bf8-b41ee6999f39"; // Rolle = Afsender

        #endregion

    }
}
