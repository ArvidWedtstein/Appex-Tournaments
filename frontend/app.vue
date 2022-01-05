<template>
  <div>
    <div class="logo">
      <!--<img src="./static/images/logoDark.png" alt="logo">-->
      <NuxtLink to="/">
        <img src="/images/logoDark.png" alt="logo">
      </NuxtLink>
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
  scroll-behavior: smooth;
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
  background: $backclr;
}
 .logo img{
  z-index: 5;
  position: absolute;
  width: 200px;
  top: 0;
  left: 0;
  padding: 2rem;
}

// Buttons 

.btn {
  font-weight: 600;
  color: #ffffff;
  border: none;
  text-decoration: none;
  

  &:hover {
    transform: translateY(-5px);
  }
  &.blue {
    background: $blue;
  }
  &.grey {
    background: $dark-grey;
  }
  &.abs {
    right: 4rem;
    bottom: 2rem;
    position: absolute;
  }
  &.rel {
    position: relative;
  }
  &.p-1 {
    padding: 1rem;
  }
  &.mg-5 {
    margin: 5%;
  }
}

</style>
