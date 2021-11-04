const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
module.exports = (projectname, newname, newdate, players) => {

    MongoClient.connect(process.env.MONGODB_URL, function(err, db) {
        if (err) throw err;
        db.db("appex").collection('tournaments').findOneAndUpdate(
          {
            name: projectname
          },
          {
            name: newname,
            date: newdate,
            players: players
          }
        )
        db.close()
    });
  
    return JSON.stringify(matches)
}
    