<template>
  <div id="app">
    <Header/>
    <router-view/>
  </div>
</template>
<script>
  import Header from './components/Header';

  export default {
    name: 'App',
    componets: {
      Header
    },
    methods: {
      changeLang(lang) {
        this.$store.dispatch('changeLanguage', lang);
      }
    }
  }
</script>
<style>
:root{
  --main-color: #3086ff;
  --secondary-color: #014fa8;
  --background-grey: #1e1e1e;
}
</style>
