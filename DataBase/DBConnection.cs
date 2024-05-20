using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace CadastraAlunos.DataBase
{
    public class DBConnection
    {
        private static string uri = "mongodb://localhost:27017";
        public MongoClient Client;
        public IMongoDatabase Db;

        public DBConnection()
        {

            this.Client = new MongoClient(uri);
            this.Db = Client.GetDatabase("Banco_de_Dados");
        }
    }
}
