<template>
  <div>


    <div class="audioRec">
      <audio-recorder class="recorder"
    upload-url="YOUR_API_URL"
    :attempts="3"
    :time="2"
    
    :before-recording="callback"
    :pause-recording="callback"
    :after-recording="callback"
    :select-record="callback"
    :before-upload="callback"
    :successful-upload="callback"
    :failed-upload="callback"/>
      <br>
     
    </div>






    <!-- <audio-recorder
    upload-url="YOUR_API_URL"
    :attempts="3"
    :time="2"
    :headers="headers"
    :before-recording="callback"
    :pause-recording="callback"
    :after-recording="callback"
    :select-record="callback"
    :before-upload="callback"
    :successful-upload="callback"
    :failed-upload="callback"/> -->



  </div>
</template>

<script>

import { BFormInput, BRow, BCol } from "bootstrap-vue";

export default {


  components: { BFormInput, BRow, BCol },

  data() {
    return {

    }
  },
  watch: {
    // whenever question changes, this function will run

  },
  methods: {
    callback(data) {
      console.debug(data);
    }
  }
}

</script>


<style>
.audioRec {
  font-family: "Avenir", Helvetica, Arial, sans-serif;

  text-align: center;
  color: #2c3e50;
  
  
  display: flex;
  justify-content: center;
  
}
.recorder{
    text-align: center;
    max-width: 28rem;
    padding-top: 1rem;
    margin: 0 100px;
    box-shadow:  0px 3px 10px 1px rgba(255, 255, 255, 0.75);
}

.recorder svg{
    margin-bottom: 0.9rem ;
}
</style>