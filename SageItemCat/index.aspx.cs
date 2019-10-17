using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SageItemCat
{
    public partial class index : System.Web.UI.Page
    {
        private Stream dataStream;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnGet_Click(object sender, EventArgs e)
        //{
        //    WebRequest req = WebRequest.Create(@"http://192.168.0.138:8124/api1/x3/erp/PILOT1/ITMCATEG?representation=ITMCATEG.$query&count=1000");
        //    req.Method = "GET";
        //    req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("admin:dione123"));
        //    //req.Credentials = new NetworkCredential("username", "password");
        //    //HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
        //    //var reader = new StreamReader(resp.GetResponseStream());
        //    //JavaScriptSerializer js = new JavaScriptSerializer();
        //    //var objText = reader.ReadToEnd();
        //    //Myobject myobject = (Myobject)js.Deserialize(objText, typeof(Myobject));

        //    HttpWebResponse response = req.GetResponse() as HttpWebResponse;
        //    // Display the status.
        //    Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        //    // Get the stream containing content returned by the server.
        //    dataStream = response.GetResponseStream();
        //    // Open the stream using a StreamReader for easy access.
        //    StreamReader reader = new StreamReader(dataStream);
        //    // Read the content.
        //    string responseFromServer = reader.ReadToEnd();
        //    // im using javascriptserializer from the System.Web.Script.Serialization namespace
        //    JavaScriptSerializer j = new JavaScriptSerializer();
        //    Myobject model = j.Deserialize<Myobject>(responseFromServer .Content);

        //}
        //public class Myobject
        //{
        //    public string TCLAXX { get; set; }
        //    public string TCLCODE { get; set; }
        //}

        protected void btnGet_Click(object sender, EventArgs e)
        {
            WebRequest req = WebRequest.Create(@"http://192.168.0.137:8124/api1/x3/erp/PILOT/ITMCATEG?representation=ITMCATEG.$query&count=1000");
            req.Method = "GET";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("admin:dione987"));
            //req.Credentials = new NetworkCredential("username", "password");
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            JsonReader jr = new JsonTextReader(reader);
            string objText = reader.ReadToEnd();
            DataList dataList = JsonConvert.DeserializeObject<DataList>(objText);
            foreach (var data in dataList.resources)
            {
                Console.WriteLine("id: {0}, name: {1}", data.TCLAXX, data.TCLCOD);
                DataTable dataTable = SPSageimport.insert(data.TCLAXX, data.TCLCOD);
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

        }

        public class MyObject
        {
            public string TCLAXX { get; set; }
            public string TCLCOD { get; set; }
        }

        public class DataList
        {
            [JsonProperty("$resources")]
            public List<MyObject> resources { get; set; }
        }
    }
}