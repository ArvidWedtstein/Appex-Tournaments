
import { MongoClient } from 'mongodb';
import mysql from 'mysql';


export default async (req, res) => {
    // Replace the uri string with your MongoDB deployment's connection string.
    const uri = "mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net";
    const client = new MongoClient(uri);
    interface Haiku {
      title: string;
      content: string;
    }
    async function run() {
      try {
        await client.connect();
        const database = client.db("appex");
        // Specifying a Schema is optional, but it enables type hints on
        // finds and inserts
        const haiku = database.collection<Haiku>("tournaments");
        const result = await haiku.insertOne({
          title: "Record of a Shriveled Datum",
          content: "No bytes, no problem. Just insert a document, in MongoDB",
        });
        res.send(result)
        console.log(`A document was inserted with the _id: ${result.insertedId}`);
      } finally {
        await client.close();
      }
    }
    run().catch(console.dir);
    /*MongoClient.connect('mongodb://localhost:27017/appex', function(err, db) {
        if (err) throw err;
    
        db.collection('tournaments').find().toArray(function (err, result) {
        if (err) throw err
        res.send(result)
        console.log(result)
        db.close();
        })
    });*/
    /*var connection = mysql.createConnection({
        host: 'localhost',
        user: 'root',
        password: '',
        database: 'appex'
      })
      
      connection.connect()
      connection.query('SELECT * FROM `tournaments`', function (err, rows, fields) {
        if (err) throw err
        res.send(rows)
        //console.log(rows)
      })
      
      connection.end()*/
}