

<template>
  <div>
    <div v-if="page === 0" class="page">
      <form>
        <div class="inputBox">
          <h2>Skriv inn navnet på tournamentet</h2>
          <input v-model.trim="tournamentName" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69">
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
      <div class="screen__background">
        <span class="screen__background__shape screen__background__shape4"></span>
        <span class="screen__background__shape screen__background__shape3"></span>		
        <span class="screen__background__shape screen__background__shape2"></span>
        <span class="screen__background__shape screen__background__shape1"></span>
		  </div>		
    </div>
    <div v-else-if="page === 1" class="page">
      <form>
        <h1 class="title">{{tournamentName}} deltakere</h1>
        <div v-for="index in playerInt" :key="index" class="deltakere">
            <input type="text" v-model="players[index]" v-bind:placeholder="`player${index}`">
        </div>
        <textarea id="tplayers" name="tplayers" rows="4" cols="50"></textarea><br><br>
        <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
        <!--<input type="submit" value="Submit">-->
        <div class="pagebtn">
          <button class="past" v-on:click="pageSwitch('past')"><i class="fas fa-arrow-left"></i></button>
          <button class="next" v-on:click="pageSwitch('next')"><i class="fas fa-arrow-right"></i></button>
        </div>
      </form>
    </div>
    <div v-else-if="page === 2" class="page">
      <div class="tournament-brackets">
        <div class="bracket">
          <div class="round" v-for="round in matches" :key="round">
              <div class="match" v-for="match in round" :key="match">
                  <div class="match__content"></div>
                      <div class="matchplayer" v-for="player in match" :key="player">
                          <button class="player" v-on:click="matchWin(player)" type="button">{{player}}</button>
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
  </div>
</template>

<script>
const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
export default {
    name: "Tournaments",
    data() {
      return {
        page: 0,
        tournamentName: '',
        players: 0,
        playerInt: 0,
        bracketSize: 0,
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
      }
    },
    methods: {
      newTournament() {
        const field = document.getElementById("tplayers").value;
        this.players = field.split("\n").length;
        console.log(this.players)
        this.bracketSize = this.players.length;
        console.log(this.bracketSize)

      },
      matchWin(value) {
        //const playerfield = document.getElementByClass(`round-${matchInt}`).getElementByClass("player")
        console.log(value)
      },
      pageSwitch(dir) {
        console.log(dir)
        if (dir === 'next') {
          this.page += 1;
        } else if (dir === 'past') {
          this.page -= 1;
        }
        
        this.playerInt = parseInt(this.playerInt);
      },
    },
    mounted() {

    },
    computed: {
      rounds () {
        return defaultRounds.filter(rounds => rounds <= this.bracketSize)
      },
      
    }
}
</script>

<style lang="scss">

</style>

