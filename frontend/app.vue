<template>
  <div>
    <button class="newTournament" type="button">New Tourament</button>
    <form>
      <label for="tname">Tournament name:</label><br>
      <input type="text" id="tname" name="tname" placeholder="Tournament name"><br>
      <label for="tdate">Date:</label><br>
      <input type="text" id="tdate" name="tdate" placeholder="Date"><br>
      <label for="tplayers">Players:</label><br>
      <textarea id="tplayers" name="tplayers" rows="4" cols="50"></textarea><br><br>
      <input type="submit" value="Submit">
    </form>
    <div class="wrapper">
      <div class="item">
        <div class="item-parent">
          <p>Parent2</p>
        </div>
        <div class="item-childrens">
          <div class="item-child">
            <div class="item">
              <div class="item-parent">
                <p>Parent3</p>
              </div>
              <div class="item-childrens">
                <div class="item-child">
                  <div class="item">
                    <div class="item-parent">
                      <p>Parent</p>
                    </div>
                    <div class="item-childrens">
                      <div class="item-child">
                        <p>childfirst 1</p>
                      </div>
                      <div class="item-child">
                        <p>childfirst 2</p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="item-child">
                  <p>child 2</p>
                </div>
              </div>
            </div>
          </div>
          <div class="item-child">
            <div class="item">
              <div class="item-parent">
                <p>Parent</p>
              </div>
              <div class="item-childrens">
                <div class="item-child">
                  <div class="item">
                    <div class="item-parent">
                      <p>Parent</p>
                    </div>
                    <div class="item-childrens">
                      <div class="item-child">
                        <p>child 1</p>
                      </div>
                      <div class="item-child">
                        <p>child 2</p>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="item-child">
                  <p>child 2</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
    name: "Tournaments",
    data() {
      return {
        messages: null,
        dark: false,
        showMessage: true,
        msgindex: 0
      }
    },
    asyncData () {

    },
    methods: {
      
    },
    mounted() {
      
    }
}
</script>