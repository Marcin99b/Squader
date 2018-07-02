<template>
    <main class="login__main">
        loginMain
        <login-form></login-form>
    </main>
</template>
<script>
import LoginForm from "./LoginForm";

export default {
  components: {
    "login-form": LoginForm
  }
};
</script>
