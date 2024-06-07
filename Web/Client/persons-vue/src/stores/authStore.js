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
        isAdmin: null,
      },
    }),
    getters: {
        isAuthenticated(){
            return localStorage.getItem('access_token')?.length > 0;
          },
        isAdmin(){
          return this.user.isAdmin;
        },
        token(){
          return localStorage.getItem('access_token')
        }
        },
    actions: {
      setUser(user){
        console.log(user);
        this.name = user.username;
            this.email = user.email;
            this.token = user.token;
            this.expiration = user.expiration;
            this.isAdmin = user.isAdmin;
            console.log(this);
      },
      async fetchUser(token){
        this.loading = true;
        const result = await api.axios
         .post("api/Identity/check", {
           token: token,
         })
         .then((response) => {
           console.log(response);
           //localStorage.setItem("access_token", response.data.token);
         })
         .catch((error) => {
           throw new Error("Не авторизован");
         }).finally(() => {
           this.loading = false;
         });
      },
      async login(){
          this.loading = true;
           const result = await api.axios
            .post("api/Identity/login", {
              username: this.model.username,
              password: this.model.password,
            })
            .then((response) => {
              console.log(response);
              localStorage.setItem("access_token", response.data.token);
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