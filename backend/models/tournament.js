
const express = require("express");
const mongoose = require("mongoose");
const Schema = mongoose.Schema;
// Status: ['Fremtidig', 'Påbegynnt', 'Gjennomført']
const TournamentSchema = new Schema(
  {
    name: {
      type: String,
      required: true,
    },
    date: {
      type: Date,
      required: true,
    },
    players: {
        type: Object, 
        required: true,
    },
    status: {
        type: String,
        required: true,
    },
  },
  { timestamps: true }
);

module.exports = mongoose.model("Tournament", TournamentSchema);