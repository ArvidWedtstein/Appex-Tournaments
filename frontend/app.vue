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
//import '~/assets/tailwind.scss'
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

.page {
    display: flex;
    justify-content: center;
    align-content: center;
    align-items: center;
    position: absolute;
    width: 100%;
    height: 100%;
    background: rgba(0,0,0,0.3);
    .inputBox {
        flex: 1 1 auto;
        padding: 0.2rem;
        input {
            position: relative;
            flex: 1 1 auto;
            background: transparent;
            text-align: left;
            vertical-align: middle;
            outline: none;
            width: 100%;
            border: none;
            color: $inputcolor;
            padding-bottom: 10px;
            font-size: 1rem;
            letter-spacing: 1px;
            transition: all 0.3s ease;
            border-bottom: 2px solid $inputcolor;
            &:focus {
                color: $inputhovercolor;
                border-bottom: 2px solid $inputhovercolor;
            }
            &:-webkit-autofill,
            &:-webkit-autofill:hover, 
            &:-webkit-autofill:focus, 
            &:-webkit-autofill:active  {
                -webkit-text-fill-color: White;
              -webkit-box-shadow: 0 0 0px 1000px #000 inset;
              box-shadow: 0 0 0px 1000px #000 inset;
              transition: background-color 5000s ease-in-out 0s;
            }
        }
    }
    .pagebtn {
        flex: 1 1 auto;
        position: relative;
        width: 100%;
        font-size: 2rem;
        button {
            padding: 0.2rem 0.5rem;
            background: #dddddd;
            outline: none;
            border-radius: 50%;
            border: none;
            transition: all 0.2s ease;
            &:hover {
                background: #888;
            }
        }
        .past {
            float: left;
            left: 0;
            position: absolute;
        }
        .next {
            float: right;
            color: red;
            right: 0;
            position: absolute;
        }
    }
}
</style>
