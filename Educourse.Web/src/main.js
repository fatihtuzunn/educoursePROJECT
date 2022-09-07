import Vue from 'vue'
import { ToastPlugin, ModalPlugin } from 'bootstrap-vue'
import VueCompositionAPI from '@vue/composition-api'

import router from './router'
import store from './store'
import App from './App.vue'

// Global Components
import './global-components'

// 3rd party plugins
import '@/libs/portal-vue'
import '@/libs/toastification'

// BSV Plugin Registration
Vue.use(ToastPlugin)
Vue.use(ModalPlugin)

// Composition API
Vue.use(VueCompositionAPI)

// import core styles
require('@core/scss/core.scss')

// import assets styles
require('@/assets/scss/style.scss')

Vue.config.productionTip = false

import { BootstrapVue, BootstrapVueIcons } from "bootstrap-vue";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import 'bootstrap-vue/dist/bootstrap-vue.css'


Vue.config.productionTip = false;
Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons);

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { fas } from '@fortawesome/free-solid-svg-icons'

/* add icons to the library */
library.add(fas)

/* add font awesome icon component */
Vue.component('fa', FontAwesomeIcon)

Vue.config.productionTip = false

/* Audio recorder */
import AudioRecorder from 'vue-audio-recorder'
import VueAxios from 'vue-axios'
import { axios } from 'axios'

Vue.use(AudioRecorder)
Vue.prototype.$hostname = "http://localhost:5000"
Vue.use(VueAxios, axios)

import AxiosPlugin from 'vue-axios-cors';
 
Vue.use(AxiosPlugin)

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
