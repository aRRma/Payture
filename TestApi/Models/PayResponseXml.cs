using System.Xml.Serialization;


namespace TestApi
{
    [XmlRoot("Pay")]
    public class PayResponseXml
    {
        [XmlAttribute("OrderId")]
        public string OrderId { get; set; }
        [XmlAttribute("Key")]
        public string Key { get; set; }
        [XmlAttribute("Success")]
        public string Success { get; set; }
        [XmlAttribute("Amount")]
        public int Amount { get; set; }
        [XmlAttribute("ErrCode")]
        public string ErrorCode { get; set; }

        public override string ToString() => $"OrderId = {OrderId}\n" +
                                             $"Key = {Key}\n" +
                                             $"Success = {Success}\n" +
                                             $"Amount = {Amount}\n" +
                                             $"ErrorCode = {ErrorCode ?? new string("NONE")}";
    }
}
