<template>




  <div class="container">

    
      <b-card class="card" title="1 - An Introduction to JavaScript" img-src="https://miro.medium.com/max/300/1*hwAsUagd9XQ3gAhpOu7UPQ.png"
        img-alt="Card image" img-left @click="routeGo(1)">
        <b-card-text>
          Let’s see what’s so special about JavaScript, what we can achieve with it, and what other technologies play
          well
          with it. </b-card-text>
      </b-card>
    
    
      <b-card class="card" title="2 - JavaScript Fundamentals" img-src="https://miro.medium.com/max/300/1*hwAsUagd9XQ3gAhpOu7UPQ.png"
        img-alt="Card image" img-left @click="routeGo(2)">
        <b-card-text>
          This part of the tutorial is about core JavaScript, the language itself. </b-card-text>
      </b-card>
    
    

      <b-card class="card" title="3 - JavaScript Variables " img-src="https://miro.medium.com/max/300/1*hwAsUagd9XQ3gAhpOu7UPQ.png"
        img-alt="Card image" img-left @click="routeGo(3)">
        <b-card-text>
          Most of the time, a JavaScript application needs to work with information. Variables are used to store this
          information.
        </b-card-text>
      </b-card>
    
    
      <b-card class="card" title="4 - JavaScript Data Types" img-src="https://miro.medium.com/max/300/1*hwAsUagd9XQ3gAhpOu7UPQ.png"
        img-alt="Card image" img-left @click="routeGo(4)">
        <b-card-text>
          A value in JavaScript is always of a certain type. For example, a string or a number.
        </b-card-text>
      </b-card>
    

  </div>

</template>

<script>
import { BCard, BCardText } from 'bootstrap-vue'


export default {
  components: {
    BCard,
    BCardText,
  },
  methods: {
    routeGo(i){
      this.$router.push('/lessons/'+i) 
      
    }
  }
}
</script>

<style scoped>
.card {
  height: 10rem;
  cursor: pointer;
}

.card:hover {
  box-shadow: 0 3px 10px 2px rgba(115, 103, 240, .8);
  transform: translate(3px, 2px);
}
</style>
