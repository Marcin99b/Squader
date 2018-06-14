<template>
  <div class="home">
    <div class="tekst">
      {{ 'Hello' | translate}}
    </div>
    <button @click="changeLang('en')">Translate into English</button>
    <button @click="changeLang('pl')">Przetłumacz na Polski</button>
    <button @click="changeLang('de')">Auf Deutsch übersetzen</button>
  </div>
</template>

<script>

export default {
  name: "home",
  methods:{
    changeLang(lang) {
      this.$store.dispatch('changeLanguage', lang);
    }
  }
};
</script>
