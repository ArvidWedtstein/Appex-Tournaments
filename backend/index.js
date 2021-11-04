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
  
});