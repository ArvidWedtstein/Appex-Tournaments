<template>
  <div id="newtournament" class="bg-appexbackclr">

		<!-- Page for setting tournament name and date -->
    <div v-if="page === 0" class="container page">
      <div class="my-5">
        <h1 class="text-xl font-light">Skriv inn navnet på tournamentet</h1>
        <input class="input w-full" v-model="tournament.name" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69" required>
        <span class="limiter font-light">{{ 69 - tournament.name.length }} {{tournament.name.length >= 68 ? `bokstav` : `bokstaver`}} til overs</span>
      </div>
      <div class="my-5">
        <h1 class="text-xl font-light">Tournament dato</h1>
        <input class="input w-full" v-model="tournament.date" type="datetime-local" id="tdate" name="tdate" placeholder="Dato" required>
      </div>
      <button class="fixed w-12 m-16 right-0 bottom-0" @click="increasePage()">
        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 320 512">
          <path d="M285.476 272.971L91.132 467.314c-9.373 9.373-24.569 9.373-33.941 0l-22.667-22.667c-9.357-9.357-9.375-24.522-.04-33.901L188.505 256 34.484 101.255c-9.335-9.379-9.317-24.544.04-33.901l22.667-22.667c9.373-9.373 24.569-9.373 33.941 0L285.475 239.03c9.373 9.372 9.373 24.568.001 33.941z"/>
        </svg>
      </button>
    </div>

		<!-- Page for setting tournament Players -->
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

		<!-- Preview Tournament Page -->
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
        players: ["susadmin"],
        turnering: {},
        previewturnering: {},
        intPlayer: 1,
      }
    },
    beforeRouteLeave(to, from, next) { // function for setting playerint to 1 if user leaves the page
      this.intPlayer = 1;
			next()
    },
    methods: {
      async newTournament() {	// Function for creating a New tournament
        if (this.players.some((player) => player === "")) return alert('Field cannot be empty'); // Check if player fields are empty

        const newTournament = this.tournamentStore.new(this.$config.baseURL, this.tournament.name, this.tournament.date, this.players).then(async (t) => {
          this.turnering = t.newTournament;
          this.previewturnering = t.previewtournament;

          await this.increasePage()
        })
      },
      addPlayer() { // Add player & Generate random name
        if (this.intPlayer < 32){
          const adj = ["Gretten", "Glad", "Fjern", "Smart", "God", "Vakker", "Snill", "Første", "Rask", "Kreativ", "Lys", "Mandig", "Treig", "Smart"]; // Adjectives
          const noun = ["gris", "data", "gnager","mann", "kvinne", "Franskmann", "Amerikaner","Tysker","Nordmann", "script"]; // Nouns

          for (let i = 0; i < this.intPlayer; i++) {
            let playername = adj[Math.floor(Math.random()*adj.length)] + " " + noun[Math.floor(Math.random()*noun.length)];
            this.players.push(playername)
          }
          this.intPlayer = (this.intPlayer * 2);
        }
      },
      removePlayer() { // Remove player
        if (this.intPlayer > 1) {
          var playerDevide = (this.intPlayer / 2)
          for (var i = 0; i < playerDevide; i++){
            this.players.pop();
            this.intPlayer = this.players.length;
          }
        }
      },
      increasePage() { // Next page
        if (this.page == 2) return
        if (this.tournament.name && this.tournament.date) {
          this.page += 1;
        } else {
          alert('Name and/or date cannot be empty')
        }
      },
      decreasePage() { // Previous page
        if (this.page == 0) return
        this.page -= 1;
      }
    }
}
</script>
<style lang="scss">

</style>
