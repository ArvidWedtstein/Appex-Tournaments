
<template>
    <main class="tournamentcontainer">
        <h1 class="title">Tidligere Turneringer</h1>
        <div v-for="tournament in tournaments.data" :key="tournament" class="tournament beige">
            <div class="cardContainer">
                <div class="tspace">
                    <p>Dato: {{tournament.date}}</p>
                </div>
                <div class="tcontent">
                    <p>{{tournament.name}}</p>
                    
                </div>
                <div class="tfooter">
                    <p>{{tournament.players.length}}    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
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
                    <p>Ant. spillere    //  Status  //  Navn vinner</p>
                </div>
            </div>
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

            this.tournaments = await axios.get('http://localhost:3001/gettournaments')
            console.log(this.tournaments)
        },
        horizontalScroll() {
            const scrollContainer = document.querySelector("main");

            scrollContainer.addEventListener("wheel", (evt) => {
                evt.preventDefault();
                //title.scrollLeft += evt.deltaY;
                scrollContainer.scrollLeft += evt.deltaY;
            });
        }
    },
    mounted() {
        this.fetchTournaments()
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
    }
    
}
.cardContainer{
    position: absolute;
    bottom: 0;
    left: 0;
    padding: 20px;
}

.beige{
    background-color: $orange;
    color: $black;
}
.blue{
    background-color: $blue;
    color: $backclr;
}
.dark{
    background-color: $black;
    color: $orange;
}
</style>
