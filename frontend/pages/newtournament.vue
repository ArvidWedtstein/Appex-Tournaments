<template>
  <div id='newtournament'>
    <div v-if="page === 0" class="page">
      <div class="pg2-content-container">
        <div class="inputBox">
          <h1>Skriv inn navnet på tournamentet</h1>
          <input v-model="tournament.name" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69" required>
          <span class="limiter">{{ 69 - tournament.name.length }} characters remaining</span>
        </div>
        <div class="inputBox">
          <h1>Tournament dato</h1>
          <input v-model="tournament.date" type="date" id="tdate" name="tdate" placeholder="Dato" required>
        </div>
        <div class="pagebtn">
          <button class="next" @click="increasePage()">
            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-right" class="svg-inline--fa fa-arrow-circle-right fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
              <path fill="currentColor" d="M256 8c137 0 248 111 248 248S393 504 256 504 8 393 8 256 119 8 256 8zm-28.9 143.6l75.5 72.4H120c-13.3 0-24 10.7-24 24v16c0 13.3 10.7 24 24 24h182.6l-75.5 72.4c-9.7 9.3-9.9 24.8-.4 34.3l11 10.9c9.4 9.4 24.6 9.4 33.9 0L404.3 273c9.4-9.4 9.4-24.6 0-33.9L271.6 106.3c-9.4-9.4-24.6-9.4-33.9 0l-11 10.9c-9.5 9.6-9.3 25.1.4 34.4z"></path>
            </svg>
          </button>
        </div>
      </div>
    </div>
    <div v-if="page === 1" class="page">
      <div class="headerContainer">
        <h1 class="display-4">"{{ tournament.name }}" Deltakere</h1>
        <p class="lead">Rediger deltakere</p>
      </div>
      <div class="playerAddContainer">
        <div class="countContainer">
          <div class="playerCount">{{ players.length }}</div>
          <p>Deltakere</p>
        </div>
        <div class="btnContainer">
          <button class="minusBtn" @click="removePlayer()">-</button>
          <button class="plusBtn" @click="addPlayer()">+</button>
        </div>
      </div>



      <div class="deltakere" v-for="i in Math.ceil(players.length / 8)" :key="i">
        <div v-for="(name, index) in players.slice((i - 1) * 8, i * 8)" :key="index" class="deltakere">
          <div class="playerBox">
            <input class="playername" v-model="players[index]" type="text" v-bind:placeholder= "'Deltaker' + index">
          </div>
        </div>
      </div>  
      <button class="newTournament" @click="newTournament()" type="button">New Tournament</button>
      <!--<input type="submit" value="Submit">-->
    </div>

    <div v-if="page === 2" class="page">
      <tournamentoverview :tournamentprop="turnering"></tournamentoverview>
      <NuxtLink to="/tournament">Begynn turnerng</NuxtLink>
      <NuxtLink to="/">Utsett turnerng</NuxtLink>
    </div>
  </div>
</template>


<script>
let intPlayer = 1;
import axios from 'axios';
import env from '~/dotenv.json'
export default {
   template: 'newtournament',
   transition: 'slide-bottom',
   data() {
      return {
        page: 0,
        tournament: {
          name: '',
          date: ''
        },
        players: [""],
        matches: [],
        turnering: {}
      }
    },
    methods: {
      async newTournament() {
        console.log(this.players)
        axios({
          method: 'post',
          url: `${env.BASE_URL}/createTournament?tournamentName=${this.tournament.name}&tournamentDate=${this.tournament.date}`,
          data: this.players
        }).then(async (response) => {
          
          console.log(response.data);
          //this.matches = response.data.matches;
          this.matches = response.data.rounds;
          this.turnering = response.data;
        })
        this.increasePage()
      },
      addPlayer() { 
        if (intPlayer < 32){
        const adj = ["Gretten", "Glad", "Fjern","Smart","God","Vakker","Snill","Første","Rask","Kreativ", "Lys", "Mandig", "Treig"];
        const noun = ["gris", "data", "gnager","mann", "kvinne", "Franskmann", "Amerikaner","Tysker","Nordmann", "script"];
        for(let i = 0; i < intPlayer; i++) {
          let playername = adj[Math.floor(Math.random()*adj.length)] + " " + noun[Math.floor(Math.random()*noun.length)];
          this.players.push(playername)
        }
        intPlayer = (intPlayer * 2);
      }},
      removePlayer(index) {
        if(intPlayer > 1){
          console.log(intPlayer)
          var playerDevide = (intPlayer / 2)
          for (var i = 0; i < playerDevide; i++){
            this.players.splice(index, 1);
            intPlayer = this.players.length;
          }
        }
        
      },
      increasePage() {
        if (this.page == 2) return
        const regex = /^[a-zA-Z0-9]*$/
        if (this.tournament.name && this.tournament.date && regex.test(this.tournament.name)) {
          this.page += 1;
        } else {
          alert('Name and/or date cannot be empty')
        }
        
      },
      decreasePage() {
          if (this.page == 0) return
          this.page -= 1;
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
    mounted() {
      if (document.querySelector("#Matrix")) {
        this.matrix()
      }
      //this.getTournament()
    }
}
</script>
<style lang="scss">
$inputcolor: rgba(0,0,0,0.5);
$inputhovercolor: rgba(0,0,0,1);
$backclr: #edece9;
$black: #221E20;
$dark-grey: #464544;
$grey: #D6D2CE;
$light-grey: #EDECE9;
$blue: #0835C4;
$green: #DDE78B;
$orange: #FAB487;
#newtournament {
  background: $backclr !important;
  height: 100vh;

}
#Matrix {
  position: absolute;
  left: 0;
  top: 0;
  z-index: -1;
}
.deltakere {
  display: flex;
  flex-direction: column;
  justify-content: left;
  width: auto;
  margin: 0;
  .playerBox {
    //flex: 1 1 auto;
    display: flex;
    //flex-direction: row;
    margin: 0.2rem;
    .playername {
      padding: 0.5rem 1rem;
      flex: 1 1 auto;
      color: #000;
      background-color: $grey;
      border: none;
      border-bottom: 2px solid $blue;
      outline: none;
      &::placeholder, &::-moz-placeholder, &:-ms-input-placeholder {
        color: gray;
      }
      &:focus-within, &:focus {
        color: gray;
      }
    }
  }
}
.pg2-content-container{
  width: 80%;
  height: 80vh;
  padding: 5vh 5%;
  align-items: center;
}
.page {
    display: flex;
    justify-content: center;
    align-content: center;
    align-items: center;
    position: relative;
    flex-direction: column;
    width: 100%;
    max-height: 100%;
    height: 100%;
    .headerContainer{
        text-align: center;
        position: absolute;
        top: 2vh;
        left: 50%;
        transform: translateX(-50%);
        min-height: 10vh;
        h1{
            font-size: 4vw;
        }
        p{
            font-size: 2vw;
        }
    }
    .playerAddContainer{
      position: absolute;
      top: 2vh;
      right: 128px;
      height: 140px;
      width: 100px;
    }
    .btnContainer{
      font-size: 3rem;
      font-weight: 400;
      display: flex;
      align-items: center;
      .plusBtn{
        position: absolute;
        right: 0;
        bottom: 0;
      }
      .minusBtn{
        position: absolute;
        left: 0;
        bottom: 0;
      }

    }
    .countContainer {
      .playerCount{
        color: $blue;
        font-size: 2.5rem;
        font-weight: 400;
        width: 100%;
        text-align: center;
      }
      p{
        width: 100%;
        text-align: center;
        font-weight: 400;
      }
    }
    .inputBox{
        flex: 1 1 auto;
        padding: 0.2rem;
        margin-top: 70px;
        
        h1{
              font-size: 20px;
              font-weight: 600;
        }
        input {
            position: relative;
            flex: 1 1 auto;
            background: transparent;
            text-align: left;
            vertical-align: middle;
            outline: none;
            width: 100%;
            border: none;
            color: $inputcolor;
            padding-bottom: 10px;
            font-size: 1rem;
            letter-spacing: 1px;
            transition: all 0.3s ease;
            border-bottom: 2px solid $inputcolor;
            
            &:focus {
                color: $inputhovercolor;
                border-bottom: 2px solid $inputhovercolor;
            }
            &:-webkit-autofill,
            &:-webkit-autofill:hover, 
            &:-webkit-autofill:focus, 
            &:-webkit-autofill:active  {
                -webkit-text-fill-color: black;
              -webkit-box-shadow: 0 0 0px 1000px #000 inset;
              box-shadow: 0 0 0px 1000px #000 inset;
              transition: background-color 5000s ease-in-out 0s;
            }
        }
    }
    .pagebtn {
      position: absolute;
      width: 50px;
      right: 0;
      bottom: 0;
      margin: 2rem 4rem;
        .next {
            float: right;
            color: black;
            right: 0;
        }
    }
}
.newTournament{
  position: absolute;
  right: 4rem;
  bottom: 2rem;
  font-weight: 600;
  padding: 1rem;
  color: #ffffff;
  border: none;
  text-decoration: none;
  background: $blue;

  &:hover {
    transform: translateY(-5px);
  }
}


</style>
