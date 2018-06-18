<template>
  <div> <!-- external div; maybe able to refactor -->
    <login-aside></login-aside>
    <login-main></login-main>
  </div>
</template>
<script>
import LoginAside from "../components/login/LoginAside";
import LoginMain from "../components/login/LoginMain";

export default {
  components: {
    LoginAside,
    LoginMain
  }
};
</script>
