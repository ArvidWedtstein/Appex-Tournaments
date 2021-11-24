export default ({ app, store }, inject) => {
    inject('notifier', {
      showMessage ({ content = '', color = '' }) {
        store.commit('infoBar/showMessage', { content, color })
      }
    })
}