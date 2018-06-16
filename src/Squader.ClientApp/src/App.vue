<template>
  <div id="app">
    <router-view/>
  </div>
</template>
<script>
  export default {
    name: 'App',
    methods: {
      changeLang(lang) {
        this.$store.dispatch('changeLanguage', lang);
      }
    }
  }
</script>
<style>

</style>
