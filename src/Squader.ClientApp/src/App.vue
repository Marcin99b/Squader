<template>
  <div id="app">
    <app-heading/>
    <router-view/>
  </div>
</template>
<script>
import AppHeading from "./components/shared/AppHeading";

export default {
  name: "App",
  components: {
    "app-heading": AppHeading
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
