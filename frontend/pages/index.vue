<template>
  <div class="w-screen h-screen overflow-hidden">
    <div class="bg-[url('/images/frontpage-grapics.png')] bg-[length:1008px]  appexsm:bg-[length:800px] bg-no-repeat absolute bg-left-bottom w-screen h-screen">
      <div class="md:container md:my-auto">
        <div class="grid auto-cols-2 justify-items-start items-center">
          <h1 class="m-2 px-4 mt-40 py-10 text-4xl row-span-3">Velkommen til Appex Tournaments!</h1>
          <div class="m-2 px-4 flex flex-row gap-1">
            <nuxt-link to="/newtournament" class="button button--orange">Lag ny turnering</nuxt-link>
            <nuxt-link to="/tournaments" class="button button--grey">Se tidligere turneringer</nuxt-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<script>
// import axios from 'axios'
import { useTournamentStore } from '~/stores/tournament'
export default {
  name: "TournamentsHome",
  data() {
    return {
      tournaments: useTournamentStore()
    }
  },
}
</script>




<style lang="scss">
::-webkit-scrollbar {
  width: 20px;
}

::-webkit-scrollbar-track {
  background-color: transparent;
}

::-webkit-scrollbar-thumb {
  background-color: #8e8d8b;
  border-radius: 20px;
  border: 6px solid transparent;
  background-clip: content-box;
}

::-webkit-scrollbar-thumb:hover {
  background-color: #5e5e5d;
}
</style>
