const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
module.exports = () => {
    MongoClient.connect(process.env.MONGODB_URL, async (err, db) => {
        if (err) throw err;
        
        const result = await db.db("appex").collection('tournaments').find().toArray()
        console.info(result[0])
        db.close()
        return JSON.stringify(result)
        //return result;
    });
}