import { defineStore } from 'pinia'

export const useAuthStore = defineStore('authStore', {
    state: () => ({
        user:
            { 
              name: null, //текущий клиент
              email: null,
              token: '',
              expiration: null,
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
       }
    },
  })