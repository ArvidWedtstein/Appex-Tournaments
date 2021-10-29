

<template>
    <div class="design-container">
      
      <!--<img src="./Assets/images/darkLogos.png">-->
      <div class="pg1-content-container">
        <h1>Velkommen til Appex tournament</h1>
        <div class="btn-container">
          <button class="blue">Lag nytt tournament</button>
          <button class="grey">Se tidligere tournaments</button>
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
$btncolorblue: #0000ff;
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
  text-align: center;
  h1 {
    top: 10%;
    position: absolute;
  }
}
.btn-container {
  position: relative;
  display: inline-flex;
  flex-direction: row;
  padding: 2rem;
  gap: 50px;
  .blue {
    flex: 1 1 auto;
    font-weight: 800;
    padding: 2rem;
    color: #ffffff;
    position: relative;
    &:hover {
      border: 5px dotted $btncolorblue;
    }
    background: $btncolorblue;
  }
  .grey {
    flex: 1 1 auto;
    font-weight: 800;
    padding: 2rem;
    color: #ffffff;
    position: relative;
    &:hover {
      border: 5px dotted $btncolorgrey;
    }
    background: $btncolorgrey;
  }
}
</style>
