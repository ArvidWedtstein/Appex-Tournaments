<template>
  <div>
    <div class="logo">
      <h1 id="logo">Appex</h1>
    </div>
    <slot/>
    <NuxtPage/>
  </div>
</template>


<script setup>
import '~/assets/tailwind.scss'
</script>


<style lang="scss">

@import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap');


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


:root {
	--black: $black;
	--dark-grey: $dark-grey;
	--grey: $grey;
	--light-grey: $light-grey;
	--blue: $blue;
	--green: $green;
	--orange: $orange;
}

*,
*::after,
*::before {
    box-sizing: border-box;
}
body{
    margin: 0;
    padding: 0;
    font-family: 'Poppins', sans-serif;
}





.logo {
  position: absolute;
}
</style>
