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
          <div class="inputBox">
            <h3>Antall deltakere</h3>
            <input type="range" min="2" max="69" id="players" v-model.number="playerInt">
            <span class="limit">{{playerInt}}</span>
          </div>
          <div class="pagebtn">
            <button class="past" v-on:click="pageSwitch('past')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" width="50px"></button>
            <button class="next" v-on:click="pageSwitch('next')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+right+chevron+chevronright+right+right+icon+icon-1320185732203239715.png" width="50px"/></button>
          </div>
        </form>
      </div>
      <div v-if="page === 1" class="page">
        <form>
          <h1 class="title">{{tournamentName}} deltakere</h1>
          <div v-for="index in playerInt" :key="index" class="deltakere">

              <input class="playername" v-bind:id="index" type="text" :v-model="'matches['+index +']'" v-bind:placeholder="'player' + index">
          </div>
          <textarea id="tplayers" name="tplayers" rows="4" cols="50"></textarea><br><br>
          <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
          <!--<input type="submit" value="Submit">-->
          <div class="pagebtn">
          <button class="past" v-on:click="pageSwitch('past')"><i class="fas fa-arrow-left"></i></button>
          </div>
        </form>
      </div>
   </div>
</template>

<script>
export default {
   template: 'newtournament',
   transition: 'slide-bottom',
   data() {
      return {
        page: 1,
        tournamentName: 'test',
        players: 0,
        playerInt: 8,
        bracketSize: 0,
    
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
}
</script>