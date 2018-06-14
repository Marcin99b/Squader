<template>
  <div class="about">
    <h1 @click="changeLang('pl')">{{ 'This is an about page' | translate }}</h1>
  </div>
</template>
<script>
    export default {
        name: "home",
        methods:{
          changeLang(lang){
              this.$store.dispatch('changeLanguage', lang);
          }
        },
    };
</script>
