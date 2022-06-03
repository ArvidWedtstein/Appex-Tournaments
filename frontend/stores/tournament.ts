import { defineStore } from 'pinia'
import axios from 'axios'
import { load } from 'dotenv';
export const useTournamentStore = defineStore('tournaments', {
  state: () => {
    return { 
      tournaments: []
    }
  },
  actions: {
    async load(baseURL: string) { // Load tournaments function
      const tournamentlist = await axios.get(`${baseURL}/get-tournament`);
      this.tournaments = tournamentlist.data;
    },
    async new(baseURL: string, name: string, date: any, players: any) { // Function for creating new tournaments
      let newtournament = {};
      let previewtournament = {};
      try {
        await axios.post(`${baseURL}/createTournament?tournamentName=${name}&tournamentDate=${date}`, players).then(async (res) => {
          this.tournaments.push(res.data.newTournament);
          newtournament = res.data.newTournament;
          previewtournament = res.data.previewtournament;
        })
      } catch (error) {
        return console.error(error)
      }
      return {newtournament, previewtournament};
    },
    getById(id) { // Function for gettin a tournaments by ID
      if (this.tournaments.length < 1) {
        console.log('get tournament')
        this.load("https://localhost:7021");
      }
      return this.tournaments.find((tournament) => tournament.id === id);
    },
    async matchwin(baseURL: string, tournamentId, winnerId, matchId) { // Function for setting a winner
      const t = this.tournaments.find((tournament) => tournament.id === tournamentId);

      // Crappy code for checking if the match has a winner.
      t.rounds.forEach(async (round) => {
        var match =round.find((match) => match.id === matchId);
        if (match) {
          if (match.winner) {
            if (match.winner.id != '') {
              return
            } else {
              const uri = `${baseURL}/matchwin?id=${tournamentId}&winnerId=${winnerId}&matchId=${matchId}`
              axios({
                method: 'post',
                url: uri
              }).then((response) => {
                const edit = this.tournaments.find((tournament) => tournament.id === response.data.id);
                this.tournaments[this.tournaments.indexOf(edit)] = response.data;
                return this.tournaments.find((tournament) => tournament.id === response.data.id);
              });
            }
          }
        }
      });
    },
    async reset(baseURL: string, tournamentId: string) { // Function for resetting a tournament.
      await axios.get(`${baseURL}/resetTournament/${tournamentId}`).then(async (res) => {
        let chosentournament = this.tournaments.find((tournament) => tournament.id === tournamentId);
        this.tournaments[this.tournaments.indexOf(chosentournament)] = res.data;
      });
    },
    async delete(baseURL: string, tournamentId: string) { // Function for letting a tournament magically disappear
      const del = this.tournaments.find((tournament) => tournament.id === tournamentId);
      this.tournaments.splice(this.tournaments.indexOf(del), 1);
      axios.delete(`${baseURL}/deletetournament`, {
        data: {
          id: tournamentId
        }
      });
    },
    async editPlayers(baseURL: string, tournamentId: string, players: string[]) { // Function for editing the players of a tournament
      axios.post(`${baseURL}/updateTournamentPlayers?tournamentId=${tournamentId}`, {
      	players: players
      });
    },
    async update(baseURL: string, tournament: any) { // Function for updating a tournament
      if (!tournament) return "Invalid Tournament";
      axios.post(`${baseURL}/updateTournament`, {
        id: tournament.id,
        name: tournament.Name,
        rounds: tournament.rounds
      });
    }
  }
})
