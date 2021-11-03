const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
const express = require('express');
const bodyParser = require("body-parser");
const fs = require('fs');
var cors = require('cors')
const app = express();
const PORT = 3001;

app.use(cors())
app.use( bodyParser.json() )
app.listen(PORT, () => {
    console.log(`running on port ${PORT}`)
})


app.get("/test", (req, res) => {
  res.end('test')
  /*MongoClient.connect(process.env.MONGODB_URL, async (err, db) => {
      if (err) throw err;
      
      const result = await db.db("appex").collection('tournaments').find().toArray()
      console.info(result[0])
      db.close()
      res.json(result)
      //return result;
  });*/
})
app.post("/newtournament", async (req, res) => {
  console.log(req.body)
  //const body = req.body;
  //const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2];
  const matches = [];
  /*let rounds = defaultRounds.filter(p => p <= req.body.players.length)
  for (let i = 0; i < rounds[0] / 2; i++) {
    matches.push([])
    for (let z = 0; z < rounds[i] / 2; z++) {
      matches[i].push([])
    }
  }
  MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', function(err, db) {
      if (err) throw err;
      
      db.db("appex").collection('tournaments').insertOne({name: req.body.tournamentname, date: Date.now(), players: req.body.players})
      console.log('db created')
      db.close()
  });

  let player = 0;
  for (let i = 0; i < matches[0].length; i++) {
    matches[0][i].push(req.body.players[player].name)
    player++;
    matches[0][i].push(req.body.players[player].name)
    player++;
  }*/

  res.end(matches)
});