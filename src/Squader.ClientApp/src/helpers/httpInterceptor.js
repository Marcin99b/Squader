import axios from "axios";
import { store } from "../store/store";

export default function execute() {
  axios.interceptors.request.use(
    config => {
      const token = store.state.token;
      if (token) {
        // i don't know yet how to pass token; leave it like so ill change later on
        config.headers.Authorization = `Bearer ${token}`;
        return config;
      } else {
        return config;
      }
    },
    err => {
      return Promise.reject(err);
    }
  );

  axios.interceptors.response.use(
    response => {
      return response;
    },
    err => {
      console.log(err.response.status);
      if (err.response.status === 401) {
        // commit logout mutation
        store.commit("logout");
      }
      console.log("err");
      return Promise.reject(err);
    }
  );
}
