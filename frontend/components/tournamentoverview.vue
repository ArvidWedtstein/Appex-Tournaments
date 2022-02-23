<template>
	<div v-cloak v-bind:class="{ 'mx-12': clickable == true }" class="my-8 flex flex-col content-center justify-center align-center">
		<div class="flex flex-auto content-center items-center rounded p-8 bg-appexdarkgrey">
			<div v-cloak v-if="tournament" class="flex content-center items-center">
				<div class="round" v-for="(round, i) in tournament.rounds" :key="i">
					<div class="match" v-for="(match, m) in round" :key="m">
						<div class="match__content"></div>
						<div class="matchplayer" v-for="player in match.players" :key="player">
							<button class="player" v-if="clickable" @click="matchWin(tournament.id, player.id, match.id)" type="button" v-cloak v-bind:class="{ 'winner': match.winner.id == player.id, 'clickable': clickable }">{{ player.name }}</button>
							<button class="player" v-else type="button" v-cloak v-bind:class="{ 'winner': match.winner.id == player.id }">{{ player.name }}</button>
						</div>
					</div>
          <div v-if="preview == false && tournament.rounds[tournament.rounds.length-1][0].winner != null" class="fixed top-0 left-0 bottom-0 right-0 m-40 rounded-2xl bg-appexblue flex flex-col justify-center align-center content-center items-center">
            <div class="text-center">
              <h3 class="text-4xl">Final Winner:</h3>
              <h1 class="text-6xl">{{ tournament.rounds[tournament.rounds.length - 1][0].winner.name }}</h1>
              <br>
              <NuxtLink class="text-2xl" to="/">Hjem</NuxtLink>
            </div>
          </div>
				</div>
			</div>
      <div v-else>
        <p class="text-white">Tournament could not be loaded</p>
      </div>
		</div>
    <div class="tournament-bracket tournament-bracket--rounded">                                                     
    <div class="tournament-bracket__round tournament-bracket__round--quarterfinals">
      <h3 class="tournament-bracket__round-title">Quarterfinals</h3>
      <ul class="tournament-bracket__list">
        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-18">18 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Canada">CAN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ca" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">4</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Kazakhstan">KAZ</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-kz" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>

        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-18">18 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Czech Republic">CZE</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-cz" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">4</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Unitede states of America">USA</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-us" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-18">18 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Finland">FIN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-fi" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">2</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Sweden">SVE</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-se" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>

        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-18">18 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Russia">RUS</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ru" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">4</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Belarus">BEL</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-by" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
      </ul>
    </div>
    <div class="tournament-bracket__round tournament-bracket__round--semifinals">
      <h3 class="tournament-bracket__round-title">Semifinals</h3>
      <ul class="tournament-bracket__list">
        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-20">20 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Canada">CAN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ca" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Czech Republic">CZE</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-cz" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">2</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>

        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-20">20 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Finland">FIN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-fi" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">4</span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Russia">RUS</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ru" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">7</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
      </ul>
    </div>
    <div class="tournament-bracket__round tournament-bracket__round--bronze">
      <h3 class="tournament-bracket__round-title">Bronze medal game</h3>
      <ul class="tournament-bracket__list">
        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-21">21 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Finland">FIN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-fi" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">3</span>
                    <span class="tournament-bracket__medal tournament-bracket__medal--bronze fa fa-trophy" aria-label="Bronze medal"></span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Canada">CAN</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ca" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">2</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
      </ul>
    </div>
    <div class="tournament-bracket__round tournament-bracket__round--gold">
      <h3 class="tournament-bracket__round-title">Gold medal game</h3>
      <ul class="tournament-bracket__list">
        <li class="tournament-bracket__item">
          <div class="tournament-bracket__match" tabindex="0">
            <table class="tournament-bracket__table">
              <caption class="tournament-bracket__caption">
                <time datetime="1998-02-22">22 February 1998</time>
              </caption>
              <thead class="sr-only">
                <tr>
                  <th>Country</th>
                  <th>Score</th>
                </tr>
              </thead>  
              <tbody class="tournament-bracket__content">
                <tr class="tournament-bracket__team tournament-bracket__team--winner">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Czech Republic">CZE</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-cz" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">1</span>
                    <span class="tournament-bracket__medal tournament-bracket__medal--gold fa fa-trophy" aria-label="Gold medal"></span>
                  </td>
                </tr>
                <tr class="tournament-bracket__team">
                  <td class="tournament-bracket__country">
                    <abbr class="tournament-bracket__code" title="Russia">RUS</abbr>
                    <span class="tournament-bracket__flag flag-icon flag-icon-ru" aria-label="Flag"></span>
                  </td>
                  <td class="tournament-bracket__score">
                    <span class="tournament-bracket__number">0</span>
                    <span class="tournament-bracket__medal tournament-bracket__medal--silver fa fa-trophy" aria-label="Silver medal"></span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </li>
      </ul>
    </div>
  </div>
	</div>
</template>										



<script>
import axios from 'axios';
import { useTournamentStore } from '~/stores/tournament'

export default {
	name: "tournamentoverview",
	props: {
		tournamentprop: {},
    clickable: false,
    preview: false
	},
	data() {
		return {
			// tournament: {} || tournamentsprop,
      tournaments: useTournamentStore()
		}
	},
	async mounted() {
    
	},
	// watch: {
	// 	tournamentprop: function () {
	// 		this.tournament = this.tournamentprop;
	// 	},
	// 	tournament: function () {
	// 		this.tournament = this.tournamentprop || this.tournament;
	// 	}
	// },
	methods: {
		async matchWin(tournamentId, winnerId, matchId) {
      this.tournaments.matchwin(this.$config.baseURL, tournamentId, winnerId, matchId);
      this.tournaments.getById(tournamentId);

		},
	},
  computed:{
    tournament(){
      // if (!this.tournamentprop) return
      return this.tournaments.getById(this.tournamentprop.id || this.$route.params.id[0])
    }
  }
}
</script>




<style lang="scss">
:root {
	--backclr: #edece9;
	--black: #221E20;
	--dark-grey: #464544;
	--grey: #D6D2CE;
	--light-grey: #EDECE9;
	--blue: #0835C4;
	--green: #DDE78B;
	--orange: #FAB487;
  scroll-behavior: smooth;
}

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
      border-bottom: 2px solid var(--green);
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
      border-left: 2px solid var(--green);
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


    // Top part of bracket 
    // ----
    //    |
    //    |
    &:nth-child(odd)::after {
      content: "";
      display: block;
      border: 2px solid transparent;
      border-top-color: var(--green);
      border-right-color: var(--green);
      height: 50%;
      position: absolute;
      right: -10px;
      width: 10px;
      top: 50%;
    }
    // Bottom part of bracket 
    //    |
    //    |
    // ----
    &:nth-child(even)::after {
      content: "";
      display: block;
      border: 2px solid transparent;
      border-bottom-color: var(--green);
      border-right-color: var(--green);
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
        border-bottom: 2px solid var(--green);
        margin-left: -2px;
        position: absolute;
        top: 55%;
        //left: -10px;
      }
    }
    .matchplayer {
      display: flex;
      flex-direction: column;
      position: relative;
      margin: 0;
      padding: 0;
      .player {
        flex: 1 1 auto;
        margin: 0;
        padding: 0.3rem 1rem;
        border: 2px solid var(--green);
        background: var(--black);
        color: var(--orange);
        border-radius: 0.25rem;
        text-align: left;
        position: relative;
        transition: border 0.3s ease;
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






/******************** */

$breakpoint-xs: 24em;
$breakpoint-sm: 38em;
$breakpoint-md: 52em;
$breakpoint-lg: 72em;





.sr-only {
  position: absolute;
  width: 1px;
  height: 1px;
  padding: 0;
  margin: -1px;
  overflow: hidden;
  clip: rect(0,0,0,0);
  border: 0;
}


//
// TOURNAMENT BRACKET
// ---------------------------
.tournament-bracket {
  display: flex;
  flex-direction: column;
  
  @media (min-width: $breakpoint-sm) {
    flex-direction: row;
  }
}

.tournament-bracket__round {
  display: block;
  margin-left: -3px;
  flex: 1;
}

.tournament-bracket__round-title {
  color: #9e9e9e;
  font-size: 0.95rem;
  font-weight: 400;
  text-align: center;
  font-style: italic;
  margin-bottom: 0.5em;
}

.tournament-bracket__list {
  display: flex;
  flex-direction: column;
  flex-flow: row wrap;
  justify-content: center;
  height: 100%;
  min-height: 100%;
  border-bottom: 1px dashed #e5e5e5;
  padding-bottom: 2em;
  margin-bottom: 2em;
  transition: padding 0.2s ease-in-out, margin 0.2s ease-in-out;
  
  @media (max-width: $breakpoint-xs) {
    padding-bottom: 1em;
    margin-bottom: 1em;
  }
  
  @media (min-width: $breakpoint-sm) {
    margin-bottom: 0;
    padding-bottom: 0;
    border-right: 1px dashed #e5e5e5;
    border-bottom: 0;
  }
  
  .tournament-bracket__round:last-child & {
    border: 0;
  }
}

.tournament-bracket__item {
  display: flex;
  flex: 0 1 auto;
  justify-content: center;
  flex-direction: column;
  align-items: flex-start;
  position: relative;
  padding: 2% 0;
  width: 48%;
  transition: padding 0.2s linear;
  
  &:nth-child(odd) {
    margin-right: 2%;
  }
  
  &:nth-child(even) {
    margin-left: 2%;
  }
  
  &::after {
    transition: width 0.2s linear;
  }
  
  @media (max-width: $breakpoint-xs) {
    width: 100%;
    
    &:nth-child(odd),
    &:nth-child(even) {
      margin-left: 0;
      margin-right: 0;
    }
  }
  
  @media (min-width: $breakpoint-sm) {
    padding: 0.5em 1em;
    // flex-grow: 2;
    width: 100%;
    
    &:nth-child(odd),
    &:nth-child(even) {
      margin: 0;
    }
    
    &::after {
      position: absolute;
      right: 0;
      content: '';
      display: block;
      width: 1em;
      height: 45%;
      border-right: 2px solid #9e9e9e;
    }

    &:nth-child(odd)::after {
      top: 50%;
      border-top: 2px solid #9e9e9e;
      transform: translateY(-1px);
      
      .tournament-bracket--rounded & {
        border-top-right-radius: 0.6em;
      }
    }
    
    &:nth-child(even)::after {
      bottom: 50%;
      border-bottom: 2px solid #9e9e9e;
      transform: translateY(1px);
      
      .tournament-bracket--rounded & {
        border-bottom-right-radius: 0.6em;
      }
    }
    .tournament-bracket__round:first-child & {
       padding-left: 0;
    }
    .tournament-bracket__round:last-child & {
       padding-right: 0;

       &::after {
         display: none;
       }
    }

    .tournament-bracket__round:nth-last-child(2) & {
      &::after {
        border-radius: 0;
        border-right: 0;
      }
    }  
  }
  
  @media (min-width: $breakpoint-lg) {
    padding: 0.5em 1.5em;
    
    &::after {
      width: 1.5em;
    }
  }
}


.tournament-bracket__match {
  display: flex;
  width: 100%;
  background-color: #ffffff;
  padding: 1em;
  border: 1px solid transparent;
  border-radius: 0.1em;
  box-shadow: 0 2px 0 0 #e5e5e5;
  outline: none; 
  cursor: pointer;
  transition: padding 0.2s ease-in-out, border 0.2s linear;
  
  &:focus {
    border-color: #2196F3;
  }
  
  &::before,
  &::after {
    transition: all 0.2s linear;
  }
  
  @media (max-width: $breakpoint-xs) {
    padding: 0.75em 0.5em;
  }
  
  @media (min-width: $breakpoint-sm) {
    &::before,
    &::after {
      position: absolute;
      left: 0;
      z-index: 1;
      content: '';
      display: block;
      width: 1em;
      height: 10%;
      border-left: 2px solid #9e9e9e;
    }

    &::before  {
      bottom: 50%;
      border-bottom: 2px solid #9e9e9e;
      transform: translate(0, 1px);
      
      .tournament-bracket--rounded & {
        border-bottom-left-radius: 0.6em;
      }
    }

    &::after  {
      top: 50%;
      border-top: 2px solid #9e9e9e;
      transform: translate(0, -1px);
      
      .tournament-bracket--rounded & {
        border-top-left-radius: 0.6em;
      }
    }
  }
  
  @media (min-width: $breakpoint-lg) {
    &::before,
    &::after {
      width: 1.5em;
    }
    
    &::before {
      transform: translate(0, 1px);
    }
    
    &::after {
      transform: translate(0, -1px);
    }
  }
}

.tournament-bracket__round:last-child .tournament-bracket__match {
  &::before,
  &::after {
    border-left: 0;
  }
  
  &::before  {
    border-bottom-left-radius: 0;
  }
  
  &::after  {
    display: none;
  }
}

.tournament-bracket__round:first-child .tournament-bracket__match {
  &::before,
  &::after {
    display: none;
  }
}

.tournament-bracket__content {
  display: flex;
  
  &::after {
    content: ':';
    width: 1em;
    text-align: center;
    padding: 0.2em 0.1em;
    
    @media (min-width: $breakpoint-sm) {
       order: 1;
    }
  }
  
  & .tournament-bracket__team:first-child {
    width: 50%;
    order: 0;
    text-align: right;
    
    @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
      align-items: flex-end;
    }
    
    & .tournament-bracket__country {
      order: 2;
      justify-content: flex-end;
      
      @media (min-width: $breakpoint-xs) {
        order: 0;
      } 
      
      @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
        flex-direction: column-reverse;
        align-items: flex-end;
      }
    }
    
    & .tournament-bracket__score {
      order: 0;
      
      @media (min-width: $breakpoint-xs) {
         order: 2;
      }
    }
  }
  
  & .tournament-bracket__team:last-child {
    width: 50%;
    order: 2;
    text-align: left;
    
    @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
      align-items: flex-start;
    }
    
    & .tournament-bracket__country {
      @media (min-width: $breakpoint-sm) {
        justify-content: flex-start;
      }
      
      @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
        align-items: flex-start;
      }
    }
    
    .tournament-bracket__code {
      order: 1;
    }
  }
}


.tournament-bracket__table {
  width: 100%;
}

.tournament-bracket__caption {
  font-size: 0.8rem;
  color: #BDBDBD;
  font-weight: 300;
  padding-bottom: 0.75em;
}

.tournament-bracket__team {
  display: flex;
  flex-direction: row-reverse;
  justify-content: space-between;
  
  @media (min-width: $breakpoint-xs) {
    flex-direction: column-reverse;
  }
  
  @media (min-width: $breakpoint-sm) {
    flex-direction: column-reverse;
  }
}

.tournament-bracket__country {
  font-size: 0.95rem;
  display: flex;
  margin-top: 0.5em;
  align-items: center;
  
  @media (max-width: $breakpoint-xs) {
    margin-top: 0;
  }
  
  @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
    display: flex;
    flex-direction: column;
    
    .tournament-bracket__code {
      margin-top: 0.2em;
    }
  }
}

.tournament-bracket__code {
  padding: 0 0.5em;
  color: #212121;
  font-weight: 600;
  text-transform: uppercase;
  border: 0;
  text-decoration: none;
  cursor: help;
  transition: padding 0.2s ease-in-out;
  
  @media (max-width: $breakpoint-xs) {
    padding: 0 0.25em;
  }
  
  @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
    padding: 0;
  }
}

.tournament-bracket__score {
  display: flex;
  align-items: center;
  
  .tournament-bracket__team:first-child & {
    flex-direction: row-reverse;
    padding-left: 0.75em;
  }
  
  .tournament-bracket__team:last-child & {
    padding-right: 0.75em;
  }
}

.tournament-bracket__number {
  display: inline-block;
  padding: 0.2em 0.4em 0.2em;
  border-bottom: 0.075em solid transparent;
  font-size: 0.95rem;
  background-color: #F5F5F5;
  border-color: spin(shade(#F5F5F5, 10%), -10);
  
  .tournament-bracket__team--winner & {
    background-color: #FFF176;
    border-color: spin(shade(#FFF176, 2%), -10);
  }
}

.tournament-bracket__medal {
  padding: 0 0.5em;
}

.tournament-bracket__medal--gold {
  color: #FFD700;
}

.tournament-bracket__medal--silver {
  color: #C0C0C0;
}

.tournament-bracket__medal--bronze {
  color: #CD7F32;
}

</style>
