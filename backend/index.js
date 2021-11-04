const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
const express = require('express');
const bodyParser = require("body-parser");
const fs = require('fs');
var cors = require('cors')
const app = express();
const PORT = 3001;


// Routes //
const gettournaments = require('./routes/gettournaments')
const newtournament = require('./routes/newtournament')


app.use(cors())
app.use( bodyParser.json() )
app.listen(PORT, () => {
    console.log(`running on port ${PORT}`)
})

const tournament = (req, res) => {
  res.end('test')
}

app.get("/gettournaments", gettournaments);
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
    MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', async (err, db) => {
        if (err) throw err;
        
        await db.db("appex").collection('tournaments').insertOne({name: req.body.tournamentname, date: req.body.tournamentdate, players: req.body.players})
        console.log('db created')
        await db.close()
    });
  
    let player = 0;
    for (let i = 0; i < matches[0].length; i++) {
      matches[0][i].push(req.body.players[player].name)
      player++;
      matches[0][i].push(req.body.players[player].name)
      player++;
    }
  
    return JSON.stringify(matches)
});