import { defineStore } from 'pinia'
import axios from 'axios'
export const useTournamentStore = defineStore('tournaments', {
  state: () => {
    return { 
      tournaments: []
    }
  },
  // could also be defined as
  // state: () => ({ count: 0 })
  actions: {
    async load(baseURL) {

      const tournamentlist = await axios.get(`${baseURL}/get-tournament`);
      this.tournaments = tournamentlist.data;
    },
    async new(baseURL, name, date, players: string[]) {
      try {
        await axios.post(`${baseURL}/createTournament?tournamentName=${name}&tournamentDate=${date}`, players).then(async (res) => {
          this.tournaments.push(res.data.newTournament);
          let newtournament = res.data.newTournament;
          let previewtournament = res.data.previewtournament;
  
          console.log(res.data)
          return {newtournament, previewtournament}
        })
      } catch (error) {
        return console.error(error)
      }
      
    },
    getById(id) {
      return this.tournaments.find((tournament) => tournament.id === id);
    },
    async matchwin(baseURL, tournamentId, winnerId, matchId) {
      const t = this.tournaments.find((tournament) => tournament.id === tournamentId);
      // Crappy code for checking if the match has a winner.
      for(let i = 0; i < t.rounds.length; i++) {
        var match = t.rounds[i].find((match) => match.id === matchId);
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
      }
    },
    async reset(baseURL, id) {
      const t = await axios.get(`${baseURL}/resetTournament/${id}`).then(async (res) => {
        let chosentournament = this.tournaments.find((tournament) => tournament.id === id);

        this.tournaments[this.tournaments.indexOf(chosentournament)] = res.data;
      });
    },
    async delete(baseURL, tournamentId) {
      const del = this.tournaments.find((tournament) => tournament.id === tournamentId);
      this.tournaments.splice(this.tournaments.indexOf(del), 1);
      axios.delete(`${baseURL}/deletetournament`, {
        data: {
          id: tournamentId
        }
      });
    }
  }
})
