const tournamentModel = require('../models/tournament')

exports.gettournaments = async (req, res, next) => {
    try {
        const tournaments = await tournamentModel.find()
        if (!tournaments) {
          const error = new Error("tournaments not found!");
          error.statusCode = 401;
          throw error;
        }
        console.log(tournaments)
        res.status(200).json({
            message: "Found Tournaments",
            tournaments: tournaments
        });
    } catch (err) {
        if (!err.statusCode) {
            err.statusCode = 500;
        }
        next(err);
    }
}

exports.newtournament = async (req, res, next) => {
    console.log(req.body)
    const body = req.body;
    const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
    const matches = [];
    let rounds = defaultRounds.filter(p => p <= req.body.players.length)
    for (let i = 0; i < rounds.length; i++) {
        matches.push([])
        for (let z = 0; z < rounds[i] / 2; z++) {
            matches[i].push([])
        }
    }
    
    let player = 0;
    for (let i = 0; i < matches[0].length; i++) {
        matches[0][i].push(req.body.players[player].name)
        player++;
        matches[0][i].push(req.body.players[player].name)
        player++;
    }
    const tournament = new tournamentModel({
        name: req.body.tournamentname,
        date: req.body.tournamentdate,
        players: req.body.players,
        status: 'Fremtidig',
        matches: matches
    })
    const result = await tournament.save();
    res.status(200).json({
      message: "Tournament Created",
      matches: matches
    });
}

exports.updatetournament = async (req, res, next) => {
    const {tournamentname, newname, newdate, players} = req.body;
    try {
        const tournament = await tournamentModel.findOneAndUpdate(
          {
            name: tournamentname
          },
          {
            name: newname,
            date: newdate, 
            players: players
          }
        )
        if (!tournament) {
          const error = new Error("tournament with this name not found!");
          error.statusCode = 401;
          throw error;
        }
    } catch (err) {
        if (!err.statusCode) {
            err.statusCode = 500;
        }
        next(err);
    }
}