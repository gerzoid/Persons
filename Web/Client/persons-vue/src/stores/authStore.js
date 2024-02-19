import { defineStore } from 'pinia'

export const useAuthStore = defineStore('authStore', {
    state: () => ({
        user:
            { 
              name: null, //текущий клиент
              email: null,
              token: null,
              expiration: null,
            },
    }),
    getters: {
        isAuthenticated: (state) => {
            return this.token.length > 0 &&
            this.expiration > Date.now();
          }
        },
    actions: {
       setUser(user){
            this.name = user.name;
            this.email = user.email;
            this.token = user.token;
            this.expiration = user.expiration;
       }
    },
  })