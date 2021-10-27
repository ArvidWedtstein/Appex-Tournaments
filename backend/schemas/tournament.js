//Require Mongoose
const mongoose = require('mongoose')
const reqString = {
    type: String,
    required: true,
}
const reqNumber = {
    type: Number,
    required: true,
    default: 0
}


const tournamentSchema = mongoose.Schema({
    tournamentId: reqString,
    date: {
        type: Date,
        default: Date.now()
    },
    players: {
        type: [Object],
        required: true,
    }
})

module.exports = mongoose.model('tournaments', tournamentSchema)