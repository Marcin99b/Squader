import Vue from "vue";
import Vuex from "vuex";
import vuexI18n from "vuex-i18n";
import createPersistedState from "vuex-persistedstate";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    logged: false,
    token: ""
  },
  mutations: {
    login: (state, response) => {
      if (response) {
        state.logged = true;
        state.token = response;
        console.log("state.logged flag is: " + state.logged);
        console.log("state.token: " + state.token);
      }
    },
    logout: state => {
      state.logged = false;
      state.token = "";
    }
  },
  actions: {
    changeLanguage(ctx, lang) {
      Vue.i18n.set(lang);
    }
  },
  plugins: [createPersistedState()]
});

Vue.use(vuexI18n.plugin, store);

//Do refactor here we do not want this file large
const translationsPl = {
  Hello: "Cześć"
};

Vue.i18n.add("pl", translationsPl);
Vue.i18n.set(window.navigator.language);

export default store;
