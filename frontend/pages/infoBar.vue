<template>
  <div class="info" :style="'background:' + color">
    <p>{{ message }}</p>
    <button text @click="show = false">&times;</button>
  </div>
</template>

<script>
export default {
  template: "<infoBar/>",
  props: {
    message: '',
    color: ''
  },
  data () {
    return {
      show: false,
    }
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