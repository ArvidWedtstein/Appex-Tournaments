<template>
  <div class="design-container">
    <!-- SVG logo stjålet (lånt) fra appex nettsiden-->
    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 241.371 56.99">
      <defs>
        <clipPath id="prefix__a">
          <path fill="#000" d="M0-56.99h241.371V0H0z"></path>
        </clipPath>
      </defs>
      <path class="logo__angle" id="logo-angle-1" fill="#000" d="M58.928 3.258l-.059 19.922-17.225-10.011-5.456 3.13 28.1 16.335.095-32.5z"></path>
      <path class="logo__angle" id="logo-angle-2" fill="#000" d="M35.618 56.99l5.457-3.123.081-19.922 17.215 10.029 5.457-3.124-28.08-16.36z"></path>
      <path class="logo__angle" id="logo-angle-3" fill="#000" d="M28.191 0L0 16.182l5.439 3.157 17.278-9.918-.048 19.924 5.438 3.155.084-32.5z"></path>
      <g clip-path="url(#prefix__a)" transform="translate(0 56.99)">
        <path fill="#000" d="M133.727-40.662a6.918 6.918 0 00-5.2 2.137 7.7 7.7 0 00-2.061 5.585 7.921 7.921 0 002.061 5.694 6.859 6.859 0 005.2 2.174 6.733 6.733 0 005.111-2.21 7.893 7.893 0 002.076-5.633 7.819 7.819 0 00-2.039-5.574 6.762 6.762 0 00-5.148-2.173m-6.97-5.44v2.914a12.487 12.487 0 013.886-2.7 11.178 11.178 0 014.468-.9 11.538 11.538 0 018.791 3.91 14.186 14.186 0 013.618 10.035 13.846 13.846 0 01-3.74 9.872 11.78 11.78 0 01-8.864 3.97 11.018 11.018 0 01-4.249-.814 12.96 12.96 0 01-3.91-2.659v12.458h-6.58v-36.086z"></path>
        <path fill="#000" d="M166.559-40.662a6.918 6.918 0 00-5.2 2.137 7.7 7.7 0 00-2.061 5.585 7.921 7.921 0 002.061 5.694 6.859 6.859 0 005.2 2.174 6.735 6.735 0 005.111-2.21 7.893 7.893 0 002.076-5.633 7.819 7.819 0 00-2.039-5.574 6.762 6.762 0 00-5.148-2.173m-6.97-5.44v2.914a12.487 12.487 0 013.886-2.7 11.178 11.178 0 014.468-.9 11.538 11.538 0 018.791 3.91 14.186 14.186 0 013.618 10.035 13.846 13.846 0 01-3.74 9.872 11.782 11.782 0 01-8.864 3.97 11.018 11.018 0 01-4.249-.814 12.96 12.96 0 01-3.91-2.659v12.458h-6.58v-36.086z"></path>
        <path fill="#000" d="M205.68-36.194a6.643 6.643 0 00-2.591-3.593 7.506 7.506 0 00-4.487-1.385 7.933 7.933 0 00-4.865 1.554 8.68 8.68 0 00-2.433 3.424zm6.63 5.221h-21.3a7.087 7.087 0 002.47 4.479 7.728 7.728 0 005.111 1.664 8.839 8.839 0 006.389-2.597l5.585 2.622a13.2 13.2 0 01-5 4.384 15.658 15.658 0 01-6.921 1.42 13.674 13.674 0 01-10.126-3.922 13.347 13.347 0 01-3.91-9.822 13.8 13.8 0 013.9-10.041 13.094 13.094 0 019.776-4 13.572 13.572 0 0110.15 4q3.9 3.992 3.899 10.55z"></path>
        <path fill="#000" d="M232.629-46.103l-5.2 7.2-5.217-7.2h-7.7l9.079 12.523-10.026 13.9h7.569l6.252-8.665 6.286 8.662h7.7l-10.143-13.986 8.968-12.434z"></path>
        <path fill="#000" d="M106.543-46.293h6.63v26.421h-6.63v-2.793a13 13 0 01-3.893 2.659 10.889 10.889 0 01-4.232.814 11.765 11.765 0 01-8.854-3.97 13.855 13.855 0 01-3.735-9.872 14.192 14.192 0 013.614-10.028 11.517 11.517 0 018.782-3.911 11.164 11.164 0 014.463.9 12.209 12.209 0 013.855 2.694zm-6.969 5.44a6.694 6.694 0 00-5.105 2.173 7.828 7.828 0 00-2.033 5.574 7.909 7.909 0 002.068 5.633 6.7 6.7 0 005.095 2.21 6.822 6.822 0 005.178-2.174 7.943 7.943 0 002.058-5.694 7.718 7.718 0 00-2.058-5.585 6.912 6.912 0 00-5.2-2.137"></path>
      </g>
    </svg>
    <div class="pg1-content-container">
    <canvas id="Matrix"></canvas>
      <div class="txt-btn-pg1">
        <h1>Velkommen til Appex Tournaments!</h1>
        <div class="btn-container">
          <nuxt-link to="/newtournament" class="btn blue rel p-1 mg-5">Lag nytt tournament</nuxt-link>
          <nuxt-link to="/tournaments" class="btn darkgrey rel p-1 mg-5">Se tidligere tournaments</nuxt-link>
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
      this.testrequest()
    },
    methods: {
      async testrequest() {
        const tournamentlist = await axios.get(`https://appex-tournaments-gylkpaupva-uc.a.run.app/get-tournament`);
        console.log(tournamentlist)
      },
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
  display: flex;
  align-content: center;
  justify-content: center;
  align-items: center;
  background-color: $backclr;
  background-image: url("/images/frontpage-grapics.png"); // Bildebug blir fikset. 
  background-position: 10% 100%;
  background-repeat: no-repeat;
  background-size: 1008px;
  z-index: 1;  
  
  h1{
    flex: 1 1 auto;
    font-weight: 500;
    font-size: 32px;
    margin: 0;
  }
}
.txt-btn-pg1{
  //margin-right: 40%;
  //margin-bottom: 50px;
  text-align: center;
  width: 50vw;
  margin-right: 40%;
  h1{
    font-size: 45px;
  }
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
