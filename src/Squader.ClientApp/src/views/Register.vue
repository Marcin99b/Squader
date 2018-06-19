<template>
  <div> <!-- external div; maybe able to refactor -->
    <register-main></register-main>
    <register-aside></register-aside>
  </div>
</template>
<script>
import RegisterAside from "../components/register/RegisterAside";
import RegisterMain from "../components/register/RegisterMain";

export default {
  components: {
    RegisterAside,
    RegisterMain
  }
};
</script>
