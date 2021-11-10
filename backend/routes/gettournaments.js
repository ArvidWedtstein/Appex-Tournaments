const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
module.exports = async () => {
    const client = new MongoClient(process.env.MONGODB_URL, { useNewUrlParser: true, useUnifiedTopology: true });
    client.connect(async (err) => {
        const result = await client.db("appex").collection('tournaments').find().toArray()
        console.info(result[0])
        client.close();
        return JSON.stringify(result)
        
    });
}