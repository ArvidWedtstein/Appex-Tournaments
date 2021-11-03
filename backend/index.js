const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
import { useBody } from 'h3'
const express = require('express');
const bodyParser = require("body-parser");
const fs = require('fs');
const app = express();
const PORT = 3001;

var mysql = require('mysql')
var connection = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'appex'
})

app.use( bodyParser.json() )
app.listen(PORT, () => {
    console.log(`running on port ${PORT}`)
})

const tournament = (req, res) => {
  res.send('test');
}

app.get("/test", tournament);
app.get("/gettournaments", (req, res) => {
  MongoClient.connect(process.env.MONGODB_URL,, async (err, db) => {
        if (err) throw err;
        
        const result = await db.db("appex").collection('tournaments').find().toArray()
        console.log(result)
        db.close()
        res.end(result)
        
    });
})
app.post("/newtournament", (req, res) => {
  const body = await useBody(req)
  const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2];
  const matches = [];
  let rounds = defaultRounds.filter(p => p <= body.players.length)
  for (let i = 0; i < rounds[0] / 2; i++) {
    matches.push([])
    for (let z = 0; z < rounds[i] / 2; z++) {
      matches[i].push([])
    }
  }
  MongoClient.connect('mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority', function(err, db) {
      if (err) throw err;
      
      db.db("appex").collection('tournaments').insertOne({name: body.tournamentname, date: Date.now(), players: body.players})
      console.log('db created')
      db.close()
  });

  let player = 0;
  for (let i = 0; i < matches[0].length; i++) {
    matches[0][i].push(body.players[player].name)
    player++;
    matches[0][i].push(body.players[player].name)
    player++;
  }

  res.end(matches)
});