using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace appIFSIntegraatio.IFS
{
  public class PaymentdataParser
  {

    public static SelectResponse ParseResponse(string xml)
    {

      XmlSerializer serializer = new XmlSerializer(typeof(SelectResponse));

      StringReader reader = new StringReader(xml);

      XmlReader xmlReader = XmlReader.Create(reader);

     return (SelectResponse)serializer.Deserialize(xmlReader);

    }

  }
}
