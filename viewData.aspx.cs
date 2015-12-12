using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public partial class viewData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getData();
    }

    public async void getData()
    {
        IMongoClient _client;
        IMongoDatabase theDB;

        _client = new MongoClient();
        theDB = _client.GetDatabase("idpDB");
        var collection = theDB.GetCollection<BsonDocument>("Population_Growth");
        var filter = new BsonDocument();
        var count = 0;
        someData.InnerHtml = "";
        using (var cursor = await collection.FindAsync(filter))
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    someData.InnerHtml += document.First().Name.ToString() + "<br/>";
                    someData.InnerHtml += document.First().Value.ToString() + "<br/>";
                    someData.InnerHtml += document.Last().Name.ToString() + "<br/>";
                    someData.InnerHtml += document.Last().Value.ToString() + "<br/>";
                    count++;
                }
            }
        }
    }
}