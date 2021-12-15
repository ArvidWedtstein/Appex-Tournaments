<template>
	<div class="design-container">
		<div class="tournament-brackets">
			<div v-if="tournament" class="bracket">
				<div class="round" v-for="(round, i) in tournament.rounds" :key="i">
					<div class="match" v-for="(match, m) in round" :key="m">
						<div class="match__content">{{match.id}}</div>
						<div class="matchplayer" v-for="player in match.players" :key="player">
							<button class="player" @click="matchWin(tournament.id, player, match.id)" type="button" v-cloak v-bind:class="{ 'winner': match.winner == player }">{{ player }}</button>
						</div>
						<!--<p>Match: {{m+1}}</p>-->
					</div>
          <div v-if="!Contains(tournament.rounds[tournament.rounds.length-1][0], 'winner')" class="finalWinner">
            <div class="bogs">
              {{Contains(tournament.rounds[tournament.rounds.length-1][0], 'winner')}}
              <h3>Final Winner:</h3>
              <h1>{{ tournament.rounds[tournament.rounds.length - 1][0] }}</h1>
              <br>
              <NuxtLink to="/">Hjem</NuxtLink>
            </div>
          </div>
				</div>
			</div>
		</div>
	</div>
</template>										



<script>
import axios from 'axios';
export default {
	name: "tournamentoverview",
	props: {
		tournamentprop: {}
	},
	data() {
		return {
			tournament: {}
		}
	},
	async mounted() {
	  if (document.querySelector('#Matrix')){
		//this.matrix()
	  }
    
	},
	watch: {
		tournamentprop: function () {
			this.tournament = this.tournamentprop;
		},
		tournament: function () {
			this.tournament = this.tournamentprop;
		}
	},
	methods: {
		async matchWin(tournamentId, winner, matchId) {
			await axios({
				method: 'post',
				url: `https://localhost:7021/Tournament/${tournamentId}?winner=${winner}&matchId=${matchId}`
			}).then(async (response) => {
				await console.log(response.data)
        
        this.tournament = response.data;
        //await this.$nuxt.refresh();
        window.location.reload()
				//this.getTournament(tournamentId)
			});
		},
		async getTournament(id) {
      console.log('gettournament')
			await axios({
				method: 'get',
				url: `https://localhost:7021/get-tournament/${id}`
			}).then(async (response) => {
				//await console.log(response.data)
				this.tournament = response.data;
			});
		},
    async Contains(obj, key) {
      console.log(obj)
      if (!obj) return false;
      let value = false;
      if (obj.winner == null || obj.winner == 'undefined') {
        value = false;
      } else if (obj.winner != null) {
        value = true;
      }
      console.log('contains isnull', value)
      return value;
    }
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
$bracketlinecolor: #DDE78B;
@mixin rad-shadow {
  border: 1px solid hsl(200 10% 50% / 15%);
  box-shadow: 0 1rem .5rem -.5rem;
  box-shadow:
  0 2.8px 2.2px hsl(200 50% 3% / calc(.3 + .03)),
  0 6.7px 5.3px hsl(200 50% 3% / calc(.3 + .01)),
  0 12.5px 10px hsl(200 50% 3% / calc(.3 + .02)),
  0 22.3px 17.9px hsl(200 50% 3% / calc(.3 + .02)),
  0 41.8px 33.4px hsl(200 50% 3% / calc(.3 + .03)),
  0 100px 80px hsl(200 50% 3% / .3)
  ;
}
body {
  overflow: auto;
}
#Matrix {
  overflow: hidden;
  position: absolute;
  margin-left: 70%;
  right: 0;
  top: 0;
  z-index: 0;
}
.tournament-brackets {
  display: flex;
  flex: 1 1 auto;
  align-content: center;
  align-items: center;
  padding: 8rem 8rem !important;
  background: $dark-grey;
  border-radius: 0.5rem;
  @include rad-shadow;
}
.finalWinner {
	position: fixed;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	background: rgba($blue, 0.5);
	.bogs {
		position: fixed;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background: $dark-grey;
		color: $light-grey;
		padding: 5rem 8rem;
		border-radius: 0.25rem;
		text-align: center;
		h1 {
			background: #222 -webkit-gradient(linear, left top, right top, from(#222), to(#222), color-stop(0.5, #fff)) 0 0 no-repeat;
			-webkit-background-size: 150px;
			-webkit-background-clip: text;
			color: rgba(255, 255, 255, 0.3);
			-webkit-animation-name: shine;
			-webkit-animation-duration: 5s;
			-webkit-animation-iteration-count: infinite;
			text-shadow: 0 0px 0px rgba(255, 255, 255, 0.5);
			font-size: 5ch;
		}
	}
}
@-webkit-keyframes shine {
	0%, 10% {
		background-position: -1000px;
	}
	20% {
		background-position: top left;
	}
	90% {
		background-position: top right;
	}
	100% {
		background-position: 1000px;
	}
}
.bracket {
  display: flex;
  align-content: center;
  align-items: center;
  .round {
    flex: 1 1 auto;
    display: flex;
    flex-grow: 1;
    flex-direction: column;
    padding: 0;
    margin: 0;
    &:first-child {
      .match {
        &::before {
          display: none;
        }
      }
      .match__content {
        &::before {
          display: none !important;
        }
      }
    }
    &:last-child {
      .match {
        &::before, &::after {
          display: none !important;
        }
      }
      .match__content::before {
        content: "";
        display: block;
        width: 20px;
        border-bottom: 2px solid $bracketlinecolor;
        margin-left: -10px;
        position: absolute;
        top: 50%;
        left: -10px;
      }
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
        border-left: 2px solid $bracketlinecolor;
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
      &:nth-child(odd)::after {
        content: "";
        display: block;
        border: 2px solid transparent;
        border-top-color: $bracketlinecolor;
        border-right-color: $bracketlinecolor;
        height: 50%;
        position: absolute;
        right: -10px;
        width: 10px;
        top: 60%;
      }
      &:nth-child(even)::after {
        content: "";
        display: block;
        border: 2px solid transparent;
        border-bottom-color: $bracketlinecolor;
        border-right-color: $bracketlinecolor;
        height: 50%;
        position: absolute;
        right: -10px;
        width: 10px;
        bottom: 50%;
      }
      .match__content {
        &::before {
          content: "";
          display: block;
          width: 20px;
          border-bottom: 2px solid $bracketlinecolor;
          margin-left: -2px;
          position: absolute;
          top: 55%;
          //left: -10px;
        }
      }
      .matchplayer {
        display: flex;
        flex-direction: column;
        //width: 100%;
        position: relative;
        margin: 0;
        padding: 0;
        .player {
          flex: 1 1 auto;
          margin: 0;
          padding: 0.3rem 1rem;
          border: 2px solid $green;
		  /*background: $orange;
		  color: $black;*/

		  /*background: $blue;
		  color: $backclr;*/

		  background: $black;
		  color: $orange;
		  border-radius: 0.25rem;
          text-align: left;
          position: relative;
          &.winner {
			  &::after {
				  content: "🏅";
				  float: right;
			  }
            //background: gold;
          }
        }
      }
    }
  }
}

</style>
