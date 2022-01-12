<template>
  <div class="pg1-content-container flex">
    <canvas id="Matrix"></canvas>
    <div class="my-auto align-middle content-center mx-12">
      <h1 class="m-6 py-4 text-6xl">Velkommen til <br>Appex Tournaments!</h1>
      <div class="btn-container bg-rose-50">
        <!-- <nuxt-link to="/newtournament" class="btn blue rel p-1 mg-5">Lag nytt tournament</nuxt-link>
        <nuxt-link to="/tournaments" class="btn darkgrey rel p-1 mg-5">Se tidligere tournaments</nuxt-link> -->
        <nuxt-link to="/newtournament" class="bg-appexblue text-white rounded py-4 px-8 mx-2 my-2 hover:bg-white border border-transparent font-semibold hover:border-appexblue transition-all duration-100 ease-linear hover:text-appexblue">Lag nytt tournament</nuxt-link>
        <nuxt-link to="/tournaments" class="bg-appexdarkgrey text-white rounded py-4 px-8 mx-2 my-2 hover:bg-white border border-transparent font-semibold hover:border-appexdarkgrey transition-all duration-100 ease-linear hover:text-appexdarkgrey">Se tidligere tournaments</nuxt-link>
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
</style>
