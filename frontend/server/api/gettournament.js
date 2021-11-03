
import { MongoClient } from 'mongodb';

//import mysql from 'mysql';

export default (async (req, res) => {

    MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', function(err, db) {
        if (err) throw err;
    
        db.collection('tournaments').find().toArray(function (err, result) {
            if (err) throw err
            
            db.close();
            return {
              tournament: result
            }
        })
    });
    
})
