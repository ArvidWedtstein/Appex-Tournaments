const MongoClient = require('mongodb').MongoClient;
const uri = "mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/appex?retryWrites=true&w=majority";





const express = require('express');
const bodyParser = require("body-parser");
const fs = require('fs');
const app = express();
const PORT = 5000;


app.use( bodyParser.json() )
app.listen(PORT, () => {
    console.log(`running on port ${PORT}`)
})

const tournament = (req, res) => {
  res.send('test');
}
let tournamentID = 0;
app.get("/", tournament);
app.post("/newtournament", (req, res) => {
  const { name, date, players } = req.body;
  res.send(`Tournament name: ${name}\n${date}\n${players}`);
  
  MongoClient.connect(uri, function(err, db) {
    if (err) throw err;
    var dbo = db.db("appex");
    var tournament = { tournamentId: tournamentID, name: name, date: date, players: players };
    dbo.collection("tournaments").insertOne(tournament, function(err, res) {
      if (err) throw err;
      console.log("1 document inserted");
      db.close();
    });
  });
  tournamentID++;
});