<template>
  <div class="relative mx-auto my-auto flex flex-col content-center justify-center align-center">
    <Tournamentoverview :tournamentprop="tournament"></Tournamentoverview>
    <nuxt-link to="/tournaments" class="bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black my-8 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear">Sett turnering på pause</nuxt-link>
  </div>
</template>
  
<script>

import axios from 'axios'
export default {
  name: "tournament",
  async asyncData({ $axios, params, $route }) {

  },
  data() {
    return {
      tournament: ""
    }
  },
  methods: {
    async getturnering() {
      await axios.get(`${this.$config.baseURL}/get-tournament/${this.$route.params.id[0]}`).then(async (res) => {
        console.log(res.data)
        this.tournament = res.data
      })
    },
    async getTournament(id) {
      await axios({
        method: 'get',
        url: `${this.$config.baseURL}/get-tournament/${id}`
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
html {
  width: 100%;
  height: 100%;
}


</style>

