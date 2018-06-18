<template>
  <div>
    LoginForm
  </div>
</template>
<script>
import axios from "axios";
import axiosConfig from "../../config/axios.conf";
import { required, minLength, maxLength } from "vuelidate/lib/validators";

export default {
  data() {
    return {
      loginNickMail: "",
      password: "",
      loginError: false,
      loginSuccess: false
    };
  },
  methods: {
    loginMethod() {
      let params = new URLSearchParams();
      params.append("nickMail", this.loginNickMail);
      params.append("password", this.password);

      axios
        .post("/dont/know/url.php", params, axiosConfig)
        .then(res => {
          // Call login mutation
          this.$store.commit("login", res.data); // send token
        })
        .catch(error => {
          // Don't need to throw exception above in order to catch
          console.log(error);
        });
    }
  },
  validations: {
    loginNickMail: {
      required,
      minLength: minLength(6),
      maxLength: maxLength(100)
    },
    password: {
      required,
      minLength: minLength(8),
      maxLength: maxLength(100)
    }
  }
};
</script>
