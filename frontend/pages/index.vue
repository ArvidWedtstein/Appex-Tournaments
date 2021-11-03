

<template>
    <div class="design-container">
    
      
      <div class="pg1-content-container">
        <div class="txt-btn-pg1">
          <h1>Velkommen til Appex tournament</h1>
          <div class="btn-container">
            <NuxtLink to="/newtournament" class="blue">Lag nytt tournament</NuxtLink>
            <NuxtLink to="/tournaments" class="grey">Se tidligere tournaments</NuxtLink>
          </div>
        </div>
      </div>

    </div>
</template>

<script>

export default {
    name: "TournamentsHome",
    data() {
      return {

      }
    }
}
</script>




<style lang="scss">
$backclr: #edece9;
$btncolorblue: #0835C4;
$btncolorgrey: #444444;
#logo{
        text-align: center;
        width: 245px;
        position: absolute;
        left: 60px;
        top: 50px;
    }

.pg1-content-container{
  width: 100%;
  height: 100%;
  position: absolute;
  display: flex;
  align-content: center;
  justify-content: center;
  align-items: center;
  background-color: $backclr;
  
  background-image: url("../static/images/frontpage-grapics.jpg");
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  h1{
    font-weight: 500;
    margin: 0;
  }
}
.txt-btn-pg1{
  margin-right: 40%;
  margin-bottom: 50px;
  text-align: center;
  align-items: center;
  width: 800px;
}
.btn-container {
  position: relative;
  display: inline-flex;
  flex-direction: row;
  padding: 1rem;
  margin-bottom: 10%;
  gap: 50px;
  font-size: 16px;

}
  .blue {
    flex: 0 1 auto;
    width: 250px;
    font-weight: 600;
    padding-top: 1rem;
    padding-bottom: 1rem;
    color: #ffffff;
    position: relative;
    border: none;
    text-decoration: none;

    &:hover {
      transform: translateY(-5px);
    }
    background: $btncolorblue;
  }
  .grey {
    flex: 0 1 auto;
    width: 250px;
    font-weight: 600;
    padding-top: 1rem;
    padding-bottom: 1rem;
    color: #ffffff;
    position: relative;
    border: none;
    text-decoration: none;

    &:hover {
       transform: translateY(-5px);
    }
    background: $btncolorgrey;
  }
</style>
