<template>
  <div class="container m-4">
    <Tournamentoverview :tournamentprop="tournament"></Tournamentoverview>
    <nuxt-link to="/tournaments" class="bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black m-1 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear">Sett turnering på pause</nuxt-link>
  </div>
</template>
  
<script>

import axios from 'axios'
export default {
  name: "tournament",
  async asyncData({ $axios, params, $route }) {
    await $axios.get(`https://appex-tournaments-gylkpaupva-uc.a.run.app/get-tournament/${$route.params.id[0]}`).then(async (res) => {
      console.log(res)
    })
  },
  data() {
    return {
      tournament: ""
    }
  },
  methods: {
    async getturnering() {
      await axios.get(`https://appex-tournaments-gylkpaupva-uc.a.run.app/get-tournament/${this.$route.params.id[0]}`).then(async (res) => {
        console.log(res.data)
        this.tournament = res.data
      })
    },
    /*async matchWin(tournamentId, winner, matchId) {
      await axios({
        method: 'post',
        url: `https://appex-tournaments-gylkpaupva-uc.a.run.app/Tournament/${tournamentId}?winner=${winner}&matchId=${matchId}`
      }).then(async (response) => {
        //await console.log(response)
        this.getTournament(tournamentId)
      });
    },*/
    async getTournament(id) {
      await axios({
        method: 'get',
        url: `https://appex-tournaments-gylkpaupva-uc.a.run.app/get-tournament/${id}`
      }).then(async (response) => {
        //await console.log(response.data)
        this.tournament = response.data;
      });
    },
  },
  mounted() {
    this.getturnering();
  },
}
</script>

<style lang="scss">
$backclr: #edece9;
$black: #221E20;
$dark-grey: #464544;
$grey: #D6D2CE;
$light-grey: #EDECE9;
$blue: #0835C4;
$green: #DDE78B;
$orange: #FAB487;
#Matrix {
  position: absolute;
  left: 0;
  top: 0;
  width: 100%;
  z-index: -1;
}


</style>

