

<template>
    <div class="design-container">
      
      <!--<img src="./Assets/images/darkLogos.png">-->
      <div class="pg1-content-container">
        <h1>Velkommen til Appex tournament</h1>
        <div class="pg1-btn-container">
          <button class="btn-blue">Lag nytt tournament</button>
          <button class="btn-dark">Se tidligere tournaments</button>
        </div>
      </div>
      
    </div>
</template>

<script>

export default {
    name: "Tournaments",
    data() {
      return {
        
      }
    }
}
</script>




<style lang="scss">
$backclr: #edece9;

#logo{
        text-align: center;
        width: 245px;
        position: absolute;
        left: 60px;
        top: 50px;
    }

.pg1-content-container{
  width: 500px;
  margin-top: 0vh;
  background-color: hotpink;
  text-align: center;
  

}
</style>
