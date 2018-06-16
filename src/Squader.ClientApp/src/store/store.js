import Vue from "vue";
import Vuex from "vuex";
import vuexI18n from 'vuex-i18n';


Vue.use(Vuex);


const store = new Vuex.Store({
    state: {},
    mutations: {},
    actions: {
        changeLanguage(ctx, lang){
            Vue.i18n.set(lang);
        }
    }
});

Vue.use(vuexI18n.plugin, store);

const translationsPl = {
    "Hello": "Cześć"
};

const translationsDe = {
  "Hello": "Hallo"
};

Vue.i18n.add('pl', translationsPl);
Vue.i18n.add('de', translationsDe);

export default store;
