
<template>
    <main class="tournamentcontainer"><!--<main v-if="tournaments.data" class="tournamentcontainer">-->
        <h1 class="title">Tidligere Turneringer</h1>
        <button class="button" v-on:click="left()"><img src="../static/images/arrowBlue.png"></button>
        <button class="button2" v-on:click="right()"><img src="../static/images/arrowBlue.png"></button>
        <!--Edit tournament-->
        <transition name="fade">
            <div class="editTournament" v-if="editTournamentScreen">
                <button class="close" type="button" v-on:click="closeTournament()">✖</button>
                <div class="headerContainer">
                    <h1>Edit Tournament</h1>
                    <p>"Tournament Navn"</p>
                </div>
                <div class="inputBox">
                <h1>Navn:</h1>  
                <input class="update" type="text" placeholder="Tournament navn">
                </div>
                <div class="inputBox">
                <h1>Dato:</h1> 
                <input class="update" type="date">
                </div>
                <div class="inputBox">
                <h1>Status:</h1>
                <input class="update" type="text" placeholder="Tournament status">
                </div>
                <!--<div class="inputContainer">
                <p>Dato:</p> 
                <input class="update" type="date"></div>
                <div class="inputContainer">
                <p>Status:</p>
                <input class="update" type="text"></div>-->
                <div class="inputContainer buttons">
                <button class="deltakerbtn" type="button">Rediger Deltakere</button>
                <button class="updatebtn" type="button" >Update</button>
                <button class="deletebtn" type="button" onclick="deleteTournament()" >Delete</button>
                </div>
            </div>
        </transition>

        <div v-for="(tournament, i) in tournaments" :key="tournament" :id="'tournament' + i" class="tournament">
            <button class="top" v-on:click="editTournament(tournament.name)">✎</button>
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: {{formatDate(tournament.date)}}</p>
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
        formatDate(date) {
            const options = { year: 'numeric', month: 'numeric', day: '2-digit' }
            return new Date(date).toLocaleDateString('no', options)
        },
        updateTournament(tournamentname) {
            axios.post(`${env.BASE_URL}/updatetournament`, {

            })
            console.log(tournaments)
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
        editTournament() {
            this.editTournamentScreen = true;
        },
        closeTournament() {
            this.editTournamentScreen = false;
        },
        deleteTournament(){
            
        }
    },
    mounted() {
        this.horizontalScroll()
        this.fetchTournaments()
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
.button {
    transform: rotate(180deg);

    position: fixed;
    bottom: 0;
    left: 0;
    width: 50px;
    margin: 2rem 4rem;
}
.button2 {
    position: fixed;
    bottom: 0;
    right: 0;
    width: 50px;
    margin: 2rem 4rem;

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
        h1{
            font-size: 4vw;
        }
        p{
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
