<template>
  <div class="container-md">
    <!-- Define SVG Trophy and Loser icons -->
    <svg style="display: none" xmlns="http://www.w3.org/2000/svg">
      <symbol id="trophy" viewBox="0 0 576 512">
        <path d="M552 64H448V24c0-13.3-10.7-24-24-24H152c-13.3 0-24 10.7-24 24v40H24C10.7 64 0 74.7 0 88v56c0 35.7 22.5 72.4 61.9 100.7 31.5 22.7 69.8 37.1 110 41.7C203.3 338.5 240 360 240 360v72h-48c-35.3 0-64 20.7-64 56v12c0 6.6 5.4 12 12 12h296c6.6 0 12-5.4 12-12v-12c0-35.3-28.7-56-64-56h-48v-72s36.7-21.5 68.1-73.6c40.3-4.6 78.6-19 110-41.7 39.3-28.3 61.9-65 61.9-100.7V88c0-13.3-10.7-24-24-24zM99.3 192.8C74.9 175.2 64 155.6 64 144v-16h64.2c1 32.6 5.8 61.2 12.8 86.2-15.1-5.2-29.2-12.4-41.7-21.4zM512 144c0 16.1-17.7 36.1-35.3 48.8-12.5 9-26.7 16.2-41.8 21.4 7-25 11.8-53.6 12.8-86.2H512v16z"/>
      </symbol>
      <symbol id="loser" viewBox="0 0 496 512">
        <path d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm-96 206.6l-28.7 28.7c-14.8 14.8-37.8-7.5-22.6-22.6l28.7-28.7-28.7-28.7c-15-15 7.7-37.6 22.6-22.6l28.7 28.7 28.7-28.7c15-15 37.6 7.7 22.6 22.6L174.6 192l28.7 28.7c15.2 15.2-7.9 37.4-22.6 22.6L152 214.6zM248 416c-35.3 0-64-28.7-64-64s28.7-64 64-64 64 28.7 64 64-28.7 64-64 64zm147.3-195.3c15.2 15.2-7.9 37.4-22.6 22.6L344 214.6l-28.7 28.7c-14.8 14.8-37.8-7.5-22.6-22.6l28.7-28.7-28.7-28.7c-15-15 7.7-37.6 22.6-22.6l28.7 28.7 28.7-28.7c15-15 37.6 7.7 22.6 22.6L366.6 192l28.7 28.7z"/>
      </symbol>
    </svg>
    <div v-cloak v-bind:class="{ 'mx-3': clickable == true }" class="my-8">
      <div v-if="tournament" class="tournament-bracket tournament-bracket__rounded">                                                     
        <div v-for="(round, i) in tournament.rounds" :key="i" class="tournament-bracket__round">
          <h3 class="tournament-bracket__round-title">Runde {{i+1}}</h3>
          <ul class="tournament-bracket__list">
            <li v-for="(match, m) in round" :key="m" class="tournament-bracket__item">
              <div class="tournament-bracket__match" tabindex="0">
                <table class="tournament-bracket__table">
                  <tbody class="tournament-bracket__content">
                    <!-- Clickable version -->
                    <tr v-if="clickable" v-for="player in match.players" :key="player" v-bind:class="{'clickable': clickable}" class="tournament-bracket__team" @click="matchWin(tournament.id, player.id, match.id)" type="button">
                      <td class="tournament-bracket__player">
                        <button class="tournament-bracket__playertxt" v-cloak>{{ player.name }}</button>
                      </td>
                      <td class="tournament-bracket__winner">
                        <span v-if="match.winner.id == player.id" class="tournament-bracket__number">
                          <svg width="40" fill="white" id="trophy" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><use xlink:href="#trophy"/></svg>
                        </span>
                        <span v-else-if="match.winner.id == ''" class="tournament-bracket__number">
                          <p>No winner selected</p>
                        </span>
                        <span v-else-if="match.winner.id != player.id" class="tournament-bracket__number">
                          <svg width="40" fill="white" id="loser" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><use xlink:href="#loser"/></svg>
                        </span>
                      </td>
                    </tr>
                    <!-- Non clickable version / preview -->
                    <tr v-else v-for="player in match.players" :key="player + 'p'" class="tournament-bracket__team" type="button">
                      <td class="tournament-bracket__player">
                        <button class="tournament-bracket__playertxt" v-cloak>{{ player.name }}</button>
                      </td>
                      <td class="tournament-bracket__winner">
                        <span v-if="match.winner.id == player.id" class="tournament-bracket__number">
                          <svg width="40" fill="white" id="trophy" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><use xlink:href="#trophy"/></svg>
                        </span>
                        <span v-else-if="match.winner.id == ''" class="tournament-bracket__number">
                          <p>No winner selected</p>
                        </span>
                        <span v-else-if="match.winner.id != player.id" class="tournament-bracket__number">
                          <svg width="40" fill="white" id="loser" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 576 512"><use xlink:href="#loser"/></svg>
                        </span>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </li>
          </ul>
        </div>
      </div>
      <!-- If everything fails, then let the user know that the tournament could not be loaded -->
      <div v-else>
        <p>Could not load Tournament</p>
      </div>
    </div>
  </div>
</template>										



<script>
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
      tournaments: useTournamentStore()
		}
	},
	methods: {
		async matchWin(tournamentId, winnerId, matchId) {
      this.tournaments.matchwin(this.$config.baseURL, tournamentId, winnerId, matchId);
      this.tournaments.getById(tournamentId)
		},
	},
  computed:{
    tournament(){
      if (!this.tournamentprop) {
        this.tournaments.load(this.$config.baseURL)
        return this.tournaments.getById(this.$route.params.id[0])
      } else {
        return this.tournaments.getById(this.tournamentprop.id)
      }
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

.finalWinner {
	position: fixed;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	background: rgba(var(--blue), 0.5);
	.bogs {
		position: fixed;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background: var(--dark-grey);
		color: var(--light-grey);
		padding: 5rem 8rem;
		border-radius: 0.25rem;
		text-align: center;
		h1 {
			background: #222 -webkit-gradient(linear, left top, right top, from(#222), to(#222), color-stop(0.5, #fff)) 0 0 no-repeat;
			-webkit-background-size: 150px;
			background-size: 150px;
			-webkit-background-clip: text;
			background-clip: text;
			color: rgba(255, 255, 255, 0.3);
			-webkit-animation-name: shine;
			animation-name: shine;
			-webkit-animation-duration: 5s;
			animation-duration: 5s;
			-webkit-animation-iteration-count: infinite;
			animation-iteration-count: infinite;
			text-shadow: 0 0px 0px rgba(255, 255, 255, 0.5);
			font-size: 5ch;
		}
	}
}
@keyframes shine {
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






/******************** */

$breakpoint-xs: 24em;
$breakpoint-sm: 38em;
$breakpoint-md: 52em;
$breakpoint-lg: 72em;

$borderradius: 0rem;

// ----------------------------
// Tournament Bracket
// ----------------------------
.tournament-bracket {
  display: flex;
  flex-direction: column;
  
  @media (min-width: $breakpoint-sm) {
    flex-direction: row;
  }
  &__winner {
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
  // ----------------------------
  // List of matches/round
  // ----------------------------
  &__list {
    display: flex;
    flex-direction: column;
    flex-flow: row wrap;
    justify-content: center;
    height: 100%;
    min-height: 100%;
    border-bottom: 1px dashed var(--light-grey);
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
      border-right: 1px dashed var(--light-grey);
      border-bottom: 0;
    }
  }
  &__round {
    display: block;
    margin-left: -3px;
    flex: 1;
    &-title {
      color: var(--dark-grey);
      font-size: 0.95rem;
      font-weight: 400;
      text-align: center;
      font-style: italic;
      margin-bottom: 0.5em;
    }
    &:first-child .tournament-bracket__match {
      &::before,
      &::after {
        display: none !important;
      }
    }
    &:last-child {
      border: 0;
      .tournament-bracket__match {
        display: flex;
        width: 100%;
        padding: 1em;
        // border: 4px solid var(--orange);
        border-radius: $borderradius;
        box-shadow: 0 2px 0 0 var(--light-grey);
        outline: none; 
        cursor: pointer;
        transition: padding 0.2s ease-in-out, border 0.2s linear;
        
        &:focus {
          border-color: var(--orange);
        }
        &::before  {
          border-bottom-left-radius: 0;
        }
        &::after  {
          display: none;
        }
        &::before,
        &::after {
          border-left: 0;
          transition: all 0.2s linear;
        }
        
        @media (max-width: $breakpoint-xs) {
          padding: 0.75em 0.5em;
        }
        
        @media (min-width: $breakpoint-sm) {
          &::before,
          &::after {
            position: absolute;
            left: 1px;
            // left: 0px;
            z-index: 1;
            content: '';
            display: block;
            width: 1em;
            height: 10%;
            border-left: 2px solid var(--dark-grey);
          }

          &::before  {
            bottom: 50%;
            border-bottom: 2px solid var(--dark-grey);
            transform: translate(0, 1px);
            
            .tournament-bracket__rounded & {
              border-bottom-left-radius: 0.6em;
            }
          }

          &::after  {
            top: 50%;
            border-top: 2px solid var(--dark-grey);
            transform: translate(0, -1px);
            
            .tournament-bracket__rounded & {
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
    }
  }
  &__table {
    width: 100%;
    max-width: 100%;
  }
  &__match {
    display: flex;
    width: 100%;
    background-color: var(--black);
    padding: 1em;
    border-radius: $borderradius;
    box-shadow: 0 2px 0 0 var(--light-grey);
    outline: none; 
    cursor: pointer;
    transition: padding 0.2s ease-in-out, border 0.2s linear;
    
    &:focus {
      border-color: var(--orange);
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
        border-left: 2px solid var(--dark-grey);
      }

      &::before  {
        bottom: 50%;
        border-bottom: 2px solid var(--dark-grey);
        transform: translate(0, 1px);
        
        .tournament-bracket__rounded & {
          border-bottom-left-radius: 0.6em;
        }
      }

      &::after  {
        top: 50%;
        border-top: 2px solid var(--dark-grey);
        transform: translate(0, -1px);
        
        .tournament-bracket__rounded & {
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
  &__item {
    display: flex;
    flex: 0 1 auto;
    justify-content: center;
    flex-direction: column;
    align-items: flex-start;
    // align-items: center;
    position: relative;
    padding: 2% 0;
    // width: 48%;
    width: 100%;
    transition: padding 0.2s linear;

    
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
        border-right: 2px solid var(--dark-grey);
      }

      &:nth-child(odd)::after {
        top: 50%;
        border-top: 2px solid var(--dark-grey);
        transform: translateY(-1px);
        
        .tournament-bracket__rounded & {
          border-top-right-radius: 0.6em;
        }
      }
      
      &:nth-child(even)::after {
        bottom: 50%;
        border-bottom: 2px solid var(--dark-grey);
        transform: translateY(1px);
        
        .tournament-bracket__rounded & {
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
    }
    
    @media (min-width: $breakpoint-lg) {
      padding: 0.5em 1.5em;
      
      &::after {
        width: 1.5em;
      }
    }
  }
  // ----------------------------
  // Team
  // ----------------------------
  &__team {
    display: flex;
    flex-direction: row-reverse;
    justify-content: center;
    align-content: center;
    align-items: center;
    border-radius: 0.25rem;
    transition: all 0.1s ease-in-out;
    color: var(--light-grey);
    border: 1px solid transparent;
    width: 50%;
    border-radius: $borderradius;
    svg { 
      &#trophy {
        fill: gold !important;
      }
    }
    
    &.clickable {
      &:hover {
        color: var(--orange) !important;
        border: 1px solid var(--orange);
        svg {
          fill: var(--orange);
        }
      }
    }
    @media (min-width: $breakpoint-xs) {
      flex-direction: column-reverse;
    }
    
    @media (min-width: $breakpoint-sm) {
      flex-direction: column-reverse;
    }
  }
  // ----------------------------
  // Player
  // ----------------------------
  &__player {
    font-size: 0.85rem;
    display: flex;
    margin-top: 0.5em;
    align-items: center;
    @media (max-width: $breakpoint-xs) {
      margin-top: 0;
    }
    
    @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
      display: flex;
      flex-direction: column;
      
      .tournament-bracket__playertxt {
        margin-top: 0.2em;
      }
    }
  }
  &__content {
    display: flex;
    &::after {
      content: ':';
      width: 1em;
      text-align: center;
      align-self: center;
      justify-self: center;
      position: absolute;
      left: 50%;
      transform: translateX(-50%);
      padding: 0.2em 0.1em;
      color: white;
      @media (min-width: $breakpoint-sm) {
        order: 1;
      }
    }
    
    &.tournament-bracket__team:first-child {
      width: 50%;
      order: 0;
      text-align: right;
      
      @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
        align-items: flex-end;
      }
      
      &.tournament-bracket__player {
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
      
      &.tournament-bracket__winner {
        order: 0;
        
        @media (min-width: $breakpoint-xs) {
          order: 2;
        }
      }
    }
    
    &.tournament-bracket__team:last-child {
      width: 50%;
      order: 2;
      text-align: left;
      
      @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
        align-items: flex-start;
      }
      
      &.tournament-bracket__player {
        @media (min-width: $breakpoint-sm) {
          justify-content: flex-start;
        }
        
        @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
          align-items: flex-start;
        }
      }
      
      .tournament-bracket__playertxt {
        order: 1;
      }
    }
  }
  &__playertxt {
    padding: 0 0.5em;
    font-weight: 600;
    text-transform: uppercase;
    text-decoration: none;
    cursor: help;
    transition: all 0.1s ease-in-out;
    @media (max-width: $breakpoint-xs) {
      padding: 0 0.25em;
    }
    
    @media (min-width: $breakpoint-sm) and (max-width: $breakpoint-md) {
      padding: 0;
    }
  }
  // ----------------------------
  // Win/Loose icon box | 🏅/❌
  // ----------------------------
  &__number {
    display: inline-block;
    padding: 0.2em 0.4em 0.2em;
    border-bottom: 0.075em solid transparent;
    font-size: 0.95rem;
  }
  &__medal {
    padding: 0 0.5em;
    &--gold {
      color: #FFD700;
      fill: #FFD700;
    }
    &--silver {
      color: #C0C0C0;
      fill: #C0C0C0;
    }
    &--bronze {
      color: #CD7F32;
      fill: #CD7F32;
    }
  }
}
</style>
