<template>
  <div id="newtournament" class="bg-appexbackclr">

		<!-- Page 0 -->
    <div v-if="page === 0" class="container page">
        <div class="my-5">
          <h1>Skriv inn navnet på tournamentet</h1>
          <input class="input w-full" v-model="tournament.name" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69" required>
          <span class="limiter">{{ 69 - tournament.name.length }} {{tournament.name.length >= 68 ? `bokstav` : `bokstaver`}} til overs</span>
        </div>
        <div class="my-5">
          <h1 class="text-xl">Tournament dato</h1>
          <input class="input w-full" v-model="tournament.date" type="datetime-local" id="tdate" name="tdate" placeholder="Dato" required>
        </div>
        <button class="fixed w-12 m-16 right-0 bottom-0" @click="increasePage()">
          <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-right" class="svg-inline--fa fa-arrow-circle-right fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
            <path fill="currentColor" d="M256 8c137 0 248 111 248 248S393 504 256 504 8 393 8 256 119 8 256 8zm-28.9 143.6l75.5 72.4H120c-13.3 0-24 10.7-24 24v16c0 13.3 10.7 24 24 24h182.6l-75.5 72.4c-9.7 9.3-9.9 24.8-.4 34.3l11 10.9c9.4 9.4 24.6 9.4 33.9 0L404.3 273c9.4-9.4 9.4-24.6 0-33.9L271.6 106.3c-9.4-9.4-24.6-9.4-33.9 0l-11 10.9c-9.5 9.6-9.3 25.1.4 34.4z"></path>
          </svg>
        </button>
    </div>


		<!-- Page 1 -->
    <div v-if="page === 1" class="container flex content-center justify-center items-center relative flex-col">
      <div class="text-center relative">
        <h1 class="text-3xl text-center w-100">"{{ tournament.name }}" Deltakere</h1>
        <p class="text-2md text-center">Sett deltakere</p>
      </div>
      <div class="relative min-h-max w-24 mt-8">
        <div class="text-center font-semibold">
          <h1 class="text-appexblue text-4lg w-100">{{ players.length }}</h1>
          <p class="text-center w-100">Deltakere</p>
        </div>
        <div class="text-2xl font-semibold flex items-center mt-16">
          <button class="absolute text-4xl left-0 bottom-0" @click="removePlayer()">-</button>
          <button class="absolute text-4xl right-0 bottom-0" @click="addPlayer()">+</button>
        </div>
      </div>
      <div v-for="(name, index) in players" :key="index" class="flex h-auto flex-col content-left overflow-y-visible">
        <div class="flex">
          <input class="input my-2" v-model="players[index]" type="text" v-bind:placeholder= "'Deltaker' + index" required>
        </div>
      </div>
      <button class="button button--blue" @click="newTournament()" type="button">Ny Turnering</button>
    </div>


		<!-- Page 2 -->
    <div v-if="page === 2" class="container flex flex-col justify-center align-center content-center items-center">
      <h1 class="text-2xl">Oppsett:</h1>
      <Tournamentoverview :tournamentprop="previewturnering" :clickable="false" :preview="true"></Tournamentoverview>
      <br>
      <NuxtLink class="button button--blue" :to="'/tournament/' + previewturnering.id">Begynn turnering</NuxtLink>
      <NuxtLink class="button button--orange" to="/">Utsett turnering</NuxtLink>
    </div>

  </div>
</template>


<script>
import axios from 'axios';
import { useTournamentStore } from '~/stores/tournament'
import tournamentoverview from '~~/components/tournamentoverview.vue';
export default {
   template: 'newtournament',
   transition: 'slide-bottom',
   components: { tournamentoverview },
   data() {
      return {
        page: 0,
        tournamentStore: useTournamentStore(),
        tournament: {
          name: '',
          date: ''
        },
        players: ["Peder"],
        turnering: {},
        previewturnering: {},
        intPlayer: 1,
      }
    },
    beforeRouteLeave(to, from, next) {
      this.intPlayer = 1;
			next()
    },
    methods: {

			// New tournament
      async newTournament() {
        if (this.players.some((player) => player === "")) return alert('Field cannot be empty'); // Check if player fields are empty

        const newTournament = this.tournamentStore.new(this.$config.baseURL, this.tournament.name, this.tournament.date, this.players).then(async (t) => {
          console.log(t)
          this.turnering = t.newTournament;
          this.previewturnering = t.previewtournament;

          await this.increasePage()
        })
        
        
        

        
      },

			// Add player
			// Generate random username
      addPlayer() {
        if (this.intPlayer < 32){
          console.log(this.intPlayer)

					// Adjectives
          const adj = ["Gretten", "Glad", "Fjern", "Smart", "God", "Vakker", "Snill", "Første", "Rask", "Kreativ", "Lys", "Mandig", "Treig", "Smart"];

					// Nouns
          const noun = ["gris", "data", "gnager","mann", "kvinne", "Franskmann", "Amerikaner","Tysker","Nordmann", "script"];

          for (let i = 0; i < this.intPlayer; i++) {
            let playername = adj[Math.floor(Math.random()*adj.length)] + " " + noun[Math.floor(Math.random()*noun.length)];
            this.players.push(playername)
          }
          this.intPlayer = (this.intPlayer * 2);
        }
      },

			// Remove player
      removePlayer() {
        if (this.intPlayer > 1){

          var playerDevide = (this.intPlayer / 2)
          for (var i = 0; i < playerDevide; i++){
            this.players.pop();
            this.intPlayer = this.players.length;
          }
        }
      },

			// Next page
      increasePage() {
        if (this.page == 2) return
          const regex = /[^A-Za-z0-9]+/
          /*if (!regex.test(this.tournament.name)) {
            return alert('Name cannot contain invalid characters (only letters and numbers)')
          }*/
        if (this.tournament.name && this.tournament.date) {
          this.page += 1;
        } else {
          alert('Name and/or date cannot be empty')
        }
      },

			// Previous page
      decreasePage() {
        if (this.page == 0) return
        this.page -= 1;
      }
    },
    mounted() {

    }
}
</script>
<style lang="scss">

</style>
