<template>
  
   <div>
  <b-card
    title="Introduction to JavaScript"
    img-src="https://i.ytimg.com/vi/_y9oxzTGERs/maxresdefault.jpg"
    img-alt="Image"
    img-top
    tag="article"
    style="max-width: 30rem;"
    class="mb-2 ml-3"
  >
    <b-card-text>
      Some quick example text to build on the card title and make up the bulk of the card's content.
    </b-card-text>

    <b-button @click="$router.push('/lessons')" variant="primary">Go lessons</b-button>
  </b-card>
</div>
  
</template>

<script>
import { BCard, BCardText, BLink } from 'bootstrap-vue'

export default {
  components: {
    BCard,
    BCardText,
    BLink,
  },
}
</script>

<style>
.card:hover {
  box-shadow: 0 3px 10px 2px rgba(115, 103, 240, .8);
  transform: translate(3px, 2px);
}
</style>
