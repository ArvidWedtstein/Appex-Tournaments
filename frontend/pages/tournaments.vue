
<template>
	<div style="margin: 150px auto;" >
		<!-- <header class="w-full border-b-8 border-solid border-appexblue z-10 fixed bg-white"> -->
		<!-- 	<h1 class="text-2xl lg:text-4xl py-[3rem] top-0 appexsm:py-[4rem] font-semibold">Tidligere Turneringer</h1> -->
		<!-- </header> -->


		<!--Edit tournament-->
		<main class="container z-[2] bg-appexbackclr text-appexblack" v-if="editTournamentScreen">
			<button class="fixed top-0 right-0 text-6xl m-6" type="button" v-on:click="closeTournament()">✖</button>
			<div class="flex-auto text-center appexsm:mt-20">
				<p class="text-3xl p-1">Rediger <b>{{editTournamentData.Name}}</b></p>
				<hr class="line">
				<p class="text-xl">Status: {{editTournamentData.status}}</p>
			</div>
			<div class="flex flex-auto flex-col content-center justify-center">
				<div class="flex-auto">
					<h1 class="text-3md font-semibold">Navn:</h1>
					<input v-model="editTournamentChanges.name" class="input" type="text" placeholder="Tournament navn">
				</div>
				<div class="flex-auto">
					<h1 class="text-3md font-semibold">Dato:</h1>
					<input v-model="editTournamentChanges.date" class="input" type="date">
				</div>
			</div>
      <!-- Tournament Bracket -->
      <Tournamentoverview :tournamentprop="editTournamentData" :clickable="false" :preview="true"></Tournamentoverview>

			<div class="flex flex-auto flex-row items-center content-center justify-center">
				<button class="button button--blue" title="Endre navn på deltakere" v-if="editTournamentData.status == 'Fremtidig'" @click="redigerDeltakerScreen = true">Rediger Deltakere</button>
				<button class="button button--orange" type="button" @click="updateTournament()">Lagre</button>
				<button class="button button--orange" type="button" @click="deleteTournament(editTournamentData._id)">Slett</button>
			</div>

			<div class="flex flex-auto flex-row items-center content-center">
				<nuxt-link class="button button--blue" :to="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Påbegynt'" type="button">Fortsett turnering</nuxt-link>
				<button class="button button--blue" @click="resetTournament(editTournamentData.id)" v-if="editTournamentData.status == 'Gjennomført'">Gjenopprett turnering</button>
				<nuxt-link class="button button--orange" :to="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Fremtidig'">Begynn turnering</nuxt-link>
			</div>
		</main>



		<!-- edit player screen -->
		<main v-if="redigerDeltakerScreen" class="w-full appexsm:overscroll-y-visible fixed bottom-0 top-0 left-0 pt-12 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center items-center justify-items-stretch">
			<button class="text-2xl absolute top-0 right-0 p-12 hover:text-opacity-70" type="button" v-on:click="closeTournament()">✖</button>
			<div class="text-center appexsm:mt-12">
				<h1 class="text-xl">"{{ editTournamentData.Name }}" Deltakere</h1>
				<p class="text-lg">Rediger deltakere</p>
			</div>
			<div class="flex-auto justify-self-start flex-col mt-3 content-center justify-center items-center justify-items-stretch">
				<div class="m-auto flex-auto" v-for="(player, h) in editPlayers" :key="player">
					<input class="input input--small input--blue" v-model="editPlayers[h]" type="text" :placeholder= "'Deltaker' + h">
				</div>
			</div>
			<button class="button button--blue" @click="redigerDeltakere()" type="button">Lagre</button>
		</main>


		<!-- tournaments list -->
		<main id="scrollContainer" class="flex flex-row scroll-smooth overscroll-x-auto snap-normal touch-pan-x appexsm:flex-col appexsm:overflow-y-visible appexsm:overscroll-x-none appexsm:overscroll-y-auto appexsm:touch-pan-y appexsm:mt-32 appexsm:h-auto" v-if="!editTournamentScreen">
			<div v-for="(tournament, i) in tournaments.tournaments" :key="tournament" :id="'tournament' + i" class="tournament rounded" @click="editTournament(tournament)">
				<!-- <figure class="tournamentimg">
					<img src="/images/nam.PNG" width="300" alt="beer">
				</figure> -->
				<div class="absolute bottom-0 left-0 m-3">
					<div class="w-100 text-md pb-4 min-h-100 overflow-auto font-light">
						<p>Dato: {{ formatDate(tournament.date) }}</p>
					</div>
					<div class="flex-auto w-100 max-h-8 text-xl font-semibold">
						<p class="">{{ tournament.Name }}</p>
					</div>
					<div class="tfooter">
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
		</main>
	</div>
</template>

<script>
import axios from 'axios'
import { useTournamentStore } from '~/stores/tournament'
import Tournamentoverview from '~~/components/tournamentoverview.vue'
export default {
  name: "Tournaments",
  data() {
    return {
      tournaments: useTournamentStore(),
      editTournamentScreen: false,
      redigerDeltakerScreen: false,
      editTournamentData: null,
      editPlayers: [],
      editTournamentChanges: {
        name: '',
        date: '',
        players: [],
      },
    };
  },
  components: { Tournamentoverview },
  methods: {
		// Reset tournament
    async resetTournament(id) {
      this.tournaments.reset(this.$config.baseURL, id);
      this.editTournamentData = this.tournaments.getById(id)
    },

		// Count players
    countPlayers(tournament) {
      let length = tournament.rounds[0].length * 2;
      return length
    },

		// Format date
		formatDate(date) {
      const options = { year: "numeric", month: "numeric", day: "2-digit" };
      return new Date(date).toLocaleDateString("no", options);
    },

		// Update tournament
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

		// Edit players
    async redigerDeltakere() {
			axios.post(`${this.$config.baseURL}/updateTournamentPlayers?id=${this.editTournamentData.id}`, {
      	players: this.editPlayers
      }).then((res) => {
				this.redigerDeltakerScreen = false;
				this.editPlayers = [];
				this.$nuxt.refresh();
      });8
    },

		// Edit tournament
    async editTournament(tournament) {
      this.editTournamentData = await tournament;
      this.editTournamentScreen = true;
      //
      this.editTournamentChanges.name = tournament.name;
      for (let b = 0; b < tournament.rounds[0].length; b++) {
        for (let c = 0; c < tournament.rounds[0][b].players.length; c++) {
          this.editPlayers.push(tournament.rounds[0][b].players[c].name)
        }
      }
    },
		// Close tournament
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

		// Delete tournament
    deleteTournament(tournamentId) {
      this.tournaments.delete(this.$config.baseURL, tournamentId)
    },
  },

	created() {

	},

  mounted() {

  },
}
</script>



<style lang="scss">
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
      }
    }
  }
  &:nth-child(3n) {
    background-color: var(--orange);
    border: 2px solid transparent;
    color: var(--black);
  }
  &:nth-child(3n - 1) {
    background-color: var(--blue);
    border: 2px solid transparent;
    color: var(--backclr);
  }
  &:nth-child(3n - 2) {
    background-color: var(--black);
    border: 2px solid transparent;
    color: var(--orange);
  }
}

.fade-enter-active, .fade-leave-active {
  transition: all .5s ease-in-out;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.line {
  background: var(--black);
  height: 1px;
  border: 0;
  animation: expandline 1s linear;
}
@keyframes expandline {
	0% {
		width: 1%;
    margin: 0 50%;
	}
	100% {
		width: 100%;
    margin: 0 0%;
	}
}
</style>
