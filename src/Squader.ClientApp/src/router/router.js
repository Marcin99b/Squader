import Vue from "vue";
import Router from "vue-router";

import routes from "./routes/index";

Vue.use(Router);

export default new Router({
  mode: "history",
  scrollBehavior(to) {
    // scroll top on route change if not hash in url
    if (!to.hash) {
      return { x: 0, y: 0 };
    }
  },
  routes
});
