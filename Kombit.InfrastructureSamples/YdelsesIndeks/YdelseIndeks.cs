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
    internal class YdelseIndeks
    {
        private GenericXmlSecurityToken token;
        private YdelseIndeksPortType port;

        public importerResponse importer(string uuidIdentifikatorBevilling, string uuidIdentifikatorOekonomiskEffektuering)
        {
            importerRequest request = new importerRequest()
            {
                ImporterYdelseIndeksInput = new object[] { new ImportInputType() {
                        BevillingIndeks = new BevillingIndeksType() {
                            UdenNotifikation = Boolean.Parse("ÆØÅ"),
                            UdenNotifikationSpecified = true,
                            UUIDIdentifikator = uuidIdentifikatorBevilling,

                            Registrering = new[] { new RegistreringType2() {
                                AttributListe = new AttributListeType() {
                                    Egenskaber = new[] { new EgenskaberType() {
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
                                                NoteTekst = "ÆØÅ"
                                            },
                                            BrugervendtNoegle = "ÆØÅ",
                                            Bevillingstartdato = "ÆØÅ",
                                            Bevillingslutdato = "ÆØÅ",
                                            Begrundelse = "ÆØÅ",
                                            Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                            FoelsomhedSpecified = true
                                    }
                                    },
                                    BevilgetYdelse = new[] { new BevilgetYdelseType() {
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
                                                NoteTekst = "ÆØÅ"
                                            },
                                            Id = "ÆØÅ",
                                            Navn = "ÆØÅ",
                                            BevilgetYdelseStartdato = DateTime.Now,
                                            BevilgetYdelseStartdatoSpecified = true,
                                            BevilgetYdelseSlutdatoSpecified = false,
                                            Begrundelse = "ÆØÅ",
                                            Tilbagebetalingspligtig = Boolean.Parse("ÆØÅ"),
                                            TilbagebetalingspligtigSpecified = true,
                                            Meddelelse = "ÆØÅ",
                                            ItSystem = new [] { new ItSystemRelationType() {
                                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                                SystemURI = "ÆØÅ",
                                                Rolle = new UnikIdType() {
                                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = "ÆØÅ",
                                                ReferenceID = new UnikIdType() {
                                                    Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                   Any = new [] {
                                                       (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                   },
                                                   SenestAendretTidspunkt = DateTime.Now,
                                                   SenestAendretTidspunktSpecified = true
                                                }
                                            }
                                            },
                                            Ydelse = new YdelseRelationType() {
                                                Ydelsesnavn = "ÆØÅ",
                                                Klassifikation = new BevillingsklasseRelationType() {
                                                    BrugervendtNoegle = "ÆØÅ",
                                                    Klassetitel = "ÆØÅ",
                                                    Rolle = new UnikIdType() {
                                                        Item = "ÆØÅ", // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Type = new UnikIdType() {
                                                        Item = "ÆØÅ", // Constant for IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    Indeks = "ÆØÅ",
                                                    ReferenceID = new UnikIdType() {
                                                        Item = "ÆØÅ", // The UUID of your IT-system
                                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                    },
                                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                       Any = new [] {
                                                           (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                       },
                                                       SenestAendretTidspunkt = DateTime.Now,
                                                       SenestAendretTidspunktSpecified = true
                                                    }
                                                },
                                                 Rolle = new UnikIdType() {
                                                        Item = "ÆØÅ", // Constant for Master
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = "ÆØÅ", // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = "ÆØÅ",
                                                ReferenceID = new UnikIdType() {
                                                    Item = "ÆØÅ", // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                   Any = new [] {
                                                       (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                   },
                                                   SenestAendretTidspunkt = DateTime.Now,
                                                   SenestAendretTidspunktSpecified = true
                                                }
                                            },
                                            Items = new [] { new OekonomiskEffektueringsplanType() {
                                                Id = "ÆØÅ",
                                                EffektueringsplanStartdato = DateTime.Now,
                                                EffektueringsplanSlutdatoSpecified = false,
                                                Beregningsfrekvens = "ÆØÅ",
                                                ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                                Dispositionsdag = "ÆØÅ",
                                                Ydelsesbeloeb = "ÆØÅ",
                                                ManueltGodkendes = Boolean.Parse("ÆØÅ"),
                                                ForudBagudSpecified = true,
                                                ManueltGodkendesSpecified = true
                                            }
                                            }

                                    }

                                    }
                                },
                                TilstandListe = new TilstandListeType() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                RelationListe = new RelationListeType() {
                                    Bevillingssag = new[] {
                                        new BevillingIndeksSagRelationType() {
                                            BrugervendtNoegle = "ÆØÅ",
                                            FuldtNavn = "ÆØÅ",
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
                                                NoteTekst = "ÆØÅ"
                                            },
                                            Rolle = new UnikIdType() {
                                                Item = "ÆØÅ", // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = "ÆØÅ", // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = "ÆØÅ",
                                            ReferenceID = new UnikIdType() {
                                                Item = "ÆØÅ", // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        }
                                    },
                                    Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
                                        CVRnr = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    }
                                },
                                NoteTekst = "ÆØÅ",
                                Tidspunkt = DateTime.Now,
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = LivscyklusKodeType.Importeret,
                                LivscyklusKodeSpecified = true,
                                StsTidspunkt = DateTime.Now,
                                StsTidspunktSpecified = true,
                            }
                            },

                        }


                }, new ImportInputType1() {
                    OekonomiskEffektueringIndeks = new OekonomiskEffektueringIndeksType() {
                        UUIDIdentifikator = uuidIdentifikatorOekonomiskEffektuering,
                        Registrering = new [] {
                            new RegistreringType3()
                            {
                                AttributListe = new AttributListeType1() {
                                    Egenskaber = new[] { new EgenskaberType1()  {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        BrugervendtNoegle = "ÆØÅ",
                                        Startdato = DateTime.Now,
                                        StartdatoSpecified = true,
                                        SlutdatoSpecified = false,
                                        SamletBruttobeloeb = "ÆØÅ",
                                        Dispositionsdato = DateTime.Now,
                                        DispositionsdatoSpecified = true,
                                        BeloebEfterSkatATP = "ÆØÅ",
                                        BeloebSendtTilUdbetaling = "ÆØÅ",
                                        BeloebUdbetalt = "ÆØÅ",
                                        Udbetalingsafdeling = "ÆØÅ",
                                        SendtTilUdbetalingTekst = "ÆØÅ",
                                        UdbetaltTekst = "ÆØÅ"
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                TilstandListe = new TilstandListeType1() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        }
                                    }
                                },
                                RelationListe = new RelationListeType1() {
                                    OekonomiskYdelseEffektueringRelation = new[] {
                                        new OekonomiskYdelseEffektueringRelationType() {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        },
                                        YdelsesperiodeStartdato = DateTime.Now,
                                        YdelsesperiodeStartdatoSpecified = true,
                                        YdelsesperiodeSlutdatoSpecified = false,
                                        Ydelsesbeloeb = "ÆØÅ",
                                        Klassifikationsbeskrivelse = "ÆØÅ",
                                        BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                            UUIDIdentifikator = "ÆØÅ",
                                            BevilgetYdelseId = "ÆØÅ"
                                        }
                                        }
                                    },
                                    Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
                                        CVRnr = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    ItSystem = new[] { new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                        SystemURI = "ÆØÅ",
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                NoteTekst = "ÆØÅ",
                                Tidspunkt = DateTime.Now,
                                TidspunktSpecified = true,
                                BrugerRef = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LivscyklusKode = LivscyklusKodeType.Importeret,
                                LivscyklusKodeSpecified = true,
                                StsTidspunkt = DateTime.Now,
                                StsTidspunktSpecified = true
                            }
                        }
                    }
                }
            },
                RequestHeader = RequestHeader
            };

            return Port.importer(request);
        }

        public opdaterResponse opdater(string uuidIdentifikatorBevilling, string uuidIdentifikatorOekonomiskEffektuering)
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
                                    NoteTekst = "ÆØÅ"
                                },
                                BrugervendtNoegle = "ÆØÅ",
                                Bevillingstartdato = "ÆØÅ",
                                Bevillingslutdato = "ÆØÅ",
                                Begrundelse = "ÆØÅ",
                                Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                FoelsomhedSpecified = true
                            }
                            },
                            BevilgetYdelse = new[] { new BevilgetYdelseType() {
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Id = "ÆØÅ",
                                Navn = "ÆØÅ",
                                BevilgetYdelseStartdato = DateTime.Now,
                                BevilgetYdelseStartdatoSpecified = true,
                                BevilgetYdelseSlutdatoSpecified = false,
                                Begrundelse = "ÆØÅ",
                                Tilbagebetalingspligtig = Boolean.Parse("ÆØÅ"),
                                TilbagebetalingspligtigSpecified = true,
                                Meddelelse = "ÆØÅ",
                                ItSystem = new [] { new ItSystemRelationType() {
                                    SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                    SystemURI = "ÆØÅ",
                                    Rolle = new UnikIdType() {
                                            Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = "ÆØÅ",
                                    ReferenceID = new UnikIdType() {
                                        Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                }
                                },
                                Ydelse = new YdelseRelationType() {
                                    Ydelsesnavn = "ÆØÅ",
                                    Klassifikation = new BevillingsklasseRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        Klassetitel = "ÆØÅ",
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = "ÆØÅ", // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = "ÆØÅ",
                                    ReferenceID = new UnikIdType() {
                                        Item = "ÆØÅ", // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                Items = new [] { new OekonomiskEffektueringsplanType() {
                                    Id = "ÆØÅ",
                                    EffektueringsplanStartdato = DateTime.Now,
                                    EffektueringsplanSlutdatoSpecified = false,
                                    Beregningsfrekvens = "ÆØÅ",
                                    ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                    Dispositionsdag = "ÆØÅ",
                                    Ydelsesbeloeb = "ÆØÅ",
                                    ManueltGodkendes = Boolean.Parse("ÆØÅ"),
                                    ForudBagudSpecified = true,
                                    ManueltGodkendesSpecified = true
                                }
                                }
                            }
                            }
                        },
                        TilstandListe = new TilstandListeType() {
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        RelationListe = new RelationListeType() {
                            Bevillingssag = new[] {
                                new BevillingIndeksSagRelationType() {
                                    BrugervendtNoegle = "ÆØÅ",
                                    FuldtNavn = "ÆØÅ",
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
                                        NoteTekst = "ÆØÅ"
                                    },
                                    Rolle = new UnikIdType() {
                                        Item = "ÆØÅ", // Constant for Master
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Type = new UnikIdType() {
                                        Item = "ÆØÅ", // Constant for IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    Indeks = "ÆØÅ",
                                    ReferenceID = new UnikIdType() {
                                        Item = "ÆØÅ", // The UUID of your IT-system
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                }
                            },
                            Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                BrugervendtNoegle = "ÆØÅ",
                                FuldtNavn = "ÆØÅ",
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ", // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                BrugervendtNoegle = "ÆØÅ",
                                FuldtNavn = "ÆØÅ",
                                CVRnr = "ÆØÅ",
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ", // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ", // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            }
                        },
                        NoteTekst = "ÆØÅ",
                        Tidspunkt = DateTime.Now,
                        UdenNotifikation = Boolean.Parse("ÆØÅ"),
                        UdenNotifikationSpecified = true,
                        UUIDIdentifikator = uuidIdentifikatorBevilling
                    },
                    new OpdaterOekonomiskEffektueringIndeksInputType() {
                        AttributListe = new AttributListeType1() {
                            Egenskaber = new[] { new EgenskaberType1()  {
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
                                    NoteTekst = "ÆØÅ"
                                },
                                BrugervendtNoegle = "ÆØÅ",
                                Startdato = DateTime.Now,
                                StartdatoSpecified = true,
                                SlutdatoSpecified = false,
                                SamletBruttobeloeb = "ÆØÅ",
                                Dispositionsdato = DateTime.Now,
                                DispositionsdatoSpecified = true,
                                BeloebEfterSkatATP = "ÆØÅ",
                                BeloebSendtTilUdbetaling = "ÆØÅ",
                                BeloebUdbetalt = "ÆØÅ",
                                Udbetalingsafdeling = "ÆØÅ",
                                SendtTilUdbetalingTekst = "ÆØÅ",
                                UdbetaltTekst = "ÆØÅ"
                            }
                            },
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        TilstandListe = new TilstandListeType1() {
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                }
                            }
                        },
                        RelationListe = new RelationListeType1() {
                            OekonomiskYdelseEffektueringRelation = new[] {
                                new OekonomiskYdelseEffektueringRelationType() {
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ", // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ", // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                },
                                YdelsesperiodeStartdato = DateTime.Now,
                                YdelsesperiodeStartdatoSpecified = true,
                                YdelsesperiodeSlutdatoSpecified = false,
                                Ydelsesbeloeb = "ÆØÅ",
                                Klassifikationsbeskrivelse = "ÆØÅ",
                                BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                    UUIDIdentifikator = "ÆØÅ",
                                    BevilgetYdelseId = "ÆØÅ"
                                }
                                }
                            },
                            Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                BrugervendtNoegle = "ÆØÅ",
                                FuldtNavn = "ÆØÅ",
                                CVRnr = "ÆØÅ",
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            ItSystem = new[] { new ItSystemRelationType1() {
                                SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                SystemURI = "ÆØÅ",
                                Rolle = new UnikIdType() {
                                        Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                BrugervendtNoegle = "ÆØÅ",
                                FuldtNavn = "ÆØÅ",
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
                                    NoteTekst = "ÆØÅ"
                                },
                                Rolle = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Type = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                Indeks = "ÆØÅ",
                                ReferenceID = new UnikIdType() {
                                    Item = "ÆØÅ",
                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                },
                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                    Any = new [] {
                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                    },
                                    SenestAendretTidspunkt = DateTime.Now,
                                    SenestAendretTidspunktSpecified = true
                                }
                            }
                            },
                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                Any = new [] {
                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                },
                                SenestAendretTidspunkt = DateTime.Now,
                                SenestAendretTidspunktSpecified = true
                            }
                        },
                        NoteTekst = "ÆØÅ",
                        Tidspunkt = DateTime.Now,
                        UUIDIdentifikator = "ÆØÅ"
                    }
                },
                RequestHeader = RequestHeader
            };

            return Port.opdater(request);
        }

        public fremsoegResponse fremsoeg(string uuidBevilling, string uuidOekonomiskEffektuering)
        {
            fremsoegRequest request = new fremsoegRequest()
            {
                FremsoegYdelseIndeksInput = new FremsoegYdelseIndeksInputType()
                {
                    BevillingUuid = new[] { uuidBevilling },
                    OekonomiskEffektueringUuid = new[] { uuidOekonomiskEffektuering },
                    SoegUdtryk = new SoegUdtrykType()
                    {
                        Items = new Object[] {
                            new SoegInputType() {
                                FoersteResultatReference = "ÆØÅ",
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = "ÆØÅ",
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = "ÆØÅ",
                                SoegVirkning = new SoegVirkningType() {
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
                                    NoteTekst = "ÆØÅ",
                                }
                            },
                            new SoegInputType1() {
                                FoersteResultatReference = "ÆØÅ",
                                AttributListe = new AttributListeType()
                                {
                                    Egenskaber = new[] { new EgenskaberType() {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        BrugervendtNoegle = "ÆØÅ",
                                        Bevillingstartdato = "ÆØÅ",
                                        Bevillingslutdato = "ÆØÅ",
                                        Begrundelse = "ÆØÅ",
                                        Foelsomhed = FoelsomhedType.IKKE_FORTROLIGE_DATA,
                                        FoelsomhedSpecified = true
                                    }
                                    },
                                    BevilgetYdelse = new[] { new BevilgetYdelseType() {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Id = "ÆØÅ",
                                        Navn = "ÆØÅ",
                                        BevilgetYdelseStartdato = DateTime.Now,
                                        BevilgetYdelseStartdatoSpecified = true,
                                        BevilgetYdelseSlutdatoSpecified = false,
                                        Begrundelse = "ÆØÅ",
                                        Tilbagebetalingspligtig = Boolean.Parse("ÆØÅ"),
                                        TilbagebetalingspligtigSpecified = true,
                                        Meddelelse = "ÆØÅ",
                                        ItSystem = new [] { new ItSystemRelationType() {
                                            SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                            SystemURI = "ÆØÅ",
                                            Rolle = new UnikIdType() {
                                                    Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = "ÆØÅ",
                                            ReferenceID = new UnikIdType() {
                                                Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        }
                                        },
                                        Ydelse = new YdelseRelationType() {
                                            Ydelsesnavn = "ÆØÅ",
                                            Klassifikation = new BevillingsklasseRelationType() {
                                                BrugervendtNoegle = "ÆØÅ",
                                                Klassetitel = "ÆØÅ",
                                                Rolle = new UnikIdType() {
                                                    Item = "ÆØÅ", // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Type = new UnikIdType() {
                                                    Item = "ÆØÅ", // Constant for IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                Indeks = "ÆØÅ",
                                                ReferenceID = new UnikIdType() {
                                                    Item = "ÆØÅ", // The UUID of your IT-system
                                                    ItemElementName = ItemChoiceType.UUIDIdentifikator
                                                },
                                                LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                    Any = new [] {
                                                        (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                    },
                                                    SenestAendretTidspunkt = DateTime.Now,
                                                    SenestAendretTidspunktSpecified = true
                                                }
                                            },
                                                Rolle = new UnikIdType() {
                                                    Item = "ÆØÅ", // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = "ÆØÅ", // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = "ÆØÅ",
                                            ReferenceID = new UnikIdType() {
                                                Item = "ÆØÅ", // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        },
                                        Items = new [] { new OekonomiskEffektueringsplanType() {
                                            Id = "ÆØÅ",
                                            EffektueringsplanStartdato = DateTime.Now,
                                            EffektueringsplanSlutdatoSpecified = false,
                                            Beregningsfrekvens = "ÆØÅ",
                                            ForudBagud = OekonomiskEffektueringsplanTypeForudBagud.Forud,
                                            Dispositionsdag = "ÆØÅ",
                                            Ydelsesbeloeb = "ÆØÅ",
                                            ManueltGodkendes = Boolean.Parse("ÆØÅ"),
                                            ForudBagudSpecified = true,
                                            ManueltGodkendesSpecified = true
                                        }
                                        }
                                    }
                                    }
                                },
                                TilstandListe = new TilstandListeType() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                RelationListe = new RelationListeType() {
                                    Bevillingssag = new[] {
                                        new BevillingIndeksSagRelationType() {
                                            BrugervendtNoegle = "ÆØÅ",
                                            FuldtNavn = "ÆØÅ",
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
                                                NoteTekst = "ÆØÅ"
                                            },
                                            Rolle = new UnikIdType() {
                                                Item = "ÆØÅ", // Constant for Master
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Type = new UnikIdType() {
                                                Item = "ÆØÅ", // Constant for IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            Indeks = "ÆØÅ",
                                            ReferenceID = new UnikIdType() {
                                                Item = "ÆØÅ", // The UUID of your IT-system
                                                ItemElementName = ItemChoiceType.UUIDIdentifikator
                                            },
                                            LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                                Any = new [] {
                                                    (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                                },
                                                SenestAendretTidspunkt = DateTime.Now,
                                                SenestAendretTidspunktSpecified = true
                                            }
                                        }
                                    },
                                    Bevillingspart = new[] { new BevillingIndeksPartRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    Bevillingsaktoer = new[] { new BevillingIndeksAktoerRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
                                        CVRnr = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    }
                                },
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = "ÆØÅ",
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = "ÆØÅ",
                                SoegVirkning = new SoegVirkningType() {
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
                                    NoteTekst = "ÆØÅ",
                                },
                                SoegStsFraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                },
                                SoegStsTilTidspunkt = new TidspunktType() {
                                    Item = true
                                }
                            },
                            new SoegInputType2() {
                                FoersteResultatReference = "ÆØÅ",
                                AttributListe = new AttributListeType1() {
                                    Egenskaber = new[] { new EgenskaberType1()  {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        BrugervendtNoegle = "ÆØÅ",
                                        Startdato = DateTime.Now,
                                        StartdatoSpecified = true,
                                        SlutdatoSpecified = false,
                                        SamletBruttobeloeb = "ÆØÅ",
                                        Dispositionsdato = DateTime.Now,
                                        DispositionsdatoSpecified = true,
                                        BeloebEfterSkatATP = "ÆØÅ",
                                        BeloebSendtTilUdbetaling = "ÆØÅ",
                                        BeloebUdbetalt = "ÆØÅ",
                                        Udbetalingsafdeling = "ÆØÅ",
                                        SendtTilUdbetalingTekst = "ÆØÅ",
                                        UdbetaltTekst = "ÆØÅ"
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                TilstandListe = new TilstandListeType1() {
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        }
                                    }
                                },
                                RelationListe = new RelationListeType1() {
                                    OekonomiskYdelseEffektueringRelation = new[] {
                                        new OekonomiskYdelseEffektueringRelationType() {
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ", // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ", // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        },
                                        YdelsesperiodeStartdato = DateTime.Now,
                                        YdelsesperiodeStartdatoSpecified = true,
                                        YdelsesperiodeSlutdatoSpecified = false,
                                        Ydelsesbeloeb = "ÆØÅ",
                                        Klassifikationsbeskrivelse = "ÆØÅ",
                                        BevilgetYdelseRef = new BevilgetYdelseRefType() {
                                            UUIDIdentifikator = "ÆØÅ",
                                            BevilgetYdelseId = "ÆØÅ"
                                        }
                                        }
                                    },
                                    Aktoer = new[] { new OekonomiskEffektueringIndeksAktoerRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
                                        CVRnr = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    ItSystem = new[] { new ItSystemRelationType1() {
                                        SystemNavn = ConfigVariables.ANVENDER_SYSTEM_NAVN,
                                        SystemURI = "ÆØÅ",
                                        Rolle = new UnikIdType() {
                                                Item = ConfigVariables.MASTER_UUID, // Constant for Master
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = ConfigVariables.IT_SYSTEM_TYPE_UUID, // Constant for IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = ConfigVariables.ANVENDER_SYSTEM_UUID, // The UUID of your IT-system
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    OekonomiskEffektueringPart = new[] { new OekonomiskEffektueringIndeksPartRelationType() {
                                        BrugervendtNoegle = "ÆØÅ",
                                        FuldtNavn = "ÆØÅ",
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
                                            NoteTekst = "ÆØÅ"
                                        },
                                        Rolle = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Type = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        Indeks = "ÆØÅ",
                                        ReferenceID = new UnikIdType() {
                                            Item = "ÆØÅ",
                                            ItemElementName = ItemChoiceType.UUIDIdentifikator
                                        },
                                        LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                            Any = new [] {
                                                (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                            },
                                            SenestAendretTidspunkt = DateTime.Now,
                                            SenestAendretTidspunktSpecified = true
                                        }
                                    }
                                    },
                                    LokalUdvidelseListe = new LokalUdvidelseListeType() {
                                        Any = new [] {
                                            (new System.Xml.XmlDocument()).CreateElement("ÆØÅ")
                                        },
                                        SenestAendretTidspunkt = DateTime.Now,
                                        SenestAendretTidspunktSpecified = true
                                    }
                                },
                                MaksimalAntalKvantitet = "999",
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = "ÆØÅ",
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                SoegVirkning = new SoegVirkningType() {
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
                                    NoteTekst = "ÆØÅ",
                                },
                                SoegStsFraTidspunkt = new TidspunktType() {
                                    Item = DateTime.Now,
                                },
                                SoegStsTilTidspunkt = new TidspunktType() {
                                    Item = true
                                },

                            },
                            new SoegInputType() {
                                FoersteResultatReference = "ÆØÅ",
                                SoegRegistrering = new SoegRegistreringType() {
                                    BrugerRef = new UnikIdType() {
                                        Item = "ÆØÅ",
                                        ItemElementName = ItemChoiceType.UUIDIdentifikator
                                    },
                                    LivscyklusKode = LivscyklusKodeType.Importeret,
                                    LivscyklusKodeSpecified = true,
                                    FraTidspunkt = new TidspunktType() {
                                        Item = DateTime.Now,
                                    },
                                    TilTidspunkt = new TidspunktType() {
                                        Item = true
                                    },
                                },
                                MaksimalAntalKvantitet = "ÆØÅ",
                                SoegVirkning = new SoegVirkningType() {
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
                                    NoteTekst = "ÆØÅ",
                                }
                            },
                        },
                        operation = AndOrType.AND,
                        operationSpecified = true,
                        ItemsElementName = new[] {
                            ItemsChoiceType.SoegUdtryk,
                            ItemsChoiceType.SoegBevillingIndeks,
                            ItemsChoiceType.SoegOekonomiskEffektueringIndeks,
                            ItemsChoiceType.NOT
                        },
                    }
                },
                RequestHeader = RequestHeader
            };

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
