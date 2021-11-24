<template>
  <div class="info" v-if="show" :style="'background:' + color">
    <p>{{ message }}</p>
    <button text @click="show = false">&times;</button>
  </div>
</template>

<script>
export default {
  data () {
    return {
      show: false,
      message: '',
      color: ''
    }
  },
  created () {
    this.$store.subscribe((mutation, state) => {
      console.log(state.infoBar.color)
      if (mutation.type === 'infoBar/showMessage') {
        this.message = state.infoBar.content
        this.color = state.infoBar.color
        this.show = true
        setTimeout(() => {
          this.show = false
        }, 3000)
      }
    })
  }
}
</script>
<style lang="scss">
.info {
  position: fixed;
  bottom: 20px;
  padding: 1rem 4rem;
  display: flex;
  align-items: center;
  vertical-align: middle;
  flex-direction: row;
  left: 50%;
  transform: translateX(-50%);
  button {
    float: right;
  }
}
</style>