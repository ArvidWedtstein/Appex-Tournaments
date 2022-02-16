<template>
  <div>
    <div class="logo">
      <NuxtLink to="/">
      <img src="/images/logoDark.png" alt="appexlogo">
      </NuxtLink>
    </div>
    <NuxtPage/>
  </div>
</template>
<script setup>
import '~/assets/tailwind.scss'
const config = useRuntimeConfig()

</script>
<script>
import { useTournamentStore } from '~/stores/tournament'
export default {
  mounted() {
    const tournaments = useTournamentStore()
    tournaments.load(this.$config.baseURL);
  },
  computed: {
    tournaments: function () {
      const tournaments = useTournamentStore()
      tournaments.load(this.$config.baseURL);
		},
  }
}


</script>

<style lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap');

*,
*::after,
*::before {
  box-sizing: border-box;
}


// ----------------------------
// Variables
// ----------------------------

:root {
  --backclr: #edece9;
  --black: #221E20;
  --dark-grey: #464544;
  --grey: #D6D2CE;
  --light-grey: #EDECE9;
  --blue: #0835C4;
  --green: #DDE78B;
  --orange: #FAB487;
  scroll-behavior: smooth;
}



body, html {
  margin: 0;
  padding: 0;
  font-family: 'Poppins', sans-serif;
  background: var(--backclr);
}


// ----------------------------
// Buttons
// ----------------------------

// Base button class
.button {
  background: var(--grey);
  color: var(--black);
  font-weight: 500;
  margin: 10px 5px;
  padding: 20px 40px;
  transition: 0.2s all ease;
  border-radius: 0.25rem;
  // General hover
  &:hover {
    transform: translateY(2px);
  }
  // Variations of the base class
  &--blue {
    background: var(--blue);
    color: white;
    // Specific hover effect for variation
    &:hover {
    }
  }
  &--orange {
    background: var(--black);
    color: var(--orange);
  }
  &--grey {
    background: var(--grey);
  }
}

// To use the brown button for example, apply both "button" and "button--brown" classes
// This allows us to reuse as much code as possible



// ----------------------------
// Input
// ----------------------------

.input {
  padding: 20px 40px;
  border: 4px solid var(--orange);
  outline: none;
  transition: 0.2s border-color ease;
  border-radius: 0.25rem;
  &:focus {
    border-color: var(--dark-grey);
  }
  &--small {
    padding: 0.5rem !important;
    margin: 0.25rem 0 !important;
  }
  &--blue {
    border: 2px solid var(--blue);
  }
}



// ----------------------------
// Container
// ----------------------------

.container {
  max-width: 900px;
  margin: 150px auto;
}



// ----------------------------
// Logo header
// ----------------------------

.logo {
  z-index: 5;
  position: fixed;
  width: 200px;
  top: 0;
  left: 0;
  padding: 2rem;
}


</style>
