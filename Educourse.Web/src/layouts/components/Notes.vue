<template>
  <div class="container">

    <!-- Input -->
    <div class="d-flex flex-column">
      <textarea name="" v-model="note" id="" cols="30" rows="10"></textarea>
      <button @click="addNote" class="btn btn-warning rounded-0">SUBMIT</button>

      <b-card-group class="d-flex flex-column">
        <b-card v-for="(note, i) in notes" :key="i" class="mt-2">
          <fa icon="fa-solid fa-trash" class="trashIcon" @click="deleteNote(i)" />
          <fa icon="fa-solid fa-pen" class="penIcon" @click="editNote(i)" />
          <b-card-text>
            {{ note.userNote }}
          </b-card-text>
          <template #footer>
            <small class="text-muted"><a @click="jumpTime(note.time)">zamanı: {{ note.time }}</a> </small>
          </template>
        </b-card>

      </b-card-group>

      <!-- Task table -->
      <!-- <table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">task</th>
      <th scope="col">time</th>
      <th scope="col">#</th>
      <th scope="col">#</th>
    </tr>
  </thead>

  <tbody >
    <tr v-for="(note,i) in notes" :key="i">
      <th scope="row">{{note.name}}</th>
      <td>{{note.time}}</td>
      <td>
        <div class="text-center" @click="deleteNote(i)">
          DELETE
        </div>
      </td>
      <td><div class="text-center" @click="editNote(i)">
        EDIT
      </div></td>
    </tr>
    
  </tbody>
</table> -->

    </div>
  </div>
</template>

<script>

import { BFormInput, BRow, BCol } from "bootstrap-vue";
import axios from "axios";

export default {
  components: { BFormInput, BRow, BCol },

  data() {
    return {
      info: null,
      loading: true,
      errored: false,
      mail: null,
      note: "",
      editedNote: null,
      notes: null

    }
  },
  props: {
    time: Number
  },
  mounted() {
    this.mail = localStorage.getItem("Email").replaceAll('"', '');
    console.log(this.mail)
    console.log(this.$hostname)
    console.log(this.notes)
    console.log(`${this.$hostname}/api/notes/notes/mailget/${this.mail}`);
    axios
      .get(`${this.$hostname}/api/notes/notes/mailget/${this.mail}`)
      .then(response => {
        this.notes = response.data
        console.log(this.notes)
      })
      .catch(error => {
        console.log(error)
        this.errored = true
      })
      .finally(() => this.loading = false)
  },
  watch: {
    // whenever question changes, this function will run

  },
  methods: {
    addNote() {
      console.log(this.notes)
      if (this.note.length === 0) return;

      if (this.editedNote === null) {

        axios.post(`${this.$hostname}/api/notes/notes/`, {
          email: this.mail,
          time: this.time,
          userNote: this.note
        }).then(res => {
          
         
        this.notes = [...this.notes, res.data]
          console.log(res.data);
        console.log(this.notes);
        })
         
          

        
      .catch(function (error) {
        console.log(error);
      });

    /* this.notes.push({
      name: this.note,
      time: this.time
    }) */
  } else {
    const index= this.editedNote
    let id = this.notes[this.editedNote].id
    let time = this.notes[this.editedNote].time
    console.log(id);
    const updatedNote= {
      id:id,
      email:this.mail,
      time:time,
      userNote: this.note};
    axios.put(`${this.$hostname}/api/notes/notes/${id}`,updatedNote)
    .then(
      res=> {
        //console.log(res.data);
        
        console.log(this.notes[index]);
        this.notes[index].userNote = updatedNote.userNote
      }
    )
    .catch(err=>{console.log(err);})
    //this.notes[this.editedNote].userNote = this.note
    this.editedNote = null;
  }

      this.note = ""
},
deleteNote(i) {
  let id = this.notes[i].id
  console.log(id)
  axios.delete(`${this.$hostname}/api/notes/notes/${id}`)
  .then(res =>

    this.notes = this.notes.filter(note => note.id !== id)

  );



  //this.notes.splice(i,1)
},
editNote(i) {
  this.note = this.notes[i].userNote;
  this.editedNote = i;
},
jumpTime(noteTime) {
  this.$emit("jumpTime", noteTime)

}
  }
}

</script>


<style>
/* .table{
    max-width: 30px !important;
    margin: auto;
} */

.trashIcon,
.penIcon {
  float: right;
  cursor: pointer;
}

.penIcon {
  margin-right: 1rem;
}
</style>
<!-- 
<script >

export default {
    name: "Board",
    data(){
        return{
            notes: [
            {
                description: "",
                createdAt: new Date(),
            },
        ]
        }
    },

    setup() {
        
        const addNote = () => {
            notes.value.push({
                description: "",
                createdAt: new Date(),
            });
        };
        const removeNote = (index) => {
            notes.value.splice(index, 1);
        };

        return {
            notes,
            addNote,
            removeNote,
        };
    },
};
</script>
 -->