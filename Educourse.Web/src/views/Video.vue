<template>
    <div>



        <div :style="style" ref="artRef"></div>


        <!-- <h1 v-if="note">Stop video for note</h1>
        <h1 v-else>Note Section here {{ time }} </h1> -->

        <b-button @click="pauseV" v-b-toggle.sidebar-right pill variant="danger" class="addNote"> Not Ekle </b-button>
        <b-button @click="pauseV" v-b-toggle.sidebar-right pill variant="danger" class="addSound"> Ses Ekle </b-button>

        <div>
            <b-button v-b-toggle.sidebar-right class="note-button" variant="primary">
                <span class="when-open">Close</span><span class="when-closed">Open</span> NOTES
            </b-button>
            <b-sidebar id="sidebar-right" no-header right shadow bg-variant="dark" text-variant="light">
                <div class="">

                    <b-tabs content-class="mt-3">
                        <b-tab title="Notes" active>
                            <Notes :time="time" @jumpTime="jumpTime"></Notes>
                        </b-tab>
                        <b-tab title="Records">
                            <AudioRecorder />
                        </b-tab>

                    </b-tabs>



                </div>
            </b-sidebar>
        </div>




    </div>
</template>

<script>
// @ is an alias to /src
import { BButton, BSidebar } from "bootstrap-vue";
import Notes from '@/layouts/components/Notes.vue';
import Artplayer from "artplayer";
import AudioRecorder from "@/layouts/components/AudioRecorder.vue";
//import video from '@/assets/video.mp4'


export default {
    name: 'HomeView',
    data() {
        return {
            mail:"",
            time: 0,
            note: true,
            art: null,
            option: {
                url: "https://artplayer.org/assets/sample/video.mp4",
                title: 'dasda',
                theme: '#ffad00',
                autoplay: true,
                highlight: [
                    {
                        time: 0.8,
                        text: ' Buraya not girilebilir',
                    },

                ],
            },
            style: {
                width: "100%",
                height: "100vh",
                margin: "auto",

            },
        };
    },
    components: {
    BButton,
    BSidebar,
    Notes,
    AudioRecorder
},
    methods: {
        pauseV(){
        this.art.pause();
        console.log("dsfghfdh")                             
        },
        jumpTime(t) {
            this.art.currentTime = t
        }




    },
    mounted() {

        this.mail=localStorage.getItem("Email")

        this.art = new Artplayer({
            ...this.option,
            autoplay: false,

            container: this.$refs.artRef,
        });


        this.art.on('pause', () => {
            console.log(this.art.currentTime);
            this.note = false
            this.time = this.art.currentTime
        });
        this.art.on('play', () => {

            this.note = true
        });
    },
    beforeUnmount() {
        if (this.instance && this.instance.destroy) {
            this.instance.destroy(false);
        }
    },

}
</script>

<style>
.note-button {
    position: fixed;
    top: 50%;
    right: 0;
    font-size: 17px;
    background: rgba(115, 103, 240, .9) !important;
    color: white;
    text-transform: uppercase;
    outline: none;
    text-decoration: none;

    padding: 0 20px;


    /*width: 136px;*/
    height: 40px;
    line-height: 45px;

    transform: rotate(-90deg);
    transform-origin: 100% 100%;
    z-index: 20;

}

.collapsed>.when-open,
.not-collapsed>.when-closed,
.not-collapsed.addNote,
.not-collapsed.addSound {
    display: none;
}

.not-collapsed {
    transform: rotate(-90deg) translateY(-30rem);
    transition: transform 0.6s;
    opacity: 0.5;

}

.not-collapsed:hover {
    opacity: 0.8;
}

#sidebar-right {
    width: 30rem;
    background-color: #161d31 !important;
}

.addNote {
    position: absolute;
    top: 90%;
    left: 85%;
    z-index: 20;
    opacity: 0.7 !important;
}

.addSound {
    position: absolute;
    top: 90%;
    left: 78%;
    z-index: 20;
    opacity: 0.7 !important;
}

.addNote:hover,
.addSound:hover {
    opacity: 1 !important;
}
</style>