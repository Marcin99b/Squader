<template>
  <div>
    RegisterForm
  </div>
</template>
<script>
import axios from "axios";
import axiosConfig from "../../config/axios.conf";
import {
  required,
  minLength,
  maxLength,
  email
} from "vuelidate/lib/validators";

export default {
  data() {
    return {
      login: "",
      email: "",
      password: "",
      registerError: false,
      registerSuccess: false
    };
  },
  methods: {
    registerMethod() {
      let params = new URLSearchParams();
      params.append("login", this.loginNickMail);
      params.append("email", this.loginNickMail);
      params.append("password", this.password);

      axios
        .post("/dont/know/url.php", params, axiosConfig)
        .then(res => {
          console.log(res);
          this.registerSuccess = true;
        })
        .catch(error => {
          // Don't need to throw exception above in order to catch
          this.registerError = true;
          console.log(error);
        });
    }
  },
  validations: {
    login: {
      required,
      minLength: minLength(6),
      maxLength: maxLength(100)
    },
    email: {
      required,
      email
    },
    password: {
      required,
      minLength: minLength(8),
      maxLength: maxLength(100)
    }
  }
};
</script>
