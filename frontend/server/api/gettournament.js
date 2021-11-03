
import { MongoClient } from 'mongodb';
import url from 'url';
//import mysql from 'mysql';

export default (async (req, res) => {
  const query = url.parse(req.url, true).query
  res.end(query)
    MongoClient.connect('', function(err, db) {
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
