<template>
  <div id='newtournament' class="bg-appexbackclr h-screen">
    <div v-if="page === 0" class="page flex justify-center content-center items-center relative flex-col w-full max-h-full h-full">
      <div class="pg2-content-container w-full h-4/5 p-16 items-center">
        <div class="inputBox py-20 my-20">
          <h1>Skriv inn navnet på tournamentet</h1>
          <input v-model="tournament.name" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69" required>
          <span class="limiter">{{ 69 - tournament.name.length }} characters remaining</span>
        </div>
        <div class="inputBox py-20 my-20">
          <h1 class="text-xl">Tournament dato</h1>
          <input class="relative flex-auto bg-transparent text-left align-middle outline-0 w-full border-0 decoration-[#00000080] pb-2 text-base " v-model="tournament.date" type="date" id="tdate" name="tdate" placeholder="Dato" required>
        </div>
        <button class="fixed w-12 m-16 right-0 bottom-0" @click="increasePage()">
          <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-right" class="svg-inline--fa fa-arrow-circle-right fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
            <path fill="currentColor" d="M256 8c137 0 248 111 248 248S393 504 256 504 8 393 8 256 119 8 256 8zm-28.9 143.6l75.5 72.4H120c-13.3 0-24 10.7-24 24v16c0 13.3 10.7 24 24 24h182.6l-75.5 72.4c-9.7 9.3-9.9 24.8-.4 34.3l11 10.9c9.4 9.4 24.6 9.4 33.9 0L404.3 273c9.4-9.4 9.4-24.6 0-33.9L271.6 106.3c-9.4-9.4-24.6-9.4-33.9 0l-11 10.9c-9.5 9.6-9.3 25.1.4 34.4z"></path>
          </svg>
        </button>
      </div>
    </div>
    <div v-if="page === 1" class="flex content-center justify-center items-center relative flex-col w-100 h-100 overflow-y-visible">
      <div class="text-center relative w-100 mx-auto min-h-10 my-16">
        <h1 class="text-3xl text-center w-100">"{{ tournament.name }}" Deltakere</h1>
        <p class="text-2md text-center">Rediger deltakere</p>
      </div>
      <div class="relative min-h-max w-24 my-16">
        <div class="text-center font-semibold">
          <h1 class="text-appexblue text-4lg w-100">{{ players.length }}</h1>
          <p class="text-center w-100">Deltakere</p>
        </div>
        <div class="text-2xl font-semibold flex items-center my-16">
          <button class="absolute text-4xl left-0 bottom-0" @click="removePlayer()">-</button>
          <button class="absolute text-4xl right-0 bottom-0" @click="addPlayer()">+</button>
        </div>
      </div>
      <div class="deltakere overflow-y-visible" v-for="i in Math.ceil(players.length / 8)" :key="i">
        <div v-for="(name, index) in players" :key="index" class="deltakere">
          <div class="flex">
            <input class="p-3 border-b-2 border-solid border-appexblue bg-appexgrey" v-model="players[(i) * index]" type="text" v-bind:placeholder= "'Deltaker' + index * (i)">
          </div>
        </div>
      </div>  
      <button class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" @click="newTournament()" type="button">Ny Turnering</button>
    </div>

    <div v-if="page === 2" class="page flex justify-center content-center relative flex-col w-full max-h-full h-full">
      <h1 class="font-14">Oppsett:</h1>
      <Tournamentoverview :tournamentprop="previewturnering"></Tournamentoverview>
      <br>
      <NuxtLink class="bg-appexblue hover:bg-white text-white font-semibold hover:text-appexblue m-1 py-4 px-8 border border-transparent hover:border-appexblue rounded transition-all duration-300 ease-linear" :to="'/tournament/' + turnering.id">Begynn turnering</NuxtLink>
      <NuxtLink class="bg-appexblack hover:bg-appexorange text-appexorange font-semibold hover:text-black m-1 py-4 px-8 border border-transparent hover:border-black rounded transition-all duration-300 ease-linear" to="/">Utsett turnering</NuxtLink>
    </div>
  </div>
</template>


<script>
let intPlayer = 1;
import axios from 'axios';
//import env from '~/dotenv.json'
import tournamentoverview from '~~/components/tournamentoverview.vue';
export default {
   template: 'newtournament',
   transition: 'slide-bottom',
   components: { tournamentoverview },
   data() {
      return {
        page: 0,
        tournament: {
          name: '',
          date: ''
        },
        players: [""],
        matches: [],
        turnering: {},
        previewturnering: {}
      }
    },
    methods: {
      async newTournament() {
        axios({
          method: 'POST',
          url: `${this.$config.baseURL}/createTournament?tournamentName=${this.tournament.name}&tournamentDate=${this.tournament.date}`,
          data: this.players
        }).then(async (response) => {
          
          console.log(response.data);
          this.matches = response.data.rounds;
          this.turnering = response.data;
          axios({
            method: 'POST',
            url: `${this.$config.baseURL}/previewmatch?id=${response.data.id}`
          }).then(async (res) => {
            console.log(res.data)
            this.previewturnering = res.data;
          })
          
        })
        this.increasePage()
      },
      addPlayer() { 
        if (intPlayer < 32){
        const adj = ["Gretten", "Glad", "Fjern", "Smart", "God", "Vakker", "Snill", "Første", "Rask", "Kreativ", "Lys", "Mandig", "Treig", "Smart"];
        const noun = ["gris", "data", "gnager","mann", "kvinne", "Franskmann", "Amerikaner","Tysker","Nordmann", "script"];
        for(let i = 0; i < intPlayer; i++) {
          let playername = adj[Math.floor(Math.random()*adj.length)] + " " + noun[Math.floor(Math.random()*noun.length)];
          this.players.push(playername)
        }
        intPlayer = (intPlayer * 2);
      }},
      removePlayer(index) {
        if(intPlayer > 1){
          console.log(intPlayer)
          var playerDevide = (intPlayer / 2)
          for (var i = 0; i < playerDevide; i++){
            this.players.splice(index, 1);
            intPlayer = this.players.length;
          }
        }
      },
      increasePage() {
        if (this.page == 2) return
        const regex = /[^A-Za-z0-9]+/
        /*if (!regex.test(this.tournament.name)) {
          return alert('Name cannot contain invalid characters (only letters and numbers)')
        }*/
        if (this.tournament.name && this.tournament.date) {
          this.page += 1;
        } else {
          alert('Name and/or date cannot be empty')
        }
      },
      decreasePage() {
        if (this.page == 0) return
        this.page -= 1;
      }
    },
    mounted() {

    }
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

.page {
  /*display: flex;
  justify-content: center;
  align-content: center;
  align-items: center;
  position: relative;
  flex-direction: column;
  width: 100%;
  max-height: 100%;
  height: 100%;*/
  .headerContainer{/*
    text-align: center;
    position: absolute;
    top: 2vh;
    left: 50%;
    transform: translateX(-50%);
    min-height: 10vh;
    h1{
        font-size: 4vw;
    }
    p{
        font-size: 2vw;
    }*/
  }
  .playerAddContainer {
    position: absolute;
    top: 2vh;
    right: 128px;
    height: 140px;
    width: 100px;
  }
  .btnContainer {
    font-size: 3rem;
    font-weight: 400;
    display: flex;
    align-items: center;
    .plusBtn {
      position: absolute;
      right: 0;
      bottom: 0;
    }
    .minusBtn {
      position: absolute;
      left: 0;
      bottom: 0;
    }
  }
  .countContainer {
    .playerCount{
      color: $blue;
      font-size: 2.5rem;
      font-weight: 400;
      width: 100%;
      text-align: center;
    }
    p{
      width: 100%;
      text-align: center;
      font-weight: 400;
    }
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
  .inputBox {
    padding: 0.2rem;
    &.padding {
      margin: 4vw 0;
      padding: 5rem 0;
    }
    &.border {
      display: flex;
      flex: 1 1 auto;
      align-content: center;
      align-items: center;
      padding: 8rem 8rem !important;
      background: $dark-grey;
      border-radius: 0.5rem;
      @include rad-shadow;
    }
    h1{
      font-size: 20px;
      font-weight: 600;
    }
    input {
      position: relative;
      flex: 1 1 auto;
      background: transparent;
      text-align: left;
      vertical-align: middle;
      outline: none;
      width: 100%;
      border: none;
      color: $inputcolor;
      padding-bottom: 10px;
      font-size: 1rem;
      letter-spacing: 1px;
      transition: all 0.3s ease;
      border-bottom: 2px solid $inputcolor;
      
      &:focus {
        color: $inputhovercolor;
        border-bottom: 2px solid $inputhovercolor;
      }
      &:-webkit-autofill,
      &:-webkit-autofill:hover, 
      &:-webkit-autofill:focus, 
      &:-webkit-autofill:active  {
          -webkit-text-fill-color: black;
        -webkit-box-shadow: 0 0 0px 1000px #000 inset;
        box-shadow: 0 0 0px 1000px #000 inset;
        transition: background-color 5000s ease-in-out 0s;
      }
    }
  }
  
}
</style>
