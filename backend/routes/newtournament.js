const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
module.exports = () => {
    const body = req.body;
    const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2];
    const matches = [];
    let rounds = defaultRounds.filter(p => p <= req.body.players.length)
    for (let i = 0; i < rounds[0] / 2; i++) {
      matches.push([])
      for (let z = 0; z < rounds[i] / 2; z++) {
        matches[i].push([])
      }
    }
    MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', function(err, db) {
        if (err) throw err;
        
        db.db("appex").collection('tournaments').insertOne({name: req.body.tournamentname, date: req.body.tournamentdate, players: req.body.players})
        console.log('db created')
        db.close()
    });
  
    let player = 0;
    for (let i = 0; i < matches[0].length; i++) {
      matches[0][i].push(req.body.players[player].name)
      player++;
      matches[0][i].push(req.body.players[player].name)
      player++;
    }
  
    return JSON.stringify(matches)
}
    