<template>
  <div class="container w-screen h-screen overflow-hidden">
    <div class="bg-[url('/images/frontpage-grapics.png')] bg-[length:1008px] bg-no-repeat bg-left-bottom h-full absolute w-full sm:bg-[length:800px]">
      <div class="bg-[url('/images/tegn.svg')] bg-[length:1008px] h-full w-2/5 absolute right-0 overflow-hidden z-[-1]"></div>
      <div class="md:container md:my-auto">
        <div class="grid auto-cols-2 justify-items-start items-center">
          <h1 class="m-2 px-4 mt-40 py-10 text-4xl row-span-3">Velkommen til Appex Tournaments!</h1>
          <div class="m-2 px-4 flex flex-row gap-1">
            <nuxt-link to="/newtournament" class="bg-appexblue text-white rounded py-4 px-8 text-center hover:bg-white border border-transparent font-semibold hover:border-appexblue transition-all duration-100 ease-linear hover:text-appexblue">Lag nytt tournament</nuxt-link>
            <nuxt-link to="/tournaments" class="bg-appexdarkgrey text-white rounded py-4 px-8 text-center hover:bg-white border border-transparent font-semibold hover:border-appexdarkgrey transition-all duration-100 ease-linear hover:text-appexdarkgrey">Se tidligere tournaments</nuxt-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<script>
import axios from 'axios'
export default {
    name: "TournamentsHome",
    data() {
      return {
      }
    },

    async asyncData({ $config }) {
      console.log($config.axios)
    }
}
</script>




<style lang="scss">
$backclr: #edebe9;

// body, html {
//   overflow: hidden !important;
// }



</style>
