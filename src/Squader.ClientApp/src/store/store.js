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
    "This is an about page": "To jest strona informacyjna"
};

Vue.i18n.add('pl', translationsPl);

export default store;
