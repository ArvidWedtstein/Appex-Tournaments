
<template>
    <div class="tournamentcontainer">
        <h1 class="title">Tidligere Turneringer</h1>
        <div class="tournament shadow">
            <h1 class="bracket">{</h1>
            <div class="theader">
                <p>Turnering</p>
            </div>
            <div class="tcontent">
                <p>Turnering</p>
            </div>
            <div class="tfooter">
                <p>Forrige Vinner: </p>
            </div>
            <h1 class="bracket">}</h1>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
        <div class="tournament shadow">
            <p>Biljard</p>
        </div>
    </div>
</template>

<script>

export default {
    name: "Tournaments",
    data() {
      return {
        
      }
    },
    methods: {
        
        
    }
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
    position: absolute;
    background: url("~/Assets/images/nam.PNG");
    background-size: 100%;
    padding: 6em;
    display: flex;
    flex-direction: row;
    align-items: center;
    flex-wrap: nowrap;
    .title {
        position: absolute;
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
    min-width: 0;
    word-wrap: break-word;
    padding: 0rem;
    margin: 0.2rem;
    text-align: center;
    background: $dark-grey;
    color: #fff;
    transition: all 0.5s;
    border-radius: 0.25rem;
    //transform: rotate3d(1,-2,1,30deg);
    &:hover {
        transform: none;
    }
    .theader {
        width: 100%;
        border-radius: calc(0.25rem - 1px) calc(0.25rem - 1px) 0 0;
        font-weight: 800;
        font-size: 2ch;
        padding: 0.75rem 1.25rem;
        margin-bottom: 0;
        border-bottom: 1px solid rgba(0,0,0,.125);
        background: rgba(0,0,0,0.8);
    }
    .tcontent {
        //background: url("~/Assets/images/braggets.PNG");
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
        position: absolute;
        color: $orange;
        font-size: 260px;
        &:first-child {
            transform: rotateZ(90deg);
            bottom: -15%;
        }
        &:last-child {
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
