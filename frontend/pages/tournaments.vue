
<template>
  <main class="fixed w-full h-full overflow-x-hidden overflow-y-visible overscroll-y-visible left-0 top-0 flex flex-row items-center flex-nowrap transition-all duration-500 ease-in-out select-none appexsm:overflow-x-hidden appexsm:overflow-y-visible appexsm:flex-col">
    <h1 class="fixed w-full text-2xl lg:text-4xl py-[3rem] top-0 appexsm:py-[4rem] font-semibold w-full text-center bg-white z-10 border-b-8 border-solid border-appexblue">Tidligere Turneringer</h1>
    <button class="fixed w-12 z-[1] mx-4 my-8 left-0 bottom-0 appexsm:hidden bg-white" @click="left()">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-left" class="svg-inline--fa fa-chevron-left fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
        <path fill="currentColor" d="M34.52 239.03L228.87 44.69c9.37-9.37 24.57-9.37 33.94 0l22.67 22.67c9.36 9.36 9.37 24.52.04 33.9L131.49 256l154.02 154.75c9.34 9.38 9.32 24.54-.04 33.9l-22.67 22.67c-9.37 9.37-24.57 9.37-33.94 0L34.52 272.97c-9.37-9.37-9.37-24.57 0-33.94z"></path>
      </svg>
    </button>
    <button class="fixed z-[1] w-12 mx-4 my-8 right-0 bottom-0 appexsm:hidden" @click="right()">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="chevron-right" class="svg-inline--fa fa-chevron-right fa-w-10" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
        <path fill="currentColor" d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941 0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484 101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941 0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z"></path>
      </svg>
    </button>
    <button class="fixed w-12 z-[1] py-[4rem] appexsm:py-[6rem] mx-4 left-0 top-0" @click="$router.go(-1)" title="back">
      <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-left" class="svg-inline--fa fa-arrow-circle-left fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
        <path fill="currentColor" d="M256 504C119 504 8 393 8 256S119 8 256 8s248 111 248 248-111 248-248 248zm28.9-143.6L209.4 288H392c13.3 0 24-10.7 24-24v-16c0-13.3-10.7-24-24-24H209.4l75.5-72.4c9.7-9.3 9.9-24.8.4-34.3l-11-10.9c-9.4-9.4-24.6-9.4-33.9 0L107.7 239c-9.4 9.4-9.4 24.6 0 33.9l132.7 132.7c9.4 9.4 24.6 9.4 33.9 0l11-10.9c9.5-9.5 9.3-25-.4-34.3z"></path>
      </svg>
    </button>
    <!--Edit tournament-->
    <transition name="fade">
      <div class="overscroll-y-visible overflow-y-visible pt-20 w-full fixed bottom-0 left-0 p-8 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center items-center" v-if="editTournamentScreen">
        <button class="fixed top-0 right-0 text-6xl m-6" type="button" v-on:click="closeTournament()">✖</button>
        <div class="flex-auto text-center appexsm:mt-20">
          <p class="text-3xl p-1">Rediger <b>{{editTournamentData.Name}}</b></p>
          <hr class="border-t-appexblack">
          <p class="text-xl">Status: {{editTournamentData.status}}</p>
        </div>
        <div class="flex flex-auto flex-col content-center justify-center">
          <div class="flex-auto">
            <h1 class="text-3md font-semibold">Navn:</h1>  
            <input v-model="editTournamentChanges.name" class="flex-auto self-center bg-appexgrey text-black border-2 border-appexblue rounded p-2" type="text" placeholder="Tournament navn">
          </div>
          <div class="flex-auto">
            <h1 class="text-3md font-semibold">Dato:</h1> 
            <input v-model="editTournamentChanges.date" class="flex-auto self-center bg-appexgrey text-black border-b border-2 border-appexblue rounded p-2" type="date">
          </div>
        </div>
        <div class="flex flex-auto content-center items-center rounded bg-appexdarkgrey p-8 px-40 m-3 appexsm:m-0 appexsm:px-20">
          <div class="flex content-center items-center">
            <div class="round" v-for="round in editTournamentData.rounds" :key="round">
              <div class="match" v-for="match in round" :key="match">
                <div class="match__content"></div>
                <div class="matchplayer" v-for="player in match.players" :key="player">
                  <!-- FIKS VINNER-->
                  <p class="player" v-if="match.winner" v-bind:class="{ 'winner': match.winner.id == player.id }">{{ player.name }}</p>
                  <p class="player" v-else>{{ player.name }}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="flex flex-auto flex-row items-center content-center justify-center">
          <button class="text-base bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black m-1 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear" type="button" title="Endre navn på deltakere" v-if="editTournamentData.status == 'Fremtidig'" @click="redigerDeltakerScreen = true">Rediger Deltakere</button>
          <button class="text-base bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" type="button" title="Lagre Endringer" @click="updateTournament()">Lagre</button>
          <button class="text-base bg-red-900 hover:bg-red-500 text-white font-semibold hover:text-appexblack m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" title="Slett Turnering" type="button" @click="deleteTournament(editTournamentData._id)">Slett</button>
        </div>
        <div class="flex flex-auto flex-row items-center content-center">
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" :href="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Påbegynt'" type="button">Fortsett turnering</a>
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" @click="resetTournament(editTournamentData.id)" v-if="editTournamentData.status == 'Gjennomført'" type="button">Gjenopprett turnering</a>
          <a class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" :href="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Fremtidig'" type="button">Begynn turnering</a>
        </div>
      </div>
    </transition>
    <transition name="fade">
      <div v-if="redigerDeltakerScreen" class="w-full appexsm:overscroll-y-visible fixed bottom-0 top-0 left-0 pt-12 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center items-center justify-items-stretch">
        <button class="text-2xl absolute top-0 right-0 p-12 hover:text-opacity-70" type="button" v-on:click="closeTournament()">✖</button>
        <div class="text-center appexsm:mt-12">
          <h1 class="text-xl">"{{ editTournamentData.Name }}" Deltakere</h1>
          <p class="text-lg">Rediger deltakere</p>
        </div>
        <div class="flex-auto justify-self-start flex-col mt-3 content-center justify-center items-center justify-items-stretch">
          <div class="m-auto flex-auto" v-for="(player, h) in editPlayers" :key="player">
            <input class="flex-auto self-center bg-appexgrey text-black border-2 border-appexblue rounded p-2 my-1" v-model="editPlayers[h]" type="text" :placeholder= "'Deltaker' + h">
          </div>
        </div>
        <button class="flex-start bg-appexblue text-center text-white rounded py-4 px-16 m-3hover:bg-white border border-transparent font-semibold hover:border-appexblue transition-all duration-100 ease-linear hover:text-appexblue" @click="redigerDeltakere()" type="button">Lagre</button>
      </div>
    </transition>
    <div id="scrollContainer" class="flex flex-row scroll-smooth overscroll-x-auto snap-normal touch-pan-x appexsm:flex-col appexsm:overflow-y-visible appexsm:overscroll-x-none appexsm:overscroll-y-auto appexsm:touch-pan-y appexsm:mt-32 appexsm:h-auto">
      <div v-for="(tournament, i) in tournaments" :key="tournament" :id="'tournament' + i" class="tournament rounded" @click="editTournament(tournament)">
        <figure class="tournamentimg">
          <!-- <img src="/images/nam.PNG" width="300" alt="beer"> -->
        </figure>
        <div class="absolute bottom-0 left-0 m-3">
          <div class="w-100 text-md pb-4 min-h-100 overflow-auto font-light">
            <p>Dato: {{ formatDate(tournament.date) }}</p>
          </div>
          <div class="flex-auto w-100 max-h-8 text-xl font-semibold">
            <p class="">{{ tournament.Name }}</p>
          </div>
          <div class="tfooter">
            <!-- <p :v-if="tournament.rounds[tournament.rounds.length - 1][0].winner.id != ''">{{tournament.rounds[tournament.rounds.length - 1][0].winner.name}}</p> -->
            <p>
              {{ countPlayers(tournament) }}
              <svg aria-hidden="true" focusable="false" data-prefix="fas" width="20" data-icon="users" class="svg-inline--fa fa-users fa-w-1 inline" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512">
                <path fill="currentColor" d="M96 224c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm448 0c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm32 32h-64c-17.6 0-33.5 7.1-45.1 18.6 40.3 22.1 68.9 62 75.1 109.4h66c17.7 0 32-14.3 32-32v-32c0-35.3-28.7-64-64-64zm-256 0c61.9 0 112-50.1 112-112S381.9 32 320 32 208 82.1 208 144s50.1 112 112 112zm76.8 32h-8.3c-20.8 10-43.9 16-68.5 16s-47.6-6-68.5-16h-8.3C179.6 288 128 339.6 128 403.2V432c0 26.5 21.5 48 48 48h288c26.5 0 48-21.5 48-48v-28.8c0-63.6-51.6-115.2-115.2-115.2zm-223.7-13.4C161.5 263.1 145.6 256 128 256H64c-35.3 0-64 28.7-64 64v32c0 17.7 14.3 32 32 32h65.9c6.3-47.4 34.9-87.3 75.2-109.4z">
                </path>
              </svg>
            </p>
            <p v-if="tournament.status">{{ tournament.status }}</p>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script>
//import env from '~/dotenv.json'
import axios from 'axios'
import Tournamentoverview from '~~/components/tournamentoverview.vue'
export default {
  name: "Tournaments",
  async asyncData({ $axios, $config }) {

  },
  data() {
    return {
      tournaments: null,
      editTournamentScreen: false,
      redigerDeltakerScreen: false,
      editTournamentData: null,
      editPlayers: [],
      editTournamentChanges: {
        name: "",
        date: "",
        players: [],
      },
    };
  },
  methods: {
    async resetTournament(id) {
      const t = await axios.get(`${this.$config.baseURL}/resetTournament/${id}`).then(async (res) => {
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
      const scrollContainer = document.getElementById('scrollContainer');
      if (scrollContainer && screen.width >= 640) {
        scrollContainer.addEventListener("wheel", (evt) => {
          evt.preventDefault();
          scrollContainer.scrollLeft += evt.deltaY;
          
        });
        // funke bare å scrolldragge mot høyre..
        scrollContainer.addEventListener('touchmove', (evt) => {
          evt.preventDefault();
          scrollContainer.scrollLeft += evt.touches[0].clientX / 10;
        })
      } else {
        setTimeout(() => {
          this.horizontalScroll();
        }, 1000)
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
      }).then((res) => {
        this.editTournamentScreen = false;
        this.editTournamentChanges.name = "";
        this.editTournamentChanges.date = "";
        this.editTournamentChanges.players = [];
        this.editTournamentData = null;
        this.$nuxt.refresh();
      });
    },
    async redigerDeltakere() {
       axios.post(`${this.$config.baseURL}/updateTournamentPlayers?id=${this.editTournamentData.id}`, {
        players: this.editPlayers
      }).then((res) => {
        
      });
      this.redigerDeltakerScreen = false;
      this.editPlayers = [];
      this.$nuxt.refresh();
    },
    left() {
     const scrollContainer = document.getElementById('scrollContainer'); 
      var x = window.innerWidth;
      var tournaments = document.getElementsByClassName("tournament").length;
      for (let i = 0; i < 8; i++) {
        var step = (x / tournaments) * -2;
        scrollContainer.scrollLeft += step;
        setTimeout(1000);
      }
    },
    right() {
      const scrollContainer = document.getElementById('scrollContainer');
      var x = window.innerWidth;
      var tournaments = document.getElementsByClassName("tournament").length;
      var step = (x / tournaments) * 16;
      scrollContainer.scrollLeft += step;
    },
    async editTournament(tournament) {
      this.editTournamentData = await tournament;
      this.editTournamentScreen = true;
      
      this.editTournamentChanges.name = tournament.name;
      for (let b = 0; b < tournament.rounds[0].length; b++) {
        for (let c = 0; c < tournament.rounds[0][b].players.length; c++) {
          this.editPlayers.push(tournament.rounds[0][b].players[c].name)
        }
      }
    },
    closeTournament() {
      this.editTournamentScreen = false;
      this.showTournamentScreen = false;
      this.redigerDeltakerScreen = false;
      this.editTournamentChanges.name = "";
      this.editTournamentChanges.date = "";
      this.editTournamentChanges.players = [];
      this.editPlayers = [];
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
    //console.log('test')
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

html {
  height: 100%;
  position: absolute;
  bottom: 0;
  top:0;
  left: 0;
  right: 0;
  overflow-x: scroll;
}
.tournament {
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
  // padding-top: 4rem;
  margin: 1rem 2rem;
  transition: all 0.5s ease;
  z-index: 0;
  &:hover {
    .tournamentimg {
      img {
        transform: scale(1.1);
      }
    }
  }
  .tournamentimg {
    overflow: hidden;
    width: 300px;
    img {
      transition: 0.3s transform ease;
    }
  }
  .tfooter {
    width: 100%;
    font-weight: 500;
    font-size: 12px;
    padding-top: 5px;
    display: flex;
    flex-direction: row;
    & > *:not(:last-child) {
      padding: 0rem 0.3rem;
      &::after {
        content: '//';
        padding: 0rem 0.3rem;
        // padding: 0 0.5rem;
      }
    }
  }
  &:nth-child(3n) {
    background-color: $orange;
    border: 2px solid transparent;
    color: $black;
  }
  &:nth-child(3n - 1) {
    background-color: $blue;
    border: 2px solid transparent;
    color: $backclr;
  }
  &:nth-child(3n - 2) {
    background-color: $black;
    border: 2px solid transparent;
    color: $orange;
  }
}

.round {
  flex: 1 1 auto;
  display: flex;
  flex-grow: 1;
  flex-direction: column;
  padding: 0;
  margin: 0;
  &:first-child {
    .match {
      &::before {
        display: none;
      }
    }
    .match__content {
      &::before {
        display: none !important;
      }
    }
  }
  &:last-child {
    .match {
      &::before, &::after {
        display: none !important;
      }
    }
    .match__content::before {
      content: "";
      display: block;
      width: 20px;
      border-bottom: 2px solid $green;
      margin-left: -10px;
      position: absolute;
      top: 50%;
      left: -10px;
    }
  }
  .match {
    display: flex;
    flex-direction: column;
    justify-content: center;
    margin: 0 10px;
    padding: 6px 0;
    flex-grow: 1;
    position: relative;
    vertical-align: middle;
    &::before {
      content: "";
      display: block;
      min-height: 20px;
      border-left: 2px solid $green;
      position: absolute;
      left: -10px;
      top: 60%;
      margin-top: -15px;
      margin-left: -2px;
    }
    &:nth-child(2n+0) {
      padding-top: 0;
      padding-top: 0;
      margin-top: 0;
      margin-bottom: 0;
    }
    &:nth-child(odd)::after {
      content: "";
      display: block;
      border: 2px solid transparent;
      border-top-color: $green;
      border-right-color: $green;
      height: 50%;
      position: absolute;
      right: -10px;
      width: 10px;
      top: 60%;
    }
    &:nth-child(even)::after {
      content: "";
      display: block;
      border: 2px solid transparent;
      border-bottom-color: $green;
      border-right-color: $green;
      height: 50%;
      position: absolute;
      right: -10px;
      width: 10px;
      bottom: 50%;
    }
    .match__content {
      &::before {
        content: "";
        display: block;
        width: 20px;
        border-bottom: 2px solid $green;
        margin-left: -2px;
        position: absolute;
        top: 55%;
        //left: -10px;
      }
    }
    .matchplayer {
      display: flex;
      flex-direction: column;
      //width: 100%;
      position: relative;
      margin: 0;
      padding: 0;
      .player {
        flex: 1 1 auto;
        margin: 0;
        padding: 0.3rem 1rem;
        border: 2px solid $green;
        background: $black;
        color: $orange;
        border-radius: 0.25rem;
        text-align: left;
        position: relative;
        &.winner {
          &::after {
            content: "🏅";
            float: right;
          }
          //background: gold;
        }
      }
    }
  }
}
.fade-enter-active, .fade-leave-active {
  transition: all .5s ease-in-out;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.rgbline {
  background: linear-gradient(90deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
    background-size: auto;
  height: 1px;
  border: 0;
  background-size: 200% 200%;
  box-shadow: 0px 1px 10px #23d5ab;
}

.expandline {
  animation: expandline 2s linear;
}
@keyframes expandline {
	0% {
		width: 1%;
	}
	100% {
		width: 100%;
	}
}
</style>
