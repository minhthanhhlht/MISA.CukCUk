import Vue from 'vue'
import App from './App.vue'
import router from "./router";
import Vuelidate from "vuelidate";
// import vuetify from './plugins/vuetify';
// import VModal from 'vue-js-modal'
// Vue.use(VModal)

Vue.config.productionTip = false
Vue.use(Vuelidate);

new Vue({
    // vuetify,
    router,
    render: h => h(App)
}).$mount('#app')