exports.gettournaments = async (req, res, next) => {
    const client = new MongoClient(process.env.MONGODB_URL, { useNewUrlParser: true, useUnifiedTopology: true });
    client.connect(async (err) => {
        const result = await client.db("appex").collection('tournaments').find().toArray()
        console.info(result[0])
        client.close();
        return JSON.stringify(result)
        
    });
}

exports.newtournament = async (req, res, next) => {
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
    MongoClient.connect(process.env.MONGODB_URL, async (err, db) => {
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
}

exports.updatetournament = async (req, res, next) => {
    const {projectname, newname, newdate, players} = req.body;
    MongoClient.connect(process.env.MONGODB_URL, function(err, db) {
        if (err) throw err;
        db.db("appex").collection('tournaments').findOneAndUpdate(
          {
            name: projectname
          },
          {
            name: newname,
            date: newdate,
            players: players
          }
        )
        db.close()
    });
  
    return JSON.stringify(matches)
}