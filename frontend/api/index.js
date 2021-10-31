//const MongoClient = require('mongodb').MongoClient;

const express = require('express');
const app = express();
const bodyParser = require("body-parser");
var mysql = require('mysql')

const PORT = 3001;

app.use( bodyParser.json() )
app.listen(PORT, () => {
    console.log(`running on port ${PORT}`)
})
module.exports = app;


/*const tournament = (req, res) => {
  res.send('test');
}

let tournamentID = 0;
app.get("/test", tournament);
app.get("/gettournaments", (req, res) => {

  var connection = mysql.createConnection({
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
  
  connection.end()
  
})
app.post("/newtournament", (req, res) => {
  const { name, players } = req.body;
  res.send(`Tournament name: ${name}\n${players}`);

  var connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'appex'
  })
  connection.connect()
  connection.query(`INSERT INTO tournaments (name, players) VALUES ("${name}", "${players}")`, function (err, rows, fields) {
    if (err) throw err
  
    console.log('INSERT')
  })
  res.send("Get ")
  connection.end()
  tournamentID++;
});*/