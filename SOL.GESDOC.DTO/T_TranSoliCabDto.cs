using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SOL.GESDOC.DTO
{
    public class T_TranSoliCabDto
    {
        public Int64 IdeSoli { get; set; }
        public String NumSoli { get; set; }
        public DateTime FecSoli { get; set; }
        public Int64 IdeUser { get; set; }
        public int CanSoli { get; set; }
        public String EstRegi { get; set; }
        public String CodUscr { get; set; }
        public DateTime FecUscr { get; set; }
        public String CodUsmo { get; set; }
        public DateTime FecUsmo { get; set; }
        public List<T_TranSoliDetDto> Items { get; set; }
        public string GetItemsXML()
        {
            XmlDocument objXML = new XmlDocument();
            XmlNode objNode = default(XmlNode);

            objNode = objXML.CreateElement("Items");

            objXML.AppendChild(objNode);

            foreach (T_TranSoliDetDto item in Items)
            {
                objNode = objXML.CreateElement("Item");
                
                XmlAttribute at01 = objNode.OwnerDocument.CreateAttribute("Item"); at01.Value = item.Item.ToString();
                XmlAttribute at02 = objNode.OwnerDocument.CreateAttribute("IdeProd"); at02.Value = item.IdeProd.ToString();
                XmlAttribute at03 = objNode.OwnerDocument.CreateAttribute("CanProd"); at03.Value = item.CanProd.ToString();
                XmlAttribute at04 = objNode.OwnerDocument.CreateAttribute("EstRegi"); at04.Value = item.EstRegi.ToString();

                objNode.Attributes.Append(at01);
                objNode.Attributes.Append(at02);
                objNode.Attributes.Append(at03);
                objNode.Attributes.Append(at04);                               

                objXML.DocumentElement.AppendChild(objNode);
            }

            return objXML.InnerXml;

        }
    }
}
