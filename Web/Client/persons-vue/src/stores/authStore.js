import { defineStore } from 'pinia'
import api from "../utils/api";
import { useRouter } from "vue-router";

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
          return localStorage.getItem('access_token')?.length > 0 && this.user!=null;
          },
        isAdmin(){
          return this.user?.isAdmin;
        },
        token(){
          return localStorage.getItem('access_token')
        }
        },
    actions: {
      setUser(user){
        this.user={};
        this.user.name = user.username;
            //this.email = user.email;
        this.user.token = user.token;
        this.user.expiration = user.expiration;
        this.user.isAdmin = user.isAdmin;
      },
      async fetchUser(token){
        this.loading = true;
        const result = await api.axios
         .post("api/Identity/check", {
           token: token,
         })
         .then((response) => {
          this.setUser(response.data);
         })
         .catch((error) => {
          this.user = null;
//          throw new Error("Не авторизован");
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
              localStorage.setItem("access_token", response.data.token.token); 
              this.setUser(response.data);
              //console.log(this.user);
            })
            .catch((error) => {
              console.error("1" + error);
              throw new Error("Не авторизован");
            }).finally(() => {
              this.loading = false;
            });
      },
      async logout(){
        localStorage.removeItem("access_token");
        this.user = null;
      },
    },
  })