<template>
  <div class="editTournament">
    <Tournamentoverview :tournamentprop="tournament"></Tournamentoverview>
    <a href="/tournaments" class="deletebtn">Sett turnering på pause</a>
    <canvas id="Matrix"></canvas>
  </div>
</template>
  
<script>

import axios from 'axios'
export default {
  name: "tournament",
  async asyncData({ $axios, params, $route }) {
    await $axios.get(`https://localhost:7021/get-tournament/${$route.params.id[0]}`).then(async (res) => {
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
      await axios.get(`https://localhost:7021/get-tournament/${this.$route.params.id[0]}`).then(async (res) => {
        console.log(res.data)
        this.tournament = res.data
      })
    },
    /*async matchWin(tournamentId, winner, matchId) {
      await axios({
        method: 'post',
        url: `https://localhost:7021/Tournament/${tournamentId}?winner=${winner}&matchId=${matchId}`
      }).then(async (response) => {
        //await console.log(response)
        this.getTournament(tournamentId)
      });
    },*/
    async getTournament(id) {
      await axios({
        method: 'get',
        url: `https://localhost:7021/get-tournament/${id}`
      }).then(async (response) => {
        //await console.log(response.data)
        this.tournament = response.data;
      });
    },
    matrix() {
      const canvas = document.getElementById('Matrix');
      const context = canvas.getContext("2d");
      this.vueCanvas = context;

      canvas.width = window.innerWidth;
      canvas.height = window.innerHeight;

      const abbegssymbols = "+ + + + + + + . . . . . . . . < > + + . . . . : : : : : : : : : : / / / + + + + + + + + / / / < > . . . . . . . . { } . : : : : : : : "
      const fontSize = 16;
      const columns = canvas.width/fontSize;
      const rainDrops = [];

      for( let x = 0; x < columns; x++ ) {
        rainDrops[x] = 1;
      }
      const draw = () => {
        context.fillStyle = 'rgba(255, 240, 255, 0.05)';
        context.fillRect(0, 0, canvas.width, canvas.height);

        context.fillStyle = '#0835C4';
        //context.fillStyle = '#ffffff';
        context.font = fontSize + 'px fraktur';

        for(let i = 0; i < rainDrops.length; i++)
        {
          const text = abbegssymbols.charAt(Math.floor(Math.random() * abbegssymbols.length));
          context.fillText(text, i*fontSize, rainDrops[i]*fontSize);

          if(rainDrops[i]*fontSize > canvas.height && Math.random() > 0.975){
            rainDrops[i] = 0;
          }
          rainDrops[i]++;
        }
      };
      setInterval(draw, 60);
    }
  },
  mounted() {
    this.matrix()
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

