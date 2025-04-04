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
        public const string ConfigurationSectionNameForYdelseIndeks = "oioIdwsYdelseIndeksConfiguration";
        public const string ConfigurationSectionNameForBevilling = "oioIdwsBevillingConfiguration";

        #endregion

        #region Variables which MUST BE MODIFIED before running the code examples

        // UUID and name of your it-system in Fælleskommunalt Administrationssystem
        public const string ANVENDER_SYSTEM_UUID = "aa165144-952f-434e-b3b0-2d466673ed9c"; // Change to the UUID of your system
        public const string ANVENDER_SYSTEM_NAVN = "FKI-KOMBIT Test med Silverbullet"; // Change to the name of your system

        public const string AFSENDER_SYSTEM_UUID = "1b3c6a6d-e977-4491-9bf8-b41ee6999f39"; // Change to the UUID of your system
        public const string AFSENDER_SYSTEM_NAVN = "FKI-KOMBIT Test med Silverbullet AFSENDER"; // Change to the name of your system

        public const string IT_SYSTEM_MASTER_TYPE_UUID = "29fe1da2-897a-46cd-b635-b9be8e0bffd6";

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

        #region Variables for YdelsesIndeks - to be revised by KOMBIT

        public const string BEVILLING_UUID_IDENTIFIKATOR = "2222aaaa-22aa-33bb-44cc-222222aaaaaa"; // bevillingUUIDIdentifikator
        public const string BEVILLINGS_EGENSKABER_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // bevillingsegenskaberVirkningFra
        public const string BEVILLINGS_EGENSKABER_VIRKNING_TIL = "2024-01-30T14:54:23.234+01:00"; // bevillingsegenskaberVirkningTil
        public const string BEVILLINGS_EGENSKABER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // bevillingsegenskaberAktoerRef
        public const string BEVILLINGS_EGENSKABER_AKTOER_TYPE_KODE = "Bruger"; // bevillingsegenskaberAktoerTypeKode
        public const string BEVILLINGS_EGENSKABER_BRUGERVENDT_NOEGLE = "2020-123456789"; // bevillingsegenskaberBrugervendtnoegle
        public const string BEVILLINGS_EGENSKABER_FOELSOMHED = "FORTROLIGE_PERSONOPLYSNINGER"; // bevillingsegenskaberFoelsomhed
        public const string BEVILGET_YDELSE_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // bevilgetYdelseVirkningFra
        public const string BEVILGET_YDELSE_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // bevilgetYdelseAktoerRef
        public const string BEVILGET_YDELSE_AKTOER_TYPE_KODE = "Bruger"; // bevilgetYdelseAktoerTypeKode
        public const string BEVILGET_YDELSE_ID = "1"; // bevilgetYdelseID
        public const string BEVILGET_YDELSE_NAVN = "Folkepension"; // bevilgetYdelseNavn
        public const string BEVILGET_YDELSE_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // bevilgetYdelseStardato
        public const string BEVILGET_YDELSE_SLUTDATO = "2024-01-31T14:54:23.234+01:00"; // bevilgetYdelseSlutdato
        public const string YDELSE_YDELSES_NAVN = "Grundbeløb - FOP"; // ydelseYdelsesnavn
        public const string BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE = "32.03.04"; // bevillingPrimaerKlasseBrugervendtNoegle
        public const string BEVILLING_PRIMAER_KLASSE_KlASSETITEL = "Folkepension"; // bevillingPrimaerKlasseKlassetitel
        public const string BEVILLING_PRIMAER_KLASSE_ROLLE_UUID = "ea909030-c5fa-4544-9b22-a0010d08ebe1"; // bevillingPrimaerKlasseRolleUuid
        public const string BEVILLING_KLASSE_TYPE_UUID = "7c51b9a8-d388-4e83-8c8b-ee3a90458d0b"; // bevillingKlasseTypeUuid
        public const string BEVILLING_PRIMAER_KLASSE_INDEKS = "1"; // bevillingPrimaerKlasseIndeks
        public const string BEVILLING_PRIMAER_KLASSE_REFERENCE_ID = "70355b26-6028-4e42-9eb1-1a93aa9890b1"; // bevillingPrimaerKlasseReferenceId
        public const string BEVILLINGS_SAG_BRUGERVENDT_NOEGLE = "2020-123456789"; // bevillingssagBrugervendtNoegle
        public const string BEVILLINGS_SAG_FULDT_NAVN = "Folkepension"; // bevillingssagFuldtNavn
        public const string BEVILLINGS_SAG_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // bevillingssagStartdato
        public const string BEVILLING_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // bevillingAktoerRef
        public const string BEVILLINGS_SAG_ROLLE_UUID = "31237487-787a-424f-8819-56aaedf00643"; // bevillingssagRolleUuid
        public const string BEVILLINGS_SAG_TYPE_UUID = "f08a4a13-2567-41d0-bf8d-3af754b03464"; // bevillingssagTypeUuid
        public const string BEVILLINGS_SAG_REFERENCE_ID = "1111aaaa-11aa-22bb-33cc-111111aaaaaa"; // bevillingssagReferenceID
        public const string BEVILLINGS_SAG_AKTOER_TYPE_KODE = "Bruger"; // bevillingssagAktoerTypeKode
        public const string BEVILLINGS_PART_BRUGERVENDT_NOEGLE = "ÆØÅ"; // bevillingspartBrugervendtNoegle
        public const string YDELSESMODTAGER_FULDT_NAVN = "Lonnie Pedersen"; // ydelsesmodtagerFuldtNavn
        public const string BEVILLINGS_PART_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // bevillingspartStartdato
        public const string BEVILLINGS_PART_AKTOER_TYPE_KODE = "Bruger"; // bevillingspartAktoerTypeKode
        public const string BEVILLING_EJER_AKTOER_TYPE_KODE = "Bruger"; // bevillingEjerAktoerTypeKode
        public const string BEVILLING_ANSVARLIG_AKTOER_TYPE_KODE = "Bruger"; // bevillingAnsvarligAktoerTypeKode
        public const string EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE = "Bruger"; // effektueringEgenskaberAktoerTypeKodeType
        public const string YDELSEEFFEKTUERING_AKTOER_TYPE_KODE = "Bruger"; // ydelseseffektueringAktoerTypeKode
        public const string EFFEKTUERING_EJER_AKTOER_TYPE_KODE = "Bruger"; // effektueringEjerAktoerTypeKode
        public const string EFFEKTUERINGS_MODTAGER_AKTOER_TYPE_KODE = "Bruger"; // effektueringsmodtagerAktoerTypeKode
        public const string YDELSESMODTAGER_AKTOER_TYPE_KODE = "ÆØÅ"; // ydelsesmodtagerAktoerTypeKode
        public const string BEVILLING_YDELSESMODTAGER_ROLLE_UUID = "93af57a7-7658-4fac-98da-9e5ac7a7d9a5"; // bevillingYdelsesmodtagerRolleUuid
        public const string BEVILLING_YDELSESMODTAGER_TYPE_UUID = "c59f1523-1786-48c7-baff-466de1db3320"; // bevillingYdelsesmodtagerTypeUuid
        public const string YDELSESMODTAGER_INDEKS = "1"; // ydelsesmodtagerIndeks
        public const string YDELSESMODTAGER_REFERENCE_ID = "urn:oio:cpr-nr:0123456789"; // ydelsesmodtagerReferenceId
        public const string BEVILLING_EJER_FULDT_NAVN = "Korsbaek Kommune"; // bevillingEjerFuldtNavn
        public const string BEVILLING_EJER_CVR_NR = "11111111"; // bevillingEjerCvrNr
        public const string BEVILLING_EJER_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // bevillingEjerStartdato
        public const string BEVILLING_EJER_SLUTDATO = "ÆØÅ"; // bevillingEjerSlutdato
        public const string BEVILLING_EJER_ROLLE_ID = "abdf4d3e-f113-4282-b13e-6cd32a82621c"; // bevillingEjerRolleUuid
        public const string BEVILLING_EJER_TYPE_UUID = "45b7dafb-d90e-41da-b30e-ba007e577a8a"; // bevillingEjerTypeUuid
        public const string BEVILLING_EJER_REFERENCE_ID = "0235dc7b-11c4-4ee5-b685-9f638f5cd032"; // bevillingEjerReferenceId
        public const string BEVILLING_ANSVARLIG_FULDT_NAVN = "Korsbaek Kommune"; // bevillingAnsvarligFuldtNavn
        public const string BEVILLING_ANSVARLIG_CVR_NR = "11111111"; // bevillingAnsvarligCvrNr
        public const string BEVILLING_ANSVARLIG_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // bevillingAnsvarligStartdato
        public const string BEVILLING_ANSVARLIG_ROLLE_UUID = "fbe1016a-170a-4dea-8652-2813c1a566c0"; // bevillingAnsvarligRolleUuid
        public const string BEVILLING_ANSVARLIG_TYPE_UUID = "4546cca2-838e-4e0d-a5bd-83757d603362"; // bevillingAnsvarligTypeUuid
        public const string BEVILLING_ANSVARLIG_INDEKS = "1"; // bevillingAnsvarligIndeks
        public const string BEVILLING_ANSVARLIG_REFERENCE_ID = "0235dc7b-11c4-4ee5-b685-9f638f5cd032"; // bevillingAnsvarligReferenceId
        public const string BEVILLING_LIVSCYKLUS_KODE = "Importeret"; // bevillingLivscykluskode
        public const string EFFEKTUERING_UUID_IDENTIFIKATOR = "3333aaaa-33aa-44bb-55cc-333333aaaaaa"; // effektueringUUIDIdentifikator
        public const string EFFEKTUERING_EGENSKABER_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // effektueringEgenskaberVirkningFra
        public const string EFFEKTUERING_EGENSKABER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // effektueringEgenskaberAktoerRef
        public const string EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE = "1607371985039P"; // effektueringEgenskaberBrugervendtNoegle
        public const string EFFEKTUERING_EGENSKABER_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // effektueringEgenskaberStartdato
        public const string EFFEKTUERING_EGENSKABER_SLUTDATO = "2024-01-31T14:54:23.234+01:00"; // effektueringEgenskaberSlutdato
        public const string EFFEKTUERING_EGENSKABER_SAMLET_BRUTTOBELOEB = "5.942"; // effektueringEgenskaberSamletBruttobeloeb
        public const string EFFEKTUERING_EGENSKABER_DISPOSITIONSDATO = "2024-01-31T14:54:23.234+01:00"; // effektueringEgenskaberDispositionsdato
        public const string EFFEKTUERING_EGENSKABER_BELOEB_EFTER_SKAT_ATP = "3.744"; // effektueringEgenskaberBeloebEfterSkatATP
        public const string EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING = "3.744"; // effektueringEgenskaberBeloebSendtTilUdbetaling
        public const string EFFEKTUERING_EGENSKABER_UDBETALINGSAFDELING = "Korsbaek Kommune"; // effektueringEgenskaberUdbetalingsafdeling
        public const string YDELSEEFFEKTUERING_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // ydelseseffektueringVirkningFra
        public const string YDELSEEFFEKTUERING_VIRKNING_TIL = "2024-01-31T14:54:23.234+01:00"; // ydelseseffektueringVirkningTil
        public const string YDELSEEFFEKTUERING_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // ydelseseffektueringAktoerRef
        public const string YDELSEEFFEKTUERING_ROLLE_UUID = "ccc9d91b-9a4c-4ada-9be4-795ca068e89d"; // ydelseseffektueringRolleUuid
        public const string YDELSEEFFEKTUERING_TYPE_UUID = "4fd9d6c1-2939-4bfe-b803-ab0b3904bd2f"; // ydelseseffektueringTypeUuid
        public const string YDELSEEFFEKTUERING_INDEKS = "1"; // ydelseseffektueringIndeks
        public const string YDELSEEFFEKTUERING_REFERENCE_ID = "6f83de8c-2644-4195-9d1a-f022ef863027"; // ydelseseffektueringReferenceId
        public const string YDELSEEFFEKTUERING_YDELSESPERIODE_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // ydelseseffektueringYdelsesperiodeStartdato
        public const string YDELSEEFFEKTUERING_YDELSESPERIODE_SLUTDATO = "2024-01-31T14:54:23.234+01:00"; // ydelseseffektueringYdelsesperiodeSlutdato
        public const string YDELSEEFFEKTUERING_YDELSESBELOEB = "5.942"; // ydelseseffektueringYdelsesbeloeb
        public const string YDELSEEFFEKTUERING_KLASSIFIKATIONSBESKRIVELSE = "32.03.04"; // ydelseseffektueringKlassifikationsbeskrivelse
        public const string YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_UUID_IDENTIFIKATOR = "2222aaaa-22aa-33bb-44cc-222222aaaaaa"; // ydelseseffektueringBevilgetYdelseRefUUIDIdentifikator
        public const string YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_BEVILGET_YDELSE_ID = "1"; // ydelseseffektueringBevilgetYdelseRefBevilgetYdelseId
        public const string EFFEKTUERING_EJER_FULDT_NAVN = "Korsbaek Kommune"; // effektueringEjerFuldtNavn
        public const string EFFEKTUERING_EJER_CVR_NR = "11111111"; // effektueringEjerCVRNr
        public const string EFFEKTUERING_EJER_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // effektueringEjerVirkningFra
        public const string EFFEKTUERING_EJER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // effektueringEjerAktoerRef
        public const string EFFEKTUERING_EJER_ROLLE_UUID = "a91824c4-da1d-47f9-bce2-5d6597879415"; // effektueringEjerRolleUuid
        public const string EFFEKTUERING_EJER_TYPE_UUID = "c622654c-d87f-4ac7-9a42-d0580253b979"; // effektueringEjerTypeUuid
        public const string EFFEKTUERING_EJER_REFERENCE_ID = "0235dc7b-11c4-4ee5-b685-9f638f5cd032"; // effektueringEjerReferenceID
        public const string EFFEKTUERINGS_MODTAGER_FULDT_NAVN = "Lonnie Pedersen"; // effektueringsmodtagerFuldtNavn
        public const string EFFEKTUERINGS_MODTAGER_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; // effektueringsmodtagerVirkningfra
        public const string EFFEKTUERINGS_MODTAGER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // effektueringsmodtagerAktoerRef
        public const string EFFEKTUERINGS_MODTAGER_ROLLE_UUID = "68d4b903-acae-4f2f-aafc-45bd999ed81f"; // effektueringModtagerRolleUuid
        public const string EFFEKTUERINGS_MODTAGER_TYPE_UUID = "480769fd-9744-4859-950f-95cbb5633d36"; // effektueringModtagerTypeUuid
        public const string EFFEKTUERINGS_MODTAGER_REFERENCE_ID = "urn:oio:cpr-nr:0123456789"; // effektueringsmodtagerReferenceId
        public const string YDELSE_LIVSCYKLUS_KODE = "Importeret"; // ydelseLivscyklusKode
        public const string YDELSE_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // ydelseAktoerRef
        public const string YDELSE_ROLLE_UUID = "6ebd938f-0bbf-4142-a65c-fefe15e9f192"; // ydelseRolleUuid
        public const string YDELSE_TYPE_UUID = "3aa45cbd-94c3-4601-84a6-66ce0f157dda"; // ydelseTypeUuid
        public const string YDELSE_REFERENCE_ID = "2637c22e-06b8-4f8c-9520-42e4de177203"; // ydelseReferenceId
        public const string EFFEKTUERINGS_PLAN_ID = "1"; // effektueringsplanID
        public const string EFFEKTUERINGS_PLAN_STARTDATO = "2024-01-01T14:54:23.234+01:00"; // effektueringsplanStardato
        public const string EFFEKTUERINGS_PLAN_SLUTDATO = "2024-01-31T14:54:23.234+01:00"; // effektueringsplanSlutdato
        public const string EFFEKTUERINGS_PLAN_BEREGNINGSFREKVENS = "7772f4e3-b06d-4ef8-b599-9134cf3fdee4"; // effektueringsplanBeregningsfrekvens
        public const string EFFEKTUERINGS_PLAN_FORUD_BAGUD = "Bagud"; // effektueringsplanForudBagud
        public const string EFFEKTUERINGS_PLAN_DISPOSITIONSDAG = "Sidste bankdag i måneden"; // effektueringsplanDispositionsdag
        public const string EFFEKTUERINGS_PLAN_YDELSESBELOEB = "6694"; // effektueringsplanYdelsesbeloeb
        public const string BEVILLINGS_SAG_VIRKNING_FRA = "ÆØÅ"; // bevillingssagVirkningFra
        public const string BEVILLINGS_SAG_AKTOER_REF = "ÆØÅ"; // bevillingssagAktoerRef
        public const string YDELSESMODTAGER_VIRKNING_FRA = "ÆØÅ"; // ydelsesmodtagerVirkningFra
        public const string YDELSESMODTAGER_AKTOER_REF = "ÆØÅ"; // ydelsesmodtagerAktoerRef
        public const string BEVILLING_EJER_BRUGERVENDT_NOEGLE = "ÆØÅ"; // bevillingEjerBrugervendtNoegle
        public const string BEVILLING_EJER_VIRKNING_FRA = "ÆØÅ"; // bevillingEjerVirkningFra
        public const string BEVILLING_EJER_AKTOER_REF = "ÆØÅ"; // bevillingEjerAktoerRef
        public const string BEVILLING_ANSVARLIG_VIRKNING_FRA = "ÆØÅ"; // bevillingAnsvarligVirkningFra
        public const string BEVILLING_ANSVARLIG_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; // bevillingAnsvarligAktoerRef
        public const string YDELSE_INDEKS = "1"; // ydelseIndeks
        public const string SECURITY_PROFILE_ROLE = "4becdcec-c8bd-44a4-ac0b-5a0162986840"; //
        public const string SECURITY_PROFILE_TYPE = "2b808769-8d09-4aa3-ac28-f8ac3526010f"; //
        public const string SECURITY_PROFILE_REFERENCE_ID = "0235dc7b-11c4-4ee5-b685-9f638f5cd032"; //
        public const string SECURITY_PROFILE_INDEKS = "1"; //
        public const string BEVILLINGS_SAG_INDEKS = "et laxas"; //
        public const string YDELSESMODTAGER_FULDT_NAVN_MODTAGER = "Lonnie Pedersen Modtager"; //
        public const string BEVILLINGS_SAG_MODTAGER_ROLLE_UUID = "3102fa7e-f56e-4510-b0d4-1650c590dc3b"; //
        public const string BEVILLING_TIDSPUNKT = "2024-01-01T14:54:23.234+01:00"; //
        public const string IT_SYSTEM_MASTER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; //
        public const string IT_SYSTEM_MASTER_AKTOER_TYPE_KODE_TYPE = "Bruger"; //
        public const string IT_SYSTEM_MASTER_ROLE_UUID = "251c24fd-57b0-4afc-9d73-b063d1957eb3"; //
        public const string IT_SYSTEM_SENDER_SYSTEM_NAME = "STS testklient 29"; //
        public const string IT_SYSTEM_SENDER_START_DATE = "2024-01-01T14:54:23.234+01:00"; //
        public const string IT_SYSTEM_SENDER_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; //
        public const string IT_SYSTEM_SENDER_AKTOER_TYPE_KODE_TYPE = "Bruger"; //
        public const string IT_SYSTEM_SENDER_ROLE = "1b3c6a6d-e977-4491-9bf8-b41ee6999f39"; //
        public const string IT_SYSTEM_SENDER_TYPE = "29fe1da2-897a-46cd-b635-b9be8e0bffd6"; //
        public const string IT_SYSTEM_SENDER_REFERENCE_ID = "ba537e12-8b0c-44b1-9de7-f75803a4e091"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_FULDT_NAVN = "Korsbaek Kommune"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_CVR_NR = "11111111"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_VIRKNING_FRA = "2024-01-01T14:54:23.234+01:00"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_AKTOER_REF = "9999aaaa-11aa-22bb-33cc-111111aaaaaa"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_AKTOER_TYPE_KODE = "Bruger"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_ROLLE_UUiD = "a1ff36be-b3fb-4e1f-aac0-9d3313070ecb"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_TYPE_UUID = "c622654c-d87f-4ac7-9a42-d0580253b979"; //
        public const string EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_REFERENCE_ID = "0235dc7b-11c4-4ee5-b685-9f638f5cd032"; //
        #endregion

    }
}
