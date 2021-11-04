const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
module.exports = async () => {
    const uri = "mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority";
    const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });
    client.connect(async (err) => {
        const result = await client.db("appex").collection('tournaments').find().toArray()
        console.info(result[0])
        client.close();
        return JSON.stringify(result)
    // perform actions on the collection object
        
    });
}