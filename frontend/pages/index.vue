<template>
  <div class="design-container">
    <div class="pg1-content-container">
    <div class="tegn-container">
      <img class="tegn" src="\images\tegn.svg">
      <h1>bilde</h1>
    </div>
    <!--<canvas id="Matrix"></canvas>-->
      <div class="txt-btn-pg1">
        <h1>Velkommen til Appex Tournaments!</h1>
        <div class="btn-container">
          <!-- <nuxt-link to="/newtournament" class="btn blue rel p-1 mg-5">Lag nytt tournament</nuxt-link>
          <nuxt-link to="/tournaments" class="btn darkgrey rel p-1 mg-5">Se tidligere tournaments</nuxt-link> -->
          <nuxt-link to="/newtournament" class="bg-appexblue text-white rounded py-4 px-8 columns-2 text-center hover:bg-white border border-transparent font-semibold hover:border-appexblue transition-all duration-100 ease-linear hover:text-appexblue">Lag nytt tournament</nuxt-link>
          <nuxt-link to="/tournaments" class="bg-appexdarkgrey text-white rounded py-4 px-8 columns-2 text-center hover:bg-white border border-transparent font-semibold hover:border-appexdarkgrey transition-all duration-100 ease-linear hover:text-appexdarkgrey">Se tidligere tournaments</nuxt-link>
        </div>
      </div>
    </div>
  </div>
</template>



<script>
import axios from 'axios'
export default {
    name: "TournamentsHome",
    data() {
      return {
      }
    },
    mounted() {
      if (document.querySelector('#Matrix')){
        this.matrix()
      }
    },
    async asyncData({ $config }) {
      console.log($config.axios)
    },
    methods: {
      refresh() {
        //window.location.reload(true)
      },
      matrix() {
        const canvas = document.getElementById('Matrix');
        const context = canvas.getContext("2d");
        this.vueCanvas = context;
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;
        const abbegssymbols = "+ + + + + + + . . . . . . . . < > + + . . . . : : : : : : : : : : / / / + + + + + + + + / / / < > . . . . . . . . { } . : : : : : : : "
        const fontSize = 32;
        const speed = 60;
        const columns = 500/fontSize;
        const rainDrops = [];

        for( let x = 0; x < columns; x++ ) {
          rainDrops[x] = 1;
        }
        const draw = () => {
          context.fillStyle = 'rgba(237, 236, 233, 0.1)';
          context.fillRect(0, 0, canvas.width, canvas.height );
      
          context.fillStyle = '#000000';
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
        setInterval(draw, speed);
      }
    },
}
</script>




<style lang="scss">
$backclr: #edebe9;

body {
  overflow: hidden !important;
}

.pg1-content-container {
  width: 100%;
  height: 100vh;
  position: absolute;
  
  background-color: $backclr;
  background-image: url("/images/frontpage-grapics.png"); // Bildebug blir fikset. 
  background-position: 10% 100%;
  background-repeat: no-repeat;
  background-size: 1008px;
  z-index: 1;  
}
.txt-btn-pg1 {
  padding: 4rem;
  
  display: flex;
  align-content: center;
  justify-content: center;
  align-items: center;
}
.btn-container {
  //padding: 1rem;
  //margin-bottom: 10%;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  font-size: 16px;
  width: 100%;

}

@media(max-width: 500px) {
  .txt-btn-pg1{
    width: 100%;
    margin-right: 0;
    padding: 5%;
    margin-top: -20vh;
    h1{
      font-size: 31px;
    }
  }
  .pg1-content-container{
    background-size: 350px;
    background-position: 200% 100%;
  }
  #Matrix{
    display: none;
  }
}
.tegn-container{
  position: absolute;
  right: 0;
  min-width: 40%;
  min-height: 100vh;
  overflow: hidden;
   z-index: -1;
}
.tegn{
  flex-grow: 1;
  min-height: 100vh!important;
}
@media(max-width: 1700px){
  .tegn-container{
    min-height: 200vh;
    min-width: 200%;
    opacity: 0.2;
  }
  .tegn{
  flex-grow: 1;
  min-width: 200%;
  min-height: 200vh;
}
}
</style>
