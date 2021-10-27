
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
            <template v-for="(round, index) in rounds" :key="index">
                <div class="round" :class="['round-' + round]">
                    <template v-for="(match, matchIndex) in round" :key="matchIndex">
                        <div class="match"><div class="match__content" :style="matchStyle"></div></div>
                    </template>
                </div>
            </template>
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
    props: {
      matchStyle: {
        type: Object,
        default: () => ({
          border: '2px solid black',
          width: '100%',
          height: '30px',
          position: 'relative'
        })
      }
    },
    data() {
      return {
        players: [],
        bracketSize: 0
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
      },
      rounds () {
        return defaultRounds.filter(rounds => rounds <= this.bracketSize)
      }
    },
    mounted() {

    },
    computed: {
      
    }
}
</script>



<style>
    *,
    *::after,
    *::before {
        box-sizing: border-box;
    }

    .bracket {
        display: flex;
    }

    .round {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
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

    .match {
        display: flex;
        flex-direction: column;
        justify-content: center;
        margin: 0 10px;
        padding: 6px 0;
        flex-grow: 1;
        position: relative;
    }

    .match::before {
        content: "";
        display: block;
        min-height: 30px;
        border-left: 2px solid purple;
        position: absolute;
        left: -10px;
        top: 50%;
        margin-top: -15px;
        margin-left: -2px;
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

    .match__content::before {
        content: "";
        display: block;
        width: 10px;
        border-bottom: 2px solid purple;
        margin-left: -2px;
        position: absolute;
        top: 50%;
        left: -10px;
    }
</style>



