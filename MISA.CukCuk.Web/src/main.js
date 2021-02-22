import Vue from 'vue'
import App from './App.vue'
import router from "./router";
// import vuetify from './plugins/vuetify';
// import VModal from 'vue-js-modal'
// Vue.use(VModal)

Vue.config.productionTip = false

new Vue({
    // vuetify,
    router,
    render: h => h(App)
}).$mount('#app')