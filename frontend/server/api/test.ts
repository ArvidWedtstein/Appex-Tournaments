//const MongoClient = require('mongodb').MongoClient;
import type { IncomingMessage, ServerResponse } from 'http'
import mysql from 'mysql';
import {
  useCookies,
  useQuery,
  useBody,
  setCookie,
  appendHeader
} from 'h3'

let tournamentID = 0;

export default async (req: IncomingMessage, res: ServerResponse) => {
  console.log('newtournament')
  const headers = (req && req.headers) ? Object.assign({}, req.headers) : {}
  const xForwardedFor = headers['content'];
  console.log(xForwardedFor)
  console.log(req.url)
    //const { name, players } = req.body;
    //res.end(`Tournament name: \n${name}\n${players}`);

    /*var connection = mysql.createConnection({
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
    connection.end()
    tournamentID++;*/
}