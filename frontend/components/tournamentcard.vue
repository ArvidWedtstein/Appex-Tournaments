<template>
  <div class="tournament">
    <!-- Optional image
    <figure class="tournamentimg">
      <img src="/images/nam.PNG" width="290" alt="beer">
    </figure> -->
    <div class="absolute bottom-0 left-0 m-3">
      <div class="w-25 text-md pb-4 min-h-100 overflow-auto font-light">
        <p>Dato: {{ formatDate(tournament.date) }}</p>
      </div>
      <div class="flex-auto w-25 max-h-8 text-xl font-semibold">
        <p class="">{{ tournament.Name }}</p>
      </div>
      <div class="tfooter">
        <p>
          {{ countPlayers(tournament) }}
          <svg aria-hidden="true" focusable="false" data-prefix="fas" width="20" data-icon="users" class="svg-inline--fa fa-users fa-w-1 inline" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 512">
            <path fill="currentColor" d="M96 224c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm448 0c35.3 0 64-28.7 64-64s-28.7-64-64-64-64 28.7-64 64 28.7 64 64 64zm32 32h-64c-17.6 0-33.5 7.1-45.1 18.6 40.3 22.1 68.9 62 75.1 109.4h66c17.7 0 32-14.3 32-32v-32c0-35.3-28.7-64-64-64zm-256 0c61.9 0 112-50.1 112-112S381.9 32 320 32 208 82.1 208 144s50.1 112 112 112zm76.8 32h-8.3c-20.8 10-43.9 16-68.5 16s-47.6-6-68.5-16h-8.3C179.6 288 128 339.6 128 403.2V432c0 26.5 21.5 48 48 48h288c26.5 0 48-21.5 48-48v-28.8c0-63.6-51.6-115.2-115.2-115.2zm-223.7-13.4C161.5 263.1 145.6 256 128 256H64c-35.3 0-64 28.7-64 64v32c0 17.7 14.3 32 32 32h65.9c6.3-47.4 34.9-87.3 75.2-109.4z">
            </path>
          </svg>
        </p>
        <p v-if="tournament.status">{{ tournament.status }}</p>
      </div>
    </div>
  </div>
</template>										



<script>
export default {
	name: "tournamentcard",
	props: {
		tournament: {},
	},
  methods: {
    countPlayers(tournament) { // Count players
      let length = tournament.rounds[0].length * 2;
      return length
    },
		formatDate(date) { // Format date
      const options = { year: "numeric", month: "numeric", day: "2-digit" };
      return new Date(date).toLocaleDateString("no", options);
    },
  }
}
</script>
<style lang="scss">
// ----------------------------
// Tournament Box
// ----------------------------
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
  margin: 1rem 2rem;
  transition: all 0.5s ease;
  z-index: 0;
  &:hover {
    .tournamentimg {
      img {
        transform: scale(1.1);
      }
    }
  }
  .tournamentimg {
    overflow: hidden;
    width: 300px;
    img {
      transition: 0.3s transform ease;
    }
  }
  .tfooter {
    width: 100%;
    font-weight: 500;
    font-size: 12px;
    padding-top: 5px;
    display: flex;
    flex-direction: row;
    & > *:not(:last-child) {
      padding: 0rem 0.3rem;
      &::after {
        content: '//';
        padding: 0rem 0.3rem;
      }
    }
  }
}
</style>
