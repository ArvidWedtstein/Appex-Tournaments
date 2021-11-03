<template>
   <div id='newtournament'>
      <form>
        <div class="inputBox">
          <h2>Skriv inn navnet på tournamentet</h2>
          <input v-model="tournamentName" type="text" id="tname" name="tname" placeholder="Tournament navn" maxlength = "69">
          <span class="limiter">{{ 69 - tournamentName.length }} characters remaining</span>
        </div>
        <div class="inputBox">
          <h3>Tournament dato</h3>
          <input type="date" id="tdate" name="tdate" placeholder="Dato">
        </div>
        <div class="inputBox">
          <h3>Antall deltakere</h3>
          <input type="range" min="2" max="69" id="players" v-model.number="playerInt">
          <span class="limit">{{playerInt}}</span>
        </div>
        <div class="pagebtn">
          <button class="past" v-on:click="pageSwitch('past')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+left+chevron+chevronleft+left+left+icon+icon-1320185731545502691.png" width="50px"></button>
          <button class="next" v-on:click="pageSwitch('next')"><img src="https://icons-for-free.com/iconfiles/png/512/arrow+right+chevron+chevronright+right+right+icon+icon-1320185732203239715.png" width="50px"/></button>
        </div>
      </form>
   </div>
</template>

<script>
export default {
   template: 'newtournament',
   transition: 'slide-bottom'
}
</script>