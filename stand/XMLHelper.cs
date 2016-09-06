using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace stand
{
    public class XMLHelper
    {
        public static bool DataTableToXML(DataTable dtTable, string strXMLPath)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            StreamWriter sw = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.UTF8);
                dtTable.WriteXml(writer, XmlWriteMode.WriteSchema);
                int nCount = (int)stream.Length;
                byte[] arr = new byte[nCount];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, nCount);
                UTF8Encoding utf = new UTF8Encoding();
                string strContent = utf.GetString(arr).Trim();
                sw = new StreamWriter(strXMLPath);
                sw.Write(strContent);

                return true;
            }
            catch (System.Exception vErr)
            {
                MessageBox.Show(vErr.Message);
                return false;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
        public static DataTable XMLToDataTable(string strXMLPath)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            StreamReader sr = null;
            try
            {
                if (strXMLPath.Length <= 0)
                {
                    return new DataTable();
                }
                sr = new StreamReader(strXMLPath);
                string strXmlContent = sr.ReadToEnd();
                stream = new StringReader(strXmlContent);
                reader = new XmlTextReader(stream);
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                return ds.Tables[0];
            }
            catch (System.Exception vErr)
            {
                MessageBox.Show(vErr.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (reader != null)
                    reader.Close();
            }
            return new DataTable();
        }
    }
}