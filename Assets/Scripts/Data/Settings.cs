using System.Xml.Serialization;

namespace aictr.data
{
    /// <summary>
    /// Stores application settings
    /// </summary>
    [XmlRoot]
    public class Settings
    {
        [XmlElement]
        public string ServerUrl { get; set; }
    }
}