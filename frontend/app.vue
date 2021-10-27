
<template>
  <div>
    <button class="newTournament" type="button">New Tourament</button>
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
        <div class="round" v-for="(round, index) in rounds" :key="index" :class="['round-' + round]" >
          <div class="match" v-for="(match, matchIndex) in round" :key="matchIndex" >
            <div class="match__content">
              <div class="matchplayer">
                <button type="button">{{players[match - 1]}}</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
const defaultRounds = [256, 128, 64, 32, 16, 8, 4, 2, 1]
/*
      bracketSize: {
        type: Number,
        default: 2
      },
      */
export default {
    name: "Tournaments",
    data() {
      return {
        players: null,
        bracketSize: 0
      }
    },
    methods: {
      newTournament() {
        const field = document.getElementById("tplayers").value;
        this.players = field.split("\n");
        console.log(this.players)
        this.bracketSize = this.players.length;
        console.log(this.bracketSize)
        this.$nuxt.refresh;
      },

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






