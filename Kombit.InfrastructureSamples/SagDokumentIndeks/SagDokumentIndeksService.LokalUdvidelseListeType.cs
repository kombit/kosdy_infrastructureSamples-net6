namespace Kombit.InfrastructureSamples.SagDokumentIndeksService {
    /// <summary>
    /// Add-on class to use LokalUdvidelseLists. It originally comes with an 'any' property of the type XmlElement, but we want objects.
    /// The types of objects we want to serialize are defined above the Udvidelse property.
    /// </summary>
    public partial class LokalUdvidelseListeType {

        [System.Xml.Serialization.XmlElement("SagIndeksEgenskaber", typeof(EgenskaberTypeSag), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("SagsaktoerLokalUdvidelse", typeof(SagsaktoerLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("SagspartLokalUdvidelse", typeof(SagspartLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("SagsklasseLokalUdvidelse", typeof(SagsklasseLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("SagsgenstandeLokalUdvidelse", typeof(SagsgenstandeLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("SagsitsystemRelation", typeof(SagsitsystemRelationType), Order = 4, Namespace = "urn:oio:sts:sagdok:sagindeks:6")]
        [System.Xml.Serialization.XmlElement("DokumentaktoerLokalUdvidelse", typeof(DokumentaktoerLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:dokumentindeks:6")]
        [System.Xml.Serialization.XmlElement("DokumentklasseLokalUdvidelse", typeof(DokumentklasseLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:dokumentindeks:6")]
        [System.Xml.Serialization.XmlElement("DokumentpartLokalUdvidelse", typeof(DokumentpartLokalUdvidelseType), Order = 4, Namespace = "urn:oio:sts:sagdok:dokumentindeks:6")]

        public object[] Udvidelse { get; set; }
    }
}
