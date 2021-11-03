

<template>
  <div>
    <div v-if="page === 2" class="page">
      <div class="tournament-brackets">
        <div class="bracket">
          <div class="round" v-for="round in matches" :key="round">
              <div class="match" v-for="match in round" :key="match">
                  <div class="match__content"></div>
                      <div class="matchplayer" v-for="player in match" :key="player">
                          <button class="player" v-on:click="matchWin(round, player)" type="radio">{{player}}</button>
                      </div>
                  </div>
              </div>
          </div>
        <!--<div class="round" v-for="round in rounds" :class="['round-' + 2]" >
          <p>{{rounds}}</p>
          
          <div class="match" v-for="(match, matchIndex) in rounds[0]" :key="matchIndex" >
            <p>{{round}}</p>
            <div class="match__content">
              <div class="matchplayer">
                <button class="player" v-on:click="matchWin(players[match - 1])" type="button">{{players[match - 1]}}</button>
              </div>
            </div>
          </div>
        </div>-->
      </div>
    </div>
    <canvas id="Matrix"></canvas>
    
  </div>
</template>
    
<script>

const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
export default {
    name: "Tournaments",
    data() {
      return {
        page: 1,
        tournamentName: 'test',
        players: 0,
        playerInt: 8,
        bracketSize: 0,
        matches: [
          [

          ],
          [

          ],
          [

          ],
          [
            []
          ]
        ]
      }
    },
    methods: {
      newTournament() {
        this.playerInt = parseInt(this.playerInt);
        const field = document.getElementById("tplayers").value;
        this.players = field.split("\n").length;
        let playerlist = field.split("\n");
        console.log(playerlist.length)
        let matchlist = [];
        for (let i = 0; i < this.playerInt; i+=2) {
            matchlist.push(playerlist[i])
            matchlist.push(playerlist[i+1])
            this.matches[0].push(matchlist);
            matchlist = []
        }
        console.table(this.matches)
        this.bracketSize = this.players.length;
        let nextmatchint = this.matches[0].length / 2;
        for (let i = 0; i < nextmatchint; i++) {
          this.matches[1].push([])
          
        }
        this.matches[2].push([])
        this.pageSwitch('next');
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
          if (this.page = 2) return
          
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
    computed: {
      rounds () {
        return defaultRounds.filter(rounds => rounds <= this.bracketSize)
      },
      
    }
}
/*
matches: [
  [
    ['player1', 'player2'],
    ['player12', 'player22']
  ],
  [
    ['winner1', "winner2"]
  ],
  [
    ['final winner']
  ]
]
*/
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
  z-index: -1;
}
.deltakere {
  display: flex;
  flex-direction: column;
  justify-content: center;
  .playername {
    margin: 0.2rem;
    flex: 1 1 auto;
    padding: 0.5rem 1rem;
    background: $grey;
    color: #ffffff;
    border: none;
    border-bottom: 2px solid $blue;
    &::placeholder, &::-moz-placeholder, &:-ms-input-placeholder{
      color: $green;
      background: red;
    }
  }
}

</style>

