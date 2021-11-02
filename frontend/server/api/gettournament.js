
import { MongoClient } from 'mongodb';
import mysql from 'mysql';

export default (async (req, res) => {
    MongoClient.connect('mongodb://localhost:27017/appex', function(err, db) {
        if (err) throw err;
    
        db.collection('tournaments').find().toArray(function (err, result) {
            if (err) throw err
            res.end(result)
            console.log(result)
            db.close();
        })
    });
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
})
