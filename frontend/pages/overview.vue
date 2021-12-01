

<template>
  <div>
    <div v-if="page === 1" class="page">
      <div class="tournament-brackets">
        <!--<div class="bracket">
          <div class="round" v-for="round in matches" :key="round">
            <div class="match" v-for="match in round" :key="match">
              <div class="match__content">

              </div>
              <div class="matchplayer" v-for="player in match" :key="player">
                <button class="player" v-on:click="matchWin(round, player)" type="radio">{{player}}</button>
              </div>
            </div>
          </div>
        </div>-->
        <div class="bracket">
          <div class="round" v-for="(round, i) in matches" :key="i">
            <div class="match" v-for="(match, x) in round" :key="x">
              <div class="matchplayer" v-for="(player, l) in match.matches" :key="l">
                <p>{{ player }}</p>
              </div>
            </div>
          </div>
        </div>
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
        tournamentName: '',
        playerInt: 8,
        bracketSize: 0,
        matches: [
          [
            {
              id:"a174mqnu",
              winner: "",
              matches: [
                "bruker1",
                "bruker2"
              ]
            },
            {
              id:"heko7o7h",
              winner: "",
              matches: [
                "bruker1",
                "bruker2"
              ]
            }
          ],
          [
            {
              id:"a174mqnu",
              winner: "",
              matches: [
                "bruker1",
                "bruker2"
              ]
            }
          ],
          [

          ]
        ]
      }
    },
    methods: {
      newTournament() {
        axios({
          method: 'post',
          url: 'http://localhost:3001/newtournament',
          data: {
            tournamentname: this.tournamentName,
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
          url: 'http://localhost:3001/gettournaments'
        }).then(async (response) => {
          await console.log(response)
        });
      },
      addPlayer() { 
        this.players.push({ name: "" })
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
        if (this.page == 2) alert("aaaa")
          
        this.page += 1;
      },
      decreasePage() {
          if (this.page == 0) return
          this.page -= 1;
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
      //this.matrix()
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


</style>

