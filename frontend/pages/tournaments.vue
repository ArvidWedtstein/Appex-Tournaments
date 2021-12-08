
<template>
    <main class="tournamentcontainer"><!--<main v-if="tournaments.data" class="tournamentcontainer">-->
        <h1 class="title">Tidligere Turneringer</h1>
        <button class="dirbuttons left bottom" @click="left()">
            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-left" class="svg-inline--fa fa-arrow-circle-left fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                <path fill="currentColor" d="M256 504C119 504 8 393 8 256S119 8 256 8s248 111 248 248-111 248-248 248zm28.9-143.6L209.4 288H392c13.3 0 24-10.7 24-24v-16c0-13.3-10.7-24-24-24H209.4l75.5-72.4c9.7-9.3 9.9-24.8.4-34.3l-11-10.9c-9.4-9.4-24.6-9.4-33.9 0L107.7 239c-9.4 9.4-9.4 24.6 0 33.9l132.7 132.7c9.4 9.4 24.6 9.4 33.9 0l11-10.9c9.5-9.5 9.3-25-.4-34.3z"></path>
            </svg>
        </button>
        <button class="dirbuttons right bottom" @click="right()">
            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-right" class="svg-inline--fa fa-arrow-circle-right fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                <path fill="currentColor" d="M256 8c137 0 248 111 248 248S393 504 256 504 8 393 8 256 119 8 256 8zm-28.9 143.6l75.5 72.4H120c-13.3 0-24 10.7-24 24v16c0 13.3 10.7 24 24 24h182.6l-75.5 72.4c-9.7 9.3-9.9 24.8-.4 34.3l11 10.9c9.4 9.4 24.6 9.4 33.9 0L404.3 273c9.4-9.4 9.4-24.6 0-33.9L271.6 106.3c-9.4-9.4-24.6-9.4-33.9 0l-11 10.9c-9.5 9.6-9.3 25.1.4 34.4z"></path>
            </svg>
        </button>
        <button class="dirbuttons left top" @click="$router.go(-1)">
            <svg aria-hidden="true" focusable="false" data-prefix="fas" data-icon="arrow-circle-left" class="svg-inline--fa fa-arrow-circle-left fa-w-16" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
                <path fill="currentColor" d="M256 504C119 504 8 393 8 256S119 8 256 8s248 111 248 248-111 248-248 248zm28.9-143.6L209.4 288H392c13.3 0 24-10.7 24-24v-16c0-13.3-10.7-24-24-24H209.4l75.5-72.4c9.7-9.3 9.9-24.8.4-34.3l-11-10.9c-9.4-9.4-24.6-9.4-33.9 0L107.7 239c-9.4 9.4-9.4 24.6 0 33.9l132.7 132.7c9.4 9.4 24.6 9.4 33.9 0l11-10.9c9.5-9.5 9.3-25-.4-34.3z"></path>
            </svg>
        </button>
        <!--Edit tournament-->
        <transition name="fade">
            <div class="editTournament" v-if="editTournamentScreen">
                <button class="close" type="button" v-on:click="closeTournament()">✖</button>
                <div class="headerContainer">
                    <h1>Rediger Tournament</h1>
                    <p>{{editTournamentData.Name}}</p>
                </div>
                <div class="inputBox">
                    <h1>Navn:</h1>  
                    <input v-model="editTournamentChanges.name" class="update" type="text" placeholder="Tournament navn">
                </div>
                <div class="inputBox">
                    <h1>Dato:</h1> 
                    <input v-model="editTournamentChanges.date" class="update" type="date">
                </div>
                <div class="inputBox">
                    <h1>Status:</h1>
                    <input v-model="editTournamentChanges.status" class="update" type="radio" name="status" id="Fremtidig" value="Fremtidig" :checked="editTournamentData.status == 'Fremtidig'">
                    <label for="Fremtidig">Fremtidig</label>
                    <input v-model="editTournamentChanges.status" class="update" type="radio" name="status" id="Påbegynt" value="Påbegynt" :checked="editTournamentData.status == 'Påbegynt'">
                    <label for="Påbegynt">Påbegynt</label>
                    <input v-model="editTournamentChanges.status" class="update" type="radio" name="status" id="Gjennomført" value="Gjennomført" :checked="editTournamentData.status == 'Gjennomført'">
                    <label for="Gjennomført">Gjennomført</label>
                </div>
                <div class="inputContainer buttons">
                    <button class="deltakerbtn" type="button">Rediger Deltakere</button>
                    <button class="updatebtn" type="button" @click="updateTournament()">Update</button>
                    <button class="deletebtn" type="button" @click="deleteTournament(editTournamentData._id)" >Delete</button>
                </div>
            </div>
        </transition>
        <transition name="fade">
            <div class="editTournament" v-if="showTournamentScreen">
                <button class="close" type="button" v-on:click="closeTournament()">✖</button>
                <div class="headerContainer">
                    <h6>{{showTournamentData.Name}}</h6>
                </div>
                <div class="inputBox">
                    <div class="bracket">
                        <div class="round" v-for="round in showTournamentData.rounds" :key="round">
                            <div class="match" v-for="match in round" :key="match">
                                <div class="match__content">{{match.id}}</div>
                                <div class="matchplayer" v-for="player in match.players" :key="player">
                                    <button class="player" v-cloak v-bind:class="{ 'winner': match.winner == player }">{{ player }}</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <Tournamentoverview :tournamentprop="showTournamentData"></Tournamentoverview>
                </div>
                <div class="inputContainer buttons">
                    <a class="deltakerbtn" :href="'/tournament?id=' + showTournamentData.id" type="button">Fortsett turnering</a>
                    <button class="deltakerbtn" v-if="showTournamentData.status == 'Fremtidig'" type="button">Begynn turnering</button>
                </div>
            </div>
        </transition>

        <div v-for="(tournament, i) in tournaments" :key="tournament" :id="'tournament' + i" class="tournament">
            <button class="top" v-on:click="editTournament(tournament)" v-cloak>✎</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: {{formatDate(tournament.date)}}</p>
                </div>
                <div class="tcontent" v-on:click="showTournament(tournament)">
                    <p>{{tournament.Name}}</p>
                </div>
                <div class="tfooter">
                    <!--<p class="players">{{tournament.players.length}}</p>-->
                    <p v-if="tournament.status" class="status">{{tournament.status}}</p>
                    <!--<p class="winner">{{tournament.players[tournament.players.length -1].name}}</p>-->
                </div>
             </div>
        </div>
    </main>
</template>

<script>
import env from '~/dotenv.json'
import axios from 'axios'
import Tournamentoverview from '~~/components/tournamentoverview.vue'
export default {
    name: "Tournaments",
    /*async asyncData() {
        console.log('sus')
        const tournamentasync = await axios.get(`${env.BASE_URL}/gettournaments`)
        console.log(tournamentasync)
        this.horizontalScroll()
        return {
            tournamentasync
        }
    },*/
    async asyncData({ $axios, $config }) {
      console.log($config)
    
    },
    data() {
        return {
            tournaments: null,
            editTournamentScreen: false,
            showTournamentScreen: false,
            editTournamentData: null,
            showTournamentData: null,
            editTournamentChanges: {
                name: "",
                date: "",
                players: [],
                status: ""
            },
            infoBar: {
                show: false,
                message: "",
                color: "#ff0000"
            }
        };
    },
    methods: {
        async fetchTournaments() {
            this.tournaments = [];
            const tournamentlist = await axios.get(`${env.BASE_URL}/get-tournament`);
            console.log(tournamentlist);
            this.tournaments = tournamentlist.data;
        },
        horizontalScroll() {
            const scrollContainer = document.querySelector("main");
            if (scrollContainer) {
                scrollContainer.addEventListener("wheel", (evt) => {
                    evt.preventDefault();
                    scrollContainer.scrollLeft += evt.deltaY;
                });
            }
        },
        formatDate(date) {
            const options = { year: "numeric", month: "numeric", day: "2-digit" };
            return new Date(date).toLocaleDateString("no", options);
        },
        updateTournament() {
            axios.post(`${env.BASE_URL}/updateTournament`, {
                id: this.editTournamentData._id,
                name: this.editTournamentChanges.name,
                date: this.editTournamentChanges.date,
                status: this.editTournamentChanges.status
            }).then((res) => {
                this.editTournamentScreen = false;
                console.log(res);
                this.infoBar.show = true;
                this.infoBar.message = "test";
                this.editTournamentChanges.name = "";
                this.editTournamentChanges.date = "";
                this.editTournamentChanges.status = "";
                this.editTournamentChanges.players = [];
                this.editTournamentData = null;
                this.$nuxt.refresh();
            });
        },
        left() {
            const scrollContainer = document.querySelector("main");
            var x = window.innerWidth;
            var tournaments = document.getElementsByClassName("tournament").length;
            for (let i = 0; i < 8; i++) {
                var step = (x / tournaments) * -2;
                scrollContainer.scrollLeft += step;
                console.log(i);
                setTimeout(1000);
            }
        },
        right() {
            const scrollContainer = document.querySelector("main");
            var x = window.innerWidth;
            var tournaments = document.getElementsByClassName("tournament").length;
            var step = (x / tournaments) * 16;
            scrollContainer.scrollLeft += step;
        },
        async editTournament(tournament) {
            console.log(tournament);
            this.editTournamentData = await tournament;
            this.editTournamentScreen = true;
        },
        async showTournament(tournament) {
            this.showTournamentData = await tournament;
            this.showTournamentScreen = true;
            console.log(this.showTournamentData);
        },
        closeTournament() {
            this.editTournamentScreen = false;
            this.showTournamentScreen = false;
            this.editTournamentChanges.name = "";
            this.editTournamentChanges.date = "";
            this.editTournamentChanges.status = "";
            this.editTournamentChanges.players = [];
            this.editTournamentData = null;
            this.showTournamentData = null;
        },
        deleteTournament(tournamentId) {
            axios.post(`${env.BASE_URL}/deletetournament`, {
                id: tournamentId
            });
            console.log(tournaments);
        }
    },
    mounted() {
        this.horizontalScroll();
        this.fetchTournaments();
    },
    components: { Tournamentoverview }
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
template{
    overflow: hidden;
}
.tournamentcontainer {
    overflow-x: hidden;
    position: relative;
    width: 100%;
    height: 100vh;
    left: 0;
    padding: 2em 2em;
    padding-top: 75px;
    display: flex;
    flex-direction: row;
    align-items: center;
    flex-wrap: nowrap;
    transition: all 0.5s ease;
    user-select: none;
    
}
.title {
    position: fixed;
    top: 11vh;
    font-size: 40px;
    font-weight: 500;
    text-align: center;
    width: 100vw;
}
.dirbuttons {
    position: fixed;
    width: 50px;
    margin: 2rem 4rem;
    &.left {
        img {
            transform: rotate(180deg);
        }
        left: 0;
    }
    &.right {
        right: 0;
    }
    &.top {
        top: 6ch;
    }
    &.bottom {
        bottom: 0;
    }
    &:hover, &:focus {
        svg {
            color: $dark-grey;
        }
        
    }
}
.tournament {
    flex: 1 1 auto;
    min-height: 300px;
    max-height: 300px;
    position: relative;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-orient: vertical;
    -webkit-box-direction: normal;
    -ms-flex-direction: column;
    flex-direction: column;
    min-width: 300px;
    word-wrap: break-word;
    padding: 0rem;
    margin: 0rem 2rem;
    transition: all 0.5s ease;
    .top {
        transform: rotate(90deg);
        position: absolute;
        top:10px;
        right: 10px;
        width: 24px;
        text-align: center;
    }
    .cardContainer{
        position: absolute;
        bottom: 0;
        left: 0;
        padding: 20px;
    }
    .tspace {
        width: 100%;
        font-weight: 500;
        font-size: 12px;
        padding-bottom: 0;
        margin-bottom: 0;
        min-height: 100%;
        overflow: auto;
        
    }
    .tcontent {
        -webkit-box-flex: 1;
        -ms-flex: 1 1 auto;
        flex: 1 1 auto;
        width: 100%;
        max-height: 32.67px;
        font-size: 22px;
        font-weight: 600;
    }
    .tfooter {
        width: 100%;
        font-weight: 500;
        font-size: 12px;
        padding-top: 5px;
        display: flex;
        flex-direction: row;
        & > *:not(:last-child) {
            flex: 1 1 auto;
            &::after {
                content: '//';
                padding: 0 1rem;
            }
        }
    }
    &:nth-child(3n) {
        background-color: $orange;
        color: $black;
    }
    &:nth-child(3n - 1) {
        background-color: $blue;
        color: $backclr;
    }
    &:nth-child(3n - 2) {
        background-color: $black;
        color: $orange;
    }
}



.editTournament {
    position: fixed;
    width: 100vw;
    bottom: 0;
    top: 0;
    left: 0;
    padding: 20vh 20% 0;
    padding-top: 3rem;
    z-index: 2;
    background: rgb(237,236,233);
    color: $black;
    display: flex;
    flex-direction: column;
    align-content: center;
    justify-content: center;
    .close {
        font-size: 4vw;
        position: absolute;
        top: 0;
        right: 0;
        padding: 3rem;
        &:hover {
            color: rgba(0,0,0,0.7);
        }
    }
    .headerContainer{
        text-align: center;
        flex: 1 1 auto;
        h1 {
            font-size: 4vw;
        }
        p {
            font-size: 2vw;
        }
    }
    
    .update {
        //width: 400px;
        //height: 50px;
        flex: 1 1 auto;
        align-self: center;
        background: $grey;
        color: #000000;
        border: none;
        border-bottom: 2px solid $blue;
        border-radius: calc(0.25rem - 1px);
        &::placeholder, &::-moz-placeholder, &:-ms-input-placeholder{
            color: gray;
        }
    }/*
    .deltakerbtn, .updatebtn {
        background: $orange;
        color: #000000;
        border: none;
        transition: all 0.1s ease;
        &:hover {
            transform: translateY(-2.5px);
        }
        &:active {
            transform: translate(0px, 2.5px);
            -webkit-transform: translate(0px, 5px);
            box-shadow: 0px 1px 0px 0px;
        }  
    }
    .deltakerbtn >{
            background-color: $blue;
    }
    .deletebtn {
        position: absolute;
        right: 45px;
        //bottom: 45px;
        //padding: 0.5rem 1rem;
        //margin: 0 1rem;
        flex: 1 1 auto;
        align-self: center;
        background: #C0392B;
        color: white;
        border: none;
        border-bottom: 2px solid white;
        border-radius: calc(0.25rem - 1px);
        transition: all 0.1s ease;
        text-align: center;
        &:hover {
            border-bottom: 4px solid red;
            background: red;
            padding-bottom: calc(8px - 2px);
            padding: 20px 60px;
        }
        &:active {
            transform: translate(0px, 5px);
            -webkit-transform: translate(0px, 5px);
            box-shadow: 0px 1px 0px 0px;
        }    

    }*/ 
    .inputContainer{
        display: flex;
        flex-direction: row;
        flex: 1 1 auto;
        align-items: center;
        align-content: center;
        margin: 0 -1rem;
        &.buttons >*{
            padding: 1rem;
            margin: 1rem;
            flex: 1 1 auto;
            background: $orange;
            color: #000000;
            border: none;
            transition: all 0.1s ease;
            width: 50%;
            &:hover {
                transform: translateY(-2.5px);
            }
            &:active {
                transform: translate(0px, 2.5px);
                -webkit-transform: translate(0px, 5px);
                box-shadow: 0px 1px 0px 0px;
            }

            
        }
        .updatebtn{
            background-color: $blue;
            color: #fff;
        }
        .deletebtn{
            width: auto;
            position: absolute;
            right: 45px;
            flex: 1 1 auto;
            align-self: center;
            background: #C0392B;
            color: white;
            border: none;
            transition: all 0.1s ease;
            text-align: center;
            &:hover {
                background: red;
            }
        }
        p{
            position: absolute;
            left: 6rem;
        }


    }

    .inputBox {
        flex: 1 1 auto;
        padding: 0.2rem;
        
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
.fade-enter-active, .fade-leave-active {
  transition: all .5s ease-in-out;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
