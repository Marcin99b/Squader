import Vue from "vue";
import Vuex from "vuex";
import vuexI18n from "vuex-i18n";
import createPersistedState from "vuex-persistedstate";

//Importing modules
import AuthModule from "./modules/authorization";
import LanguagesModule from "./modules/languages";

//Importing translations
import toPolish from "./translations/toPolish";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    AuthModule,
    LanguagesModule
  },
  state: {},
  mutations: {},
  actions: {},
  plugins: [createPersistedState()]
});

Vue.use(vuexI18n.plugin, store);

Vue.i18n.add("pl", toPolish);

Vue.i18n.set(store.state.currentLanguage || navigator.language);

export default store;
