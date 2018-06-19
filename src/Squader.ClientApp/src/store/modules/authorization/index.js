export default {
  state: {
    logged: false,
    token: ""
  },
  mutations: {
    login: (state, response) => {
      if (response) {
        state.logged = true;
        state.token = response;
        console.log("state.logged flag is: " + state.logged);
        console.log("state.token: " + state.token);
      }
    },
    logout: state => {
      state.logged = false;
      state.token = "";
    }
  },
};