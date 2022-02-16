<template>
  <div class="relative h-screen flex flex-col content-center justify-center align-center">
    <Tournamentoverview class="m-auto" :tournamentprop="tournament" :clickable="true"></Tournamentoverview>
    <nuxt-link to="/tournaments" class="mx-auto bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black my-8 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear">Sett turnering på pause</nuxt-link>
  </div>
</template>
  
<script>

import axios from 'axios'
import { useTournamentStore } from '~/stores/tournament'
export default {
  name: "tournament",
  data() {
    return {
      tournament: useTournamentStore()
    }
  },
  methods: {
    async getturnering() {
      this.tournament = this.tournament.getById(this.$route.params.id[0]);
      // await axios.get(`${this.$config.baseURL}/get-tournament/${this.$route.params.id[0]}`).then(async (res) => {
      //   console.log(res.data)
      //   this.tournament = res.data
      // })
    }
  },
  mounted() {
    this.getturnering();
  },
}
</script>

<style lang="scss">
html {
  width: 100%;
  height: 100%;
}


</style>

