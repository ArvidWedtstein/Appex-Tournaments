
<template>
    <main class="tournamentcontainer"><!--<main v-if="tournaments.data" class="tournamentcontainer">-->
        <h1 class="title">Tidligere Turneringer</h1>
        <button class="button" v-on:click="left()">Left</button>
        <button class="button2" v-on:click="right()">Right</button>
        <!--Edit tournament-->
        <transition name="fade">
            <div class="editTournament" v-if="editTournamentScreen">
                <button class="close" type="button" v-on:click="closeTournament()">X</button>
                <div class="jumbotron">
                    <h1 class="display-4">Edit Tournament</h1>
                    <hr>
                    <p class="lead">Edit</p>
                </div>
                <input class="update" type="text" placeholder="Edit tournament name">
                <input class="update" type="date" placeholder="Edit date">
                <input class="update" type="text" placeholder="Edit players">
                <button class="updatebtn" type="button" placeholder="Edit players">Update</button>
            </div>
        </transition>

        <div v-for="tournament in tournaments" :key="tournament" class="tournament beige">
            <button class="top" v-on:click="editTournament(tournament.name)">Edit</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: {{tournament.date}}</p>
                </div>
                <div class="tcontent">
                    <p>{{tournament.name}}</p>
                    
                </div>
                <div class="tfooter">
                    <p class="players">{{tournament.players.length}}</p>
                    <p v-if="tournament.status" class="status">{{tournament.status}}</p>
                    <p class="winner">{{tournament.players[tournament.players.length -1].name}}</p>
                </div>
             </div>
        </div>
        <div class="tournament beige">
            <button class="top" v-on:click="editTournament()">🖋</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                    
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
             </div>
        </div>
        <div class="tournament blue">
            <button class="top" v-on:click="editTournament()">Edit</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div> 
        </div>
        <div class="tournament dark">
            <button class="top" v-on:click="editTournament()">Edit</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
             </div>
        </div>
        <div class="tournament beige">
            <button class="top" v-on:click="editTournament()">Edit</button>
            <div class="cardContainer"> 
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>  
        </div>
        <div class="tournament blue">
            <div class="cardContainer"> 
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>
        </div>
        <div class="tournament blue">
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
                </div>
            </div> 
        </div>
        <div class="tournament dark">
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>
        </div>
        <div class="tournament beige">
            <div class="cardContainer"> 
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>  
        </div>
        <div class="tournament blue">
            <div class="cardContainer"> 
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>
        </div>
        <div class="tournament dark">
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div> 
        </div>
        <div class="tournament beige">
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: DD:MM:YYYY</p>
                    
                </div>
                <div class="tcontent">
                    <p>Turnering Navn</p>
                </div>
                <div class="tfooter">
                    <p class="players">Ant. spillere</p>
                    <p class="status">Status</p>
                    <p class="winner">Winner</p>
                </div>
            </div>
        </div>
    </main>
</template>

<script >
import env from '~/dotenv.json'
import axios from 'axios'
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
    data() {
        return {
            tournaments: null,
            editTournamentScreen: false
        }
    },
    methods: {
        async fetchTournaments() {
            this.tournaments = []
            const tournamentlist = await axios.get(`${env.BASE_URL}/gettournaments`)
            console.log(tournamentlist.data)
            this.tournaments = tournamentlist.data.tournaments
        },
        horizontalScroll() {
            const scrollContainer = document.querySelector("main");
            if (scrollContainer)  {
                scrollContainer.addEventListener("wheel", (evt) => {
                    evt.preventDefault();
                    scrollContainer.scrollLeft += evt.deltaY;
                });
            }
        },
        updateTournament(tournamentname) {
            axios.post(`${env.BASE_URL}/updatetournament`, {

            })
            console.log(tournaments)
        },
        left() {
            const scrollContainer = document.querySelector("main");
            var x = scrollContainer.getBoundingClientRect().right
            console.log(x)
            //var tournaments = this.tournaments.data.length;
            var tournaments = document.getElementsByClassName("tournament").length;
            
            var step = x / tournaments;
            console.log(step)
            scrollContainer.scrollLeft -= step;
        },
        right() {
            const scrollContainer = document.querySelector("main");
            var x = scrollContainer.getBoundingClientRect().right
            console.log(x)
            //var tournaments = this.tournaments.data.length;
            var tournaments = document.getElementsByClassName("tournament").length;
            console.log(tournaments)
            var step = x / tournaments;
            console.log(step)
            scrollContainer.scrollLeft += step;
        },
        editTournament() {
            this.editTournamentScreen = true;
        },
        closeTournament() {
            this.editTournamentScreen = false;
        }
    },
    mounted() {
        this.horizontalScroll()
        this.fetchTournaments()
    },

}
</script>




<style lang="scss">


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
    height: 60%;
    left: 0;
    padding: 2em 2em;
    margin-top: 160px;
    display: flex;
    flex-direction: row;
    align-items: center;
    flex-wrap: nowrap;
    transition: all 0.5s ease;
    user-select: none;
    
}
.title {
    position: fixed;
    top: 13vh;
    font-size: 40px;
    font-weight: 500;
    text-align: center;
    width: 100vw;
}
.button {
    position: fixed;
    bottom: 13vh;
    left: 0;
    font-size: 40px;
    font-weight: 500;
    text-align: center;
}
.button2 {
    position: fixed;
    bottom: 13vh;
    right: 0;
    font-size: 40px;
    font-weight: 500;
    text-align: center;
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
        position: absolute;
        top: 0;
        right: 0;
        padding: 0.2rem;
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
    padding: 10rem;
    z-index: 2;
    background: rgba(0,0,0,0.9);
    color: #ffffff;
    display: flex;
    flex-direction: column;
    align-content: center;
    justify-content: center;
    .close {
        font-size: 10ch;
        position: absolute;
        top: 0;
        right: 0;
        padding: 3rem;
        &:hover {
            color: #dddddd;
        }
    }
    .update {
        margin: 1rem;
        padding: 0.5rem 1rem;
        width: 50vw;
        flex: 1 1 auto;
        background: $grey;
        color: #000000;
        border: none;
        align-self: center;
        border-bottom: 2px solid $blue;
        border-radius: calc(0.25rem - 1px);
        &::placeholder, &::-moz-placeholder, &:-ms-input-placeholder{
            color: gray;
        }
    }
    .updatebtn {
        width: 20vw;
        padding: 0.5rem 1rem;
        flex: 1 1 auto;
        align-self: center;
        background: $grey;
        color: #000000;
        border: none;
        border-bottom: 2px solid $blue;
        border-radius: calc(0.25rem - 1px);
        transition: all 0.1s ease;
        &:hover {
            border-bottom: 4px solid $blue;
            padding-bottom: calc(8px - 2px);
        }
        &::before {
            content: '';
            width: 100%;
            background: linear-gradient(45deg, #333333, #ff0000);
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
