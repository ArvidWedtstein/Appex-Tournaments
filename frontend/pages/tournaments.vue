
<template>
	<div style="margin: 100px 0;" class="my-auto">
  
    <!-- Tournaments List - Will change to a vertical list on mobile screen sizes -->
		<main id="scrollContainer" class="flex flex-row my-auto scroll-smooth overscroll-x-auto snap-normal touch-pan-x appexsm:flex-col appexsm:overflow-x-visible appexsm:overscroll-x-none appexsm:overscroll-y-auto appexsm:touch-pan-y appexsm:mt-32 appexsm:h-auto" v-if="!editTournamentScreen">
			<div v-for="(tournament, i) in tournaments.tournaments" class="cycleColor" :id="'tournament' + i" @click="editTournament(tournament)" :key="tournament">
				<Tournamentcard :tournament="tournament"></Tournamentcard>
			</div>
      <footer class="w-full bottom-0 m-3 z-10 fixed">
        <h1 class="footertxt text-xl text-center font-light">Made by Aleksnadder, Victor, David & Arvid</h1>
      </footer>
		</main>

		<!-- Screen for editing Tournament -->
		<main class="m-6 z-[2] bg-appexbackclr text-appexblack" v-if="editTournamentScreen">
			<button class="fixed top-0 right-0 text-6xl m-6" type="button" v-on:click="closeTournament()">✖</button>
			<div class="flex-auto text-center appexsm:mt-20">
				<p class="text-3xl p-1">Rediger <b>{{editTournamentData.Name}}</b></p>
				<hr class="line">
				<p class="text-xl">Status: {{editTournamentData.status}}</p>
			</div>
			<div class="flex flex-auto flex-col content-center justify-center">
				<div class="flex-auto">
					<h1 class="text-3md font-semibold">Navn:</h1>
					<input v-model="editTournamentChanges.name" class="input" type="text" placeholder="Turnering navn">
				</div>
				<div class="flex-auto">
					<h1 class="text-3md font-semibold">Dato:</h1>
					<input v-model="editTournamentChanges.date" class="input" type="date">
				</div>
			</div>
      <div class="text-center my-8">
        <hr class="line">
        <h1 class="text-2xl">Preview</h1>
        <Tournamentoverview :tournamentprop="editTournamentData" :clickable="false" :preview="true"></Tournamentoverview>
      </div>
			<div class="flex flex-auto flex-row items-center content-center justify-center">
				<button class="button button--blue" title="Endre navn på deltakere" v-if="editTournamentData.status == 'Fremtidig'" @click="redigerDeltakerScreen = true">Rediger Deltakere</button>
				<button class="button button--orange" type="button" @click="updateTournament()">Lagre</button>
				<button class="button button--orange" type="button" @click="deleteTournament(editTournamentData._id)">Slett</button>
			</div>
			<div class="flex flex-auto flex-row items-center content-center justify-center">
				<nuxt-link class="button button--blue" :to="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Påbegynt'" type="button">Fortsett turnering</nuxt-link>
				<button class="button button--blue" @click="resetTournament(editTournamentData.id)" v-if="editTournamentData.status == 'Gjennomført'">Gjenopprett turnering</button>
				<nuxt-link class="button button--orange" :to="'/tournament/' + editTournamentData.id" v-if="editTournamentData.status == 'Fremtidig'">Begynn turnering</nuxt-link>
			</div>
		</main>

		<!-- Screen for editing Tournament players-->
		<main v-if="redigerDeltakerScreen" class="w-full appexsm:overscroll-y-visible fixed bottom-0 top-0 left-0 pt-12 z-[2] bg-appexbackclr text-appexblack flex flex-col content-center justify-center items-center justify-items-stretch">
			<button class="text-2xl absolute top-0 right-0 p-12 hover:text-opacity-70" type="button" v-on:click="closeTournament()">✖</button>
			<div class="text-center appexsm:mt-12">
				<h1 class="text-xl">"{{ editTournamentData.Name }}" Deltakere</h1>
				<p class="text-lg">Rediger deltakere</p>
			</div>
			<div class="flex-auto justify-self-start flex-col mt-3 content-center justify-center items-center justify-items-stretch">
				<div class="m-auto flex-auto" v-for="(player, h) in editTournamentChanges.players" :key="player">
					<input class="input input--small input--blue" v-model="editTournamentChanges.players[h].name" type="text" :placeholder= "'Deltaker' + h">
				</div>
			</div>
			<button class="button button--blue" @click="redigerDeltakere()" type="button">Lagre</button>
		</main>
	</div>
</template>

<script>
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
      editTournamentChanges: {
        name: '',
        date: '',
        players: [],
      },
    };
  },
  components: { Tournamentoverview },
  methods: {
    async resetTournament(tournamentId) { // Reset tournament
      this.tournaments.reset(this.$config.baseURL, tournamentId);
      this.editTournamentData = this.tournaments.getById(tournamentId)
    },
    async updateTournament() { // Update tournament
      await this.tournaments.update(this.$config.baseURL, this.editTournamentData).then(() => {
        this.editTournamentScreen = false;
        this.editTournamentChanges.name = "";
        this.editTournamentChanges.date = "";
        this.editTournamentChanges.players = [];
        this.editTournamentData = null;
      })
    },
    async redigerDeltakere() { // Edit players
      await this.tournaments.editPlayers(this.$config.baseURL, this.editTournamentData.id, this.editTournamentData.players);
      this.editTournamentData = await this.tournaments.getById(this.editTournamentData.id)
			
      this.redigerDeltakerScreen = false;
      this.editTournamentChanges.players = [];
    },
    async editTournament(tournament) { // Edit tournament
      this.editTournamentData = await tournament;
      this.editTournamentScreen = true;

      this.editTournamentChanges.name = tournament.name;

      tournament.rounds[0].forEach(async (match) => {
        match.players.forEach(async (player) => {
          this.editTournamentChanges.players.push(player)
        })
      })
    },
    closeTournament() { // Close tournament
      this.editTournamentScreen = false;
      this.showTournamentScreen = false;
      this.redigerDeltakerScreen = false;
      this.editTournamentChanges.name = "";
      this.editTournamentChanges.date = "";
      this.editTournamentChanges.players = [];
      this.editTournamentData = null;
      this.showTournamentData = null;
    },
    deleteTournament(tournamentId) { // Delete tournament
      this.tournaments.delete(this.$config.baseURL, tournamentId)
    },
  }
}
</script>



<style lang="scss">
.cycleColor {
  &:nth-child(3n) {
    .tournament {
      background-color: var(--orange);
      border: 2px solid transparent;
      color: var(--black);
    }
  }
  &:nth-child(3n - 1) {
    .tournament {
      background-color: var(--blue);
      border: 2px solid transparent;
      color: var(--backclr);
    }
  }
  &:nth-child(3n - 2) {
    .tournament {
      background-color: var(--black);
      border: 2px solid transparent;
      color: var(--orange);
    }
  }
}
// ----------------------------
// Brackets on footer text
// ----------------------------
.footertxt {
  &::before,
  &::after {
    font-family: 'poppins';
    font-size: 40px;
    font-weight: 300;
    position: relative;
    text-rendering: optimizeSpeed;
    transform: matrix(1, 0, 0, 1, 0, -129.6);
    vertical-align: middle;
  }
  &::before {
    content: '{';
    right: 1rem;
  }
  &::after {
    content: '}';
    left: 1rem;
  }
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
