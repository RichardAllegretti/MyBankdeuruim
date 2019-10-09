using System.Xml.Serialization;

namespace MyBank.Dominio.objetos
{
    [XmlRoot]
	public class Agencia
	{
        [XmlElement]
		public int Id { get; set; }

        [XmlElement]
        public int Codigo { get; set; }

        [XmlElement]
		public string Nome { get; set; }

        [XmlElement]
		public string NomeCidade { get; set; }

        [XmlElement]
		public string UF { get; set; }

	}
}
