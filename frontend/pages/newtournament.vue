<template>
   <div id='newtournament'>
      <div v-if="page === 0" class="page">
        <form>
          <div class="inputBox">
            <h2>Skriv inn navnet på tournamentet</h2>
            <input v-model="tournamentName" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69">
            <span class="limiter">{{ 69 - tournamentName.length }} characters remaining</span>
          </div>
          <div class="inputBox">
            <h3>Tournament dato</h3>
            <input type="date" id="tdate" name="tdate" placeholder="Dato">
          </div>
          <div class="pagebtn">
            <button class="past" v-on:click="pageSwitch('past')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" width="50px"></button>
            <button class="next" v-on:click="pageSwitch('next')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+right+chevron+chevronright+right+right+icon+icon-1320185732203239715.png" width="50px"/></button>
          </div>
        </form>
      </div>
      <div v-if="page === 1" class="page">
        <div class="jumbotron">
          <p class="lead">Antall deltakere</p>
          <button class="lead" @click="addPlayer()">+</button>
          <span class="limit">{{players.length}}</span>
        </div>
        <div v-for="(name, index) in players" :key="index" class="deltakere">
          <div class="playerBox">
            <input class="playername" v-model="players[index].name" type="text" v-bind:placeholder="'Deltaker ' + index">
            <span @click="removePlayer(index)" class="close">X</span>
          </div>
        </div>
        <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
        <!--<input type="submit" value="Submit">-->
        <div class="pagebtn">
          <button class="past" v-on:click="pageSwitch('past')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" width="50px"></button>
        </div>
      </div>
   </div>
</template>

<script>
const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
export default {
   template: 'newtournament',
   transition: 'slide-bottom',
   data() {
      return {
        page: 0,
        tournamentName: '',
        players: [],
        bracketSize: 0,
        matches: [
          [

          ],
          [

          ],
          [

          ],
          [
            
          ]
        ]
      }
    },
    methods: {
      newTournament() {
        let matchlist = [];
        let rounds = 16;
        console.log(defaultRounds.filter(rounds => rounds <= this.bracketSize) + 'ree')
        for (let i = 0; i < this.playerInt; i+=2) {
            matchlist.push(playerlist[i])
            matchlist.push(playerlist[i+1])
            this.matches[0].push(matchlist);
            matchlist = []
        }
        console.info(this.matches)
        this.bracketSize = this.players.length;
        let nextmatchint = this.matches[0].length / 2;
        for (let i = 0; i < nextmatchint; i++) {
          this.matches[1].push([])
          
        }
        this.matches[2].push([])
        //this.pageSwitch('next');
      },
      addPlayer() { 
        this.players.push({ name: "" })
        console.info(this.players)
      },
      removePlayer(index) {
        this.players.splice(index, 1);
        console.info(this.players)
      },
      matchWin(round, playername) {
        //const playerfield = document.getElementByClass(`round-${matchInt}`).getElementByClass("player")
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
      pageSwitch(dir) {
        //console.log(dir)
        if (dir === 'next') {
          if (this.page = 1) return
          
          this.page += 1;
        } else if (dir === 'past') {
          if (this.page = 0) return
          this.page -= 1;
        }
        console.log(this.page)
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
            context.fillStyle = 'rgba(255, 255, 255, 0.05)';
            context.fillRect(0, 0, canvas.width, canvas.height);

            //context.fillStyle = '#0F0';
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
        setInterval(draw, 60);
      }
    },
    mounted() {
      this.matrix()
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
      background: $grey;
      color: #000000;
      border: none;
      border-bottom: 2px solid $blue;
      &::placeholder, &::-moz-placeholder, &:-ms-input-placeholder{
        color: gray;
      }
    }
    .close {
      flex: 1 1 auto;
      position: relative;
      right: 0;
      top: 0;
      padding: 0.5rem 1rem;
    }
  }
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
    background: $backclr !important;
    .inputBox {
        flex: 1 1 auto;
        padding: 0.2rem;
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
</style>
