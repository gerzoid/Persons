import { createApp } from 'vue'
import './style.css'
import { createRouter, createWebHistory } from 'vue-router'
import { createPinia } from 'pinia'

import Login from './Pages/Login.vue'
import Weather from './Pages/Weather.vue'
import Spiski  from './Pages/Spiski.vue'
import App from './Pages/App.vue'
import { useAuthStore } from "./stores/authStore";

let Pinia = createPinia();
var apps = createApp(App).use(Pinia);

const authStore = useAuthStore();

const authGuard = (to, from, next) => {
    if (authStore.isAuthenticated) {
      next();
    } else {
      next("/login")
    }
  };

  const routes = [
    { path: '/login', component: Login },
    { path: '/', component: Spiski, beforeEnter: authGuard },    
    { path: '/weather', component: Weather, beforeEnter: authGuard }
];
const router = createRouter({
    routes,
    history: createWebHistory()
});


apps.use(router).mount('#app');