

<template>
    <div class="design-container">
    
      <canvas id="Matrix"></canvas>
      <div class="pg1-content-container">
        <div class="txt-btn-pg1">
          <h1>Velkommen til Appex tournament</h1>
          <div class="btn-container">
            <nuxt-link to="/newtournament" class="blueBtn">Lag nytt tournament</nuxt-link>
            <nuxt-link to="/tournaments" class="grey">Se tidligere tournaments</nuxt-link>
          </div>
        </div>
      </div>

    </div>
</template>

<script>

export default {
    name: "TournamentsHome",
    data() {
      return {

      }
    },
    mounted() {
      if (document.querySelector('#Matrix')){
        //this.matrix()
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
        canvas.width = 500;
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
            context.fillStyle = 'rgba(237, 236, 233, 0.05)';
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
$backclr: #edece9;
$btncolorblue: #0835C4;
$btncolorgrey: #444444;
body {
  overflow: auto;
}
#Matrix {
  overflow: hidden;
  position: absolute;
  margin-left: 70%;
  right: 0;
  top: 0;
  z-index: 0;
}
#logo{
        text-align: center;
        width: 245px;
        position: absolute;
        left: 60px;
        top: 50px;
    }

.pg1-content-container{
  width: 100%;
  height: 100%;
  position: absolute;
  display: flex;
  align-content: center;
  justify-content: center;
  align-items: center;
  //background-color: $backclr;
  background-image: url("../static/images/frontpage-grapics.png");
  background-position: 10% 100%;
  background-repeat: no-repeat;
  background-size:60%;
  padding: 2rem;
  z-index: -1;  
  
  h1{
    flex: 1 1 auto;
    font-weight: 500;
    font-size: 32px;
    margin: 0;
  }
}
.txt-btn-pg1{
  margin-right: 40%;
  margin-bottom: 50px;
  text-align: center;
  align-items: center;
  width: 800px;
}
.btn-container {
  position: relative;
  display: inline-flex;
  flex-direction: row;
  padding: 1rem;
  margin-bottom: 10%;
  gap: 50px;
  font-size: 16px;

}
  .blueBtn {
    flex: 0 1 auto;
    width: 250px;
    font-weight: 600;
    padding-top: 1rem;
    padding-bottom: 1rem;
    color: #ffffff;
    position: relative;
    border: none;
    text-decoration: none;

    &:hover {
      transform: translateY(-5px);
    }
    background: $btncolorblue;
  }
  .grey {
    flex: 0 1 auto;
    width: 250px;
    font-weight: 600;
    padding-top: 1rem;
    padding-bottom: 1rem;
    color: #ffffff;
    position: relative;
    border: none;
    text-decoration: none;

    &:hover {
       transform: translateY(-5px);
    }
    background: $btncolorgrey;
  }
</style>
