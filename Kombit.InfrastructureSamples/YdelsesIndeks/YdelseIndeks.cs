using Kombit.InfrastructureSamples.YdelseIndeksService;
using Kombit.InfrastructureSamples.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using Digst.OioIdws.OioWsTrustCore;
using Digst.OioIdws.SoapCore;

namespace Kombit.InfrastructureSamples.YdelsesIndeks
{
    public class YdelseIndeks
    {
        private GenericXmlSecurityToken token;
        private YdelseIndeksPortType port;

        public importerResponse importer()
        {
            importerRequest request = new importerRequest()
            {
                ImporterYdelseIndeksInput = new object[] { new ImportInputType() {
                        BevillingIndeks = new BevillingIndeksType() {
                            UdenNotifikation = false, // Follow up
                            UdenNotifikationSpecified = true,
                            UUIDIdentifikator = ConfigVariables.BEVILLING_UUID_IDENTIFIKATOR,

                            Registrering = new[] { new RegistreringType2() {
                                AttributListe = new AttributListeType() {
                                    Egenskaber = new[] { new EgenskaberType() {
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType() { // Follow up
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_TYPE_KODE), // Mandatory
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = , // Optional
                                            },
                                            BrugervendtNoegle = ConfigVariables.BEVILLINGS_EGENSKABER_BRUGERVENDT_NOEGLE, // Mandatory
                                            //Bevillingstartdato = , // Filled by the Indeks
                                            //Bevillingslutdato = , // Filled by the Indeks
                                        //  Begrundelse = , // Optional
                                            Foelsomhed = (FoelsomhedType) Enum.Parse(typeof(FoelsomhedType), ConfigVariables.BEVILLINGS_EGENSKABER_FOELSOMHED), // Mandatory
                                            FoelsomhedSpecified = true,
                                    }
                                    },
                                    BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                            Virkning = new VirkningType {
                                                FraTidspunkt = new TidspunktType() { // Follow up
                                                    Item = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA),
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = // Optional
                                            },
                                            Id = ConfigVariables.BEVILGET_YDELSE_ID,
                                            Navn = ConfigVariables.BEVILGET_YDELSE_NAVN,
                                            BevilgetYdelseStartdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_STARTDATO),
                                            BevilgetYdelseSlutdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_SLUTDATO),
                                            BevilgetYdelseStartdatoSpecified = true, // Follow up
                                            BevilgetYdelseSlutdatoSpecified = true, // Follow up
                                        //  Begrundelse = , // Optional
                                        //  Tilbagebetalingspligtig = Boolean.Parse(), // Optional
                                        //  TilbagebetalingspligtigSpecified = true, // Optional
                                        //  Meddelelse = ConfigVariables., // Optional
                                            ItSystem = new [] { new ItSystemRelationType() {
                                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                            //  SystemURI = ,
                                                Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                //Indeks = , // Not to be filled
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                            },
                                            new ItSystemRelationType() {
                                                SystemNavn = ConfigVariables.AFSENDER_SYSTEM_NAVN,
                                            //  SystemURI = ,
                                                Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.AFSENDER_SYSTEM_UUID, // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                //Indeks = , // Not to be filled
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                            }
                                            },
                                            Ydelse = new YdelseRelationType() {
                                                Ydelsesnavn = ConfigVariables.YDELSE_YDELSES_NAVN,
                                                Klassifikation = new BevillingsklasseRelationType() {
                                                    BrugervendtNoegle = ConfigVariables.BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE,
                                                    Klassetitel = ConfigVariables.BEVILLING_PRIMAER_KLASSE_KlASSETITEL,
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = Guid.NewGuid().ToString(),
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                },
                                                 Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_KLASSE_TYPE_UUID, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS, // Mandatory
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                            }

                                    }

                                    }
                                },
                                TilstandListe = new TilstandListeType(),
                                RelationListe = new RelationListeType() {
                                    Bevillingssag = new[] {
                                        new BevillingIndeksSagRelationType() {
                                            BrugervendtNoegle = ConfigVariables.BEVILLINGS_SAG_BRUGERVENDT_NOEGLE, // Mandatory
                                            FuldtNavn = ConfigVariables.BEVILLINGS_SAG_FULDT_NAVN, // Mandatory / Case TItle
                                            Virkning = new VirkningType { // Follow up
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_SAG_STARTDATO),
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_AKTOER_REF, // Mandatory
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_SAG_AKTOER_TYPE_KODE), // Mandatory
                                                AktoerTypeKodeSpecified = true,
                                            //  NoteTekst = ConfigVariables.
                                            },
                                            Rolle = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLINGS_SAG_ROLLE_UUID, // Madatory 
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLINGS_SAG_TYPE_UUID, // Mandatory
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                          Indeks = ConfigVariables.BEVILLINGS_SAG_INDEKS, // 
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLINGS_SAG_REFERENCE_ID, // Mandatory  
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                        }
                                    },
                                    Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                        //BrugervendtNoegle = ConfigVariables.BEVILLINGS_PART_BRUGERVENDT_NOEGLE,
                                        FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN_MODTAGER,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_PART_STARTDATO),
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_PART_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLINGS_SAG_MODTAGER_ROLLE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        //Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS, // Mandatory
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // Mandatory
                                            ItemElementName = ItemChoiceType.URNIdentifikator
                                        },
                                    },
                                    new BevillingIndeksPartRelationType() {
                                        //BrugervendtNoegle = ConfigVariables.BEVILLINGS_PART_BRUGERVENDT_NOEGLE,
                                        FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_PART_STARTDATO),
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_PART_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_ROLLE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS, // Mandatory
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // Mandatory
                                            ItemElementName = ItemChoiceType.URNIdentifikator
                                        },
                                    },
                                    },
                                    // Bevillings Ejer / Benefit Owner
                                    Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.BEVILLING_EJER_FULDT_NAVN,
                                        CVRnr = ConfigVariables.BEVILLING_EJER_CVR_NR,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLING_EJER_STARTDATO),
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_EJER_AKTOER_TYPE_KODE), // Follow up
                                            AktoerTypeKodeSpecified = true,
                                            //NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_EJER_ROLLE_ID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_EJER_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_EJER_REFERENCE_ID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    }
                                    ,
                                    // Bevillings Ansvarlig / Benefit Responsible
                                    new BevillingIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.BEVILLING_ANSVARLIG_FULDT_NAVN,
                                        CVRnr = ConfigVariables.BEVILLING_ANSVARLIG_CVR_NR,
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLING_ANSVARLIG_STARTDATO),
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_ANSVARLIG_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                            //NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_ANSVARLIG_ROLLE_UUID, // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_ANSVARLIG_TYPE_UUID, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.BEVILLING_ANSVARLIG_INDEKS,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_ANSVARLIG_REFERENCE_ID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    }
                                    },
                                    Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item =  DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                            },
                                            TilTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_TIL),
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.BEVILLING_ANSVARLIG_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_ANSVARLIG_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.SECURITY_PROFILE_ROLE, // 
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.SECURITY_PROFILE_TYPE, // 
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.SECURITY_PROFILE_INDEKS, //
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.SECURITY_PROFILE_REFERENCE_ID, // 
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        }
                                    }
                                    }

                                },
                                
                            //  NoteTekst = ConfigVariables.,
                                Tidspunkt = DateTime.Parse(ConfigVariables.BEVILLING_TIDSPUNKT),
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE),
                                LivscyklusKodeSpecified = true, // Follow up
                            }
                            },

                        }


                }, new ImportInputType1() {
                    OekonomiskEffektueringIndeks = new OekonomiskEffektueringIndeksType() {
                        UUIDIdentifikator = ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR,
                        Registrering = new [] {
                            new RegistreringType3()
                            {
                                AttributListe = new AttributListeType1() {
                                    Egenskaber = new[] { new EgenskaberType1()  {
                                        Virkning = new VirkningType { // Follow up
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_VIRKNING_FRA), // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        BrugervendtNoegle = ConfigVariables.EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE,
                                        Startdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_STARTDATO), // DateTime.Now
                                        Slutdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_SLUTDATO),
                                        StartdatoSpecified = true,
                                        SlutdatoSpecified = true,
                                        SamletBruttobeloeb = ConfigVariables.EFFEKTUERING_EGENSKABER_SAMLET_BRUTTOBELOEB,
                                        Dispositionsdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_DISPOSITIONSDATO),
                                        DispositionsdatoSpecified = true,
                                        BeloebEfterSkatATP = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_EFTER_SKAT_ATP,
                                        BeloebSendtTilUdbetaling = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING,
                                    //  BeloebUdbetalt = ,
                                        Udbetalingsafdeling = ConfigVariables.EFFEKTUERING_EGENSKABER_UDBETALINGSAFDELING,
                                    //  SendtTilUdbetalingTekst = ,
                                    //  UdbetaltTekst = 
                                    }
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                },

                                TilstandListe = new TilstandListeType1(),
                                RelationListe = new RelationListeType1() {
                                    OekonomiskYdelseEffektueringRelation = new[] {
                                        new OekonomiskYdelseEffektueringRelationType() {
                                            Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_VIRKNING_FRA), // DateTime.Now,
                                            },
                                            TilTidspunkt  = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_VIRKNING_TIL), // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.YDELSEEFFEKTUERING_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSEEFFEKTUERING_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = ConfigVariables. // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.YDELSEEFFEKTUERING_ROLLE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.YDELSEEFFEKTUERING_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.YDELSEEFFEKTUERING_INDEKS,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.YDELSEEFFEKTUERING_REFERENCE_ID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        },
                                        */
                                        YdelsesperiodeStartdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_STARTDATO), // DateTime.Now,
                                        YdelsesperiodeSlutdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_SLUTDATO),
                                        YdelsesperiodeStartdatoSpecified = true,
                                        YdelsesperiodeSlutdatoSpecified = true,
                                        Ydelsesbeloeb = ConfigVariables.YDELSEEFFEKTUERING_YDELSESBELOEB,
                                        Klassifikationsbeskrivelse = ConfigVariables.YDELSEEFFEKTUERING_KLASSIFIKATIONSBESKRIVELSE,
                                        BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                            UUIDIdentifikator = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_UUID_IDENTIFIKATOR,
                                            BevilgetYdelseId = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_BEVILGET_YDELSE_ID
                                        }
                                        }
                                    },
                                    // Ejer / Aktoer
                                    Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.EFFEKTUERING_EJER_FULDT_NAVN,
                                        CVRnr = ConfigVariables.EFFEKTUERING_EJER_CVR_NR,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EJER_VIRKNING_FRA) // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EFFEKTUERING_EJER_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EJER_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERING_EJER_ROLLE_UUID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERING_EJER_TYPE_UUID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERING_EJER_REFERENCE_ID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    },
                                    // Oekonomisk Effektueringsaktoer.Udbetalende Enhed (Paying Unit)
                                    new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        FuldtNavn = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_FULDT_NAVN,
                                        CVRnr = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_CVR_NR,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_VIRKNING_FRA) // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_ROLLE_UUiD,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_TYPE_UUID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_AKTOER_UDBETALENDE_ENHED_REFERENCE_ID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    ItSystem = new[] { new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA) // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_MASTER_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.IT_SYSTEM_MASTER_AKTOER_TYPE_KODE_TYPE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_MASTER_ROLE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    //  Indeks = , // Never to be used
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }, new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.IT_SYSTEM_SENDER_SYSTEM_NAME,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.IT_SYSTEM_SENDER_START_DATE) // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_SENDER_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.IT_SYSTEM_SENDER_AKTOER_TYPE_KODE_TYPE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = // Optional
                                        },
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_SENDER_ROLE, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_SENDER_TYPE, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    //  Indeks = , // Never to be used
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_SENDER_REFERENCE_ID, // Mandatory
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                    //  BrugervendtNoegle = , // Optional
                                        FuldtNavn = ConfigVariables.EFFEKTUERINGS_MODTAGER_FULDT_NAVN,
                                        Virkning = new VirkningType {
                                            FraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_MODTAGER_VIRKNING_FRA), // DateTime.Now,
                                            },
                                            AktoerRef = new UnikIdType() {
                                                Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_REF,
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_TYPE_KODE),
                                            AktoerTypeKodeSpecified = true,
                                        //  NoteTekst = ConfigVariables.
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_ROLLE_UUID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_TYPE_UUID,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                    //  Indeks = , //
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_REFERENCE_ID,
                                            ItemElementName = ItemChoiceType.URNIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    }
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                },
                            //  NoteTekst = ConfigVariables.,
                                Tidspunkt = DateTime.Now, // Mandatory / Dateformat YYYY-MM-DDThh:mm:ss:ssssTZD / Filled by the 'Fagsystem'
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = ConfigVariables.YDELSE_AKTOER_REF,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.YDELSE_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                LivscyklusKodeSpecified = true,
                            }
                        }
                    }
                }
            },
                RequestHeader = RequestHeader
            };

            return Port.importer(request);
        }

        public opdaterResponse opdater()
        {
            opdaterRequest request = new opdaterRequest()
            {
                OpdaterYdelseIndeksInput = new RetInputType[] {
                    new OpdaterBevillingIndeksInputType()
                    {
                        AttributListe = new AttributListeType()
                        {
                            Egenskaber = new[] { new EgenskaberType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                BrugervendtNoegle = ConfigVariables.BEVILLINGS_EGENSKABER_BRUGERVENDT_NOEGLE,
                                //Bevillingstartdato = ConfigVariables.,
                                //Bevillingslutdato = ConfigVariables.,
                                //Begrundelse = ConfigVariables.,
                                Foelsomhed = (FoelsomhedType) Enum.Parse(typeof(FoelsomhedType), ConfigVariables.BEVILLINGS_EGENSKABER_FOELSOMHED),
                                FoelsomhedSpecified = true
                            }
                            },
                            BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Id = ConfigVariables.BEVILGET_YDELSE_ID,
                                Navn = ConfigVariables.BEVILGET_YDELSE_NAVN,
                                BevilgetYdelseStartdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_STARTDATO),
                                BevilgetYdelseStartdatoSpecified = true,
                                BevilgetYdelseSlutdatoSpecified = false,
                                //Begrundelse = ConfigVariables.,
                                //Tilbagebetalingspligtig = Boolean.Parse(ConfigVariables.),
                                TilbagebetalingspligtigSpecified = false,
                                //Meddelelse = ConfigVariables.,
                                ItSystem = new [] { new ItSystemRelationType() {
                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                    //SystemURI = ConfigVariables.,
                                    Rolle = new UnikIdType() {
                                            Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    //Indeks = ConfigVariables.,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                }, new ItSystemRelationType() {
                                    SystemNavn = ConfigVariables.AFSENDER_SYSTEM_NAVN,
                                    //SystemURI = ConfigVariables.,
                                    Rolle = new UnikIdType() {
                                            Item = ConfigVariables.AFSENDER_SYSTEM_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    //Indeks = ConfigVariables.,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                }
                                },
                                Ydelse = new YdelseRelationType() {
                                    Ydelsesnavn = ConfigVariables.YDELSE_YDELSES_NAVN,
                                    Klassifikation = new BevillingsklasseRelationType() {
                                        BrugervendtNoegle = ConfigVariables.BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE,
                                        Klassetitel = ConfigVariables.BEVILLING_PRIMAER_KLASSE_KlASSETITEL,
                                        Rolle = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_KLASSE_TYPE_UUID, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS,
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        /*
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                        */
                                    },
                                    Rolle = new UnikIdType() {
                                        Item = ConfigVariables.YDELSE_ROLLE_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.YDELSE_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = ConfigVariables.YDELSE_INDEKS,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.YDELSE_REFERENCE_ID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                },
                                Items = new [] { new OekonomiskEffektueringsplanType() {
                                    Id = ConfigVariables.EFFEKTUERINGS_PLAN_ID,
                                    EffektueringsplanStartdato = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_PLAN_STARTDATO),
                                    EffektueringsplanSlutdato = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_PLAN_SLUTDATO),
                                    EffektueringsplanStartdatoSpecified = true,
                                    EffektueringsplanSlutdatoSpecified = true,
                                    Beregningsfrekvens = ConfigVariables.EFFEKTUERINGS_PLAN_BEREGNINGSFREKVENS,
                                    ForudBagud = (OekonomiskEffektueringsplanTypeForudBagud) Enum.Parse(typeof(OekonomiskEffektueringsplanTypeForudBagud), ConfigVariables.EFFEKTUERINGS_PLAN_FORUD_BAGUD),
                                    Dispositionsdag = ConfigVariables.EFFEKTUERINGS_PLAN_DISPOSITIONSDAG,
                                    Ydelsesbeloeb = ConfigVariables.EFFEKTUERINGS_PLAN_YDELSESBELOEB,
                                    //ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                    ForudBagudSpecified = true,
                                    ManueltGodkendesSpecified = false
                                }
                                }
                            }
                            }
                        },
                        TilstandListe = new TilstandListeType() { // FOLLOW UP
                            /*
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                            */
                        },
                        RelationListe = new RelationListeType() {
                            Bevillingssag = new[] {
                                new BevillingIndeksSagRelationType() {
                                    BrugervendtNoegle = ConfigVariables.BEVILLINGS_SAG_BRUGERVENDT_NOEGLE,
                                    FuldtNavn = ConfigVariables.BEVILLINGS_SAG_FULDT_NAVN,
                                    Virkning = new VirkningType {
                                        FraTidspunkt = new TidspunktType() {
                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_SAG_VIRKNING_FRA),
                                        },
                                        AktoerRef = new UnikIdType() {
                                            Item = ConfigVariables.BEVILLINGS_SAG_AKTOER_REF,
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_SAG_AKTOER_TYPE_KODE),
                                        AktoerTypeKodeSpecified = true,
                                        //NoteTekst = ConfigVariables.
                                    },
                                    Rolle = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLINGS_SAG_ROLLE_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLINGS_SAG_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = ConfigVariables.BEVILLINGS_SAG_INDEKS,
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLINGS_SAG_REFERENCE_ID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    /*
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                    */
                                }
                            },
                            Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                //BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.YDELSESMODTAGER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.YDELSESMODTAGER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSESMODTAGER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_ROLLE_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.URNIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            }
                            },
                            Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                //BrugervendtNoegle = ConfigVariables.BEVILLING_EJER_BRUGERVENDT_NOEGLE,
                                FuldtNavn = ConfigVariables.BEVILLING_EJER_FULDT_NAVN,
                                CVRnr = ConfigVariables.BEVILLING_EJER_CVR_NR,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.BEVILLING_EJER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLING_EJER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_EJER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_EJER_ROLLE_ID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_EJER_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                //Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_EJER_REFERENCE_ID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            },
                            new BevillingIndeksAktoerRelationType() {
                                //BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.BEVILLING_ANSVARLIG_FULDT_NAVN,
                                CVRnr = ConfigVariables.BEVILLING_ANSVARLIG_CVR_NR,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.BEVILLING_ANSVARLIG_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.BEVILLING_ANSVARLIG_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_ANSVARLIG_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_ANSVARLIG_ROLLE_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_ANSVARLIG_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.BEVILLING_ANSVARLIG_INDEKS,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.BEVILLING_ANSVARLIG_REFERENCE_ID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            },
                            },
                            /*
                            Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                    AktoerTypeKodeSpecified = true,
                                    NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables., // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables., // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            }
                            */
                        },
                            
                        //NoteTekst = ConfigVariables.,
                        Tidspunkt = DateTime.Now,
                        //UdenNotifikation = Boolean.Parse(ConfigVariables.),
                        UdenNotifikationSpecified = false,
                        UUIDIdentifikator = ConfigVariables.BEVILLING_UUID_IDENTIFIKATOR
                    },
                    new OpdaterOekonomiskEffektueringIndeksInputType() {
                        AttributListe = new AttributListeType1() {
                            Egenskaber = new[] { new EgenskaberType1()  {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                BrugervendtNoegle = ConfigVariables.EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE,
                                Startdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_STARTDATO),
                                Slutdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_SLUTDATO),
                                StartdatoSpecified = true,
                                SlutdatoSpecified = true,
                                SamletBruttobeloeb = ConfigVariables.EFFEKTUERING_EGENSKABER_SAMLET_BRUTTOBELOEB,
                                Dispositionsdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_DISPOSITIONSDATO),
                                DispositionsdatoSpecified = true,
                                BeloebEfterSkatATP = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_EFTER_SKAT_ATP,
                                BeloebSendtTilUdbetaling = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING,
                                BeloebUdbetalt = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING,
                                Udbetalingsafdeling = ConfigVariables.EFFEKTUERING_EGENSKABER_UDBETALINGSAFDELING,
                                //SendtTilUdbetalingTekst = ConfigVariables.,
                                //UdbetaltTekst = ConfigVariables.
                            }
                            },
                            /*
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                            */
                        },
                        TilstandListe = new TilstandListeType1(),
                        RelationListe = new RelationListeType1() {
                            OekonomiskYdelseEffektueringRelation = new[] {
                                new OekonomiskYdelseEffektueringRelationType() {
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.YDELSEEFFEKTUERING_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSEEFFEKTUERING_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.YDELSEEFFEKTUERING_ROLLE_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.YDELSEEFFEKTUERING_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = ConfigVariables.YDELSEEFFEKTUERING_INDEKS,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.YDELSEEFFEKTUERING_REFERENCE_ID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                },
                                */
                                YdelsesperiodeStartdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_STARTDATO),
                                YdelsesperiodeSlutdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_SLUTDATO),
                                YdelsesperiodeStartdatoSpecified = true,
                                YdelsesperiodeSlutdatoSpecified = true,
                                Ydelsesbeloeb = ConfigVariables.YDELSEEFFEKTUERING_YDELSESBELOEB,
                                Klassifikationsbeskrivelse = ConfigVariables.YDELSEEFFEKTUERING_KLASSIFIKATIONSBESKRIVELSE,
                                BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                    UUIDIdentifikator = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_UUID_IDENTIFIKATOR,
                                    BevilgetYdelseId = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_BEVILGET_YDELSE_ID
                                }
                                }
                            },
                            Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                //BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.EFFEKTUERING_EJER_FULDT_NAVN,
                                CVRnr = ConfigVariables.EFFEKTUERING_EJER_CVR_NR,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EJER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.EFFEKTUERING_EJER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EJER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERING_EJER_ROLLE_UUID,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERING_EJER_TYPE_UUID,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                //Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERING_EJER_REFERENCE_ID,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            }
                            },
                            ItSystem = new[] { new ItSystemRelationType1() {
                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.IT_SYSTEM_MASTER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.IT_SYSTEM_MASTER_AKTOER_TYPE_KODE_TYPE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                //Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            }
                            },
                            OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                //BrugervendtNoegle = ConfigVariables.,
                                FuldtNavn = ConfigVariables.EFFEKTUERINGS_MODTAGER_FULDT_NAVN,
                                Virkning = new VirkningType {
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_MODTAGER_VIRKNING_FRA),
                                    },
                                    AktoerRef = new UnikIdType() {
                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_REF,
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_TYPE_KODE),
                                    AktoerTypeKodeSpecified = true,
                                    //NoteTekst = ConfigVariables.
                                },
                                Rolle = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_ROLLE_UUID,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_TYPE_UUID,
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                //Indeks = ConfigVariables.,
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_REFERENCE_ID,
                                    ItemElementName = ItemChoiceType.URNIdentifikator
                                },
                                /*
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                                */
                            }
                            },
                            /*
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                            */
                        },
                        //NoteTekst = ConfigVariables.,
                        Tidspunkt = DateTime.Now,
                        UUIDIdentifikator = ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR

                    }
                },
                RequestHeader = RequestHeader
            };

            return Port.opdater(request);
        }

        public fremsoegResponse fremsoeg()
            {
            fremsoegRequest request = new fremsoegRequest()
                {
                FremsoegYdelseIndeksInput = new FremsoegYdelseIndeksInputType()
                    {
                    BevillingUuid = new[] { ConfigVariables.BEVILLING_UUID_IDENTIFIKATOR },
                    OekonomiskEffektueringUuid = new[] { ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR },
                    SoegUdtryk = new SoegUdtrykType()
                        {
                        Items = new Object[] {
                                    new SoegUdtrykType()
                                    {
                                        Items = new Object[] {
                                        new SoegInputType1() {
                                            AttributListe = new AttributListeType()
                                            {
                                                Egenskaber = new[] { new EgenskaberType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    BrugervendtNoegle = ConfigVariables.BEVILLINGS_EGENSKABER_BRUGERVENDT_NOEGLE,
                                                    Bevillingstartdato = ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA,
                                                    Foelsomhed = (FoelsomhedType) Enum.Parse(typeof(FoelsomhedType), ConfigVariables.BEVILLINGS_EGENSKABER_FOELSOMHED),
                                                    FoelsomhedSpecified = true,
                                                }
                                                },
                                                BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Id = ConfigVariables.BEVILGET_YDELSE_ID,
                                                    Navn = ConfigVariables.BEVILGET_YDELSE_NAVN,
                                                    BevilgetYdelseStartdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_STARTDATO),
                                                    BevilgetYdelseSlutdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_SLUTDATO),
                                                    BevilgetYdelseStartdatoSpecified = true,
                                                    BevilgetYdelseSlutdatoSpecified = true,
                                                    TilbagebetalingspligtigSpecified = false,
                                                    ItSystem = new [] { new ItSystemRelationType() {
                                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                        Rolle = new UnikIdType() {
                                                                Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }
                                                    }
                                                    },
                                                    Ydelse = new YdelseRelationType() {
                                                        Ydelsesnavn = ConfigVariables.YDELSE_YDELSES_NAVN,
                                                        Klassifikation = new BevillingsklasseRelationType() {
                                                            BrugervendtNoegle = ConfigVariables.BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE,
                                                            Klassetitel = ConfigVariables.BEVILLING_PRIMAER_KLASSE_KlASSETITEL
                                                        },
                                                        Rolle = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_KLASSE_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }
                                                        /*,
                                                            Rolle = new UnikIdType() {
                                                                Item = ConfigVariables., // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables., // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Indeks = ConfigVariables.,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables., // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                            Any = new [] {
                                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                            },
                                                            SenestAendretTidspunkt = DateTime.Now,
                                                            SenestAendretTidspunktSpecified = true
                                                        }*/
                                                    }/*,
                                                    Items = new [] { new OekonomiskEffektueringsplanType() {
                                                        Id = ConfigVariables.,
                                                        EffektueringsplanStartdato = DateTime.Now,
                                                        EffektueringsplanSlutdatoSpecified = false,
                                                        Beregningsfrekvens = ConfigVariables.,
                                                        ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                                        Dispositionsdag = ConfigVariables.,
                                                        Ydelsesbeloeb = ConfigVariables.,
                                                        ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                                        ForudBagudSpecified = true,
                                                        ManueltGodkendesSpecified = true
                                                    }
                                                    }*/
                                                }
                                                }
                                            },
                                            TilstandListe = new TilstandListeType(),
                                            RelationListe = new RelationListeType() {
                                                Bevillingssag = new[] {
                                                    new BevillingIndeksSagRelationType() {
                                                        BrugervendtNoegle = ConfigVariables.BEVILLINGS_SAG_BRUGERVENDT_NOEGLE,
                                                        FuldtNavn = ConfigVariables.BEVILLINGS_SAG_FULDT_NAVN,
                                                        Virkning = new VirkningType {
                                                            FraTidspunkt = new TidspunktType() {
                                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_SAG_VIRKNING_FRA),
                                                            },
                                                            TilTidspunkt = new TidspunktType() {
                                                                Item = true // DateTime.Now,
                                                            },
                                                            AktoerRef = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLINGS_SAG_AKTOER_REF,
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_SAG_AKTOER_TYPE_KODE),
                                                            AktoerTypeKodeSpecified = true,
                                                        },
                                                        Rolle = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_ROLLE_UUID, // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        //Indeks = ConfigVariables.,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_REFERENCE_ID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }/*,
                                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                            Any = new [] {
                                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                            },
                                                            SenestAendretTidspunkt = DateTime.Now,
                                                            SenestAendretTidspunktSpecified = true
                                                        }*/
                                                    }
                                                },
                                                Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.YDELSESMODTAGER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.YDELSESMODTAGER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSESMODTAGER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.URNIdentifikator,
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.BEVILLING_EJER_BRUGERVENDT_NOEGLE,
                                                    FuldtNavn = ConfigVariables.BEVILLING_EJER_FULDT_NAVN,
                                                    CVRnr = ConfigVariables.BEVILLING_EJER_CVR_NR,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLING_EJER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_EJER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_EJER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_EJER_ROLLE_ID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_EJER_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables., // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },/*
                                                Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Now,
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                        AktoerTypeKodeSpecified = true,
                                                        NoteTekst = ConfigVariables.
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables., // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables., // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables., // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }
                                                }
                                                }*/
                                            },
                                            SoegRegistrering = new SoegRegistreringType() {
                                                BrugerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                                LivscyklusKodeSpecified = true,
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true // DateTime.Now,
                                                },
                                            },
                                            FoersteResultatReference = "0",
                                            MaksimalAntalKvantitet = "50",
                                            SoegVirkning = new SoegVirkningType() {
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true // DateTime.Now,
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                AktoerTypeKodeSpecified = true,
                                            },
                                            SoegStsFraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                            },
                                            SoegStsTilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                            }
                                        }

                                    },
                                    operation = AndOrType.OR,
                                    operationSpecified = true,
                                    ItemsElementName = new[] {
                                        ItemsChoiceType.SoegBevillingIndeks
                                    }
                                    },
                                    new SoegUdtrykType()
                                    {
                                        Items = new Object[] {
                                        new SoegInputType2() {
                                            FoersteResultatReference = "0",
                                            AttributListe = new AttributListeType1() {
                                                Egenskaber = new[] { new EgenskaberType1()  {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    BrugervendtNoegle = ConfigVariables.EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE,
                                                    Startdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_STARTDATO),
                                                    Slutdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_SLUTDATO),
                                                    StartdatoSpecified = true,
                                                    SlutdatoSpecified = true,
                                                    SamletBruttobeloeb = ConfigVariables.EFFEKTUERING_EGENSKABER_SAMLET_BRUTTOBELOEB,
                                                    Dispositionsdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_DISPOSITIONSDATO),
                                                    DispositionsdatoSpecified = true,
                                                    BeloebEfterSkatATP = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_EFTER_SKAT_ATP,
                                                    BeloebSendtTilUdbetaling = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING,
                                                    //BeloebUdbetalt = ConfigVariables.,
                                                    Udbetalingsafdeling = ConfigVariables.EFFEKTUERING_EGENSKABER_UDBETALINGSAFDELING,
                                                    //SendtTilUdbetalingTekst = ConfigVariables.,
                                                    //UdbetaltTekst = ConfigVariables.
                                                }
                                                }/*,
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }*/
                                            },
                                            TilstandListe = new TilstandListeType1(),
                                            RelationListe = new RelationListeType1() {
                                                OekonomiskYdelseEffektueringRelation = new[] {
                                                    new OekonomiskYdelseEffektueringRelationType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.YDELSEEFFEKTUERING_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSEEFFEKTUERING_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.YDELSEEFFEKTUERING_INDEKS,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_REFERENCE_ID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/,
                                                    YdelsesperiodeStartdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_STARTDATO),
                                                    YdelsesperiodeSlutdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_SLUTDATO),
                                                    YdelsesperiodeStartdatoSpecified = true,
                                                    YdelsesperiodeSlutdatoSpecified = true,
                                                    Ydelsesbeloeb = ConfigVariables.YDELSEEFFEKTUERING_YDELSESBELOEB,
                                                    Klassifikationsbeskrivelse = ConfigVariables.YDELSEEFFEKTUERING_KLASSIFIKATIONSBESKRIVELSE,
                                                    BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                                        UUIDIdentifikator = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_UUID_IDENTIFIKATOR,
                                                        BevilgetYdelseId = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_BEVILGET_YDELSE_ID
                                                    }
                                                    }
                                                },
                                                Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.EFFEKTUERING_EJER_FULDT_NAVN,
                                                    CVRnr = ConfigVariables.EFFEKTUERING_EJER_CVR_NR,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EJER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERING_EJER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EJER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_ROLLE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_TYPE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_REFERENCE_ID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                ItSystem = new[] { new ItSystemRelationType1() {
                                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                    //SystemURI = ConfigVariables.,
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.EFFEKTUERINGS_MODTAGER_FULDT_NAVN,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_MODTAGER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_ROLLE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_TYPE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_REFERENCE_ID,
                                                        ItemElementName = ItemChoiceType.URNIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                }/*,
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }*/
                                            },
                                            MaksimalAntalKvantitet = "50",
                                            SoegRegistrering = new SoegRegistreringType() {
                                                BrugerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                                LivscyklusKodeSpecified = true,
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                                },
                                            },
                                            SoegVirkning = new SoegVirkningType() {
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                AktoerTypeKodeSpecified = true,
                                            },
                                            SoegStsFraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                            },
                                            SoegStsTilTidspunkt = new TidspunktType() {
                                                Item = true,
                                            }
                                        }
                                        },
                                        operation = AndOrType.OR,
                                        operationSpecified = true,
                                        ItemsElementName = new[] {
                                            ItemsChoiceType.SoegOekonomiskEffektueringIndeks
                                        },
                                    }
                        },
                        //operation = AndOrType.OR,
                        operationSpecified = false,
                        ItemsElementName = new[] {
                                            ItemsChoiceType.SoegUdtryk,
                                            ItemsChoiceType.SoegUdtryk
                        },
                        }
                    },
                RequestHeader = RequestHeader
                };

            XmlSaver.SaveRequestAsXml(request, "fremsoeg.xml");

            return Port.fremsoeg(request);
            }

        public fremsoegResponse fremsoegNOT()
            {
            fremsoegRequest request = new fremsoegRequest()
                {
                FremsoegYdelseIndeksInput = new FremsoegYdelseIndeksInputType()
                    {
                    BevillingUuid = new[] { ConfigVariables.BEVILLING_UUID_IDENTIFIKATOR },
                    OekonomiskEffektueringUuid = new[] { ConfigVariables.EFFEKTUERING_UUID_IDENTIFIKATOR },
                    SoegUdtryk = new SoegUdtrykType()
                        {
                        Items = new Object[] { new SoegUdtrykType()
                                    {
                                    Items = new Object[] {
                                        new SoegInputType1() {
                                            AttributListe = new AttributListeType()
                                            {
                                                Egenskaber = new[] { new EgenskaberType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    BrugervendtNoegle = ConfigVariables.BEVILLINGS_EGENSKABER_BRUGERVENDT_NOEGLE,
                                                    Bevillingstartdato = ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA,
                                                    Foelsomhed = (FoelsomhedType) Enum.Parse(typeof(FoelsomhedType), ConfigVariables.BEVILLINGS_EGENSKABER_FOELSOMHED),
                                                    FoelsomhedSpecified = true,
                                                }
                                                },
                                                BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Id = ConfigVariables.BEVILGET_YDELSE_ID,
                                                    Navn = ConfigVariables.BEVILGET_YDELSE_NAVN,
                                                    BevilgetYdelseStartdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_STARTDATO),
                                                    BevilgetYdelseSlutdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_SLUTDATO),
                                                    BevilgetYdelseStartdatoSpecified = true,
                                                    BevilgetYdelseSlutdatoSpecified = true,
                                                    TilbagebetalingspligtigSpecified = false,
                                                    ItSystem = new [] { new ItSystemRelationType() {
                                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                        Rolle = new UnikIdType() {
                                                                Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }
                                                    }
                                                    },
                                                    Ydelse = new YdelseRelationType() {
                                                        Ydelsesnavn = ConfigVariables.YDELSE_YDELSES_NAVN,
                                                        Klassifikation = new BevillingsklasseRelationType() {
                                                            BrugervendtNoegle = ConfigVariables.BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE,
                                                            Klassetitel = ConfigVariables.BEVILLING_PRIMAER_KLASSE_KlASSETITEL
                                                        },
                                                        Rolle = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_KLASSE_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }
                                                        /*,
                                                            Rolle = new UnikIdType() {
                                                                Item = ConfigVariables., // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables., // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Indeks = ConfigVariables.,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables., // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                            Any = new [] {
                                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                            },
                                                            SenestAendretTidspunkt = DateTime.Now,
                                                            SenestAendretTidspunktSpecified = true
                                                        }*/
                                                    }/*,
                                                    Items = new [] { new OekonomiskEffektueringsplanType() {
                                                        Id = ConfigVariables.,
                                                        EffektueringsplanStartdato = DateTime.Now,
                                                        EffektueringsplanSlutdatoSpecified = false,
                                                        Beregningsfrekvens = ConfigVariables.,
                                                        ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                                        Dispositionsdag = ConfigVariables.,
                                                        Ydelsesbeloeb = ConfigVariables.,
                                                        ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                                        ForudBagudSpecified = true,
                                                        ManueltGodkendesSpecified = true
                                                    }
                                                    }*/
                                                }
                                                }
                                            },
                                            TilstandListe = new TilstandListeType(),
                                            RelationListe = new RelationListeType() {
                                                Bevillingssag = new[] {
                                                    new BevillingIndeksSagRelationType() {
                                                        BrugervendtNoegle = ConfigVariables.BEVILLINGS_SAG_BRUGERVENDT_NOEGLE,
                                                        FuldtNavn = ConfigVariables.BEVILLINGS_SAG_FULDT_NAVN,
                                                        Virkning = new VirkningType {
                                                            FraTidspunkt = new TidspunktType() {
                                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_SAG_VIRKNING_FRA),
                                                            },
                                                            TilTidspunkt = new TidspunktType() {
                                                                Item = true // DateTime.Now,
                                                            },
                                                            AktoerRef = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLINGS_SAG_AKTOER_REF,
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_SAG_AKTOER_TYPE_KODE),
                                                            AktoerTypeKodeSpecified = true,
                                                        },
                                                        Rolle = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_ROLLE_UUID, // Constant for Master
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        Type = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_TYPE_UUID, // Constant for IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        //Indeks = ConfigVariables.,
                                                        ReferenceID = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLINGS_SAG_REFERENCE_ID, // The UUID of your IT-system
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        }/*,
                                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                            Any = new [] {
                                                                (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                            },
                                                            SenestAendretTidspunkt = DateTime.Now,
                                                            SenestAendretTidspunktSpecified = true
                                                        }*/
                                                    }
                                                },
                                                Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.YDELSESMODTAGER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.YDELSESMODTAGER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSESMODTAGER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.URNIdentifikator,
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.BEVILLING_EJER_BRUGERVENDT_NOEGLE,
                                                    FuldtNavn = ConfigVariables.BEVILLING_EJER_FULDT_NAVN,
                                                    CVRnr = ConfigVariables.BEVILLING_EJER_CVR_NR,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLING_EJER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_EJER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_EJER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_EJER_ROLLE_ID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.BEVILLING_EJER_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables., // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },/*
                                                Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Now,
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                        AktoerTypeKodeSpecified = true,
                                                        NoteTekst = ConfigVariables.
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables., // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables., // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables., // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }
                                                }
                                                }*/
                                            },
                                            SoegRegistrering = new SoegRegistreringType() {
                                                BrugerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                                LivscyklusKodeSpecified = true,
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true // DateTime.Now,
                                                },
                                            },
                                            FoersteResultatReference = "0",
                                            MaksimalAntalKvantitet = "50",
                                            SoegVirkning = new SoegVirkningType() {
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true // DateTime.Now,
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                AktoerTypeKodeSpecified = true,
                                            },
                                            SoegStsFraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                            },
                                            SoegStsTilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                            }
                                        }

                                    },
                                    operation = AndOrType.OR,
                                    operationSpecified = true,
                                    ItemsElementName = new[] {
                                        ItemsChoiceType.SoegBevillingIndeks
                                    }
                                    },


                                    new SoegUdtrykType()
                                    {
                                        Items = new Object[] { new SoegUdtrykType()
                                            {
                                            Items = new Object[] {
                                                new SoegInputType1() {
                                                    AttributListe = new AttributListeType()
                                                    {
                                                        Egenskaber = new[] { new EgenskaberType() {
                                                            Virkning = new VirkningType {
                                                                FraTidspunkt = new TidspunktType() {
                                                                    Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_VIRKNING_FRA),
                                                                },
                                                                TilTidspunkt = new TidspunktType() {
                                                                    Item = true,
                                                                },
                                                                AktoerRef = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLINGS_EGENSKABER_AKTOER_REF,
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE),
                                                                AktoerTypeKodeSpecified = true,
                                                            },
                                                            BrugervendtNoegle = ConfigVariables.EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE,
                                                            Bevillingstartdato = ConfigVariables.EFFEKTUERING_EGENSKABER_STARTDATO,
                                                            Bevillingslutdato = ConfigVariables.EFFEKTUERING_EGENSKABER_SLUTDATO,
                                                            //Foelsomhed = (FoelsomhedType) Enum.Parse(typeof(FoelsomhedType), ConfigVariables.BEVILLINGS_EGENSKABER_FOELSOMHED),
                                                            FoelsomhedSpecified = false,
                                                        }
                                                        },
                                                        BevilgetYdelse = new[] { new BevilgetYdelseType() {
                                                            Virkning = new VirkningType {
                                                                FraTidspunkt = new TidspunktType() {
                                                                    Item = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_VIRKNING_FRA),
                                                                },
                                                                TilTidspunkt = new TidspunktType() {
                                                                    Item = true // DateTime.Now,
                                                                },
                                                                AktoerRef = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                                AktoerTypeKodeSpecified = true,
                                                            },
                                                            Id = ConfigVariables.BEVILGET_YDELSE_ID,
                                                            Navn = ConfigVariables.BEVILGET_YDELSE_NAVN,
                                                            BevilgetYdelseStartdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_STARTDATO),
                                                            BevilgetYdelseSlutdato = DateTime.Parse(ConfigVariables.BEVILGET_YDELSE_SLUTDATO),
                                                            BevilgetYdelseStartdatoSpecified = true,
                                                            BevilgetYdelseSlutdatoSpecified = true,
                                                            TilbagebetalingspligtigSpecified = false,
                                                            ItSystem = new [] { new ItSystemRelationType() {
                                                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                                Rolle = new UnikIdType() {
                                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Type = new UnikIdType() {
                                                                    Item = ConfigVariables.ANSVARLIG_ORGANISATIONSENHED_TYPE_UUID, // Constant for IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                ReferenceID = new UnikIdType() {
                                                                    Item = ConfigVariables.IT_SYSTEM_MASTER_TYPE_UUID, // The UUID of your IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                }
                                                            }
                                                            },
                                                            Ydelse = new YdelseRelationType() {
                                                                Ydelsesnavn = ConfigVariables.YDELSE_YDELSES_NAVN,
                                                                Klassifikation = new BevillingsklasseRelationType() {
                                                                    BrugervendtNoegle = ConfigVariables.BEVILLING_PRIMAER_KLASSE_BRUGERVENDT_NOEGLE,
                                                                    Klassetitel = ConfigVariables.BEVILLING_PRIMAER_KLASSE_KlASSETITEL
                                                                },
                                                                Rolle = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_ROLLE_UUID, // Constant for Master
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Type = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLING_KLASSE_TYPE_UUID, // Constant for IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Indeks = ConfigVariables.BEVILLING_PRIMAER_KLASSE_INDEKS,
                                                                ReferenceID = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLING_PRIMAER_KLASSE_REFERENCE_ID, // The UUID of your IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                }
                                                                /*,
                                                                    Rolle = new UnikIdType() {
                                                                        Item = ConfigVariables., // Constant for Master
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Type = new UnikIdType() {
                                                                    Item = ConfigVariables., // Constant for IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Indeks = ConfigVariables.,
                                                                ReferenceID = new UnikIdType() {
                                                                    Item = ConfigVariables., // The UUID of your IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                                    Any = new [] {
                                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                                    },
                                                                    SenestAendretTidspunkt = DateTime.Now,
                                                                    SenestAendretTidspunktSpecified = true
                                                                }*/
                                                            }/*,
                                                            Items = new [] { new OekonomiskEffektueringsplanType() {
                                                                Id = ConfigVariables.,
                                                                EffektueringsplanStartdato = DateTime.Now,
                                                                EffektueringsplanSlutdatoSpecified = false,
                                                                Beregningsfrekvens = ConfigVariables.,
                                                                ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                                                Dispositionsdag = ConfigVariables.,
                                                                Ydelsesbeloeb = ConfigVariables.,
                                                                ManueltGodkendes = Boolean.Parse(ConfigVariables.),
                                                                ForudBagudSpecified = true,
                                                                ManueltGodkendesSpecified = true
                                                            }
                                                            }*/
                                                        }
                                                        }
                                                    },
                                                    TilstandListe = new TilstandListeType(),
                                                    RelationListe = new RelationListeType() {
                                                        Bevillingssag = new[] {
                                                            new BevillingIndeksSagRelationType() {
                                                                BrugervendtNoegle = ConfigVariables.BEVILLINGS_SAG_BRUGERVENDT_NOEGLE,
                                                                FuldtNavn = ConfigVariables.BEVILLINGS_SAG_FULDT_NAVN,
                                                                Virkning = new VirkningType {
                                                                    FraTidspunkt = new TidspunktType() {
                                                                        Item = DateTime.Parse(ConfigVariables.BEVILLINGS_SAG_VIRKNING_FRA),
                                                                    },
                                                                    TilTidspunkt = new TidspunktType() {
                                                                        Item = true // DateTime.Now,
                                                                    },
                                                                    AktoerRef = new UnikIdType() {
                                                                        Item = ConfigVariables.BEVILLINGS_SAG_AKTOER_REF,
                                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                    },
                                                                    AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLINGS_SAG_AKTOER_TYPE_KODE),
                                                                    AktoerTypeKodeSpecified = true,
                                                                },
                                                                Rolle = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLINGS_SAG_ROLLE_UUID, // Constant for Master
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                Type = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLINGS_SAG_TYPE_UUID, // Constant for IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                //Indeks = ConfigVariables.,
                                                                ReferenceID = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLINGS_SAG_REFERENCE_ID, // The UUID of your IT-system
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                }/*,
                                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                                    Any = new [] {
                                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                                    },
                                                                    SenestAendretTidspunkt = DateTime.Now,
                                                                    SenestAendretTidspunktSpecified = true
                                                                }*/
                                                            }
                                                        },
                                                        Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                                            //BrugervendtNoegle = ConfigVariables.,
                                                            FuldtNavn = ConfigVariables.YDELSESMODTAGER_FULDT_NAVN,
                                                            Virkning = new VirkningType {
                                                                FraTidspunkt = new TidspunktType() {
                                                                    Item = DateTime.Parse(ConfigVariables.YDELSESMODTAGER_VIRKNING_FRA),
                                                                },
                                                                TilTidspunkt = new TidspunktType() {
                                                                    Item = true // DateTime.Now,
                                                                },
                                                                AktoerRef = new UnikIdType() {
                                                                    Item = ConfigVariables.YDELSESMODTAGER_AKTOER_REF,
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSESMODTAGER_AKTOER_TYPE_KODE),
                                                                AktoerTypeKodeSpecified = true,
                                                            },
                                                            Rolle = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_ROLLE_UUID, // Constant for Master
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            Type = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLING_YDELSESMODTAGER_TYPE_UUID, // Constant for IT-system
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            Indeks = ConfigVariables.YDELSESMODTAGER_INDEKS,
                                                            ReferenceID = new UnikIdType() {
                                                                Item = ConfigVariables.YDELSESMODTAGER_REFERENCE_ID, // The UUID of your IT-system
                                                                ItemElementName = ItemChoiceType.URNIdentifikator,
                                                            }/*,
                                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                                Any = new [] {
                                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                                },
                                                                SenestAendretTidspunkt = DateTime.Now,
                                                                SenestAendretTidspunktSpecified = true
                                                            }*/
                                                        }
                                                        },
                                                        Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                                            //BrugervendtNoegle = ConfigVariables.BEVILLING_EJER_BRUGERVENDT_NOEGLE,
                                                            FuldtNavn = ConfigVariables.BEVILLING_EJER_FULDT_NAVN,
                                                            CVRnr = ConfigVariables.BEVILLING_EJER_CVR_NR,
                                                            Virkning = new VirkningType {
                                                                FraTidspunkt = new TidspunktType() {
                                                                    Item = DateTime.Parse(ConfigVariables.BEVILLING_EJER_VIRKNING_FRA),
                                                                },
                                                                TilTidspunkt = new TidspunktType() {
                                                                    Item = true // DateTime.Now,
                                                                },
                                                                AktoerRef = new UnikIdType() {
                                                                    Item = ConfigVariables.BEVILLING_EJER_AKTOER_REF,
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILLING_EJER_AKTOER_TYPE_KODE),
                                                                AktoerTypeKodeSpecified = true,
                                                            },
                                                            Rolle = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLING_EJER_ROLLE_ID, // Constant for Master
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            Type = new UnikIdType() {
                                                                Item = ConfigVariables.BEVILLING_EJER_TYPE_UUID, // Constant for IT-system
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            }/*,
                                                            Indeks = ConfigVariables.,
                                                            ReferenceID = new UnikIdType() {
                                                                Item = ConfigVariables., // The UUID of your IT-system
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                                Any = new [] {
                                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                                },
                                                                SenestAendretTidspunkt = DateTime.Now,
                                                                SenestAendretTidspunktSpecified = true
                                                            }*/
                                                        }
                                                        },/*
                                                        Sikkerhedsprofil = new[] { new SikkerhedsprofilRelationType() {
                                                            Virkning = new VirkningType {
                                                                FraTidspunkt = new TidspunktType() {
                                                                    Item = DateTime.Now,
                                                                },
                                                                TilTidspunkt = new TidspunktType() {
                                                                    Item = true
                                                                },
                                                                AktoerRef = new UnikIdType() {
                                                                    Item = ConfigVariables.AKTOER_REF,
                                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                                },
                                                                AktoerTypeKode = AktoerTypeKodeType.Bruger,
                                                                AktoerTypeKodeSpecified = true,
                                                                NoteTekst = ConfigVariables.
                                                            },
                                                            Rolle = new UnikIdType() {
                                                                Item = ConfigVariables., // Constant for Master
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            Type = new UnikIdType() {
                                                                Item = ConfigVariables., // Constant for IT-system
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            Indeks = ConfigVariables.,
                                                            ReferenceID = new UnikIdType() {
                                                                Item = ConfigVariables., // The UUID of your IT-system
                                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                            },
                                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                                Any = new [] {
                                                                    (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                                },
                                                                SenestAendretTidspunkt = DateTime.Now,
                                                                SenestAendretTidspunktSpecified = true
                                                            }
                                                        }
                                                        }*/
                                                    },
                                                    SoegRegistrering = new SoegRegistreringType() {
                                                        BrugerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                                        LivscyklusKodeSpecified = true,
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                    },
                                                    FoersteResultatReference = "0",
                                                    MaksimalAntalKvantitet = "50",
                                                    SoegVirkning = new SoegVirkningType() {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true // DateTime.Now,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    SoegStsFraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                    },
                                                    SoegStsTilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                    }
                                                }

                                            },
                                            operationSpecified = false,
                                            ItemsElementName = new[] {
                                                ItemsChoiceType.SoegBevillingIndeks
                                            }
                                            }
                                        },
                                        operation = AndOrType.OR,
                                            operationSpecified = true,
                                            ItemsElementName = new[] {
                                                ItemsChoiceType.NOT
                                            }
                                    },
                                    new SoegUdtrykType()
                                    {
                                        Items = new Object[] {
                                        new SoegInputType2() {
                                            FoersteResultatReference = "0",
                                            AttributListe = new AttributListeType1() {
                                                Egenskaber = new[] { new EgenskaberType1()  {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EGENSKABER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    BrugervendtNoegle = ConfigVariables.EFFEKTUERING_EGENSKABER_BRUGERVENDT_NOEGLE,
                                                    Startdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_STARTDATO),
                                                    Slutdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_SLUTDATO),
                                                    StartdatoSpecified = true,
                                                    SlutdatoSpecified = true,
                                                    SamletBruttobeloeb = ConfigVariables.EFFEKTUERING_EGENSKABER_SAMLET_BRUTTOBELOEB,
                                                    Dispositionsdato = DateTime.Parse(ConfigVariables.EFFEKTUERING_EGENSKABER_DISPOSITIONSDATO),
                                                    DispositionsdatoSpecified = true,
                                                    BeloebEfterSkatATP = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_EFTER_SKAT_ATP,
                                                    BeloebSendtTilUdbetaling = ConfigVariables.EFFEKTUERING_EGENSKABER_BELOEB_SENDT_TIL_UDBETALING,
                                                    //BeloebUdbetalt = ConfigVariables.,
                                                    Udbetalingsafdeling = ConfigVariables.EFFEKTUERING_EGENSKABER_UDBETALINGSAFDELING,
                                                    //SendtTilUdbetalingTekst = ConfigVariables.,
                                                    //UdbetaltTekst = ConfigVariables.
                                                }
                                                }/*,
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }*/
                                            },
                                            TilstandListe = new TilstandListeType1(),
                                            RelationListe = new RelationListeType1() {
                                                OekonomiskYdelseEffektueringRelation = new[] {
                                                    new OekonomiskYdelseEffektueringRelationType() {
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.YDELSEEFFEKTUERING_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.YDELSEEFFEKTUERING_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_ROLLE_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = ConfigVariables.YDELSEEFFEKTUERING_INDEKS,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.YDELSEEFFEKTUERING_REFERENCE_ID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/,
                                                    YdelsesperiodeStartdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_STARTDATO),
                                                    YdelsesperiodeSlutdato = DateTime.Parse(ConfigVariables.YDELSEEFFEKTUERING_YDELSESPERIODE_SLUTDATO),
                                                    YdelsesperiodeStartdatoSpecified = true,
                                                    YdelsesperiodeSlutdatoSpecified = true,
                                                    Ydelsesbeloeb = ConfigVariables.YDELSEEFFEKTUERING_YDELSESBELOEB,
                                                    Klassifikationsbeskrivelse = ConfigVariables.YDELSEEFFEKTUERING_KLASSIFIKATIONSBESKRIVELSE,
                                                    BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                                        UUIDIdentifikator = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_UUID_IDENTIFIKATOR,
                                                        BevilgetYdelseId = ConfigVariables.YDELSEEFFEKTUERING_BEVILGET_YDELSE_REF_BEVILGET_YDELSE_ID
                                                    }
                                                    }
                                                },
                                                Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.EFFEKTUERING_EJER_FULDT_NAVN,
                                                    CVRnr = ConfigVariables.EFFEKTUERING_EJER_CVR_NR,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERING_EJER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERING_EJER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERING_EJER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_ROLLE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_TYPE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERING_EJER_REFERENCE_ID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                ItSystem = new[] { new ItSystemRelationType1() {
                                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                    //SystemURI = ConfigVariables.,
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                },
                                                OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                                    //BrugervendtNoegle = ConfigVariables.,
                                                    FuldtNavn = ConfigVariables.EFFEKTUERINGS_MODTAGER_FULDT_NAVN,
                                                    Virkning = new VirkningType {
                                                        FraTidspunkt = new TidspunktType() {
                                                            Item = DateTime.Parse(ConfigVariables.EFFEKTUERINGS_MODTAGER_VIRKNING_FRA),
                                                        },
                                                        TilTidspunkt = new TidspunktType() {
                                                            Item = true,
                                                        },
                                                        AktoerRef = new UnikIdType() {
                                                            Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_REF,
                                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                        },
                                                        AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.EFFEKTUERINGS_MODTAGER_AKTOER_TYPE_KODE),
                                                        AktoerTypeKodeSpecified = true,
                                                    },
                                                    Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_ROLLE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_TYPE_UUID,
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    //Indeks = ConfigVariables.,
                                                    ReferenceID = new UnikIdType() {
                                                        Item = ConfigVariables.EFFEKTUERINGS_MODTAGER_REFERENCE_ID,
                                                        ItemElementName = ItemChoiceType.URNIdentifikator
                                                    }/*,
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                        Any = new [] {
                                                            (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                        },
                                                        SenestAendretTidspunkt = DateTime.Now,
                                                        SenestAendretTidspunktSpecified = true
                                                    }*/
                                                }
                                                }/*,
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement(ConfigVariables.)
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }*/
                                            },
                                            MaksimalAntalKvantitet = "50",
                                            SoegRegistrering = new SoegRegistreringType() {
                                                BrugerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILLING_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LivscyklusKode = (LivscyklusKodeType) Enum.Parse(typeof(LivscyklusKodeType), ConfigVariables.BEVILLING_LIVSCYKLUS_KODE), // LivscyklusKodeType.Importeret,
                                                LivscyklusKodeSpecified = true,
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                                },
                                            },
                                            SoegVirkning = new SoegVirkningType() {
                                                FraTidspunkt = new TidspunktType() {
                                                    Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                                },
                                                TilTidspunkt = new TidspunktType() {
                                                    Item = true,
                                                },
                                                AktoerRef = new UnikIdType() {
                                                    Item = ConfigVariables.BEVILGET_YDELSE_AKTOER_REF,
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                AktoerTypeKode = (AktoerTypeKodeType) Enum.Parse(typeof(AktoerTypeKodeType), ConfigVariables.BEVILGET_YDELSE_AKTOER_TYPE_KODE),
                                                AktoerTypeKodeSpecified = true,
                                            },
                                            SoegStsFraTidspunkt = new TidspunktType() {
                                                Item = DateTime.Parse(ConfigVariables.BEVILLINGS_EGENSKABER_VIRKNING_FRA),
                                            },
                                            SoegStsTilTidspunkt = new TidspunktType() {
                                                Item = true,
                                            }
                                        }
                                        },
                                        operation = AndOrType.OR,
                                        operationSpecified = true,
                                        ItemsElementName = new[] {
                                            ItemsChoiceType.SoegOekonomiskEffektueringIndeks
                                        },
                                    }
                        },
                        //operation = AndOrType.OR,
                        operationSpecified = false,
                        ItemsElementName = new[] {
                                            ItemsChoiceType.SoegUdtryk,
                                            ItemsChoiceType.NOT,
                                            ItemsChoiceType.SoegUdtryk
                        },
                        }
                    },
                RequestHeader = RequestHeader
                };

            XmlSaver.SaveRequestAsXml(request, "fremsoegNOT.xml");

            return Port.fremsoeg(request);
            }



        #region Port and token helper methods

        /// <summary>
        /// The Port property used to send requests. Creates a new port only if it doesn't already exist, or the token has expired
        /// </summary>
        private YdelseIndeksPortType Port
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
        private YdelseIndeksPortType CreatePort()
        {
            StsTokenServiceConfiguration stsConfiguration = TokenFetcher.getTokenConfiguration(ConfigVariables.ConfigurationSectionNameForYdelseIndeks);
            token = TokenFetcher.getToken(stsConfiguration);
            return FederatedChannelFactoryExtensions.CreateChannelWithIssuedToken<YdelseIndeksPortType>(token, stsConfiguration);
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
