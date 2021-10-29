

<template>
<div>
    <form>
      <label for="tname">Tournament name:</label><br>
      <input type="text" id="tname" name="tname" placeholder="Tournament name"><br>
      <label for="tdate">Date:</label><br>
      <input type="text" id="tdate" name="tdate" placeholder="Date"><br>
      <label for="tplayers">Players:</label><br>
      <!--<textarea id="tplayers" v-model="players" name="tplayers" rows="4" cols="50"></textarea><br><br>-->
      <textarea id="tplayers" name="tplayers" rows="4" cols="50"></textarea><br><br>
      <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
      <!--<input type="submit" value="Submit">-->
    </form>
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
</template>

<script>
const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1];
export default {
    name: "Tournaments",
    data() {
      return {
        players: null,
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
        this.players = field.split("\n");
        console.log(this.players)
        this.bracketSize = this.players.length;
        console.log(this.bracketSize)

      },
      matchWin(value) {
        //const playerfield = document.getElementByClass(`round-${matchInt}`).getElementByClass("player")
        console.log(value)
      }
    },
    mounted() {

    },
    computed: {
      rounds () {
        return defaultRounds.filter(rounds => rounds <= this.bracketSize)
      }
    }
}
</script>

<style lang="scss">

</style>

