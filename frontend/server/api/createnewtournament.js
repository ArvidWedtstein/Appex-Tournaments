

import { MongoClient } from 'mongodb';
//import mysql from 'mysql';
import { useBody } from 'h3'


export default (async (req) => {
    console.log()
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

    let player = 0;
    for (let i = 0; i < matches[0].length; i++) {
      matches[0][i].push(body.players[player].name)
      player++;
      matches[0][i].push(body.players[player].name)
      player++;
    }

    return {
        matches: matches
    }
})
