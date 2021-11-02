
<template>
    <main class="tournamentcontainer">
        <h1 class="title">Tidligere Turneringer</h1>
        <div v-for="tournament in tournaments" :key="tournament" class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
                <hr class="my-4">
            </div>
            <div class="tcontent">
                <p></p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
    </main>
</template>

<script>

import axios from 'axios';


export default {
    name: "Tournaments",
    data() {
        return {
            tournaments: []
        }
    },
    methods: {
        async fetchTournaments() {

            this.tournaments = await axios.get('/api/gettournaments')
            console.log(this.tournaments)
        },
        horizontalScroll() {
            const scrollContainer = document.querySelector("main");
            const title = document.getElementById("title");

            scrollContainer.addEventListener("wheel", (evt) => {
                evt.preventDefault();
                //title.scrollLeft += evt.deltaY;
                scrollContainer.scrollLeft += evt.deltaY;
            });
        }
    },
    mounted() {
        //this.fetchTournaments()
        this.horizontalScroll()
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

.tournamentcontainer {

    background: $backclr;
    width: 100%;
    height: 100%;
    overflow-y: auto;
    overflow-x: hidden;
    position: absolute;
    left: 0;
    background: url("~/images/nam.PNG");
    background-size: 100%;
    padding: 6em;
    display: flex;
    flex-direction: row;
    align-items: center;
    flex-wrap: nowrap;
    transition: all 0.5s ease;
    user-select: none;
    .title {
        position: fixed;
        top: 0;
        left: 50%;
        transform: translateX(-50%);
    }
}

.tournament {
    flex: 1 1 auto;
    min-height: 1px;
    position: relative;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-orient: vertical;
    -webkit-box-direction: normal;
    -ms-flex-direction: column;
    flex-direction: column;
    align-items: center;
    min-width: 20vw;
    word-wrap: break-word;
    padding: 0rem;
    margin: 0rem 2rem;
    text-align: center;
    //background: $dark-grey;
    background: url("~/images/appexwindmill.PNG");
    background-size: cover;
    background-clip: padding-box;
    background-position: 50%;
    background-repeat: no-repeat;
    color: #fff;
    transition: all 0.5s ease;
    border-radius: 0.25rem;
    &:hover > .bracket{
        transform: none;
        opacity: 1;
        //display: block;
    }
    .theader {
        width: 100%;
        border-radius: calc(0.25rem - 1px) calc(0.25rem - 1px) 0 0;
        font-weight: 800;
        font-size: 2ch;
        padding: 0.75rem 1.25rem;
        margin-bottom: 0;
        border-bottom: 1px solid rgba(0,0,0,.125);
    }
    .tcontent {
        //background: url("~/images/braggets.PNG");
        //clip-path: 0% 20%, 0% 40%, 100% 100%, 50% 0%;
        -webkit-box-flex: 1;
        -ms-flex: 1 1 auto;
        flex: 1 1 auto;
        padding: 1.25rem;
        width: 100%;
        color: #221E20;
    }
    .tfooter {
        width: 100%;
        border-radius: 0 0 calc(.25rem - 1px) calc(.25rem - 1px);
        font-weight: 400;
        font-size: 2ch;
        //background: rgba(0,0,0,0.8);
        padding: 0.75rem 1.25rem;
        border-top: 1px solid rgba(0,0,0,.125);
    }
    .bracket {
        //display: none;
        transition: all 0.1s ease;
        opacity: 0;
        position: absolute;
        color: $dark-grey;
        font-size: 260px;
        &:first-child {
            text-shadow: 10px 0px 10px $blue;
            transform: rotateZ(90deg);
            bottom: -15%;
        }
        &:last-child {
            text-shadow: -10px 0px 10px $blue;
            transform: rotateZ(90deg);
            top: -15%;
        }
    }
}
.shadow {
  -moz-box-shadow:    3px 3px 5px 6px #ccc;
  -webkit-box-shadow: 3px 3px 5px 6px #ccc;
  box-shadow:         3px 3px 5px 6px #ccc;
}
</style>
