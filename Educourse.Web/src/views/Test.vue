<template>
  <div>


    <div class="audioRec">
      <audio-recorder
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
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
  display: flex;
  justify-content: center;
}
</style>