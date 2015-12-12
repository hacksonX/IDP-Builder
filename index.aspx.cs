using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        makeTable();
    }

    public async void makeTable()
    {
        IMongoClient _client;
        IMongoDatabase theDB;

        _client = new MongoClient();
        theDB = _client.GetDatabase("idpDB");
        var myDOc = new BsonDocument
        {
            {"Population_growth", new BsonDocument
                {
                    { "Municipality", new BsonArray {"Bloudberg", "Aganang", "Polokwane", "Lepelle-Nkumpi", "Capricorn"}},
                    { "2001 Population", new BsonArray {171.721, 146.872, 109.441, 508.277, 227.970, 1164281 } },
                    { "2011 Population", new BsonArray {162629, 131164, 108321, 628999,230350, 1261463} },
                    { "Population Growth Rate (2001-2011)", new BsonArray {-0.54, -1.13, -0.1, 2.13, 0.1, 0.8 } }


                }
             }
        };
        var collection = theDB.GetCollection<BsonDocument>("Population_Growth");
        await collection.InsertOneAsync(myDOc);
        someData.InnerHtml = "Works";
    }
}