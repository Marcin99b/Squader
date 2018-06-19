import Vue from "vue";

export default {
  state: {
    currentLanguage: navigator.language
  },
  actions: {
    changeLanguage({ commit }, lang) {
      Vue.i18n.set(lang);
      commit("changeLanguage", lang);
    }
  },
  mutations: {
    changeLanguage(state, lang){
      state.currentLanguage = lang;
    }
  }
};
