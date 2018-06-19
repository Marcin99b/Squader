import Vue from "vue";
import App from "./App.vue";
import axios from "axios";
import router from "./router/router";
import store from "./store/store";
import "./registerServiceWorker";
import axiosConfig from "./config/axios.conf";

Vue.config.productionTip = false;
Vue.prototype.$http = axios.create(axiosConfig);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
