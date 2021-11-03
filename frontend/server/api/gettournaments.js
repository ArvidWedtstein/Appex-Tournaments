

import { MongoClient } from 'mongodb';
//import mysql from 'mysql';

export default (async (req) => {
    const body = await useBody(req)
    /*const client = new MongoClient('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', { useNewUrlParser: true, useUnifiedTopology: true });
    client.connect(err => {
        if (err) throw err;
        
        const result = client.db("appex").tournaments.find().toArray()
        console.log('found results')
        console.log(result)
        client.close()
        
    });*/
    return MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', async (err, db) => {
        if (err) throw err;
        
        const result = await db.db("appex").collection('tournaments').find().toArray()
        console.log(result)
        db.close()
        return {
            result: result
        }
        
    });
   
    

    
})
