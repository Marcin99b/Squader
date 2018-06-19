<template>
  <div id="app">
    <Heading/>
    <router-view/>
  </div>
</template>
<script>
import Heading from "./components/shared/Heading";

export default {
  name: "App",
  components: {
    Heading
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
