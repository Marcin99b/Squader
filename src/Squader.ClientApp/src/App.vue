<template>
  <div id="app">
    <Header/>
    <router-link to="/login">
      Login link na razie tutaj bo potem chyba w header bedzie ale to robi @Mateusz więc sie nie wpycham
    </router-link>
    <br>
    <router-link to="/register">
      Register link na razie tutaj bo potem chyba w header bedzie ale to robi @Mateusz więc sie nie wpycham
    </router-link>
    <router-view/>
  </div>
</template>
<script>
import Header from "./components/Header";

export default {
  name: "App",
  components: {
    Header
  },
  methods: {
    changeLang(lang) {
      this.$store.dispatch("changeLanguage", lang);
    }
  }
};
</script>
<style>
:root {
  --main-color: #3086ff;
  --secondary-color: #014fa8;
  --background-grey: #1e1e1e;
}
</style>
