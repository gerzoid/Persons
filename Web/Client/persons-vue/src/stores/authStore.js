import { defineStore } from 'pinia'
import api from "../utils/api";

export const useAuthStore = defineStore('authStore', {
    state: () => ({
      loading: false,
      model : {
        username: "",
        password: "",
      },
      user: {
        name: null, //текущий клиент
        email: null,
        token: '',
        expiration: null,
        isAdminin: false,
      },
    }),
    getters: {
        isAuthenticated(){
            return localStorage.getItem('access_token')?.length > 0;
          }
        },
    actions: {
      setUser(user){
            this.name = user.username;
            this.email = user.email;
            this.token = user.token;
            this.expiration = user.expiration;
            console.log(this);
      },
      async login(){
          this.loading = true;
           const result = await api.axios
            .post("api/Identity/login", {
              username: this.model.username,
              password: this.model.password,
            })
            .then((response) => {
              localStorage.setItem("access_token", response.data.token);
              router.push("/tables");
            })
            .catch((error) => {
              //console.error("1" + error);
              throw new Error("Не авторизован");
            }).finally(() => {
              this.loading = false;
            });
      },
    },
  })