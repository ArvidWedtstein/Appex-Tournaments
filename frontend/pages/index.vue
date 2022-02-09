<template>
  <div class="container w-screen h-screen overflow-hidden">
    <div class="bg-[url('/images/frontpage-grapics.png')] bg-[length:1008px]  appexsm:bg-[length:800px] bg-no-repeat absolute bg-left-bottom w-screen h-screen">
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
.rgbline {
  background: linear-gradient(90deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
    background-size: auto;
  height: 1px;
  border: 0;
  background-size: 200% 200%;
  box-shadow: 0px 1px 10px #23d5ab;
}

.expandline {
  animation: expandline 2s linear;
}
@keyframes expandline {
	0% {
		width: 1%;
	}
	100% {
		width: 100%;
	}
}
</style>
