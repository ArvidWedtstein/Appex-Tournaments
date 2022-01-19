
<template>
  <main class="overflow-x-hidden relative w-full h-full left-0 p-8 flex flex-row items-center flex-nowrap transition-all duration-500 ease-in-out select-none">
    <h1 class="fixed text-2xl lg:text-4xl top-16 lg:top-8 font-semibold w-full text-center">Tidligere Turneringer</h1>
    <button class="fixed w-12 mx-4 my-8 left-0 bottom-0" @click="left()">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-left" class="svg-inline--fa fa-chevron-left fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
        <path fill="currentColor" d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04 33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57 9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z"></path>
      </svg>
    </button>
    <button class="fixed w-12 mx-4 my-8 right-0 bottom-0" @click="right()">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-right" class="svg-inline--fa fa-chevron-right fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
        <path fill="currentColor" d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941 0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484 101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941 0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z"></path>
      </svg>
    </button>
    <button class="fixed w-12 mx-4 my-20 left-0 top-0" @click="$router.go(-1)" title="back">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-left" class="svg-inline--fa fa-arrow-circle-left fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
        <path fill="currentColor" d="M256 504C119 504 8 393 8 256S119 8 256 8s248 111 248 248-111 248-248 248zm28.9-143.6L209.4 288H392c13.3 0 24-10.7 24-24v-16c0-13.3-10.7-24-24-24H209.4l75.5-72.4c9.7-9.3 9.9-24.8.4-34.3l-11-10.9c-9.4-9.4-24.6-9.4-33.9 0L107.7 239c-9.4 9.4-9.4 24.6 0 33.9l132.7 132.7c9.4 9.4 24.6 9.4 33.9 0l11-10.9c9.5-9.5 9.3-25-.4-34.3z"></path>
      </svg>
    </button>
    <!--Edit tournament-->
    <transition name="fade">
      <div class="w-full fixed bottom-0 top-0 left-0 p-16 p-40 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center" v-if="editTournamentScreen">
        <button class="fixed top-0 right-0 text-6xl" type="button" v-on:click="closeTournament()">✖</button>
        <div class="text-center flex-auto">
          <h1 class="text-4xl">Rediger Tournament</h1>
          <p class="text-2xl">{{editTournamentData.Name}}</p>
        </div>
        <div class="flex-auto">
          <h1 class="text-3md font-semibold">Navn:</h1>  
          <input v-model="editTournamentChanges.name" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2" type="text" placeholder="Tournament navn">
        </div>
        <div class="flex-auto">
          <h1 class="text-3md font-semibold">Dato:</h1> 
          <input v-model="editTournamentChanges.date" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2" type="date">
        </div>
        <div class="flex-auto">
          <h1 class="text-3md font-semibold">Status:</h1>
          <input v-model="editTournamentChanges.status" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2 m-2" type="radio" name="status" id="Fremtidig" value="Fremtidig" :checked="editTournamentData.status == 'Fremtidig'">
          <label for="Fremtidig">Fremtidig</label>
          <input v-model="editTournamentChanges.status" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2 m-2" type="radio" name="status" id="Påbegynt" value="Påbegynt" :checked="editTournamentData.status == 'Påbegynt'">
          <label for="Påbegynt">Påbegynt</label>
          <input v-model="editTournamentChanges.status" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2 m-2" type="radio" name="status" id="Gjennomført" value="Gjennomført" :checked="editTournamentData.status == 'Gjennomført'">
          <label for="Gjennomført">Gjennomført</label>
        </div>
        <div class="flex flex-auto flex-row items-center content-center justify-center">
          <button class="bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black m-1 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear" type="button" v-if="editTournamentData.status == 'Fremtidig'" @click="redigerDeltakerScreen = true">Rediger Deltakere</button>
          <button class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" type="button" @click="updateTournament()">Update</button>
          <button class="bg-red-900 hover:bg-red-500 text-white font-semibold hover:text-appexblack m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" type="button" @click="deleteTournament(editTournamentData._id)">Delete</button>
        </div>
      </div>
    </transition>
    <transition name="fade">
      <div class="w-full fixed bottom-0 top-0 left-0 pt-12 px-40 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center" v-if="showTournamentScreen">
        <button class="fixed top-0 right-0 text-6xl" type="button" v-on:click="closeTournament()">✖</button>
        <div class="text-center flex-auto">
          <h3><b>"{{showTournamentData.Name}}"</b> Turnering</h3>
          <h3>Status: <b>{{showTournamentData.status}}</b></h3>
        </div>
        <div class="flex-auto p-1">
          <div class="flex-auto relative content-center self-center align-middle">
            <div class="round" v-for="round in showTournamentData.rounds" :key="round">
              <div class="match" v-for="match in round" :key="match">
                <!-- <div class="match__content">{{match.id}}</div> -->
                <div class="matchplayer" v-for="player in match.players" :key="player">
                  <p class="player" v-cloak v-bind:class="{ 'winner': match.winner == player }">{{ player }}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="flex flex-auto flex-row items-center content-center">
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" :href="'/tournament/' + showTournamentData.id" v-if="showTournamentData.status == 'Påbegynt'" type="button">Fortsett turnering</a>
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" @click="resetTournament(showTournamentData.id)" v-if="showTournamentData.status == 'Gjennomført'" type="button">Gjenopprett turnering</a>
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" :href="'/tournament/' + showTournamentData.id" v-if="showTournamentData.status == 'Fremtidig'" type="button">Begynn turnering</a>
        </div>
      </div>
    </transition>
    <transition name="fade">
      <div class="w-full fixed bottom-0 top-0 left-0 pt-12 px-40 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center" v-if="redigerDeltakerScreen">
        <button class="text-2xl absolute top-0 right-0 p-12 hover:text-opacity-70" type="button" v-on:click="closeTournament()">✖</button>
        <div class="text-center flex-auto">
          <h1 class="text-xl">"{{ editTournamentData.Name }}" Deltakere</h1>
          <p class="text-lg">Rediger deltakere</p>
        </div>
        <div v-for="(player, h) in editPlayers" :key="player">
          <div class="m-1 flex">
            <input class="py-2 px-1 flex-auto bg-appexgrey border-b-2 border-solid border-abbexblue text-appexblack" v-model="editPlayers[h]" type="text" :placeholder= "'Deltaker' + h">
          </div>
        </div>
        <button class="bg-appexblue text-white rounded py-4 px-8 mx-2 my-2 hover:bg-white border border-transparent font-semibold hover:border-appexblue transition-all duration-100 ease-linear hover:text-appexblue" @click="redigerDeltakere()" type="button">Lagre</button>
      </div>
    </transition>
    <div v-for="(tournament, i) in tournaments" :key="tournament" :id="'tournament' + i" class="tournament flex-auto h-80 h-full relative flex flex-col w-80 p-0 top-30 my-auto rounded mx-16 transition-all duration-500 ease-in-out">
      <button class="absolute rotate-90 top-2.5 right-2.5 w-6 text-center" v-on:click="editTournament(tournament)">✎</button>
      <div class="absolute bottom-0 left-0 p-5">
        <div class="w-100 text-md pb-0 min-h-100 overflow-auto font-light">
          <p>Dato: {{formatDate(tournament.date)}}</p>
        </div>
        <div class="flex-auto w-100 max-h-8 text-xl font-semibold">
          <button class="no-underline hover:underline" v-on:click="showTournament(tournament)">{{tournament.Name}}</button>
        </div>
        <div class="tfooter">
          <p class="players">{{countPlayers(tournament)}}</p>
          <p v-if="tournament.status" class="status">{{tournament.status}}</p>
          <!--<p class="winner" :v-if="tournament.rounds[tournament.rounds.length - 1][0]">{{tournament.rounds[tournament.rounds.length - 1][0].winner}}</p>-->
        </div>
      </div>
    </div>
  </main>
</template>

<script>
//import env from '~/dotenv.json'
import axios from 'axios'
import Tournamentoverview from '~~/components/tournamentoverview.vue'
let intPlayer = 1;
export default {
  name: "Tournaments",
  async asyncData({ $axios, $config }) {

  },
  data() {
    return {
      tournaments: null,
      editTournamentScreen: false,
      showTournamentScreen: false,
      redigerDeltakerScreen: false,
      editTournamentData: null,
      showTournamentData: null,
      editPlayers: [],
      editTournamentChanges: {
        name: "",
        date: "",
        players: [],
        status: ""
      },
    };
  },
  methods: {
    async resetTournament(id) {
      const t = await axios.get(`${this.$config.baseURL}/resetTournament/${id}`).then(async (res) => {
        console.log(res.data)
        let chosentournament = this.tournaments.find(t => t.id === res.data.id);
        
        chosentournament = res.data;
        this.tournaments[this.tournaments.indexOf(chosentournament)] = chosentournament;
      });
      window.location.reload();
    },
    countPlayers(tournament) {
      let length = tournament.rounds[0].length * 2;
      return length
    },
    async fetchTournaments() {
      this.tournaments = [];
      const tournamentlist = await axios.get(`${this.$config.baseURL}/get-tournament`);
      this.tournaments = tournamentlist.data;
    },
    horizontalScroll() {
      const scrollContainer = document.querySelector("main");
      if (scrollContainer) {
        scrollContainer.addEventListener("wheel", (evt) => {
          evt.preventDefault();
          scrollContainer.scrollLeft += evt.deltaY;
        });
      }
    },
    formatDate(date) {
      const options = { year: "numeric", month: "numeric", day: "2-digit" };
      return new Date(date).toLocaleDateString("no", options);
    },
    updateTournament() {
      axios.post(`${this.$config.baseURL}/updateTournament`, {
        id: this.editTournamentData._id,
        name: this.editTournamentChanges.name,
        date: this.editTournamentChanges.date,
        status: this.editTournamentChanges.status
      }).then((res) => {
        this.editTournamentScreen = false;
        console.log(res);
        this.editTournamentChanges.name = "";
        this.editTournamentChanges.date = "";
        this.editTournamentChanges.status = "";
        this.editTournamentChanges.players = [];
        this.editTournamentData = null;
        this.$nuxt.refresh();
      });
    },
    async redigerDeltakere() {
      console.log(this.editPlayers)
    },
    left() {
      const scrollContainer = document.querySelector("main");
      var x = window.innerWidth;
      var tournaments = document.getElementsByClassName("tournament").length;
      for (let i = 0; i < 8; i++) {
        var step = (x / tournaments) * -2;
        scrollContainer.scrollLeft += step;
        console.log(i);
        setTimeout(1000);
      }
    },
    right() {
      const scrollContainer = document.querySelector("main");
      var x = window.innerWidth;
      var tournaments = document.getElementsByClassName("tournament").length;
      var step = (x / tournaments) * 16;
      scrollContainer.scrollLeft += step;
    },
    async editTournament(tournament) {
      console.log(tournament);
      this.editTournamentData = await tournament;
      this.editTournamentScreen = true;
      for (let a = 0; a < await tournament.rounds.length; a++) {
        console.log(tournament.rounds[a])
        for (let b = 0; b < tournament.rounds[a].length; b++) {
          for (let c = 0; c < tournament.rounds[a][b].players.length; c++) {
            this.editPlayers.push(tournament.rounds[a][b].players[c])
          }
        }
      }
      console.log(this.editPlayers)
    },
    async showTournament(tournament) {
      this.showTournamentData = await tournament;
      this.showTournamentScreen = true;
      console.log(this.showTournamentData);
    },
    closeTournament() {
      this.editTournamentScreen = false;
      this.showTournamentScreen = false;
      this.redigerDeltakerScreen = false;
      this.editTournamentChanges.name = "";
      this.editTournamentChanges.date = "";
      this.editTournamentChanges.status = "";
      this.editTournamentChanges.players = [];
      this.editTournamentData = null;
      this.showTournamentData = null;
    },
    deleteTournament(tournamentId) {
      axios.delete(`${this.$config.baseURL}/deletetournament`, {
        id: tournamentId
      });
      console.log(tournaments);
    }
  },
  mounted() {
    this.horizontalScroll();
    this.fetchTournaments();
  },
  components: { Tournamentoverview }
}
</script>




<style lang="scss">
$inputcolor: rgba(0,0,0,0.5);
$inputhovercolor: rgba(0,0,0,1);
$backclr: #edece9;
$black: #221E20;
$dark-grey: #464544;

$grey: #D6D2CE;
$light-grey: #EDECE9;
$blue: #0835C4;
$green: #DDE78B;
$orange: #FAB487;
template{
  overflow: hidden;
}
html {
  height: 100%;
  position: absolute;
  bottom: 0;
  top:0;
  left: 0;
  right: 0;
}
.tournament {
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex: 1 1 auto;
  min-height: 300px;
  max-height: 300px;
  position: relative;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-orient: vertical;
  -webkit-box-direction: normal;
  -ms-flex-direction: column;
  flex-direction: column;
  min-width: 300px;
  word-wrap: break-word;
  padding: 0rem;
  margin: 0rem 2rem;
  transition: all 0.5s ease;
  .tfooter {
    width: 100%;
    font-weight: 500;
    font-size: 12px;
    padding-top: 5px;
    display: flex;
    flex-direction: row;
    & > *:not(:last-child) {
      flex: 1 1 auto;
      &::after {
        content: '//';
        padding: 0 0.5rem;
      }
    }
  }
  &:nth-child(3n) {
    background-color: $orange;
    color: $black;
  }
  &:nth-child(3n - 1) {
    background-color: $blue;
    color: $backclr;
  }
  &:nth-child(3n - 2) {
    background-color: $black;
    color: $orange;
  }
}

.fade-enter-active, .fade-leave-active {
  transition: all .5s ease-in-out;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
