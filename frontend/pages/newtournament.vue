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
          <button class="next" @click="increasePage()"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+right+chevron+chevronright+right+right+icon+icon-1320185732203239715.png" width="50px"/></button>
        </div>
      </div>
    </div>
    <div v-if="page === 1" class="page">
      <div class="jumbotron">
        <h1 class="display-4">{{tournament.name}} Deltakere</h1>
        <p class="lead">Antall deltakere</p>
        <button class="playerCount red" @click="addPlayer()">+</button>
        <span class="playerCount">{{players.length}}</span>
      </div>
      <div v-for="(name, index) in players" :key="index" class="deltakere">
        <div class="playerBox">
          <input class="playername" v-model="players[index].name" type="text" v-bind:placeholder= "'Deltaker' + index">
          <span @click="removePlayer(index)" class="close">X</span>
        </div>
      </div>
      <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
      <!--<input type="submit" value="Submit">-->
      <div class="pagebtn">
        <button class="past" v-on:click="decreasePage()"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" width="50px"></button>
      </div>
    </div>
    <div v-if="page === 2" class="page">
      <div class="tournament-brackets">
        <div class="bracket">
          <div class="round" v-for="round in matches" :key="round">
            <div class="match" v-for="match in round" :key="match">
              <div class="match__content"></div>
              <div class="matchplayer" v-for="player in match" :key="player">
                <button class="player" v-on:click="matchWin(round, player)" type="button">{{player}}</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
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
        players: [{name: ''}],
        matches: []
      }
    },
    methods: {
      newTournament() {
        axios({
          method: 'post',
          url: `${env.BASE_URL}/newtournament`,
          data: {
            tournamentname: this.tournament.name,
            tournamentdate: this.tournament.date,
            players: this.players
          }
        }).then(async (response) => {
          
          console.log(response.data.matches);
          this.matches = response.data.matches;
        })
        this.increasePage()
      },
      async getTournament() {
        await axios({
          method: 'get',
          url: `${env.BASE_URL}/gettournaments`
        }).then(async (response) => {
          await console.log(response)
        });
        
      },
      addPlayer() { 
        const adj = ["Gretten", "Glad", "Fjern","Smart","God","Vakker","Snill","Første","Rask","Kreativ", "Lys", "Mandig"]
        const noun = ["gris", "data", "gnager","mann", "kvinne", "Franskmann", "Amerikaner","Tysker","Nordmann"]
        for(let i = 0; i < intPlayer; i++) {
          this.players.push({ name: adj[Math.floor(Math.random()*adj.length)] + " " + noun[Math.floor(Math.random()*noun.length)] })
        }
        intPlayer = (intPlayer * 2);
      },
      removePlayer(index) {
        this.players.splice(index, 1);
      },
      matchWin(round, playername) {
        let rounds = defaultRounds.filter(p => p <= this.players.length)
        console.log(this.matches.indexOf(round))
        let winnerint = this.matches[0].flat().indexOf(playername)
        let nextmatchint = this.matches.indexOf(round) + 1;
        if (nextmatchint >= 2) {
          this.matches[nextmatchint][0].push(playername)
          if (this.matches[nextmatchint][0].length >= 2) return;
        } else {
          if (winnerint > round.length) {
            if (this.matches[nextmatchint][1].length >= 2) return;
              
            this.matches[nextmatchint][1].push(playername)
            
          } else {
            if (this.matches[nextmatchint][0].length >= 2) return;
            this.matches[nextmatchint][0].push(playername)
          }
        }
        console.log(this.matches)
        
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
    },
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
  justify-content: center;
  .playerBox {
    flex: 1 1 auto;
    display: flex;
    flex-direction: row;
    margin: 0.2rem;
    .playername {
      padding: 0.5rem 1rem;
      flex: 1 1 auto;
      color: #000000;
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
    .close {
      flex: 1 1 auto;
      position: relative;
      right: 0;
      top: 0;
      padding: 0.5rem 1rem;
      background: rgba(255,0,0,0.5);
      border-bottom: 2px solid $blue;
      transition: all 0.2s ease;
      &:hover {
        background: rgba(255,0,0,1);
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
    height: 100%;
    margin-top: 3rem;
    .playerCount {
      padding: 1rem;
      margin: 1rem;
      border-radius: calc(0.55rem - 1px);
      border: 2px solid $dark-grey;
      font-size: 4ch;
      transition: all 0.1s ease;
      background-color: #c34747;
      box-shadow: 0 5px 5px #853232, 
        0 9px 0 #5e2525, 0px 9px 10px rgb(0 0 0 / 40%), 
        inset 0px 2px 9px rgb(255 255 255 / 20%), 
        inset 0 -2px 9px rgb(0 0 0 / 20%);
      &:active {
        text-shadow: 0 1px 1px rgba(255, 255, 255, .9), 0 -1px 1px rgba(0, 0, 0, .1);
        box-shadow: none;
      }
    }
    .inputBox {
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
        flex: 1 1 auto;
        align-self: flex-end;
        position: relative;
        width: 100%;
        font-size: 2rem;
        button {
            padding: 0.2rem 0.5rem;
            background: #dddddd;
            outline: none;
            border-radius: 50%;
            border: none;
            transition: all 0.2s ease;
            &:hover {
                background: #888;
            }
        }
        .past {
            float: left;
            left: 0;
            position: absolute;
        }
        .next {
            float: right;
            color: red;
            right: 0;
            position: absolute;
        }
    }
}
.jumbotron {
  text-align: center;
  flex: 1 1 auto;
  padding: 2rem 1rem;
  margin-bottom: 1rem;
  border-radius: 0.3rem;
  .display-4 {
      font-size: 3.5rem;
      font-weight: 300;
      line-height: 1.2;
  }
  .lead {
      font-size: 1.25rem;
      font-weight: 300;
      margin-top: 0;
      margin-bottom: 1rem;
  }
}
.bracket {
    display: flex;
}

.round {
    display: flex;
    flex-grow: 1;
    flex-direction: column;
    padding: 0;
    margin: 0;
}


.round:first-child .match::before {
    display: none;
}

.round:first-child .match__content::before {
    display: none;
}

.round:last-child .match::after {
    display: none;
}
.round:last-child .match::before {
    display: none;
}
.match {
    display: flex;
    flex-direction: column;
    justify-content: center;
    margin: 0 10px;
    padding: 6px 0;
    flex-grow: 1;
    position: relative;
    vertical-align: middle;
    &::before {
        content: "";
        display: block;
        min-height: 20px;
        border-left: 2px solid purple;
        position: absolute;
        left: -10px;
        top: 60%;
        margin-top: -15px;
        margin-left: -2px;
    }
    &:nth-child(2n+0) {
        padding-top: 0;
        padding-top: 0;
        margin-top: 0;
        margin-bottom: 0;
    }
}
.match:nth-child(odd)::after {
    content: "";
    display: block;
    border: 2px solid transparent;
    border-top-color: purple;
    border-right-color: purple;
    height: 50%;
    position: absolute;
    right: -10px;
    width: 10px;
    top: 50%;
}

.match:nth-child(even)::after {
    content: "";
    display: block;
    border: 2px solid transparent;
    border-bottom-color: purple;
    border-right-color: purple;
    height: 50%;
    position: absolute;
    right: -10px;
    width: 10px;
    bottom: 50%;
}
.round:last-child {
    .match__content::before {
        content: "";
        display: block;
        width: 20px;
        border-bottom: 2px solid purple;
        margin-left: -10px;
        position: absolute;
        top: 50%;
        left: -10px;
    }
}
.match__content::before {
    content: "";
    display: block;
    width: 20px;
    border-bottom: 2px solid purple;
    margin-left: -2px;
    position: absolute;
    top: 50%;
    left: -10px;
}
.matchplayer {
    display: flex;
    flex-direction: column;
    width: 100%;
    position: relative;
    margin: 0;
    padding: 0;
    .player {
        flex: 1 1 auto;
        margin: 0;
        padding: 0.3rem 1rem;
        border: 2px solid black;
        text-align: left;
        position: relative;
    }
}
</style>
