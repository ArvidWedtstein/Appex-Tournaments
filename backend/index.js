
var MongoClient = require('mongodb').MongoClient;
const uri = "mongodb+srv://appex:appex@cluster0.ovkm8.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });
client.connect(err => {
  const collection = client.db("test").collection("devices");
  // perform actions on the collection object
  client.close();
  console.log('connected');
});