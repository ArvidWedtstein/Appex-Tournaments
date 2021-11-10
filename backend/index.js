const MongoClient = require('mongodb').MongoClient;
require('dotenv').config();
const express = require('express');
const bodyParser = require("body-parser");
const fs = require('fs');
var cors = require('cors')
const app = express();
const mongoose = require("mongoose");


const router = require("./routes/router");

app.use(cors())
app.use( bodyParser.json() )

app.use("", router);

app.use((error, req, res, next) => {
  console.log(error);
  const status = error.statusCode || 500;
  const message = error.message;
  const data = error.data;
  res.status(status).json({ message: message, data: data });
});


mongoose.connect(process.env.MONGODB_URL).then((result) => {
    app.listen(process.env.PORT || 8080);
    console.log(`Listening to your request on ${process.env.PORT}`)
}).catch((err) => console.log(err));
