import Home from "../../views/Home.vue";
import Login from "../../views/Login.vue";
import Register from "../../views/Register.vue";

export default [
  {
    path: "/",
    name: "home",
    component: Home
  },
  {
    path: "/login",
    name: "login",
    component: Login
  },
  {
    path: "/register",
    name: "register",
    component: Register
  }
];
