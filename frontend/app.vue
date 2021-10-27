
<template>
  <div>
    <button class="newTournament" type="button">New Tourament</button>
    <form>
      <label for="tname">Tournament name:</label><br>
      <input type="text" id="tname" name="tname" placeholder="Tournament name"><br>
      <label for="tdate">Date:</label><br>
      <input type="text" id="tdate" name="tdate" placeholder="Date"><br>
      <label for="tplayers">Players:</label><br>
      <textarea id="tplayers" name="tplayers" rows="4" cols="50"></textarea><br><br>
      <button class="newTournament" v-on:click="newTournament()" type="button">New Tourament</button>
      <!--<input type="submit" value="Submit">-->
    </form>
    <div class="tournament-brackets">
      <div class="bracket">
        <div v-for="(round, index) in rounds" :key="index">
          <div  class="round" :class="['round-' + round]">
            <div v-for="(match, matchIndex) in round" :key="matchIndex">
              <div class="match">
                <p class="currentmatch">match: {{match}}</p>
                <div class="match__content matchstyle" style="border: 2px solid black; width: 100%; height: 30px; position: relative;">
                  <div class="matchstyle">
                  {{players[matchIndex]}}
                  </div>
                </div>
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
        players: [],
        bracketSize: 2
      }
    },
    methods: {
      newTournament() {
        const field = document.getElementById('tplayers').value;
        let players = field.split("\n");
        console.log(players)
        this.players = players;
        this.bracketSize = players.length;
        console.log(this.bracketSize)
        this.rounds();
        this.$nuxt.refresh();
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






